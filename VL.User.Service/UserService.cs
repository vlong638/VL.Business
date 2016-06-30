﻿using System;
using System.Collections.Generic;
using VL.Common.Logger.Utilities;
using VL.Common.Protocol;
using VL.Common.Protocol.IService;
using VL.User.Objects.Entities;
using VL.User.Objects.SubResults;
using VL.User.Service.Configs;
using VL.User.Service.DomainEntities;
using VL.User.Service.Utilities;

namespace VL.User.Service
{
    /// <summary>
    /// Service是工作单元块,这里负责单元化的工作处理
    /// 以及服务日志的处理(这里将UnitOfWork无关的部分移至ServiceDelegator,仅留下了纯粹的UnitOfWork)
    /// </summary>
    public class UserService : IUserService
    {
        UserServiceContext ServiceContext { set; get; }
        DependencyResult DependencyResult { set; get; }

        public bool CheckAlive()
        {
            var result = CheckNodeReferences();
            return result.IsAllDependenciesAvailable;
        }
        public DependencyResult CheckNodeReferences()
        {
            try
            {
                if (DependencyResult == null)
                {
                    ServiceContext = new UserServiceContext(
                        new DbConfigs("DbConnections.config"),
                        new ProtocolConfig("ProtocolConfig.config"),
                        LoggerProvider.GetLog4netLogger("ServiceLog"));
                }
                DependencyResult = ServiceContext.Init();
            }
            catch (Exception ex)
            {
                LoggerProvider.GetLog4netLogger("ServiceLog").Error(ex.ToString());
            }
            return DependencyResult;
        }

        public Result<CreateUserResult> Register(TUser user)
        {
            return ServiceDelegator.HandleSimpleTransactionEvent(nameof(User), (session) =>
            {
                return new SubjectOperator().CreateUser(session, user);
            });
        }
        public Result<AuthenticateResult> AuthenticateUser(TUser user)
        {
            return ServiceDelegator.HandleSimpleTransactionEvent(nameof(User), (session) =>
            {
                return new SubjectOperator().AuthenticateUser(session, user);
            });
        }
        public Result<List<TUser>> GetAllUsers()
        {
            return ServiceDelegator.HandleSimpleTransactionEvent(nameof(User), (session) =>
            {
                return new ObjectOperator().GetAllUsers(session);
            });
        }

        #region Test
        public int Test()
        {
            LoggerProvider.GetLog4netLogger("ServiceLog").Error("message for test");
            return 1;
        }
        public A GetA()
        {
            return new A()
            {
                Name = "A",
                As = new List<A>()
                {
                    new A()
                    {
                        Name ="Sub A"
                    }
                },
                Bs = new List<B>()
                {
                    new B()
                    {
                        Name="Sub B",
                        Value=1
                    }
                },
            };
        }
        #endregion
    }
}
