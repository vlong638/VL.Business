using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VL.Spider.Manipulator.Entities
{
    /// <summary>
    /// 数据源-管理配置
    /// 主要负责管理器调度及输出方面的配置
    /// </summary>
    public class SpiderManagerConfig
    {
        /// <summary>
        /// 最大线程数
        /// </summary>
        public int MaxConnectionNumber { set; get; }
        /// <summary>
        /// 输出文件路径
        /// </summary>
        public string OutputPath { set; get; }
    }
    /// <summary>
    /// 数据源-请求配置
    /// 主要负责请求时的Http参数配置
    /// </summary>
    public class SpiderRequestConfig
    {
        public string URL{ set; get; }
        public string Method{ set; get; }
        public string UserAgent{ set; get; }

        public HttpWebRequest GetRequest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = Method;
            request.UserAgent = UserAgent;
            return request;
        }
    }
    /// <summary>
    /// 抓取规则配置
    /// 主要负责如何抓取的内容的配置
    /// </summary>
    public class SpiderScrabeConfig
    {
    }

    public enum CheckAccessibilityResult
    {
        Success,
        Unaccessible,
        Error,
    }
    /// <summary>
    /// 爬虫
    /// </summary>
    public class Spider
    {
        public CheckAccessibilityResult CheckAccessibility(SpiderRequestConfig requestConfig)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestConfig.URL);
                request.Method = requestConfig.Method;
                request.UserAgent = requestConfig.UserAgent;
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
                return CheckAccessibilityResult.Error;
            }
        }
    }
    /// <summary>
    /// 爬虫管理中心
    /// </summary>
    public class SpiderManager
    {
        public CheckAccessibilityResult CheckAccessibility(SpiderRequestConfig requestConfig)
        {
            return new Spider().CheckAccessibility(requestConfig);
        }
    }
}
