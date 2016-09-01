using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Linq;
using VL.Common.Configurator.Objects.ConfigEntities;
using VL.Common.DAS.Objects;
using VL.Common.Logger.Objects;
using VL.Common.Protocol.IService;
using VL.Spider.Manipulator.Entities;
using VL.Spider.Manipulator.Utilities;
using VL.Spider.Objects.Entities;
using VL.Spider.Objects.Enums;

namespace VL.Spider.Manipulator.Configs
{
    /// <summary>
    /// 抓取规则配置
    /// 主要负责如何抓取的内容的配置
    /// </summary>
    public abstract class IGrabConfig : XMLConfigItem, IConfig, IGeneticCloneable<IGrabConfig, ConfigOfSpider>
    {
        public ConfigOfSpider SpiderConfig { set; get; }
        public static IGrabConfig GetGrabConfig(XElement element, ConfigOfSpider spiderConfig)
        {
            EGrabType grabType = (EGrabType)Enum.Parse(typeof(EGrabType), element.Attribute(nameof(EGrabType)).Value);
            switch (grabType)
            {
                case EGrabType.File:
                    return new GrabConfigOfFile(spiderConfig, element);
                case EGrabType.StaticList:
                    return new GrabConfigOfStaticList(element, spiderConfig);
                case EGrabType.DynamicList:
                    return new GrabConfigOfDynamicList(element, spiderConfig);
                default:
                    throw new NotImplementedException("暂未实现该类型的抓取配置" + grabType);
            }
        }
        public static IGrabConfig GetGrabConfig(EGrabType grabType, ConfigOfSpider spiderConfig)
        {
            switch (grabType)
            {
                case EGrabType.File:
                    return new GrabConfigOfFile(spiderConfig);
                case EGrabType.StaticList:
                    return new GrabConfigOfStaticList(spiderConfig);
                case EGrabType.DynamicList:
                    return new GrabConfigOfDynamicList(spiderConfig);
                case EGrabType.Detail:
                    return new GrabConfigOfDetail(spiderConfig);
                default:
                    throw new NotImplementedException("暂未实现该类型的抓取配置" + grabType);
            }
        }
        public bool IsOn { set; get; }
        public abstract bool CheckAvailable(ILogger logger);
        public string GrabTypeString { get { return GetGrabType().ToString(); } }
        public abstract EGrabType GetGrabType();

        public delegate void GrabbingDelegate(string url, bool isSuccess, string message);
        public GrabbingDelegate OnGrabFinish;//event

        public IGrabConfig(ConfigOfSpider spiderConfig)
        {
            SpiderConfig = spiderConfig;
        }
        public IGrabConfig(XElement element, ConfigOfSpider spiderConfig) : base(element)
        {
            SpiderConfig = spiderConfig;
        }


        public void StartGrabbing(ConfigOfRequest requestConfig)
        {
            if (!IsOn)
                return;

            //抓取内容
            switch (requestConfig.URLStrategy)
            {
                case URLStrategy.Default:
                    var orientURL = requestConfig.URL;
                    HttpWebRequest request = GetHttpWebRequest(orientURL, requestConfig);
                    using (WebResponse response = request.GetResponse())
                    {
                        try
                        {
                            Encoding encoding = GetEncoding(requestConfig);
                            var pageString = new StreamReader(response.GetResponseStream(), encoding).ReadToEnd();
                            Result result = GrabContentByGrabType(pageString);
                            OnGrabFinish(orientURL, result.ResultCode == EResultCode.Success, result.Message);
                        }
                        catch (Exception ex)
                        {
                            OnGrabFinish(orientURL, false, "抓取出现异常:" + ex.ToString());
                        }
                    }
                    break;
                case URLStrategy.IncreaseByValue:
                    int stopBy = requestConfig.StopWhenLT;
                    int increaseValue = requestConfig.StartAt;
                    while (true)
                    {
                        string increaseURL = string.Format(requestConfig.URL, increaseValue);
                        request = GetHttpWebRequest(increaseURL, requestConfig);
                        using (WebResponse response = request.GetResponse())
                        {
                            try
                            {
                                Encoding encoding = GetEncoding(requestConfig);
                                var pageString = new StreamReader(response.GetResponseStream(), encoding).ReadToEnd();
                                if (pageString.Length <= stopBy)
                                {
                                    OnGrabFinish(increaseURL, false, "抓取达成终止条件而终止:页面数据长度(" + pageString.Length + ")未达到设定标准(" + stopBy + ")");
                                    break;
                                }
                                Result result = GrabContentByGrabType(pageString, SpiderConfig.SpiderName + increaseValue);
                                OnGrabFinish(increaseURL, result.ResultCode == EResultCode.Success, result.Message);
                            }
                            catch (Exception ex)
                            {
                                OnGrabFinish(increaseURL, false, "抓取出现异常:" + ex.ToString());
                                break;
                            }
                        }
                        increaseValue += requestConfig.IncreaseBy;
                    }
                    break;

                default:
                    break;
            }
        }
        private Result GrabContentByGrabType(string pageString, string pageName = null)
        {
            Result result = null;
            switch (GetGrabType())
            {
                //case EGrabType.File:
                    //result = GrabbingContent(pageString, pageName);
                    //break;
                case EGrabType.File:
                case EGrabType.StaticList:
                case EGrabType.DynamicList:
                    result = Constraints.ServiceContext.ServiceDelegator.HandleTransactionEvent(Constraints.DbName, (session) =>
                    {
                        return ProcessingGrab(session, pageString, pageName);
                    });
                    break;
                default:
                    throw new NotImplementedException("暂不支持该类型的GrabType抓取处理");
            }

            return result;
        }
        private static Encoding GetEncoding(ConfigOfRequest requestConfig)
        {
            Encoding encoding = Encoding.Unicode;
            switch (requestConfig.Encoding)
            {
                case EEncoding.Auto:
                    //TODO 从页面中分析出Encoding格式
                    break;
                case EEncoding.ASCII:
                case EEncoding.Unicode:
                case EEncoding.GBK:
                    encoding = Encoding.GetEncoding(requestConfig.Encoding.ToString());
                    break;
                case EEncoding.UTF8:
                    encoding = Encoding.UTF8;
                    break;
                default:
                    break;
            }

            return encoding;
        }

