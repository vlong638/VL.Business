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
        public static bool FetchTMSAlgorithm(this TMSAlgorithmSettings tMSAlgorithmSettings, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (tMSAlgorithmSettings.AlgorithmId == Guid.Empty)
            {
                var subselect = new SelectBuilder();
                subselect.TableName = nameof(TMSAlgorithmSettings);
                subselect.ComponentSelect.Add(TMSAlgorithmSettingsProperties.AlgorithmId);
                subselect.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.SubWeightType, tMSAlgorithmSettings.SubWeightType, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmProperties.AlgorithmId, subselect, LocateType.Equal));
            }
            else
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmProperties.AlgorithmId, tMSAlgorithmSettings.AlgorithmId, LocateType.Equal));
            }
            query.SelectBuilders.Add(builder);
            tMSAlgorithmSettings.MSAlgorithm = IORMProvider.GetQueryOperator(session).Select<TMSAlgorithm>(session, query);
            if (tMSAlgorithmSettings.MSAlgorithm == null)
            {
                throw new NotImplementedException(string.Format("1..* 关联未查询到匹配数据, Parent:{0}; Child: {1}", nameof(TMSAlgorithmSettings), nameof(TMSAlgorithm)));
            }
            return true;
        }
        #endregion
    }
}
