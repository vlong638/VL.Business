using System;
using System.Collections.Generic;
using VL.Common.Core.ORM;

namespace VL.Common.Core.Object.Subsidence
{
    public partial class TEarthworkBlock : IPDMTBase
    {
        public List<TEarthworkBlockElement> EarthworkBlockElements { get; set; } = new List<TEarthworkBlockElement>();
    }
}
