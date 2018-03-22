using System;
using System.Collections.Generic;
using VL.Common.Core.DAS;
using VL.Common.Core.ORM;
using VL.Common.Core.Protocol;
using VL.Common.Core.Object.Subsidence;

namespace Subsidence.Business
{
    public static partial class EntityFetcher
    {
        #region Methods
        public static bool FetchEarthworkBlockElements(this TEarthworkBlock tEarthworkBlock, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.IssueDateTime, tEarthworkBlock.IssueDateTime, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.Id, tEarthworkBlock.Id, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            tEarthworkBlock.EarthworkBlockElements = session.GetQueryOperator().SelectAll<TEarthworkBlockElement>(query);
            return tEarthworkBlock.EarthworkBlockElements.Count > 0;
        }
        #endregion
    }
}
