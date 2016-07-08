using System;
using VL.Common.DAS.Objects;
using VL.Common.Protocol.IService;
using VL.User.Objects.Entities;
using VL.User.Objects.SubResults;

namespace VL.User.Service.DomainEntities
{
    public class SubjectOperator
    {
        public Result<CreateUserResult> CreateUser(DbSession session, TUser user)
        {
            Result<CreateUserResult> result = new Result<CreateUserResult>();
            result.Data = user.Create(session);
            if (result.Data==CreateUserResult.Success)
            {
                result.ResultCode = EResultCode.Success;
            }
            else
            {
                result.ResultCode = EResultCode.Failure;
                switch (result.Data)
                {
                    case CreateUserResult.DbOperationFailed:
                        result.Message = "操作数据库失败";
                        break;
                    case CreateUserResult.UserNameExist:
                        result.Message = "用户名已存在";
                        break;
                    case CreateUserResult.MobileExist:
                        result.Message = "手机已存在";
                        break;
                    case CreateUserResult.EmailExist:
                        result.Message = "邮箱已存在";
                        break;
                    case CreateUserResult.IdExist:
                        result.Message = "Id已存在";
                        break;
                    default:
                        result.Message = "未支持该错误码:" + result.Data.ToString();
                        break;
                }
            }
            return result;
        }
        public Result<AuthenticateResult> AuthenticateUser(DbSession session, TUser user)
        {
            Result<AuthenticateResult> result = new Result<AuthenticateResult>();
            result.Data = user.Authenticate(session);
            if (result.Data == AuthenticateResult.Success)
            {
                result.ResultCode = EResultCode.Success;
            }
            else
            {
                result.ResultCode = EResultCode.Failure;
                switch (result.Data)
                {
                    case AuthenticateResult.UserNameUnexist:
                        result.Message = "用户名不存在";
                        break;
                    case AuthenticateResult.PasswordError:
                        result.Message = "密码错误";
                        break;
                    default:
                        result.Message = "未支持该错误码:" + result.Data.ToString();
                        break;
                }
            }
            return result;
        }
    }
}
