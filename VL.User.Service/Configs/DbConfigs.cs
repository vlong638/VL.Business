using System.Collections.Generic;
using VL.Common.DAS.Utilities;

namespace VL.User.Service.Configs
{
    public class DbConfigs : DbConfigEntity
    {
        public DbConfigs(string fileName) : base(fileName)
        {
        }

        protected override List<DbConfigItem> GetDbConfigItems()
        {
            List<DbConfigItem> result = new List<DbConfigItem>()
            {
                new DbConfigItem("User"),
                new DbConfigItem("Other"),
            };
            return result;
        }
    }
}
