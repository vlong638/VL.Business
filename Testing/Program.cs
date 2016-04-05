using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.TransactionServiceClient client = new ServiceReference1.TransactionServiceClient();
            var result = client.CreateUser();
            var resultCode = result.ResultCode;
            var subResultCode = result.SubResultCode;
            //client.Test();
        }
    }
}
