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
            if (tUser.UserId == Guid.Empty)
            {
                var subselect = new SelectBuilder();
                subselect.TableName = nameof(TUser);
                subselect.ComponentSelect.Values.Add(TUserProperties.UserId);
                subselect.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.UserId, tUser.UserId, LocateType.Equal));
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserBasicInfoProperties.UserId, subselect, LocateType.Equal));
            }
            else
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserBasicInfoProperties.UserId, tUser.UserId, LocateType.Equal));
            }
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
