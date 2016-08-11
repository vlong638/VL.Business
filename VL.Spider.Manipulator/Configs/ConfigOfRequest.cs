using System;
using System.IO;
using System.Net;
using System.Xml.Linq;
using VL.Common.Configurator.Objects.ConfigEntities;
using VL.Spider.Manipulator.Configs;
using VL.Spider.Manipulator.Entities;
using VL.Spider.Manipulator.Utilities;

namespace VL.Spider.Manipulator.Configs
{
    /// <summary>
    /// 数据源-请求配置
    /// 主要负责请求时的Http参数配置
    /// </summary>
    public class ConfigOfRequest : XMLConfigItem,IConfig
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

        public HttpWebRequest GetRequest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = Method;
            request.UserAgent = UserAgent;
            return request;
        }

        public bool CheckAvailable()
        {
            if (string.IsNullOrEmpty(URL))
            {
                throw new NotImplementedException("缺少源URL");
            }

            return true;
        }
        public override XElement ToXElement()
        {
            return new XElement(nameof(ConfigOfRequest)
                , new XAttribute(nameof(URL), URL)
                , new XAttribute(nameof(Method), Method)
                , new XAttribute(nameof(UserAgent), UserAgent)
                );
        }
        public override void LoadXElement(XElement element)
        {
            URL = element.Attribute(nameof(URL)).Value;
            Method = element.Attribute(nameof(Method)).Value;
            UserAgent = element.Attribute(nameof(UserAgent)).Value;
        }


        /// <summary>
        /// 检查对应的RequestConfig是否通畅
        /// </summary>
        /// <param name="spiderConfig"></param>
        /// <returns></returns>
        public CheckAccessibilityResult CheckAccessibility(ServiceContextOfSpider context)
        {
            //if (spiderConfig == null)
            //{
            //    spiderConfig = CurrentConfigOfSpider;
            //}
            //if (!CheckConfig())
            //{
            //    return CheckAccessibilityResult.ConfigNotReady;
            //}

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.URL);
                request.Method = this.Method;
                request.UserAgent = this.UserAgent;
                using (WebResponse response = request.GetResponse())
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    if (reader.Read() != -1)
                    {
                        return CheckAccessibilityResult.Success;
                    }
                    else
                    {
                        return CheckAccessibilityResult.Unaccessible;
                    }
                }
            }
            catch (Exception ex)
            {
                context.ServiceLogger.Error(ex.ToString());
                return CheckAccessibilityResult.Error;
            }
        }
    }
}
