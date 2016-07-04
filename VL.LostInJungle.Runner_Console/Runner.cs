using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.DAS.Objects;
using VL.Common.Logger.Utilities;
using VL.Common.Protocol;
using VL.LostInJungle.Runner_Console.Utilities;

namespace VL.LostInJungle.Runner_Console
{
    public class Runner
    {
        static void Main(string[] args)
        {
            //基础配置
            var service = new ContextOfLIJService(new ConfigOfLIJData(), new ProtocolConfig(), LoggerProvider.GetLog4netLogger("ServiceLog"));
            var result = service.Init();
            if (!result.IsAllDependenciesAvailable)
            {
                Console.WriteLine(result.Message);
                Console.ReadLine();
                return;
            }
            //业务逻辑
            try
            {
                using (DbSession session = service.GetDbSession(HelperOfDb.DbNameOfLostInJungle))
                {
                    //用户集合
                    var users = new UserServiceReference.UserServiceClient().GetAllUsers();
                    //LIJ领域模型
                    var dataContext = new ContextOfLIJData();
                    dataContext.InitData(session);
                    //数据生成器
                    var creator = new CreatorOfLIJData();
                    creator.InitData(session, dataContext, users.Data);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
