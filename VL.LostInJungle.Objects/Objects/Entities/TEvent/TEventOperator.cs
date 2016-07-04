using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
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
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TEventProperties.EventId, OperatorType.Equal, entity.EventId));
            return IORMProvider.GetQueryOperator(session).Delete<TEvent>(session, query);
        }
        public static bool DbDelete(this List<TEvent> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.EventId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TEventProperties.EventId, OperatorType.In, Ids));
            return IORMProvider.GetQueryOperator(session).Delete<TEvent>(session, query);
        }
        public static bool DbInsert(this TEvent entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TEventProperties.AreaId, entity.AreaId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TEventProperties.EventId, entity.EventId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TEventProperties.Occurrence, entity.Occurrence));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TEvent>(session, query);
        }
        public static bool DbInsert(this List<TEvent> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TEventProperties.AreaId, entity.AreaId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TEventProperties.EventId, entity.EventId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TEventProperties.Occurrence, entity.Occurrence));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TEvent>(session, query);
        }
        public static bool DbUpdate(this TEvent entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TEventProperties.EventId, OperatorType.Equal, entity.EventId));
            if (fields.Contains(TEventProperties.AreaId.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TEventProperties.AreaId, entity.AreaId));
            }
            if (fields.Contains(TEventProperties.Occurrence.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TEventProperties.Occurrence, entity.Occurrence));
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TEvent>(session, query);
        }
        public static bool DbUpdate(this List<TEvent> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TEventProperties.EventId, OperatorType.Equal, entity.EventId));
                if (fields.Contains(TEventProperties.AreaId.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TEventProperties.AreaId, entity.AreaId));
                }
                if (fields.Contains(TEventProperties.Occurrence.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TEventProperties.Occurrence, entity.Occurrence));
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TEvent>(session, query);
        }
        #endregion
        #region 读
        public static TEvent DbSelect(this TEvent entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TEventProperties.EventId, OperatorType.Equal, entity.EventId));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TEvent>(session, query);
        }
        public static List<TEvent> DbSelect(this List<TEvent> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            var Ids = entities.Select(c =>c.EventId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TEventProperties.EventId, OperatorType.In, Ids));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TEvent>(session, query);
        }
        #endregion
        #endregion
    }
}
