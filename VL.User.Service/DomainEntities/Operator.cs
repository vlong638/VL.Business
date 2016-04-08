using System;
using VL.Common.DAS.Objects;
using VL.Common.DAS.Utilities;
using VL.Common.Protocol.IResult;
using VL.User.Entities;
using VL.User.Service.SubResults;

namespace VL.User.Service.DomainEntities
{
    public class Operator
    {
        public static Result<CreateUserResult> CreateUser(TUser user)
        {
            var result = new Result<CreateUserResult>();
            try
            {
                result.ResultCode = EResultCode.Success;
                using (DbSession session = DbHelper.GetDbSession(nameof(User)))
                {
                    if (user.CheckUniqueOfUserName(session))
                    {
                        result.ResultCode = EResultCode.Failure;
                        result.SubResultCode = CreateUserResult.UserNameExist;
                        return result;
                    }
                    if (user.CheckUniqueOfMobile(session))
                    {
                        result.ResultCode = EResultCode.Failure;
                        result.SubResultCode = CreateUserResult.MobileExist;
                        return result;
                    }
                    if (user.CheckUniqueOfEmail(session))
                    {
                        result.ResultCode = EResultCode.Failure;
                        result.SubResultCode = CreateUserResult.EmailExist;
                        return result;
                    }
                    user.UserId = System.Guid.NewGuid();
                    if (user.DbInsert(session))
                    {
                        result.ResultCode = EResultCode.Success;
                        return result;
                    }
                    else
                    {
                        result.ResultCode = EResultCode.Failure;
                        result.SubResultCode = CreateUserResult.InserFailed;
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ResultCode = EResultCode.Error;
                result.Content = ex.Message;
                return result;
            }
        }
    }
}
