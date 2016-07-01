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
        public static bool FetchTUserBasicInfo(this TUser tUser, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserBasicInfoProperties.UserId, OperatorType.Equal, tUser.UserId));
            query.SelectBuilders.Add(builder);
            tUser.UserBasicInfo = IORMProvider.GetQueryOperator(session).Select<TUserBasicInfo>(session, query);
            if (tUser.UserBasicInfo == null)
            {
                throw new NotImplementedException(string.Format("1..* 关联未查询到匹配数据, Parent:{0}; Child: {1}", nameof(TUser), nameof(TUserBasicInfo)));
            }
            return true;
        }
        #endregion
    }
}
