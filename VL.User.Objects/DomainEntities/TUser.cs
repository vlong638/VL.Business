using System;
using System.Collections.Generic;
using System.IO;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.ORM.Utilities.QueryOperators;
using VL.Common.Protocol.IService;
using VL.Common.Protocol.IService.IORM;
using VL.User.Objects.SubResults;

namespace VL.User.Objects.Entities
{
    public partial class TUser : IPDMTBase
    {
        #region Outer Subject Function
        public CreateUserResult Create(DbSession session)
        {
            //用户名校验
            if (this.CheckExistenceOfUserName(session))
            {
                return CreateUserResult.UserNameExist;
            }
            //手机号码校验
            if (this.CheckExistenceOfMobile(session))
            {
                return CreateUserResult.MobileExist;
            }
            //邮箱校验
            if (this.CheckExistenceOfEmail(session))
            {
                return CreateUserResult.EmailExist;
            }
            //Id校验
            if (this.CheckExistenceOfId(session))
            {
                return CreateUserResult.IdExist;
            }
            //保存入数据库
            UserId = Guid.NewGuid();
            CreateTime = DateTime.Now;
            if (this.DbInsert(session))
            {
                return CreateUserResult.Success;
            }
            else
            {
                return CreateUserResult.DbOperationFailed;
            }
        }

        public AuthenticateResult Authenticate(DbSession session)
        {
            //用户名校验
            if (!this.CheckExistenceOfUserName(session))
            {
                return AuthenticateResult.UserNameUnexist;
            }
            //密码校验
            if (!this.CheckValidityOfPassword(session))
            {
                return AuthenticateResult.Success;
            }
            else
            {
                return AuthenticateResult.PasswordError;
            }
        }
        #endregion

        #region Inner Function
        private bool CheckExistenceOfUserName(DbSession session)
        {
            var queryOperator = IORMProvider.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.TableName = nameof(TUser);
            selectBuilder.ComponentSelect.Values.Add(new ComponentValueOfSelect ("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.UserName, this.UserName, LocateType.Equal));
            var result = queryOperator.SelectAsInt<TUser>(session, selectBuilder);
            return result.HasValue&& result.Value> 0;
        }
        private bool CheckExistenceOfMobile(DbSession session)
        {
            var queryOperator = IORMProvider.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.TableName = nameof(TUser);
            selectBuilder.ComponentSelect.Values.Add(new ComponentValueOfSelect("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.Mobile, this.Mobile, LocateType.Equal));
            var result = queryOperator.SelectAsInt<TUser>(session, selectBuilder);
            return result.HasValue && result.Value > 0;
        }
        private bool CheckExistenceOfEmail(DbSession session)
        {
            var queryOperator = IORMProvider.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.TableName = nameof(TUser);
            selectBuilder.ComponentSelect.Values.Add(new ComponentValueOfSelect("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.Email, this.Email, LocateType.Equal));
            var result = queryOperator.SelectAsInt<TUser>(session, selectBuilder);
            return result.HasValue && result.Value > 0;
        }
        private bool CheckExistenceOfId(DbSession session)
        {
            var queryOperator = IORMProvider.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.TableName = nameof(TUser);
            selectBuilder.ComponentSelect.Values.Add(new ComponentValueOfSelect("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.IdCardNumber, this.IdCardNumber, LocateType.Equal));
            var result = queryOperator.SelectAsInt<TUser>(session, selectBuilder);
            return result.HasValue && result.Value > 0;
        }
        private bool CheckValidityOfPassword(DbSession session)
        {
            var queryOperator = IORMProvider.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.TableName = nameof(TUser);
            selectBuilder.ComponentSelect.Values.Add(new ComponentValueOfSelect("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.UserId, this.UserId, LocateType.Equal));
            selectBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.Password, this.Password, LocateType.Equal));
            var result = queryOperator.SelectAsInt<TUser>(session, selectBuilder);
            return result.HasValue && result.Value > 0;
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
