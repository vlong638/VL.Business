using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.DAS.Utilities;

namespace VL.Spider.Manipulator.Utilities
{
    public class DbConfigOfSpider : DbConfigEntity
    {
        public DbConfigOfSpider(string fileName) : base(fileName)
        {
        }

        protected override List<DbConfigItem> GetDbConfigItems()
        {
            List<DbConfigItem> result = new List<DbConfigItem>()
            {
                new DbConfigItem(nameof(VL.Spider)),
            };
            return result;
        }
    }
}
