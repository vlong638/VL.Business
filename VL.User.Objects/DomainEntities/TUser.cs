using System;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.ORM.Utilities.QueryOperators;
using VL.Common.Protocol.IService;
using VL.User.Objects.SubResults;

namespace VL.User.Objects.Entities
{
    public partial class TUser : IPDMTBase, ISimulatable
    {
        public Result<CreateUserResult> Create(DbSession session)
        {
            var result = new Result<CreateUserResult>();
            //用户名校验
            if (this.CheckExistenceOfUserName(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = CreateUserResult.UserNameExist;
                result.Content = "用户名已存在";
                return result;
            }
            //手机号码校验
            if (this.CheckExistenceOfMobile(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = CreateUserResult.MobileExist;
                result.Content = "手机号码已存在";
                return result;
            }
            //邮箱校验
            if (this.CheckExistenceOfEmail(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = CreateUserResult.EmailExist;
                result.Content = "邮箱已存在";
                return result;
            }
            //保存入数据库
            UserId = Guid.NewGuid();
            CreateTime = DateTime.Now;
            if (this.DbInsert(session))
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
        public Result SimulateCreate(DbSession session, DateTime simulateTime)
        {
            //真实创建
            var result = this.Create(session);
            if (result.ResultCode != EResultCode.Success)
            {
                return result;
            }
            //篡改信息以符合模拟要求
            CreateTime = simulateTime;
            if (!this.DbUpdate(session, TUserProperties.CreateTime.Title))
            {
                result.ResultCode = EResultCode.Failure;
                result.Content = "数据篡改失败";
            }
            return result;
        }
        public Result<AuthenticateResult> Authenticate(DbSession session)
        {
            var result = new Result<AuthenticateResult>();
            //用户名校验
            if (!this.CheckExistenceOfUserName(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = AuthenticateResult.UserNameUnexist;
                result.Content = "用户名不存在";
                return result;
            }
            //密码校验
            if (!this.CheckValidityOfPassword(session))
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

        public bool CheckExistenceOfUserName(DbSession session)
        {
            var queryOperator = IDbQueryOperator.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.UserName, OperatorType.Equal, this.UserName));
            return queryOperator.SelectAsInt(session, selectBuilder) > 0;
        }
        public bool CheckExistenceOfMobile(DbSession session)
        {
            var queryOperator = IDbQueryOperator.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.Mobile, OperatorType.Equal, this.Mobile));
            return queryOperator.SelectAsInt(session, selectBuilder) > 0;
        }
        public bool CheckExistenceOfEmail(DbSession session)
        {
            var queryOperator = IDbQueryOperator.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.Email, OperatorType.Equal, this.Email));
            return queryOperator.SelectAsInt(session, selectBuilder) > 0;
        }
        public bool CheckValidityOfPassword(DbSession session)
        {
            var queryOperator = IDbQueryOperator.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.UserId, OperatorType.Equal, this.UserId));
            selectBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.Password, OperatorType.Equal, this.Password));
            return queryOperator.SelectAsInt(session, selectBuilder) > 0;
        }
    }
}
