using System;
using System.Net;

namespace VL.Spider.Manipulator.Entities.GrabConfigs
{
    /// <summary>
    /// 数据源-请求配置
    /// 主要负责请求时的Http参数配置
    /// </summary>
    public class RequestConfig:IConfig
    {
        public string URL { set; get; }
        public string Method { set; get; }
        public string UserAgent { set; get; }

        public HttpWebRequest GetRequest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = Method;
            request.UserAgent = UserAgent;
            return request;
        }

        public void CheckAvailable()
        {
            if (string.IsNullOrEmpty(URL))
            {
                throw new NotImplementedException("缺少源URL");
            }
        }
    }
}
