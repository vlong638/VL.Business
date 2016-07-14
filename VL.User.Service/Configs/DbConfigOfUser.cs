using System.Collections.Generic;
using VL.Common.DAS.Utilities;

namespace VL.User.Service.Configs
{
    public class DbConfigOfUser : DbConfigEntity
    {
        public DbConfigOfUser(string fileName) : base(fileName)
        {
        }

        protected override List<DbConfigItem> GetDbConfigItems()
        {
            List<DbConfigItem> result = new List<DbConfigItem>()
            {
                new DbConfigItem(nameof(VL.User)),
            };
            return result;
        }
    }
}
