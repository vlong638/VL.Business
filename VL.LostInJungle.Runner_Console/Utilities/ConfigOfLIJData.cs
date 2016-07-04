using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.DAS.Utilities;
using VL.LostInJungle.Runner_Console.Utilities;

namespace VL.LostInJungle.Runner_Console.Utilities
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public class ConfigOfLIJData : DbConfigEntity
    {
        public ConfigOfLIJData(string fileName = nameof(ConfigOfLIJData)) : base(fileName)
        {
        }

        protected override List<DbConfigItem> GetDbConfigItems()
        {
            List<DbConfigItem> result = new List<DbConfigItem>()
            {
                new DbConfigItem(HelperOfDb.DbNameOfLostInJungle),
            };
            return result;
        }
    }
}
