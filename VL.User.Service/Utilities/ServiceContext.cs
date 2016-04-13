using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.Configurator.Objects.ConfigEntities;
using VL.Common.DAS.Utilities;
using VL.Common.Protocol.IService;
using VL.User.Service.Configs;

namespace VL.User.Service.Utilities
{
    interface IContext
    {
        bool Init();
    }

    public class ServiceContext : IContext
    {
        public static DbConfigs DbConfigs { get; set; } = new DbConfigs("DbConnections.config");

        public bool Init()
        {
            bool result = true;
            ServiceLogHelper.ServiceLogger.Info("--服务的依赖项检测--开始--");
            //TODO 依赖项加载
            //TODO 制定标准的检测规范:数据库依赖检测,服务依赖检测
            //配置文件依赖检测
            result = result && CheckAvailabilityOfConfig(DbConfigs);
            //数据库依赖检测
            foreach (var dbConfigItem in DbConfigs.DbConfigItems)
            {
                result = result && CheckAvailabilityOfDbSession(dbConfigItem);
            }
            //服务依赖检测
            ServiceLogHelper.ServiceLogger.Info("--服务的依赖项检测--结束--");
            return result;
        }

        private static bool CheckAvailabilityOfConfig(FileConfigEntity configEntity)
        {
            try
            {
                configEntity.Load();
                return true;
            }
            catch (Exception ex)
            {
                ServiceLogHelper.ServiceLogger.Error("配置文件加载失败,配置文件路径:" + configEntity.InputFilePath);
                ServiceLogHelper.ServiceLogger.Error("错误详情" + ex.ToString());
                return false;
            }
        }

        private static bool CheckAvailabilityOfDbSession(DbConfigItem dbConfigItem)
        {
            try
            {
                var session = dbConfigItem.GetDbSession();
                if (session != null)
                {
                    session.Open();
                    session.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                ServiceLogHelper.ServiceLogger.Error("数据库连接失败,数据库配置名称:" + dbConfigItem.DbName);
                ServiceLogHelper.ServiceLogger.Error("错误详情" + ex.ToString());
                return false;
            }
        }
    }
}
