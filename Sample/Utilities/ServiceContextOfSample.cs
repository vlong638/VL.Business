using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.DAS.Utilities;
using VL.Common.Logger.Objects;
using VL.Common.Protocol;
using VL.Common.Protocol.IService;

namespace Sample.Utilities
{
    public class ServiceContextOfSample : ServiceContext
    {
        static ServiceContextOfSample()
        {
        }

        public ServiceContextOfSample(DbConfigEntity databaseConfig, ProtocolConfig protocolConfig, ILogger serviceLogger) : base(databaseConfig, protocolConfig, serviceLogger)
        {
        }

        public override string GetUnitName()
        {
            return nameof(Sample);
        }

        protected override DbConfigEntity GetDefaultDatabaseConfig()
        {
            throw new NotImplementedException();
        }

        protected override ProtocolConfig GetDefaultProtocolConfig()
        {
            throw new NotImplementedException();
        }

        protected override ILogger GetDefaultServiceLogger()
        {
            throw new NotImplementedException();
        }

        protected override List<DependencyResult> InitOthers()
        {
            return new List<DependencyResult>();
        }
    }
}
