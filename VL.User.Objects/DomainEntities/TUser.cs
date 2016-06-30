using System;
using System.Collections.Generic;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.ORM.Utilities.QueryOperators;
using VL.Common.Protocol.IService;
using VL.User.Objects.SubResults;

namespace VL.User.Objects.Entities
{
    public partial class TUser : IPDMTBase
    {


        #region Outer Subject Function
        public Result<CreateUserResult> Create(DbSession session)
        {
            var result = new Result<CreateUserResult>(nameof(Create));
            //用户名校验
            if (this.CheckExistenceOfUserName(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.Data = CreateUserResult.UserNameExist;
                result.Message = "用户名已存在";
                return result;
            }
            //手机号码校验
            if (this.CheckExistenceOfMobile(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.Data = CreateUserResult.MobileExist;
                result.Message = "手机号码已存在";
                return result;
            }
            //邮箱校验
            if (this.CheckExistenceOfEmail(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.Data = CreateUserResult.EmailExist;
                result.Message = "邮箱已存在";
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
                result.Data = CreateUserResult.InsertFailed;
                result.Message = "数据新增失败";
                return result;
            }
        }
        public Result<AuthenticateResult> Authenticate(DbSession session)
        {
            var result = new Result<AuthenticateResult>(nameof(Authenticate));
            //用户名校验
            if (!this.CheckExistenceOfUserName(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.Data = AuthenticateResult.UserNameUnexist;
                result.Message = "用户名不存在";
                return result;
            }
            //密码校验
            if (!this.CheckValidityOfPassword(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.Data = AuthenticateResult.PasswordError;
                result.Message = "密码错误";
                return result;
            }
            else
            {
                //TODO处理登录状态
                return result;
            }
        }
        #endregion

        #region Inner Function
        private bool CheckExistenceOfUserName(DbSession session)
        {
            var queryOperator = IDbQueryOperator.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.UserName, OperatorType.Equal, this.UserName));
            return queryOperator.SelectAsInt(session, selectBuilder) > 0;
        }
        private bool CheckExistenceOfMobile(DbSession session)
        {
            var queryOperator = IDbQueryOperator.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.Mobile, OperatorType.Equal, this.Mobile));
            return queryOperator.SelectAsInt(session, selectBuilder) > 0;
        }
        private bool CheckExistenceOfEmail(DbSession session)
        {
            var queryOperator = IDbQueryOperator.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.Email, OperatorType.Equal, this.Email));
            return queryOperator.SelectAsInt(session, selectBuilder) > 0;
        }
        private bool CheckValidityOfPassword(DbSession session)
        {
            var queryOperator = IDbQueryOperator.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.UserId, OperatorType.Equal, this.UserId));
            selectBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.Password, OperatorType.Equal, this.Password));
            return queryOperator.SelectAsInt(session, selectBuilder) > 0;
        }
        #endregion

        #region Outer Object Function
        public List<TUser> GetAllUsers(DbSession session)
        {
            return new List<TUser>().DbSelect(session);
        }
        #endregion
    }
}
