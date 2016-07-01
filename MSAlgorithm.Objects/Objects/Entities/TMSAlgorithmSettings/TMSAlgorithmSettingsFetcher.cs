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
        public static bool FetchTMSAlgorithm(this TMSAlgorithmSettings tMSAlgorithmSettings, DbSession session)
        {
            var query = VL.Common.Protocol.IService.IORM.IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmProperties.AlgorithmId, OperatorType.Equal, tMSAlgorithmSettings.AlgorithmId));
            query.SelectBuilders.Add(builder);
            tMSAlgorithmSettings.MSAlgorithm = IDbQueryOperator.GetQueryOperator(session).Select<TMSAlgorithm>(session, query);
            if (tMSAlgorithmSettings.MSAlgorithm == null)
            {
                throw new NotImplementedException(string.Format("1..* 关联未查询到匹配数据, Parent:{0}; Child: {1}", nameof(TMSAlgorithmSettings), nameof(TMSAlgorithm)));
            }
            return true;
        }
        #endregion
    }
}
