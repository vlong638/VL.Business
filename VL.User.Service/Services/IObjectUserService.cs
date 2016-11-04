using System.Collections.Generic;
using System.ServiceModel;
using VL.Common.DAS.Objects;
using VL.Common.Protocol.IService;
using VL.User.Objects.Entities;

namespace VL.User.Service
{
    [ServiceContract]
    public interface IObjectUserService : IWCFServiceNode
    {
        [OperationContract]
        Report<List<TUser>> GetAllUsers();
    }
}
