using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VL.Common.Logger.Utilities;
using VL.Common.Protocol.IService;
using VL.Spider.Manipulator.Configs;
using VL.Spider.Manipulator.Utilities;
using VL.Spider.Objects.Objects.Entities;

namespace VL.Spider.Manipulator.Entities
{
    #region Configs
    #endregion
    /// <summary>
    /// 爬虫
    /// </summary>
    public class SpiderManager
    {
        #region 配置文件存储
        public ServiceContextOfSpider Context { set; get; } = new ServiceContextOfSpider();
        public ConfigOfSpider CurrentConfigOfSpider { set; get; } = new ConfigOfSpider("Default");
        public ConfigOfSpiders ConfigOfSpiders { set; get; } = new ConfigOfSpiders(nameof(ConfigOfSpiders) + ".config");
        #endregion
        #region 数据库存储
        ServiceContextOfSpider ServiceContext { set; get; }
        DependencyResult DependencyResult { set; get; }
        public TSpider CurrentSpider { set; get; }
        public List<TSpider> Spiders { set; get; }

        private Result LoadSpiders()
        {
            return ServiceContext.ServiceDelegator.HandleTransactionEvent(DbName, (session) =>
            {
                Spiders = new List<TSpider>().DbSelect(session);
                return new Result() { ResultCode = EResultCode.Success };
            });
        }
        public bool CheckAlive()
        {
            var result = CheckNodeReferences();
            return result.IsAllDependenciesAvailable;
        }
        public DependencyResult CheckNodeReferences()
        {
            try
            {
                if (DependencyResult == null)
                {
                    ServiceContext = new ServiceContextOfSpider();
                }
                DependencyResult = ServiceContext.Init();
            }
            catch (Exception ex)
            {
                //TODO Default Log
                LoggerProvider.GetLog4netLogger("Default").Error(ex.ToString());
            }
            return DependencyResult;
        }
        #endregion

