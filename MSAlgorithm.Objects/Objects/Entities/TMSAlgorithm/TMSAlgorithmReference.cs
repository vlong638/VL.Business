using System;
using System.Collections.Generic;
using VL.Common.ORM.Objects;

namespace Dacai.MagicSquareAlgorithm.Objects.Entities
{
    public partial class TMSAlgorithm : IPDMTBase
    {
        public List<TMSAlgorithmSettings> MSAlgorithmSettings { get; set; }
    }
}
