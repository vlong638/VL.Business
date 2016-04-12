using System;
using VL.Common.DAS.Objects;
using VL.Common.Protocol.IResult;
using VL.Common.Protocol.ISimulation;
using VL.User.Objects.Entities;
using VL.User.Service.SubResults;

namespace VL.User.Service.DomainEntities
{
    public class Operator : ISimulatable<TUser>
    {
        public Result<CreateUserResult> CreateUser(DbSession session, TUser user)
        {
            var result = new Result<CreateUserResult>();
            //用户名校验
            if (user.CheckExistenceOfUserName(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = CreateUserResult.UserNameExist;
                result.Content = "用户名已存在";
                return result;
            }
            //手机号码校验
            if (user.CheckExistenceOfMobile(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = CreateUserResult.MobileExist;
                result.Content = "手机号码已存在";
                return result;
            }
            //邮箱校验
            if (user.CheckExistenceOfEmail(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = CreateUserResult.EmailExist;
                result.Content = "邮箱已存在";
                return result;
            }
            //保存入数据库
            user.UserId = System.Guid.NewGuid();
            user.CreateTime = DateTime.Now;
            if (user.DbInsert(session))
            {
                result.ResultCode = EResultCode.Success;
                return result;
            }
            else
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = CreateUserResult.InserFailed;
                result.Content = "数据新增失败";
                return result;
            }
        }
        public Result<AuthenticateResult> AuthenticateUser(DbSession session, TUser user)
        {
            var result = new Result<AuthenticateResult>();
            //用户名校验
            if (!user.CheckExistenceOfUserName(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = AuthenticateResult.UserNameUnexist;
                result.Content = "用户名不存在";
                return result;
            }
            //登录校验
            if (!user.Authenticate(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = AuthenticateResult.PasswordError;
                result.Content = "密码错误";
                return result;
            }
            else
            {
                //TODO处理登录状态
                return result;
            }
        }

        #region Simulate
        public Result SimulateCreate(DbSession session, TUser user, DateTime simulateTime)
        {
            //真实创建
            var result = CreateUser(session, user);
            if (result.ResultCode != EResultCode.Success)
            {
                return result;
            }
            //篡改信息以符合模拟要求
            user.CreateTime = simulateTime;
            if (!user.DbUpdate(session, TUserProperties.CreateTime.Title))
            {
                result.ResultCode = EResultCode.Failure;
                result.Content = "数据篡改失败";
            }
            return result;
        } 
        #endregion
    }
}
