using System;
using System.Collections.Generic;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public partial class TDetail : IPDMTBase
    {
        public List<TNode> Nodes { get; set; }
    }
}
