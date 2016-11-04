using System;
using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace VL.LostInJungle.Objects.Entities
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TCreatureQuality entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureQualityProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TCreatureQuality>(session, query);
        }
        public static bool DbDelete(this List<TCreatureQuality> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.CreatureId );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureQualityProperties.CreatureId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TCreatureQuality>(session, query);
        }
        public static bool DbInsert(this TCreatureQuality entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureQualityProperties.CreatureId, entity.CreatureId));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureQualityProperties.FirstLevelQuality, entity.FirstLevelQuality));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureQualityProperties.SecondLevelQuality, entity.SecondLevelQuality));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureQualityProperties.ThirdLevelQuality, entity.ThirdLevelQuality));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TCreatureQuality>(session, query);
        }
        public static bool DbInsert(this List<TCreatureQuality> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureQualityProperties.CreatureId, entity.CreatureId));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureQualityProperties.FirstLevelQuality, entity.FirstLevelQuality));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureQualityProperties.SecondLevelQuality, entity.SecondLevelQuality));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureQualityProperties.ThirdLevelQuality, entity.ThirdLevelQuality));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TCreatureQuality>(session, query);
        }
        public static bool DbUpdate(this TCreatureQuality entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureQualityProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.CreatureId, entity.CreatureId));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.FirstLevelQuality, entity.FirstLevelQuality));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.SecondLevelQuality, entity.SecondLevelQuality));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.ThirdLevelQuality, entity.ThirdLevelQuality));
            }
            else
            {
                if (fields.Contains(TCreatureQualityProperties.FirstLevelQuality))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.FirstLevelQuality, entity.FirstLevelQuality));
                }
                if (fields.Contains(TCreatureQualityProperties.SecondLevelQuality))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.SecondLevelQuality, entity.SecondLevelQuality));
                }
                if (fields.Contains(TCreatureQualityProperties.ThirdLevelQuality))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.ThirdLevelQuality, entity.ThirdLevelQuality));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TCreatureQuality>(session, query);
        }
        public static bool DbUpdate(this List<TCreatureQuality> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureQualityProperties.CreatureId, entity.CreatureId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.CreatureId, entity.CreatureId));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.FirstLevelQuality, entity.FirstLevelQuality));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.SecondLevelQuality, entity.SecondLevelQuality));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.ThirdLevelQuality, entity.ThirdLevelQuality));
                }
                else
                {
                    if (fields.Contains(TCreatureQualityProperties.FirstLevelQuality))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.FirstLevelQuality, entity.FirstLevelQuality));
                    }
                    if (fields.Contains(TCreatureQualityProperties.SecondLevelQuality))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.SecondLevelQuality, entity.SecondLevelQuality));
                    }
                    if (fields.Contains(TCreatureQualityProperties.ThirdLevelQuality))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureQualityProperties.ThirdLevelQuality, entity.ThirdLevelQuality));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TCreatureQuality>(session, query);
        }
        #endregion
        #region 读
        public static TCreatureQuality DbSelect(this TCreatureQuality entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TCreatureQualityProperties.CreatureId);
                builder.ComponentSelect.Add(TCreatureQualityProperties.FirstLevelQuality);
                builder.ComponentSelect.Add(TCreatureQualityProperties.SecondLevelQuality);
                builder.ComponentSelect.Add(TCreatureQualityProperties.ThirdLevelQuality);
            }
            else
            {
                builder.ComponentSelect.Add(TCreatureQualityProperties.CreatureId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureQualityProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TCreatureQuality>(session, query);
        }
        public static List<TCreatureQuality> DbSelect(this List<TCreatureQuality> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TCreatureQualityProperties.CreatureId);
                builder.ComponentSelect.Add(TCreatureQualityProperties.FirstLevelQuality);
                builder.ComponentSelect.Add(TCreatureQualityProperties.SecondLevelQuality);
                builder.ComponentSelect.Add(TCreatureQualityProperties.ThirdLevelQuality);
            }
            else
            {
                builder.ComponentSelect.Add(TCreatureQualityProperties.CreatureId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.CreatureId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureQualityProperties.CreatureId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TCreatureQuality>(session, query);
        }
        public static void DbLoad(this TCreatureQuality entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TCreatureQualityProperties.FirstLevelQuality))
            {
                entity.FirstLevelQuality = result.FirstLevelQuality;
            }
            if (fields.Contains(TCreatureQualityProperties.SecondLevelQuality))
            {
                entity.SecondLevelQuality = result.SecondLevelQuality;
            }
            if (fields.Contains(TCreatureQualityProperties.ThirdLevelQuality))
            {
                entity.ThirdLevelQuality = result.ThirdLevelQuality;
            }
        }
        public static void DbLoad(this List<TCreatureQuality> entities, DbSession session, params PDMDbProperty[] fields)
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
