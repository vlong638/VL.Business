using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.ORM.Utilities.QueryOperators;

namespace Dacai.MagicSquareAlgorithm.Objects.Entities
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TMSAlgorithmSettings entity, DbSession session)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.AlgorithmId, OperatorType.Equal, entity.AlgorithmId));
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.TopWeightType, OperatorType.Equal, entity.TopWeightType));
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.SubWeightType, OperatorType.Equal, entity.SubWeightType));
            return IDbQueryOperator.GetQueryOperator(session).Delete<TMSAlgorithmSettings>(session, query);
        }
        public static bool DbDelete(this List<TMSAlgorithmSettings> entities, DbSession session)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.AlgorithmId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.AlgorithmId, OperatorType.In, Ids));
            return IDbQueryOperator.GetQueryOperator(session).Delete<TMSAlgorithmSettings>(session, query);
        }
        public static bool DbInsert(this TMSAlgorithmSettings entity, DbSession session)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.AlgorithmId, entity.AlgorithmId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.TopWeightType, entity.TopWeightType));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.SubWeightType, entity.SubWeightType));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.ResultType, entity.ResultType));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.WeightValue, entity.WeightValue));
            query.InsertBuilders.Add(builder);
            return IDbQueryOperator.GetQueryOperator(session).Insert<TMSAlgorithmSettings>(session, query);
        }
        public static bool DbInsert(this List<TMSAlgorithmSettings> entities, DbSession session)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.AlgorithmId, entity.AlgorithmId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.TopWeightType, entity.TopWeightType));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.SubWeightType, entity.SubWeightType));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.ResultType, entity.ResultType));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.WeightValue, entity.WeightValue));
                query.InsertBuilders.Add(builder);
            }
            return IDbQueryOperator.GetQueryOperator(session).InsertAll<TMSAlgorithmSettings>(session, query);
        }
        public static bool DbUpdate(this TMSAlgorithmSettings entity, DbSession session, params string[] fields)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.AlgorithmId, OperatorType.Equal, entity.AlgorithmId));
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.TopWeightType, OperatorType.Equal, entity.TopWeightType));
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.SubWeightType, OperatorType.Equal, entity.SubWeightType));
            if (fields.Contains(TMSAlgorithmSettingsProperties.ResultType.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.ResultType, entity.ResultType));
            }
            if (fields.Contains(TMSAlgorithmSettingsProperties.WeightValue.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.WeightValue, entity.WeightValue));
            }
            query.UpdateBuilders.Add(builder);
            return IDbQueryOperator.GetQueryOperator(session).Update<TMSAlgorithmSettings>(session, query);
        }
        public static bool DbUpdate(this List<TMSAlgorithmSettings> entities, DbSession session, params string[] fields)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.AlgorithmId, OperatorType.Equal, entity.AlgorithmId));
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.TopWeightType, OperatorType.Equal, entity.TopWeightType));
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.SubWeightType, OperatorType.Equal, entity.SubWeightType));
                if (fields.Contains(TMSAlgorithmSettingsProperties.ResultType.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.ResultType, entity.ResultType));
                }
                if (fields.Contains(TMSAlgorithmSettingsProperties.WeightValue.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmSettingsProperties.WeightValue, entity.WeightValue));
                }
                query.UpdateBuilders.Add(builder);
            }
            return IDbQueryOperator.GetQueryOperator(session).UpdateAll<TMSAlgorithmSettings>(session, query);
        }
        #endregion
        #region 读
        public static TMSAlgorithmSettings DbSelect(this TMSAlgorithmSettings entity, DbSession session, params string[] fields)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.AlgorithmId, OperatorType.Equal, entity.AlgorithmId));
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.TopWeightType, OperatorType.Equal, entity.TopWeightType));
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.SubWeightType, OperatorType.Equal, entity.SubWeightType));
            query.SelectBuilders.Add(builder);
            return IDbQueryOperator.GetQueryOperator(session).Select<TMSAlgorithmSettings>(session, query);
        }
        public static List<TMSAlgorithmSettings> DbSelect(this List<TMSAlgorithmSettings> entities, DbSession session, params string[] fields)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            var Ids = entities.Select(c =>c.AlgorithmId );
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmSettingsProperties.AlgorithmId, OperatorType.In, Ids));
            query.SelectBuilders.Add(builder);
            return IDbQueryOperator.GetQueryOperator(session).SelectAll<TMSAlgorithmSettings>(session, query);
        }
        #endregion
        #endregion
    }
}
