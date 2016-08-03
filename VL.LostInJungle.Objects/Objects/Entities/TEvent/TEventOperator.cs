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
        public static bool DbDelete(this TEvent entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TEventProperties.EventId, entity.EventId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TEvent>(session, query);
        }
        public static bool DbDelete(this List<TEvent> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.EventId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TEventProperties.EventId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TEvent>(session, query);
        }
        public static bool DbInsert(this TEvent entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TEventProperties.AreaId, entity.AreaId));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TEventProperties.EventId, entity.EventId));
            if (entity.Occurrence == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Occurrence));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TEventProperties.Occurrence, entity.Occurrence));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TEvent>(session, query);
        }
        public static bool DbInsert(this List<TEvent> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TEventProperties.AreaId, entity.AreaId));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TEventProperties.EventId, entity.EventId));
            if (entity.Occurrence == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Occurrence));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TEventProperties.Occurrence, entity.Occurrence));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TEvent>(session, query);
        }
        public static bool DbUpdate(this TEvent entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TEventProperties.EventId, entity.EventId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TEventProperties.AreaId, entity.AreaId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TEventProperties.EventId, entity.EventId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TEventProperties.Occurrence, entity.Occurrence));
            }
            else
            {
                if (fields.Contains(TEventProperties.AreaId))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TEventProperties.AreaId, entity.AreaId));
                }
                if (fields.Contains(TEventProperties.Occurrence))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TEventProperties.Occurrence, entity.Occurrence));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TEvent>(session, query);
        }
        public static bool DbUpdate(this List<TEvent> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TEventProperties.EventId, entity.EventId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TEventProperties.AreaId, entity.AreaId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TEventProperties.EventId, entity.EventId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TEventProperties.Occurrence, entity.Occurrence));
                }
                else
                {
                    if (fields.Contains(TEventProperties.AreaId))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TEventProperties.AreaId, entity.AreaId));
                    }
                    if (fields.Contains(TEventProperties.Occurrence))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TEventProperties.Occurrence, entity.Occurrence));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TEvent>(session, query);
        }
        #endregion
        #region 读
        public static TEvent DbSelect(this TEvent entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TEventProperties.AreaId);
                builder.ComponentSelect.Values.Add(TEventProperties.EventId);
                builder.ComponentSelect.Values.Add(TEventProperties.Occurrence);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TEventProperties.EventId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TEventProperties.EventId, entity.EventId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TEvent>(session, query);
        }
        public static List<TEvent> DbSelect(this List<TEvent> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TEventProperties.AreaId);
                builder.ComponentSelect.Values.Add(TEventProperties.EventId);
                builder.ComponentSelect.Values.Add(TEventProperties.Occurrence);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TEventProperties.EventId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.EventId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TEventProperties.EventId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TEvent>(session, query);
        }
        public static void DbLoad(this TEvent entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TEventProperties.AreaId))
            {
                entity.AreaId = result.AreaId;
            }
            if (fields.Contains(TEventProperties.Occurrence))
            {
                entity.Occurrence = result.Occurrence;
            }
        }
        public static void DbLoad(this List<TEvent> entities, DbSession session, params PDMDbProperty[] fields)
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
