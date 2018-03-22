using System;
using System.Collections.Generic;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public partial class TEarthworkBlocking : IPDMTBase
    {
        public List<TEarthworkBlock> EarthworkBlocks { get; set; }
    }
}
