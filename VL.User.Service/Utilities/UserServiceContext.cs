using VL.Common.Logger.Utilities;
using VL.Common.Protocol;
using VL.Common.Protocol.IService;
using VL.User.Service.Configs;

namespace VL.User.Service.Utilities
{
    public class UserServiceContext : ServiceContext
    {
        static UserServiceContext()
        {
            ServiceLogger = LoggerProvider.GetLog4netLogger("ServiceLog");
            ProtocolConfig = new ProtocolConfig("ProtocolConfig.config");
            DatabaseConfig = new DbConfigs("DbConnections.config");
        }

        protected override bool InitOthers()
        {
            return true;
        }
    }
}
