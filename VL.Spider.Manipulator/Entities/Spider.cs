using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VL.Spider.Manipulator.Entities.GrabConfigs;
using VL.Spider.Manipulator.Utilities;

namespace VL.Spider.Manipulator.Entities
{
    #region Configs
    /// <summary>
    /// 数据源-管理配置
    /// 主要负责管理器调度及输出方面的配置
    /// </summary>
    public class SpiderManageConfig
    {
        /// <summary>
        /// 最大线程数
        /// </summary>
        public int MaxConnectionNumber { set; get; }
    }
    #endregion
    /// <summary>
    /// 爬虫
    /// </summary>
    public class SpiderEntity
    {
        public ServiceContextOfSpider Context { set; get; } = new ServiceContextOfSpider();
        public RequestConfig RequestConfig { set; get; } = new RequestConfig()
        {
            Method = WebRequestMethods.Http.Get,
            UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0)",
        };
        public SpiderManageConfig ManageConfig { set; get; } = new SpiderManageConfig()
        {
            MaxConnectionNumber = 1,
        };
        public HTTPGrabConfig GrabConfig { set; get; }


        public bool CheckConfig()
        {
            //TODO
            return true;
        }

        public CheckAccessibilityResult CheckAccessibility()
        {
            if (!CheckConfig())
            {
                return CheckAccessibilityResult.ConfigNotReady;
            }

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(RequestConfig.URL);
                request.Method = RequestConfig.Method;
                request.UserAgent = RequestConfig.UserAgent;
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
                Context.ServiceLogger.Error(ex.ToString());
                return CheckAccessibilityResult.Error;
            }
        }
        public StartGrabbingResult StartGrabbing()
        {
            if (!CheckConfig())
            {
                return StartGrabbingResult.ConfigNotReady;
            }
            Task.Factory.StartNew(() =>
            {
                GrabConfig.StartGrabbing(RequestConfig);
            });
            return StartGrabbingResult.ThreadStarted;
        }
    }


    #region Results
    public enum CheckAccessibilityResult
    {
        Success,
        Unaccessible,
        Error,
        ConfigNotReady,
    }
    public enum StartGrabbingResult
    {
        ConfigNotReady,
        ThreadStarted,
    }
    #endregion
}
