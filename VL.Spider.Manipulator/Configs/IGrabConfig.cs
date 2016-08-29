using System;
using System.IO;
using System.Net;
using System.Xml.Linq;
using VL.Common.Configurator.Objects.ConfigEntities;
using VL.Common.Logger.Objects;

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

        public IGrabConfig(ConfigOfSpider spiderConfig)
        {
            SpiderConfig = spiderConfig;
        }
        public IGrabConfig(XElement element, ConfigOfSpider spiderConfig) : base(element)
        {
            SpiderConfig = spiderConfig;
        }

        public bool IsOn { set; get; }
        public abstract bool CheckAvailable(ILogger logger);
        public string GrabType { get { return GetGrabType().ToString(); } }
        public abstract EGrabType GetGrabType();
        public delegate void GrabbingDelegate(string url, bool isSuccess, string message);
        public GrabbingDelegate OnGrabFinish;//event

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
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        try
                        {
                            var grabResult = GrabbingContent(reader.ReadToEnd());
                            OnGrabFinish(orientURL, grabResult.IsSuccess, grabResult.Message);
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
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            try
                            {
                                var resultString = reader.ReadToEnd();
                                if (resultString.Length <= stopBy)
                                {
                                    OnGrabFinish(increaseURL, false, "抓取达成终止条件而终止:页面数据长度(" + resultString.Length + ")未达到设定标准(" + stopBy + ")");
                                    break;
                                }
                                var grabResult = GrabbingContent(resultString, SpiderConfig.SpiderName + increaseValue);
                                OnGrabFinish(increaseURL, grabResult.IsSuccess, grabResult.Message);
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

        private static HttpWebRequest GetHttpWebRequest(string url, ConfigOfRequest requestConfig)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = requestConfig.Method;
            request.UserAgent = requestConfig.UserAgent;
            return request;
        }

        protected abstract GrabResult GrabbingContent(string pageContent, string pageName = "Default");

        public abstract IGrabConfig Clone(ConfigOfSpider spider);
    }

    public class GrabResult
    {
        public bool IsSuccess { set; get; }
        public string Message { set; get; }

        public GrabResult(bool isSuccess, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
