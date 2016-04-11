using VL.Common.DAS.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.ORM.Utilities.QueryOperators;

namespace VL.User.Entities
{
    public static class TUserEx
    {
        public static bool CheckUniqueOfUserName(this TUser user,DbSession session)
        {
            var queryOperator = IDbQueryOperator.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.UserName, OperatorType.Equal, user.UserName));
            return queryOperator.SelectAsInt(session, selectBuilder) > 0;
        }
        public static bool CheckUniqueOfMobile(this TUser user, DbSession session)
        {
            var queryOperator = IDbQueryOperator.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.Mobile, OperatorType.Equal, user.Mobile));
            return queryOperator.SelectAsInt(session, selectBuilder) > 0;
        }
        public static bool CheckUniqueOfEmail(this TUser user, DbSession session)
        {
            var queryOperator = IDbQueryOperator.GetQueryOperator(session);
            var selectBuilder = new SelectBuilder();
            selectBuilder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias("count(*)"));
            selectBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.Email, OperatorType.Equal, user.Email));
            return queryOperator.SelectAsInt(session, selectBuilder) > 0;
        }
    }
}
