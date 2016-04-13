using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.UserServiceReference;
using VL.Common.Protocol;
using VL.Common.Protocol.IService;
using VL.User.Service.Configs;
using VL.User.Service.Utilities;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //UserServiceContext.ProtocolConfig = new ProtocolConfig("ProtocolConfig.config");
            //UserServiceContext.DatabaseConfig = new DbConfigs("DbConnections.config");
            //UserServiceContext.ProtocolConfig.Save();
            //UserServiceContext.DatabaseConfig.Save();


            //TestService();
            //CreateDbConfigForUser();
            var result = new UserServiceContext().Init();
        }

        private static void CreateDbConfigForUser()
        {
            DbConfigs dbConfigs = new DbConfigs("DbConnections.config");
            dbConfigs.Save();
        }

        private static void TestService()
        {
            UserServiceClient client = new UserServiceClient();
            TUser user = new TUser();
            user.UserName = "vlong638";
            user.Password = "701616";
            var result = client.Register(user);
        }
    }
}
