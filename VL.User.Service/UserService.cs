using System;
using VL.Common.Protocol.IService;
using VL.User.Objects.Entities;
using VL.User.Objects.SubResults;
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
        public bool CheckAlive()
        {
            return true;
        }
        public DependencyResult CheckNodeReferences()
        {
            return new UserServiceContext().InitForService();
        }

        public Result<CreateUserResult> Register(TUser user)
        {
            return ServiceDelegator.HandleSimpleTransactionEvent(nameof(User), (session) =>
            {
                return new Operator().CreateUser(session, user);
            });
        }
        public Result<AuthenticateResult> AuthenticateUser(TUser user)
        {
            return ServiceDelegator.HandleSimpleTransactionEvent(nameof(User), (session) =>
            {
                return new Operator().AuthenticateUser(session, user);
            });
        }

        #region Simulation
        public Result SimulateRegister(TUser user, DateTime simulateTime)
        {
            return ServiceDelegator.HandleSimpleTransactionEvent(nameof(User), (session) =>
            {
                return new Operator().SimulateCreate(session, user, simulateTime);
            }, true);
        }

        #endregion
    }
}
