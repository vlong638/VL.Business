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
            if (tUserBasicInfo.UserId == Guid.Empty)
            {
                var subselect = new SelectBuilder();
                subselect.TableName = nameof(TUserBasicInfo);
                subselect.ComponentSelect.Values.Add(TUserBasicInfoProperties.UserId);
                subselect.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserBasicInfoProperties.UserId, tUserBasicInfo.UserId, LocateType.Equal));
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.UserId, subselect, LocateType.Equal));
            }
            else
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.UserId, tUserBasicInfo.UserId, LocateType.Equal));
            }
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
