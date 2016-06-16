using Dacai.MagicSquareAlgorithm.Objects.Entities;
using MSAlgorithm.Service.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VL.Common.Protocol.IService;

namespace MSAlgorithm.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class MSAlgorithmService : IMSAlgorithmService
    {
        public Result<int> CalculateOdds(Guid algorithmId)
        {
            return ServiceDelegator.HandleSimpleTransactionEvent(nameof(MSAlgorithm), (session) =>
            {
                TMSAlgorithm algorithm = new TMSAlgorithm();
                algorithm.AlgorithmId = algorithmId;
                //TODO获取到有效的algorithm
                return algorithm.CalculateOdds(session);
            });
        }
    }
}
