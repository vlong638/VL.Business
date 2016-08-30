using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.Logger.Utilities;
using VL.Common.Protocol.IService;
using VL.Spider.Manipulator.Utilities;

namespace VL.Spider.Manipulator.Entities
{
    public static class Constraints
    {
        public static string DbName = nameof(VL.Spider);
        public static ServiceContextOfSpider ServiceContext { set; get; }
        public static DependencyResult DependencyResult { set; get; }
        //public static ServiceContextOfSpider Context { set; get; } = new ServiceContextOfSpider();
        public static bool CheckAlive()
        {
            var result = CheckNodeReferences();
            return result.IsAllDependenciesAvailable;
        }
        public static DependencyResult CheckNodeReferences()
        {
            try
            {
                if (DependencyResult == null)
                {
                    ServiceContext = new ServiceContextOfSpider();
                }
                DependencyResult = ServiceContext.Init();
            }
            catch (Exception ex)
            {
                //TODO Default Log
                LoggerProvider.GetLog4netLogger("Default").Error(ex.ToString());
            }
            return DependencyResult;
        }
    }
}
