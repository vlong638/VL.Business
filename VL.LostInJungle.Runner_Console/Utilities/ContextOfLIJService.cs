using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.DAS.Utilities;
using VL.Common.Logger.Objects;
using VL.Common.Protocol;
using VL.Common.Protocol.IService;
using VL.LostInJungle.Runner_Console.UserServiceReference;

namespace VL.LostInJungle.Runner_Console.Utilities
{
    /// <summary>
    /// 上下文
    /// </summary>
    public class ContextOfLIJService : ServiceContext
    {
        public ContextOfLIJService(DbConfigEntity databaseConfig, ProtocolConfig protocolConfig, ILogger serviceLogger) : base(databaseConfig, protocolConfig, serviceLogger)
        {
        }

        public override string GetUnitName()
        {
            return nameof(LostInJungle);
        }

        protected override List<DependencyResult> InitOthers()
        {
            var result = new List<DependencyResult>();
            //UserService
            var userServiceClient = new UserServiceReference.UserServiceClient();
            result.Add(userServiceClient.CheckNodeReferences());
            return result;
        }
    }
}
