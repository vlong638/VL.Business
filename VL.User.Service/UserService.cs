using System;
using VL.Common.DAS.Objects;
using VL.Common.DAS.Utilities;
using VL.Common.Protocol.IResult;
using VL.User.Objects.Entities;
using VL.User.Service.DomainEntities;
using VL.User.Service.SubResults;
using VL.User.Service.Utilities;

namespace VL.User.Service
{
    /// <summary>
    /// Service是工作单元块,这里负责单元化的工作处理
    /// 以及服务日志的处理(这里将UnitOfWork无关的部分移至ServiceDelegator,仅留下了纯粹的UnitOfWork)
    /// </summary>
    public class UserService : IUserService
    {
        #region Ordinary Operation
        public Result<CreateUserResult> Register(TUser user)
        {
            return ServiceDelegator.HandleEvent(() =>
            {
                var result = new Result<CreateUserResult>();
                using (DbSession session = DbHelper.GetDbSession(nameof(User)))
                {
                    try
                    {
                        result = new Operator().CreateUser(session, user);
                    }
                    catch (Exception ex)
                    {
                        result.ResultCode = EResultCode.Error;
                        result.Content = ex.Message;
                    }
                    if (result.ResultCode == EResultCode.Success)
                    {
                        session.CommitTransaction();
                    }
                    else
                    {
                        session.RollBackTransaction();
                    }
                }
                return result;
            });
        } 
        #endregion

        #region Simulation
        public Result SimulateRegister(TUser user, DateTime simulateTime)
        {
            return ServiceDelegator.HandleEvent(() =>
            {
                var result = new Result();
                using (DbSession session = DbHelper.GetDbSession(nameof(User)))
                {
                    try
                    {
                        result = new Operator().SimulateCreate(session, user, simulateTime);
                    }
                    catch (Exception ex)
                    {
                        result.ResultCode = EResultCode.Error;
                        result.Content = ex.Message;
                    }
                    if (result.ResultCode == EResultCode.Success)
                    {
                        session.CommitTransaction();
                    }
                    else
                    {
                        session.RollBackTransaction();
                    }
                }
                return result;
            });
        } 
        #endregion
    }
}