        public Result Init()
        {
            //检测服务依赖项
            var checkResult = CheckNodeReferences();
            if (!checkResult.IsAllDependenciesAvailable)
            {
                return new Result()
                {
                    ResultCode = EResultCode.Error,
                    Message = checkResult.Message,
                };
            }
            //没有配置文件时初始化生成
            if (!File.Exists(ConfigOfSpiders.OutputFilePath))
            {
                ConfigOfSpiders.Save();
            }
            //加载所有配置
            ConfigOfSpiders.Load();
            var loadResult = LoadSpiders();
            if (loadResult.ResultCode!=EResultCode.Success)
            {
                return loadResult;
            }
            var spiderName = ConfigOfSpiders.LatestSpiderConfigName;
            if (ChangeCurrentSpider(ConfigOfSpiders.LatestSpiderConfigName).ResultCode!=EResultCode.Success)
            {
                new Result<bool>()
                {
                    ResultCode = EResultCode.Error,
                    Message = "更改当前的TSpider时出错" };
            }
            return new Result<bool>()
            {
                ResultCode = EResultCode.Success,
            };
        }
        public Result<ConfigOfSpider> DeleteSpider(string spiderName)
        {
            return ServiceContext.ServiceDelegator.HandleTransactionEvent(DbName, (session) =>
            {
                var config= ConfigOfSpiders.Configs.First(c => c.SpiderName == spiderName);
                var spider = Spiders.First(c => c.SpiderName == config.SpiderName);
                if (spider.DbDelete(session))
                {
                    //配置文件删除
                    ConfigOfSpiders.Configs.Remove(config);
                    var currentSpider = ConfigOfSpiders.Configs.FirstOrDefault();
                    //缓存删除
                    Spiders.Remove(spider);
                    //变更当前选项
                    if (currentSpider!=null)
                    {
                        ChangeCurrentSpider(currentSpider.SpiderName);
                    }
                    ConfigOfSpiders.Save();
                    return new Result<ConfigOfSpider>() { ResultCode = EResultCode.Success, Data = currentSpider == null ? new ConfigOfSpider("") : currentSpider };
                }
                else
                {
                    return new Result<ConfigOfSpider>() { ResultCode = EResultCode.Failure };
                }
            });
        }
        public string GetAvailableSpiderName(string orientSpiderName)
        {
            string spiderName = orientSpiderName + "副本";
            if (!ConfigOfSpiders.Configs.Exists(c => c.SpiderName == spiderName))
            {
                return spiderName;
            }
            else
            {
                int i = 0;
                do
                {
                    spiderName = orientSpiderName + "副本" + i.ToString();
                    i++;
                }
                while (ConfigOfSpiders.Configs.Exists(c => c.SpiderName == spiderName));
                return spiderName;
            }
        }
        public Result<TSpider> AddSpider(string spiderName)
        {
            return ServiceContext.ServiceDelegator.HandleTransactionEvent(DbName, (session) =>
            {
                //数据库新增
                var spider = new TSpider();
                if (spider.Create(session, spiderName))
                {
                    //配置文件新增
                    var newSpiderConfig = new ConfigOfSpider(spiderName);
                    ConfigOfSpiders.Configs.Add(newSpiderConfig);
                    ConfigOfSpiders.LatestSpiderConfigName = spiderName;
                    //变更当前选项
                    Spiders.Add(spider);
                    ChangeCurrentSpider(spider.SpiderName);
                    ConfigOfSpiders.Save();
                    return new Result<TSpider>() { Data = spider, ResultCode = EResultCode.Success };
                }
                else
                {
                    return new Result<TSpider>() { ResultCode = EResultCode.Failure };
                }
            });
        }
        public Result CopySpider(string orientSpiderName)
        {
            return ServiceContext.ServiceDelegator.HandleTransactionEvent(DbName, (session) =>
            {
                //配置文件新增
                var config = ConfigOfSpiders.Configs.First(c => c.SpiderName == orientSpiderName).Clone();
                config.SpiderName = GetAvailableSpiderName(orientSpiderName);
                //数据库新增
                var spider = new TSpider();
                if (spider.Create(session, config.SpiderName))
                {
                    //配置文件新增
                    ConfigOfSpiders.Configs.Add(config);
                    //ConfigOfSpiders.LatestSpiderConfigName = config.SpiderName;
                    //变更当前选项
                    Spiders.Add(spider);
                    //ChangeCurrentSpider(spider.SpiderName);
                    ConfigOfSpiders.Save();
                    return new Result() { ResultCode = EResultCode.Success };
                }
                else
                {
                    return new Result() { ResultCode = EResultCode.Failure };
                }
            });
        }
        public string DbName = nameof(VL.Spider);
        public Result ChangeCurrentSpider(string spiderName)
        {
            var currentSpider = Spiders.FirstOrDefault(c => c.SpiderName == spiderName);
            if (currentSpider == null)
            {
                var addResult = AddSpider(spiderName);
                if (addResult.ResultCode != EResultCode.Success)
                {
                    return addResult;
                }
                CurrentSpider = Spiders.First(c => c.SpiderName == spiderName);
            }
            else
            {
                CurrentSpider = currentSpider;
            }
            CurrentConfigOfSpider = ConfigOfSpiders.Configs.FirstOrDefault(c => c.SpiderName == spiderName);
            ConfigOfSpiders.LatestSpiderConfigName = CurrentConfigOfSpider.SpiderName;
            return new Result() { ResultCode = EResultCode.Success };
        }
        public Result ChangeCurrentSpiderName(string spiderName)
        {
            return ServiceContext.ServiceDelegator.HandleTransactionEvent(DbName, (session) =>
            {
                var config = ConfigOfSpiders.Configs.First(c => c.SpiderName == CurrentConfigOfSpider.SpiderName);
                var spider = Spiders.First(c => c.SpiderName == CurrentConfigOfSpider.SpiderName);
                if (spider.ChangeName(session, spiderName))
                {
                    //配置文件变更
                    config.SpiderName = spiderName;
                    //最后选项变更
                    ConfigOfSpiders.LatestSpiderConfigName = spiderName;
                    ConfigOfSpiders.Save();
                    return new Result() { ResultCode = EResultCode.Success };
                }
                else
                {
                    return new Result() { ResultCode = EResultCode.Failure };
                }
            });
        }

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
