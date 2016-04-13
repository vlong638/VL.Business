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
            //�û���У��
            if (this.CheckExistenceOfUserName(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = CreateUserResult.UserNameExist;
                result.Content = "�û����Ѵ���";
                return result;
            }
            //�ֻ�����У��
            if (this.CheckExistenceOfMobile(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = CreateUserResult.MobileExist;
                result.Content = "�ֻ������Ѵ���";
                return result;
            }
            //����У��
            if (this.CheckExistenceOfEmail(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = CreateUserResult.EmailExist;
                result.Content = "�����Ѵ���";
                return result;
            }
            //���������ݿ�
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
                result.Content = "��������ʧ��";
                return result;
            }
        }
        public Result SimulateCreate(DbSession session, DateTime simulateTime)
        {
            //��ʵ����
            var result = this.Create(session);
            if (result.ResultCode != EResultCode.Success)
            {
                return result;
            }
            //�۸���Ϣ�Է���ģ��Ҫ��
            CreateTime = simulateTime;
            if (!this.DbUpdate(session, TUserProperties.CreateTime.Title))
            {
                result.ResultCode = EResultCode.Failure;
                result.Content = "���ݴ۸�ʧ��";
            }
            return result;
        }
        public Result<AuthenticateResult> Authenticate(DbSession session)
        {
            var result = new Result<AuthenticateResult>();
            //�û���У��
            if (!this.CheckExistenceOfUserName(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = AuthenticateResult.UserNameUnexist;
                result.Content = "�û���������";
                return result;
            }
            //����У��
            if (!this.CheckValidityOfPassword(session))
            {
                result.ResultCode = EResultCode.Failure;
                result.SubResultCode = AuthenticateResult.PasswordError;
                result.Content = "�������";
                return result;
            }
            else
            {
                //TODO�����¼״̬
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
