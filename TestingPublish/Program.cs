using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingPublish.UserServiceReference;
using VL.Common.Protocol;

namespace TestingPublish
{
    class Program
    {
        static void Main(string[] args)
        {
            //do
            //{
            //    var result1 = new UserServiceClient().Test();
            //    var result2 = new UserServiceClient().CheckNodeReferences();
            //    //var result = new UserServiceClient().Test();
            //} while (Console.ReadLine() != "q");
            
            //服务初始化
            var result2 = new UserServiceClient().CheckNodeReferences();
            var result3 = new UserServiceClient().GetIsSQLLogAvailable();
            //注册用户测试
            Register();
        }

        private static void Register()
        {
            UserServiceClient client = new UserServiceClient();
            TUser user = new TUser();
            user.UserName = "vlong638";
            user.Password = "701616";
            user.Email = "vlong638@163.com";
            user.IdCardNumber = "330326199105080034";
            var result = client.Register(user);
            Console.ReadLine();
        }
    }
}
