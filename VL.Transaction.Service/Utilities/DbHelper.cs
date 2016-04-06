using System;
using System.Linq;
using VL.Common.Configurator.Objects.BuiltInConfigEntities;
using VL.Common.DAS.Objects;

namespace VL.Transaction.Service.Utilities
{
    public enum DatabaseName
    {
        Succinctly
    }
    public static class DbHelper
    {
        public static DbConnectionsConfigEntity ConfigEntities = new DbConnectionsConfigEntity(nameof(DbConnectionsConfigEntity) + ".config", @"D:\GitProjects\VL.Business\VL.Transaction.Service\Configs");

        public static DbSession GetDbSession(this DatabaseName name)
        {
            var configEntity = ConfigEntities.DbConnectionConfigs.FirstOrDefault(c => c.Name == name.ToString());
            if (configEntity == null)
            {
                throw new NotImplementedException("数据库连接未设置" + name);
            }
            switch (name)
            {
                case DatabaseName.Succinctly:
                    return new DbSession(Common.DAS.Objects.EDatabaseType.MSSQL, configEntity.ConnectingString);
                default:
                    throw new NotImplementedException("未实现该数据库的数据库连接创建" + name);
            }
        }
    }
}
