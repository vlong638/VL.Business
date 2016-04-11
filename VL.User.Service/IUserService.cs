using System;
using System.ServiceModel;
using VL.Common.Protocol.IResult;
using VL.User.Objects.Entities;
using VL.User.Service.SubResults;

namespace VL.User.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        Result<CreateUserResult> CreateUser(TUser user);
        [OperationContract]
        Result SimulateCreateUser(TUser user, DateTime simulateTime);
    }
}
