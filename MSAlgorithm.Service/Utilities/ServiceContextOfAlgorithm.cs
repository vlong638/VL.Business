using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.DAS.Utilities;
using VL.Common.Logger.Objects;
using VL.Common.Logger.Utilities;
using VL.Common.Protocol;
using VL.Common.Protocol.IService;

namespace MSAlgorithm.Service.Utilities
{
    public class ServiceContextOfAlgorithm : ServiceContext
    {
        public ServiceContextOfAlgorithm() : base()
        {
        }
        public ServiceContextOfAlgorithm(DbConfigEntity databaseConfig, ProtocolConfig protocolConfig, ILogger serviceLogger) : base(databaseConfig, protocolConfig, serviceLogger)
        {
        }

        public override string GetUnitName()
        {
            return nameof(MSAlgorithm);
        }

        protected override DbConfigEntity GetDefaultDatabaseConfig()
        {
            return new DbConfigOfAlgorithm("DbConnections.config");
        }
        protected override ProtocolConfig GetDefaultProtocolConfig()
        {
            return new ProtocolConfig("ProtocolConfig.config");
        }

        protected override ILogger GetDefaultServiceLogger()
        {
            return LoggerProvider.GetLog4netLogger("ServiceLog");
        }

        protected override List<DependencyResult> InitOthers()
        {
            return new List<DependencyResult>();
        }
    }
}
