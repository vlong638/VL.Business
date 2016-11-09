using System;
using Testing.SubjectUserService;
using VL.User.Service.Configs;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateUser();
            //CreateDbConfigForUser();
            CheckNodeReferences();
        }

        private static void CheckNodeReferences()
        {
            do
            {
                var result = new SubjectUserServiceClient().CheckNodeReferences();
            } while (Console.ReadLine() != "q");
        }

        private static void CreateDbConfigForUser()
        {
            DbConfigOfUser dbConfigs = new DbConfigOfUser("DbConnections.config");
            dbConfigs.Save();
        }

        private static void CreateUser()
        {
            SubjectUserServiceClient client = new SubjectUserServiceClient();
            TUser user = new TUser();
            user.UserName = "vlong638";
            user.Password = "701616";
            var result = client.CreateUser(user);
        }
    }
}
