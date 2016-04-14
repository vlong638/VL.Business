﻿using System;
using System.ServiceModel;
using VL.Common.Protocol.IService;
using VL.User.Objects.Entities;
using VL.User.Objects.SubResults;

namespace VL.User.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IUserService:IWCFServiceNode
    {
        [OperationContract]
        Result<CreateUserResult> Register(TUser user);
        [OperationContract]
        Result<AuthenticateResult> AuthenticateUser(TUser user);

        #region Simulation
        [OperationContract]
        Result SimulateRegister(TUser user, DateTime simulateTime); 
        #endregion
    }
}
