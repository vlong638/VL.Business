using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingPublish.UserServiceReference;

namespace TestingPublish
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
               var result1 = new UserServiceClient().Test();
                var result2 = new UserServiceClient().CheckNodeReferences();
                //var result = new UserServiceClient().Test();
            } while (Console.ReadLine() != "q");

            //注册用户测试
            //Register();
        }

        private static void Register()
        {
            UserServiceClient client = new UserServiceClient();
            TUser user = new TUser();
            user.UserName = "vlong638";
            user.Password = "701616";
            var result = client.Register(user);
            Console.ReadLine();
        }
    }
}