        private static HttpWebRequest GetHttpWebRequest(string url, ConfigOfRequest requestConfig)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = requestConfig.Method;
            request.UserAgent = requestConfig.UserAgent;
            return request;
        }
        //protected abstract Result GrabbingContent(string pageString, string pageName = "Default");
        protected Result ProcessingGrab(DbSession session, string pageString, string issueName = "")
        {
            //补全期名称
            if (string.IsNullOrEmpty(issueName))
            {
                issueName = GetPageNameWhileEmptyOrNull(issueName);
            }
            //请求查询
            var request = new TGrabRequest(SpiderConfig.Spider.SpiderId, GetGrabType(), issueName);
            if (!request.DbLoad(session))
            {
                var requestResult = StartGrabRequest(session, issueName);
                request = requestResult.Data;
            }
            if (request.ProcessStatus==EProcessStatus.Success)
            {
                return new Result() { ResultCode = EResultCode.Failure, Message = "存在已经处理的请求" };
            }
            //请求发起处理
            Result result=null;
            try
            {
                result = GrabContent(session, pageString, issueName);
            }
            catch (Exception ex)
            {
                result = new Result() { ResultCode = EResultCode.Error, Message = ex.ToString() };
            }
            //请求结束处理
            return FinishGrabRequest(session, request, result.ResultCode, result.Message);

            #region old
            ////期请求存储
            //session.BeginTransaction();
            //try
            //{
            //    //内容抓取处理
            //    if (result.ResultCode==EResultCode.Success)
            //    {
            //        result = GrabContent(session, pageString,issueName);
            //    }
            //    //请求结束处理
            //    result = FinishGrabRequest(session, requestResult.Data);
            //    if (result.ResultCode == EResultCode.Success)
            //    {
            //    }
            //    if (result.ResultCode == EResultCode.Success)
            //    {
            //        session.CommitTransaction();
            //    }
            //    else
            //    {
            //        session.RollBackTransaction();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    session.RollBackTransaction();
            //    return new Result() { ResultCode = EResultCode.Error, Message = ex.ToString() };
            //}
            //return new Result() { ResultCode = result.ResultCode, Message = result.Message }; 
            #endregion
        }
        public abstract string GetPageNameWhileEmptyOrNull(string issueName);
        public Result<TGrabRequest> StartGrabRequest(DbSession session, string issueName)
        {
            TGrabRequest request = new TGrabRequest();
            var result = request.Create(session, SpiderConfig.Spider.SpiderId, GetGrabType(), issueName, SpiderConfig.Spider.SpiderName);
            switch (result)
            {
                case TGrabRequest.CreateGrabRequestResult.Success:
                    return new Result<TGrabRequest>() { ResultCode = EResultCode.Success, Data = request, Message = "创建请求对象成功" };
                case TGrabRequest.CreateGrabRequestResult.DbOperationFailed:
                    return new Result<TGrabRequest>() { ResultCode = EResultCode.Failure, Message = "创建请求对象失败" };
                case TGrabRequest.CreateGrabRequestResult.Existed:
                    return new Result<TGrabRequest>() { ResultCode = EResultCode.Failure, Message = "存在重复的请求对象,新增数据详情:" + Newtonsoft.Json.JsonConvert.SerializeObject(request) };
                default:
                    ExceptionHelper.DoWhileResultCodeHandlerNotImplemented();
                    return null;
            }
        }
        public abstract Result GrabContent(DbSession session, string pageString, string issueName);
        public Result FinishGrabRequest(DbSession session, TGrabRequest request,EResultCode code,string message)
        {
            EProcessStatus status = EProcessStatus.Ready;
            switch (code)
            {
                case EResultCode.Success:
                    status = EProcessStatus.Success;
                    break;
                case EResultCode.Failure:
                    status = EProcessStatus.Failure;
                    break;
                case EResultCode.Error:
                    status = EProcessStatus.Error;
                    break;
                default:
                    ExceptionHelper.DoWhileResultCodeHandlerNotImplemented();
                    break;
            }
            return new Result() { ResultCode = request.Settle(session, status, message) ? EResultCode.Success : EResultCode.Failure, Message = message };
        }
        public abstract IGrabConfig Clone(ConfigOfSpider spider);
    }
}
