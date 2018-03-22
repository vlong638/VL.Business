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
        public static bool FetchEarthworkBlocks(this TEarthworkBlocking tEarthworkBlocking, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockProperties.IssueDateTime, tEarthworkBlocking.IssueDateTime, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            tEarthworkBlocking.EarthworkBlocks = session.GetQueryOperator().SelectAll<TEarthworkBlock>(query);
            return tEarthworkBlocking.EarthworkBlocks.Count > 0;
        }
        #endregion
    }
}
