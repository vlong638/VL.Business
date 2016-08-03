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
        public static bool DbDelete(this TAreaEvent entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.AreaId, entity.AreaId, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.EventId, entity.EventId, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.RoundNum, entity.RoundNum, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TAreaEvent>(session, query);
        }
        public static bool DbDelete(this List<TAreaEvent> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.AreaId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.AreaId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TAreaEvent>(session, query);
        }
        public static bool DbInsert(this TAreaEvent entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaEventProperties.AreaId, entity.AreaId));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaEventProperties.EventId, entity.EventId));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaEventProperties.RoundNum, entity.RoundNum));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TAreaEvent>(session, query);
        }
        public static bool DbInsert(this List<TAreaEvent> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaEventProperties.AreaId, entity.AreaId));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaEventProperties.EventId, entity.EventId));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaEventProperties.RoundNum, entity.RoundNum));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TAreaEvent>(session, query);
        }
        public static bool DbUpdate(this TAreaEvent entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.AreaId, entity.AreaId, LocateType.Equal));
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.EventId, entity.EventId, LocateType.Equal));
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.RoundNum, entity.RoundNum, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaEventProperties.AreaId, entity.AreaId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaEventProperties.EventId, entity.EventId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaEventProperties.RoundNum, entity.RoundNum));
            }
            else
            {
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TAreaEvent>(session, query);
        }
        public static bool DbUpdate(this List<TAreaEvent> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.AreaId, entity.AreaId, LocateType.Equal));
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.EventId, entity.EventId, LocateType.Equal));
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.RoundNum, entity.RoundNum, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaEventProperties.AreaId, entity.AreaId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaEventProperties.EventId, entity.EventId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaEventProperties.RoundNum, entity.RoundNum));
                }
                else
                {
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TAreaEvent>(session, query);
        }
        #endregion
        #region 读
        public static TAreaEvent DbSelect(this TAreaEvent entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TAreaEventProperties.AreaId);
                builder.ComponentSelect.Values.Add(TAreaEventProperties.EventId);
                builder.ComponentSelect.Values.Add(TAreaEventProperties.RoundNum);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TAreaEventProperties.AreaId);
                builder.ComponentSelect.Values.Add(TAreaEventProperties.EventId);
                builder.ComponentSelect.Values.Add(TAreaEventProperties.RoundNum);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.AreaId, entity.AreaId, LocateType.Equal));
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.EventId, entity.EventId, LocateType.Equal));
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.RoundNum, entity.RoundNum, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TAreaEvent>(session, query);
        }
        public static List<TAreaEvent> DbSelect(this List<TAreaEvent> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TAreaEventProperties.AreaId);
                builder.ComponentSelect.Values.Add(TAreaEventProperties.EventId);
                builder.ComponentSelect.Values.Add(TAreaEventProperties.RoundNum);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TAreaEventProperties.AreaId);
                builder.ComponentSelect.Values.Add(TAreaEventProperties.EventId);
                builder.ComponentSelect.Values.Add(TAreaEventProperties.RoundNum);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.AreaId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaEventProperties.AreaId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TAreaEvent>(session, query);
        }
        public static void DbLoad(this TAreaEvent entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
        }
        public static void DbLoad(this List<TAreaEvent> entities, DbSession session, params PDMDbProperty[] fields)
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
