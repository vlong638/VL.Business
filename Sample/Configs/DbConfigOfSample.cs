using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.DAS.Utilities;

namespace Sample.Configs
{
    public class DbConfigOfSample : DbConfigEntity
    {
        public DbConfigOfSample(string fileName) : base(fileName)
        {
        }

        protected override List<DbConfigItem> GetDbConfigItems()
        {
            List<DbConfigItem> result = new List<DbConfigItem>()
            {
                new DbConfigItem("Sample"),
            };
            return result;
        }
    }
}
