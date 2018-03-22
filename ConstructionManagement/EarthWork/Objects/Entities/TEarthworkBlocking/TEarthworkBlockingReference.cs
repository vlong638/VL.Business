using System;
using System.Collections.Generic;
using VL.Common.Core.ORM;

namespace VL.Common.Core.Object.Subsidence
{
    public partial class TEarthworkBlocking : IPDMTBase
    {
        public List<TEarthworkBlock> EarthworkBlocks { get; set; } = new List<TEarthworkBlock>();
    }
}
