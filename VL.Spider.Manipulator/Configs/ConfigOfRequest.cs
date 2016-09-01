using System;
using System.IO;
using System.Net;
using System.Xml.Linq;
using VL.Common.Configurator.Objects.ConfigEntities;
using VL.Common.Logger.Objects;
using VL.Spider.Manipulator.Configs;
using VL.Spider.Manipulator.Entities;
using VL.Spider.Manipulator.Utilities;

namespace VL.Spider.Manipulator.Configs
{
    public enum URLStrategy
    {
        /// <summary>
        /// 默认 
        /// </summary>
        Default,
        /// <summary>
        /// 量化增长
        /// </summary>
        IncreaseByValue
    }
    /// <summary>
    /// 数据源-请求配置
    /// 主要负责请求时的Http参数配置
    /// </summary>
    public class ConfigOfRequest : XMLConfigItem,IConfig, IGeneticCloneable<ConfigOfRequest>
    {
        public ConfigOfRequest()
        {
        }
        public ConfigOfRequest(XElement element) : base(element)
        {
        }

        public string URL { set; get; } = "";
        public string Method { set; get; } = WebRequestMethods.Http.Get.ToString();
        public string UserAgent { set; get; } = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0)";
        #region Strategies
        public URLStrategy URLStrategy { set; get; } = URLStrategy.Default;
        #region IncreaseByValue
        public int StartAt { set; get; } = 1;
        public int IncreaseBy { set; get; } = 1;
        public int StopWhenLT { set; get; } = 500;
        /// <summary>
        /// 数据编码
        /// </summary>
        public EEncoding Encoding { set; get; } = EEncoding.Auto;
        #endregion
        #endregion

        public bool CheckAvailable(ILogger logger)
        {
            if (string.IsNullOrEmpty(URL))
            {
                throw new NotImplementedException("缺少源URL");
            }
            switch (URLStrategy)
            {
                case URLStrategy.Default:
                    if (!CheckAccessibility(URL))
                    {
                        throw new NotImplementedException("未从指定的URL获取到响应数据");
                    }
                    break;
                case URLStrategy.IncreaseByValue:
                    string increaseURL = string.Format(URL, StartAt);
                    if (!CheckAccessibility(increaseURL))
                    {
                        throw new NotImplementedException("未从指定的URL获取到响应数据");
                    }
                    break;
                default:
                    break;
            }
            return true;
        }
        public override XElement ToXElement()
        {
            return new XElement(nameof(ConfigOfRequest)
                , new XAttribute(nameof(URL), URL)
                , new XAttribute(nameof(Method), Method)
                , new XAttribute(nameof(UserAgent), UserAgent)
                , new XAttribute(nameof(URLStrategy), (int)URLStrategy)
                , new XAttribute(nameof(StartAt), (int)StartAt)
                , new XAttribute(nameof(IncreaseBy), (int)IncreaseBy)
                , new XAttribute(nameof(StopWhenLT), (int)StopWhenLT)
                , new XAttribute(nameof(Encoding), Encoding)
                );
        }
        public override void LoadXElement(XElement element)
        {
            URL = element.Attribute(nameof(URL)).Value;
            Method = element.Attribute(nameof(Method)).Value;
            UserAgent = element.Attribute(nameof(UserAgent)).Value;
            if (element.Attribute(nameof(URLStrategy))!=null)
            {
                URLStrategy = (URLStrategy)Enum.Parse(typeof(URLStrategy), element.Attribute(nameof(URLStrategy)).Value);
            }
            if (element.Attribute(nameof(StartAt)) != null)
            {
                StartAt = Convert.ToInt32(element.Attribute(nameof(StartAt)).Value);
            }
            if (element.Attribute(nameof(IncreaseBy)) != null)
            {
                IncreaseBy = Convert.ToInt32(element.Attribute(nameof(IncreaseBy)).Value);
            }
            if (element.Attribute(nameof(StopWhenLT)) != null)
            {
                StopWhenLT = Convert.ToInt32(element.Attribute(nameof(StopWhenLT)).Value);
            }
            var encodingAttr = element.Attribute(nameof(Encoding));
            if (encodingAttr != null)
            {
                Encoding = (EEncoding)Enum.Parse(typeof(EEncoding), encodingAttr.Value);
            }
        }
        /// <summary>
        /// 检查对应的RequestConfig是否通畅
        /// </summary>
        /// <param name="spiderConfig"></param>
        /// <returns></returns>
        public bool CheckAccessibility(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = this.Method;
            request.UserAgent = this.UserAgent;
            using (WebResponse response = request.GetResponse())
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return reader.Read() != -1;
            }
        }
        public ConfigOfRequest Clone()
        {
            return new ConfigOfRequest()
            {
                URL = this.URL,
                Method = this.Method,
                UserAgent = this.UserAgent,
                URLStrategy = this.URLStrategy,
                StartAt = this.StartAt,
                IncreaseBy = this.IncreaseBy,
                StopWhenLT = this.StopWhenLT,
            };
        }
    }
}
