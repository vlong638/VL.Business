using System;
using System.Collections.Generic;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public partial class TList : IPDMTBase
    {
        public TDetail Detail { get; set; }
    }
}
