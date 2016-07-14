using System;
using Testing.UserServiceReference;
using VL.User.Service.Configs;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestService();
            //CreateDbConfigForUser();
            //CheckNodeReferences();
        }

        private static void CheckNodeReferences()
        {
            do
            {
                var result = new UserServiceClient().CheckNodeReferences();
            } while (Console.ReadLine() != "q");
        }

        private static void CreateDbConfigForUser()
        {
            DbConfigOfUser dbConfigs = new DbConfigOfUser("DbConnections.config");
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
