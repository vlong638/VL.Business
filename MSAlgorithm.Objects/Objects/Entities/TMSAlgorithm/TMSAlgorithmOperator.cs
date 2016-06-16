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
        public static bool DbDelete(this TMSAlgorithm entity, DbSession session)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmProperties.AlgorithmId, OperatorType.Equal, entity.AlgorithmId));
            return IDbQueryOperator.GetQueryOperator(session).Delete<TMSAlgorithm>(session, query);
        }
        public static bool DbDelete(this List<TMSAlgorithm> entities, DbSession session)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.AlgorithmId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmProperties.AlgorithmId, OperatorType.In, Ids));
            return IDbQueryOperator.GetQueryOperator(session).Delete<TMSAlgorithm>(session, query);
        }
        public static bool DbInsert(this TMSAlgorithm entity, DbSession session)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.AlgorithmId, entity.AlgorithmId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.Name, entity.Name));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.Type, entity.Type));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.DZWeight, entity.DZWeight));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.JCWeight, entity.JCWeight));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.PLWeight, entity.PLWeight));
            query.InsertBuilders.Add(builder);
            return IDbQueryOperator.GetQueryOperator(session).Insert<TMSAlgorithm>(session, query);
        }
        public static bool DbInsert(this List<TMSAlgorithm> entities, DbSession session)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.AlgorithmId, entity.AlgorithmId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.Name, entity.Name));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.Type, entity.Type));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.DZWeight, entity.DZWeight));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.JCWeight, entity.JCWeight));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.PLWeight, entity.PLWeight));
                query.InsertBuilders.Add(builder);
            }
            return IDbQueryOperator.GetQueryOperator(session).InsertAll<TMSAlgorithm>(session, query);
        }
        public static bool DbUpdate(this TMSAlgorithm entity, DbSession session, params string[] fields)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmProperties.AlgorithmId, OperatorType.Equal, entity.AlgorithmId));
            if (fields.Contains(TMSAlgorithmProperties.Name.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.Name, entity.Name));
            }
            if (fields.Contains(TMSAlgorithmProperties.Type.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.Type, entity.Type));
            }
            if (fields.Contains(TMSAlgorithmProperties.DZWeight.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.DZWeight, entity.DZWeight));
            }
            if (fields.Contains(TMSAlgorithmProperties.JCWeight.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.JCWeight, entity.JCWeight));
            }
            if (fields.Contains(TMSAlgorithmProperties.PLWeight.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.PLWeight, entity.PLWeight));
            }
            query.UpdateBuilders.Add(builder);
            return IDbQueryOperator.GetQueryOperator(session).Update<TMSAlgorithm>(session, query);
        }
        public static bool DbUpdate(this List<TMSAlgorithm> entities, DbSession session, params string[] fields)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmProperties.AlgorithmId, OperatorType.Equal, entity.AlgorithmId));
                if (fields.Contains(TMSAlgorithmProperties.Name.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.Name, entity.Name));
                }
                if (fields.Contains(TMSAlgorithmProperties.Type.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.Type, entity.Type));
                }
                if (fields.Contains(TMSAlgorithmProperties.DZWeight.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.DZWeight, entity.DZWeight));
                }
                if (fields.Contains(TMSAlgorithmProperties.JCWeight.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.JCWeight, entity.JCWeight));
                }
                if (fields.Contains(TMSAlgorithmProperties.PLWeight.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TMSAlgorithmProperties.PLWeight, entity.PLWeight));
                }
                query.UpdateBuilders.Add(builder);
            }
            return IDbQueryOperator.GetQueryOperator(session).UpdateAll<TMSAlgorithm>(session, query);
        }
        #endregion
        #region 读
        public static TMSAlgorithm DbSelect(this TMSAlgorithm entity, DbSession session, params string[] fields)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmProperties.AlgorithmId, OperatorType.Equal, entity.AlgorithmId));
            query.SelectBuilders.Add(builder);
            return IDbQueryOperator.GetQueryOperator(session).Select<TMSAlgorithm>(session, query);
        }
        public static List<TMSAlgorithm> DbSelect(this List<TMSAlgorithm> entities, DbSession session, params string[] fields)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            var Ids = entities.Select(c =>c.AlgorithmId );
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TMSAlgorithmProperties.AlgorithmId, OperatorType.In, Ids));
            query.SelectBuilders.Add(builder);
            return IDbQueryOperator.GetQueryOperator(session).SelectAll<TMSAlgorithm>(session, query);
        }
        #endregion
        #endregion
    }
}
