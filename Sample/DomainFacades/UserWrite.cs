using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOTask.Objects.DomainFacades
{
    public partial class User
    {
        //public Result<CreateUserResult> CreateUser(DbSession session, TUser user)
        //{
        //    //将返回结果封装为服务通用返回规范
        //    Result<CreateUserResult> result = new Result<CreateUserResult>();
        //    result.Data = user.Create(session);
        //    if (result.Data == CreateUserResult.Success)
        //    {
        //        result.ResultCode = EResultCode.Success;
        //    }
        //    else
        //    {
        //        result.ResultCode = EResultCode.Failure;
        //        switch (result.Data)
        //        {
        //            case CreateUserResult.DbOperationFailed:
        //                result.Message = "操作数据库失败";
        //                break;
        //            case CreateUserResult.UserNameExist:
        //                result.Message = "用户名已存在";
        //                break;
        //            case CreateUserResult.MobileExist:
        //                result.Message = "手机已存在";
        //                break;
        //            case CreateUserResult.EmailExist:
        //                result.Message = "邮箱已存在";
        //                break;
        //            case CreateUserResult.IdExist:
        //                result.Message = "Id已存在";
        //                break;
        //            default:
        //                result.Message = "未支持该错误码:" + result.Data.ToString();
        //                break;
        //        }
        //    }
        //    return result;
        //}
    }
}
