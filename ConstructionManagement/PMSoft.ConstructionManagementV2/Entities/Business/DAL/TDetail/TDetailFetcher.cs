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
        public static bool FetchNodes(this TDetail tDetail, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.Segregation, tDetail.Segregation, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.IssueType, tDetail.IssueType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.IssueDateTime, tDetail.IssueDateTime, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            tDetail.Nodes = session.GetQueryOperator().SelectAll<TNode>(query);
            return tDetail.Nodes.Count > 0;
        }
        #endregion
    }
}
