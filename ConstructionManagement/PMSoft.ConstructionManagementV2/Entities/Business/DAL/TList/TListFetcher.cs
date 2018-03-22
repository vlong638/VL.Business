using System;
using System.Collections.Generic;
using VL.Common.Core.DAS;
using VL.Common.Core.ORM;
using VL.Common.Core.Protocol;
using PMSoft.ConstructionManagementV2.DomainModel;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public static partial class EntityFetcher
    {
        #region Methods
        public static bool FetchTDetail(this TList tList, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.Segregation, tList.Segregation, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.IssueType, tList.IssueType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.IssueDateTime, tList.IssueDateTime, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            tList.Detail = session.GetQueryOperator().Select<TDetail>(query);
            return tList.Detail != null;
        }
        #endregion
    }
}
