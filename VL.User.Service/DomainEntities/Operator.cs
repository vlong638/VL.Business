using System;
using VL.Common.DAS.Objects;
using VL.Common.Protocol.IService;
using VL.User.Objects.Entities;
using VL.User.Objects.SubResults;

namespace VL.User.Service.DomainEntities
{
    public class Operator
    {
        public Result<CreateUserResult> CreateUser(DbSession session, TUser user)
        {
            return user.Create(session);
        }
        public Result<AuthenticateResult> AuthenticateUser(DbSession session, TUser user)
        {
            return user.Authenticate(session);
        }

        #region Simulation
        public Result SimulateCreate(DbSession session, TUser user, DateTime simulateTime)
        {
            return user.SimulateCreate(session, simulateTime);
        } 
        #endregion
    }
}
