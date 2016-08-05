using System;
using System.IO;
using System.Net;

namespace VL.Spider.Manipulator.Entities.GrabConfigs
{

    public interface IConfig
    {
        void CheckAvailable();
    }

    /// <summary>
    /// 抓取规则配置
    /// 主要负责如何抓取的内容的配置
    /// </summary>
    public abstract class HTTPGrabConfig: IConfig
    {
        public abstract void CheckAvailable();

        public void StartGrabbing(RequestConfig requestConfig)
        {
            CheckAvailable();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestConfig.URL);
            request.Method = requestConfig.Method;
            request.UserAgent = requestConfig.UserAgent;
            using (WebResponse response = request.GetResponse())
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                GrabbingContent(reader.ReadToEnd());
            }
        }
        protected abstract void GrabbingContent(string pageContent);
    }
}
