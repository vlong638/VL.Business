using System;
using System.Collections.Generic;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public partial class TEarthworkBlock : IPDMTBase
    {
        public List<TEarthworkBlockElement> EarthworkBlockElements { get; set; }
    }
}
