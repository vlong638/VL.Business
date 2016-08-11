using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VL.Spider.Manipulator.Configs;
using VL.Spider.Manipulator.Utilities;

namespace VL.Spider.Manipulator.Entities
{
    #region Configs
    #endregion
    /// <summary>
    /// 爬虫
    /// </summary>
    public class SpiderManager
    {
        public ServiceContextOfSpider Context { set; get; } = new ServiceContextOfSpider();
        public ConfigOfSpider CurrentConfigOfSpider { set; get; } = new ConfigOfSpider("Default");
        public ConfigOfSpiders ConfigOfSpiders { set; get; } = new ConfigOfSpiders(nameof(ConfigOfSpiders) + ".config");

        public bool CheckConfig()
        {
            //TODO
            return true;
        }

        /// <summary>
        /// 开始抓取
        /// </summary>
        /// <param name="spiderConfig"></param>
        /// <returns></returns>
        public StartGrabbingResult StartGrabbing(ConfigOfSpider spiderConfig = null)
        {
            if (spiderConfig == null)
            {
                spiderConfig = CurrentConfigOfSpider;
            }
            if (!CheckConfig())
            {
                return StartGrabbingResult.ConfigNotReady;
            }
            Task.Factory.StartNew(() =>
            {
                spiderConfig.GrabConfigs.ForEach(c => c.StartGrabbing(spiderConfig.RequestConfig));
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
