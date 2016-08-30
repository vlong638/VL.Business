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

namespace VL.Spider.Manipulator.Configs
{
    public enum EGrabType
    {
        /// <summary>
        /// 全文件保存
        /// </summary>
        File,
        /// <summary>
        /// 静态页面列表项
        /// </summary>
        SListContent,
        /// <summary>
        /// 动态页面列表项
        /// </summary>
        DListContent
    }
    /// <summary>
    /// 抓取规则配置
    /// 主要负责如何抓取的内容的配置
    /// </summary>
    public abstract class IGrabConfig : XMLConfigItem, IConfig, IGeneticCloneable<IGrabConfig, ConfigOfSpider>
    {
        public ConfigOfSpider SpiderConfig { set; get; }
        public static IGrabConfig GetGrabConfig(XElement element, ConfigOfSpider spiderConfig)
        {
            EGrabType grabType = (EGrabType)Enum.Parse(typeof(EGrabType), element.Attribute(nameof(GrabType)).Value);
            switch (grabType)
            {
                case EGrabType.File:
                    return new GrabConfigOfFile(spiderConfig, element);
                case EGrabType.SListContent:
                    return new GrabConfigOfSListContent(spiderConfig, element);
                case EGrabType.DListContent:
                    return new GrabConfigOfDListContent(spiderConfig, element);
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
                case EGrabType.SListContent:
                    return new GrabConfigOfSListContent(spiderConfig);
                case EGrabType.DListContent:
                    return new GrabConfigOfDListContent(spiderConfig);
                default:
                    throw new NotImplementedException("暂未实现该类型的抓取配置" + grabType);
            }
        }
        public bool IsOn { set; get; }
        public abstract bool CheckAvailable(ILogger logger);
        public string GrabType { get { return GetGrabType().ToString(); } }
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
                            var grabResult = GrabbingContent(pageString);
                            OnGrabFinish(orientURL, grabResult.ResultCode==EResultCode.Success, grabResult.Message);
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
                        increaseValue += requestConfig.IncreaseBy;
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
                                var result=Constraints.ServiceContext.ServiceDelegator.HandleTransactionEvent(Constraints.DbName, (session) =>
                                 {
                                     return GrabbingContent(session, pageString, SpiderConfig.SpiderName + increaseValue);
                                 });

                                //TODO使用Session
                                OnGrabFinish(increaseURL, result.ResultCode == EResultCode.Success, result.Message);
                            }
                            catch (Exception ex)
                            {
                                OnGrabFinish(increaseURL, false, "抓取出现异常:" + ex.ToString());
                                break;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
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
        protected abstract Result GrabbingContent(string pageString, string pageName = "Default");
        protected abstract Result GrabbingContent(DbSession session, string pageString, string pageName = "Default");
        public abstract IGrabConfig Clone(ConfigOfSpider spider);
    }
}
