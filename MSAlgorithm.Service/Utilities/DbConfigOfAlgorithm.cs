using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.DAS.Utilities;

namespace MSAlgorithm.Service.Utilities
{
    public class DbConfigOfAlgorithm : DbConfigEntity
    {
        public DbConfigOfAlgorithm(string fileName) : base(fileName)
        {
        }

        protected override List<DbConfigItem> GetDbConfigItems()
        {
            List<DbConfigItem> result = new List<DbConfigItem>()
            {
                new DbConfigItem(nameof(MSAlgorithm)),
            };
            return result;
        }
    }
}
