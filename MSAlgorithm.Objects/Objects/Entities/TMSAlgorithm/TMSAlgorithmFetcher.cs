using System;
using System.Collections.Generic;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace Dacai.MagicSquareAlgorithm.Objects.Entities
{
    public static partial class EntityFetcher
    {
        #region Methods
        public static bool FetchMSAlgorithmSettings(this TMSAlgorithm tMSAlgorithm, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.AlgorithmId, tMSAlgorithm.AlgorithmId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            tMSAlgorithm.MSAlgorithmSettings = IORMProvider.GetQueryOperator(session).SelectAll<TMSAlgorithmSettings>(session, query);
            return tMSAlgorithm.MSAlgorithmSettings.Count > 0;
        }
        #endregion
    }
}
