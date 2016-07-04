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
        public static bool DbDelete(this TAreaEvent entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.AreaId, OperatorType.Equal, entity.AreaId));
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.EventId, OperatorType.Equal, entity.EventId));
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.RoundNum, OperatorType.Equal, entity.RoundNum));
            return IORMProvider.GetQueryOperator(session).Delete<TAreaEvent>(session, query);
        }
        public static bool DbDelete(this List<TAreaEvent> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.AreaId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.AreaId, OperatorType.In, Ids));
            return IORMProvider.GetQueryOperator(session).Delete<TAreaEvent>(session, query);
        }
        public static bool DbInsert(this TAreaEvent entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaEventProperties.AreaId, entity.AreaId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaEventProperties.EventId, entity.EventId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaEventProperties.RoundNum, entity.RoundNum));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TAreaEvent>(session, query);
        }
        public static bool DbInsert(this List<TAreaEvent> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaEventProperties.AreaId, entity.AreaId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaEventProperties.EventId, entity.EventId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaEventProperties.RoundNum, entity.RoundNum));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TAreaEvent>(session, query);
        }
        public static bool DbUpdate(this TAreaEvent entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.AreaId, OperatorType.Equal, entity.AreaId));
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.EventId, OperatorType.Equal, entity.EventId));
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.RoundNum, OperatorType.Equal, entity.RoundNum));
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TAreaEvent>(session, query);
        }
        public static bool DbUpdate(this List<TAreaEvent> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.AreaId, OperatorType.Equal, entity.AreaId));
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.EventId, OperatorType.Equal, entity.EventId));
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.RoundNum, OperatorType.Equal, entity.RoundNum));
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TAreaEvent>(session, query);
        }
        #endregion
        #region 读
        public static TAreaEvent DbSelect(this TAreaEvent entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.AreaId, OperatorType.Equal, entity.AreaId));
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.EventId, OperatorType.Equal, entity.EventId));
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.RoundNum, OperatorType.Equal, entity.RoundNum));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TAreaEvent>(session, query);
        }
        public static List<TAreaEvent> DbSelect(this List<TAreaEvent> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            var Ids = entities.Select(c =>c.AreaId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaEventProperties.AreaId, OperatorType.In, Ids));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TAreaEvent>(session, query);
        }
        #endregion
        #endregion
    }
}
