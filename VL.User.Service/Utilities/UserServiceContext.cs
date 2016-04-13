using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.Configurator.Objects.ConfigEntities;
using VL.Common.DAS.Utilities;
using VL.Common.Protocol;
using VL.Common.Protocol.IService;
using VL.User.Service.Configs;

namespace VL.User.Service.Utilities
{
    interface IContext
    {
        bool Init();
    }

    public class UserServiceContext : ServiceContext
    {
        public override bool Init()
        {
            ProtocolConfig = new ProtocolConfig("ProtocolConfig.config");
            DatabaseConfig = new DbConfigs("DbConnections.config");

            bool result = true;
            ServiceLogHelper.ServiceLogger.Info("---------------------服务的依赖项检测--开始---------------------");
            //配置文件依赖检测
            result = result && CheckAvailabilityOfConfig(ProtocolConfig);
            result = result && CheckAvailabilityOfConfig(DatabaseConfig);
            //数据库依赖检测
            foreach (var dbConfigItem in DatabaseConfig.DbConfigItems)
            {
                result = result && CheckAvailabilityOfDbSession(dbConfigItem);
            }
            //TODO服务依赖检测
            ServiceLogHelper.ServiceLogger.Info("---------------------服务的依赖项检测--结束---------------------");
            return result;
        }

        private static bool CheckAvailabilityOfConfig(FileConfigEntity configEntity)
        {
            try
            {
                configEntity.Load();
                ServiceLogHelper.ServiceLogger.Error("配置文件加载成功,配置文件:" + configEntity.InputFileName);
                return true;
            }
            catch (Exception ex)
            {
                ServiceLogHelper.ServiceLogger.Error("配置文件加载失败,配置文件:" + configEntity.InputFileName);
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
                    ServiceLogHelper.ServiceLogger.Error("数据库连接成功,数据库配置名称:" + dbConfigItem.DbName);
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
