using System;
using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace Dacai.MagicSquareAlgorithm.Objects.Entities
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TMSAlgorithmSettings entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.AlgorithmId, entity.AlgorithmId, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.TopWeightType, entity.TopWeightType, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.SubWeightType, entity.SubWeightType, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TMSAlgorithmSettings>(session, query);
        }
        public static bool DbDelete(this List<TMSAlgorithmSettings> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.AlgorithmId );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.AlgorithmId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TMSAlgorithmSettings>(session, query);
        }
        public static bool DbInsert(this TMSAlgorithmSettings entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TMSAlgorithmSettingsProperties.AlgorithmId, entity.AlgorithmId));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TMSAlgorithmSettingsProperties.TopWeightType, entity.TopWeightType));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TMSAlgorithmSettingsProperties.SubWeightType, entity.SubWeightType));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TMSAlgorithmSettingsProperties.ResultType, entity.ResultType));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TMSAlgorithmSettingsProperties.WeightValue, entity.WeightValue));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TMSAlgorithmSettings>(session, query);
        }
        public static bool DbInsert(this List<TMSAlgorithmSettings> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TMSAlgorithmSettingsProperties.AlgorithmId, entity.AlgorithmId));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TMSAlgorithmSettingsProperties.TopWeightType, entity.TopWeightType));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TMSAlgorithmSettingsProperties.SubWeightType, entity.SubWeightType));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TMSAlgorithmSettingsProperties.ResultType, entity.ResultType));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TMSAlgorithmSettingsProperties.WeightValue, entity.WeightValue));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TMSAlgorithmSettings>(session, query);
        }
        public static bool DbUpdate(this TMSAlgorithmSettings entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.AlgorithmId, entity.AlgorithmId, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.TopWeightType, entity.TopWeightType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.SubWeightType, entity.SubWeightType, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.AlgorithmId, entity.AlgorithmId));
                builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.TopWeightType, entity.TopWeightType));
                builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.SubWeightType, entity.SubWeightType));
                builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.ResultType, entity.ResultType));
                builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.WeightValue, entity.WeightValue));
            }
            else
            {
                if (fields.Contains(TMSAlgorithmSettingsProperties.ResultType))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.ResultType, entity.ResultType));
                }
                if (fields.Contains(TMSAlgorithmSettingsProperties.WeightValue))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.WeightValue, entity.WeightValue));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TMSAlgorithmSettings>(session, query);
        }
        public static bool DbUpdate(this List<TMSAlgorithmSettings> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.AlgorithmId, entity.AlgorithmId, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.TopWeightType, entity.TopWeightType, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.SubWeightType, entity.SubWeightType, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.AlgorithmId, entity.AlgorithmId));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.TopWeightType, entity.TopWeightType));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.SubWeightType, entity.SubWeightType));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.ResultType, entity.ResultType));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.WeightValue, entity.WeightValue));
                }
                else
                {
                    if (fields.Contains(TMSAlgorithmSettingsProperties.ResultType))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.ResultType, entity.ResultType));
                    }
                    if (fields.Contains(TMSAlgorithmSettingsProperties.WeightValue))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TMSAlgorithmSettingsProperties.WeightValue, entity.WeightValue));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TMSAlgorithmSettings>(session, query);
        }
        #endregion
        #region 读
        public static TMSAlgorithmSettings DbSelect(this TMSAlgorithmSettings entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.AlgorithmId);
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.TopWeightType);
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.SubWeightType);
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.ResultType);
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.WeightValue);
            }
            else
            {
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.AlgorithmId);
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.TopWeightType);
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.SubWeightType);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.AlgorithmId, entity.AlgorithmId, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.TopWeightType, entity.TopWeightType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.SubWeightType, entity.SubWeightType, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TMSAlgorithmSettings>(session, query);
        }
        public static List<TMSAlgorithmSettings> DbSelect(this List<TMSAlgorithmSettings> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.AlgorithmId);
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.TopWeightType);
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.SubWeightType);
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.ResultType);
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.WeightValue);
            }
            else
            {
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.AlgorithmId);
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.TopWeightType);
                builder.ComponentSelect.Add(TMSAlgorithmSettingsProperties.SubWeightType);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.AlgorithmId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TMSAlgorithmSettingsProperties.AlgorithmId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TMSAlgorithmSettings>(session, query);
        }
        public static void DbLoad(this TMSAlgorithmSettings entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TMSAlgorithmSettingsProperties.ResultType))
            {
                entity.ResultType = result.ResultType;
            }
            if (fields.Contains(TMSAlgorithmSettingsProperties.WeightValue))
            {
                entity.WeightValue = result.WeightValue;
            }
        }
        public static void DbLoad(this List<TMSAlgorithmSettings> entities, DbSession session, params PDMDbProperty[] fields)
        {
            foreach (var entity in entities)
            {
                entity.DbLoad(session, fields);
            }
        }
        #endregion
        #endregion
    }
}
