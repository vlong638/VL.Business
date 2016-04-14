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
                var result = new UserServiceClient().CheckNodeReferences();
            } while (Console.ReadLine() != "q");

            if (false)
            {
                Register();
            }
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
