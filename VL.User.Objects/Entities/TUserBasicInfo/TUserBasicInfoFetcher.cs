using System;
using System.Collections.Generic;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace VL.User.Objects.Entities
{
    public static partial class EntityFetcher
    {
        #region Methods
        public static bool FetchTUser(this TUserBasicInfo tUserBasicInfo, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.UserId, OperatorType.Equal, tUserBasicInfo.UserId));
            query.SelectBuilders.Add(builder);
            tUserBasicInfo.User = IORMProvider.GetQueryOperator(session).Select<TUser>(session, query);
            if (tUserBasicInfo.User == null)
            {
                throw new NotImplementedException(string.Format("1..* 关联未查询到匹配数据, Parent:{0}; Child: {1}", nameof(TUserBasicInfo), nameof(TUser)));
            }
            return true;
        }
        #endregion
    }
}
