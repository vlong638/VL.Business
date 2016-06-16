using System;
using System.Collections.Generic;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.ORM.Utilities.QueryOperators;

namespace Dacai.MagicSquareAlgorithm.Objects.Entities
{
    public static partial class EntityFetcher
    {
        #region Methods
        public static bool FetchMSAlgorithmSettings(this TMSAlgorithm tMSAlgorithm, DbSession session)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.AlgorithmId, OperatorType.Equal, tMSAlgorithm.AlgorithmId));
            query.SelectBuilders.Add(builder);
            tMSAlgorithm.MSAlgorithmSettings = IDbQueryOperator.GetQueryOperator(session).SelectAll<TMSAlgorithmSettings>(session, query);
            return tMSAlgorithm.MSAlgorithmSettings.Count > 0;
        }
        #endregion
    }
}
