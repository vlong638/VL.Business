using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Common.DAS.Objects;
using VL.LostInJungle.Objects.Entities;

namespace VL.LostInJungle.Runner_Console.Utilities
{
    public class ContextOfLIJData
    {
        public List<TArea> Areas { set; get; } = new List<TArea>();
        public List<TPrototypeCreature> PrototypeCreatures { set; get; } = new List<TPrototypeCreature>();


        public void InitData(DbSession session)
        {
            Areas.DbSelect(session);
            PrototypeCreatures.DbSelect(session);
        }
    }
}
