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
        public static bool DbDelete(this TMSAlgorithm entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TMSAlgorithmProperties.AlgorithmId, entity.AlgorithmId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TMSAlgorithm>(session, query);
        }
        public static bool DbDelete(this List<TMSAlgorithm> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.AlgorithmId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TMSAlgorithmProperties.AlgorithmId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TMSAlgorithm>(session, query);
        }
        public static bool DbInsert(this TMSAlgorithm entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TMSAlgorithmProperties.AlgorithmId, entity.AlgorithmId));
            if (entity.Name == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Name));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TMSAlgorithmProperties.Name, entity.Name));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TMSAlgorithmProperties.Type, entity.Type));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TMSAlgorithmProperties.DZWeight, entity.DZWeight));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TMSAlgorithmProperties.JCWeight, entity.JCWeight));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TMSAlgorithmProperties.PLWeight, entity.PLWeight));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TMSAlgorithm>(session, query);
        }
        public static bool DbInsert(this List<TMSAlgorithm> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TMSAlgorithmProperties.AlgorithmId, entity.AlgorithmId));
            if (entity.Name == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Name));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TMSAlgorithmProperties.Name, entity.Name));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TMSAlgorithmProperties.Type, entity.Type));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TMSAlgorithmProperties.DZWeight, entity.DZWeight));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TMSAlgorithmProperties.JCWeight, entity.JCWeight));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TMSAlgorithmProperties.PLWeight, entity.PLWeight));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TMSAlgorithm>(session, query);
        }
        public static bool DbUpdate(this TMSAlgorithm entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TMSAlgorithmProperties.AlgorithmId, entity.AlgorithmId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.AlgorithmId, entity.AlgorithmId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.Name, entity.Name));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.Type, entity.Type));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.DZWeight, entity.DZWeight));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.JCWeight, entity.JCWeight));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.PLWeight, entity.PLWeight));
            }
            else
            {
                if (fields.Contains(TMSAlgorithmProperties.Name))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.Name, entity.Name));
                }
                if (fields.Contains(TMSAlgorithmProperties.Type))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.Type, entity.Type));
                }
                if (fields.Contains(TMSAlgorithmProperties.DZWeight))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.DZWeight, entity.DZWeight));
                }
                if (fields.Contains(TMSAlgorithmProperties.JCWeight))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.JCWeight, entity.JCWeight));
                }
                if (fields.Contains(TMSAlgorithmProperties.PLWeight))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.PLWeight, entity.PLWeight));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TMSAlgorithm>(session, query);
        }
        public static bool DbUpdate(this List<TMSAlgorithm> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TMSAlgorithmProperties.AlgorithmId, entity.AlgorithmId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.AlgorithmId, entity.AlgorithmId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.Name, entity.Name));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.Type, entity.Type));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.DZWeight, entity.DZWeight));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.JCWeight, entity.JCWeight));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.PLWeight, entity.PLWeight));
                }
                else
                {
                    if (fields.Contains(TMSAlgorithmProperties.Name))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.Name, entity.Name));
                    }
                    if (fields.Contains(TMSAlgorithmProperties.Type))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.Type, entity.Type));
                    }
                    if (fields.Contains(TMSAlgorithmProperties.DZWeight))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.DZWeight, entity.DZWeight));
                    }
                    if (fields.Contains(TMSAlgorithmProperties.JCWeight))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.JCWeight, entity.JCWeight));
                    }
                    if (fields.Contains(TMSAlgorithmProperties.PLWeight))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TMSAlgorithmProperties.PLWeight, entity.PLWeight));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TMSAlgorithm>(session, query);
        }
        #endregion
        #region 读
        public static TMSAlgorithm DbSelect(this TMSAlgorithm entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.AlgorithmId);
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.Name);
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.Type);
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.DZWeight);
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.JCWeight);
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.PLWeight);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.AlgorithmId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TMSAlgorithmProperties.AlgorithmId, entity.AlgorithmId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TMSAlgorithm>(session, query);
        }
        public static List<TMSAlgorithm> DbSelect(this List<TMSAlgorithm> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.AlgorithmId);
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.Name);
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.Type);
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.DZWeight);
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.JCWeight);
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.PLWeight);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TMSAlgorithmProperties.AlgorithmId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.AlgorithmId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TMSAlgorithmProperties.AlgorithmId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TMSAlgorithm>(session, query);
        }
        public static void DbLoad(this TMSAlgorithm entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TMSAlgorithmProperties.Name))
            {
                entity.Name = result.Name;
            }
            if (fields.Contains(TMSAlgorithmProperties.Type))
            {
                entity.Type = result.Type;
            }
            if (fields.Contains(TMSAlgorithmProperties.DZWeight))
            {
                entity.DZWeight = result.DZWeight;
            }
            if (fields.Contains(TMSAlgorithmProperties.JCWeight))
            {
                entity.JCWeight = result.JCWeight;
            }
            if (fields.Contains(TMSAlgorithmProperties.PLWeight))
            {
                entity.PLWeight = result.PLWeight;
            }
        }
        public static void DbLoad(this List<TMSAlgorithm> entities, DbSession session, params PDMDbProperty[] fields)
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
