using Dacai.MagicSquareAlgorithm.Objects.Entities;
using VL.Common.DAS.Objects;
using VL.Common.Protocol.IService;

namespace MSAlgorithm.Service.DomainEntities
{
    class Operator
    {
        public Result<int> CalculateOdds(DbSession session, TMSAlgorithm algorithm)
        {
            return algorithm.CalculateOdds(session);
        }
    }
}
