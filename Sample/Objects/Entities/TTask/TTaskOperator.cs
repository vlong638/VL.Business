using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace TODOTask.Objects.Entities
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TTask entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTaskProperties.TaskId, OperatorType.Equal, entity.TaskId));
            return IORMProvider.GetQueryOperator(session).Delete<TTask>(session, query);
        }
        public static bool DbDelete(this List<TTask> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.TaskId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTaskProperties.TaskId, OperatorType.In, Ids));
            return IORMProvider.GetQueryOperator(session).Delete<TTask>(session, query);
        }
        public static bool DbInsert(this TTask entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.TaskId, entity.TaskId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.What, entity.What));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.Where, entity.Where));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.Who, entity.Who));
            if (entity.WhenToStart.HasValue)
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenToStart, entity.WhenToStart.Value));
            }
            if (entity.WhenToEnd.HasValue)
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenToEnd, entity.WhenToEnd.Value));
            }
            if (entity.WhenStart.HasValue)
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenStart, entity.WhenStart.Value));
            }
            if (entity.WhenEnd.HasValue)
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenEnd, entity.WhenEnd.Value));
            }
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.DealStatus, entity.DealStatus));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TTask>(session, query);
        }
        public static bool DbInsert(this List<TTask> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.TaskId, entity.TaskId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.What, entity.What));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.Where, entity.Where));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.Who, entity.Who));
                if (entity.WhenToStart.HasValue)
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenToStart, entity.WhenToStart.Value));
                }
                if (entity.WhenToEnd.HasValue)
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenToEnd, entity.WhenToEnd.Value));
                }
                if (entity.WhenStart.HasValue)
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenStart, entity.WhenStart.Value));
                }
                if (entity.WhenEnd.HasValue)
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenEnd, entity.WhenEnd.Value));
                }
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.DealStatus, entity.DealStatus));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TTask>(session, query);
        }
        public static bool DbUpdate(this TTask entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTaskProperties.TaskId, OperatorType.Equal, entity.TaskId));
            if (fields.Contains(TTaskProperties.What.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.What, entity.What));
            }
            if (fields.Contains(TTaskProperties.Where.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.Where, entity.Where));
            }
            if (fields.Contains(TTaskProperties.Who.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.Who, entity.Who));
            }
            if (fields.Contains(TTaskProperties.WhenToStart.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenToStart, entity.WhenToStart));
            }
            if (fields.Contains(TTaskProperties.WhenToEnd.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenToEnd, entity.WhenToEnd));
            }
            if (fields.Contains(TTaskProperties.WhenStart.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenStart, entity.WhenStart));
            }
            if (fields.Contains(TTaskProperties.WhenEnd.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenEnd, entity.WhenEnd));
            }
            if (fields.Contains(TTaskProperties.DealStatus.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.DealStatus, entity.DealStatus));
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TTask>(session, query);
        }
        public static bool DbUpdate(this List<TTask> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTaskProperties.TaskId, OperatorType.Equal, entity.TaskId));
                if (fields.Contains(TTaskProperties.What.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.What, entity.What));
                }
                if (fields.Contains(TTaskProperties.Where.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.Where, entity.Where));
                }
                if (fields.Contains(TTaskProperties.Who.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.Who, entity.Who));
                }
                if (fields.Contains(TTaskProperties.WhenToStart.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenToStart, entity.WhenToStart));
                }
                if (fields.Contains(TTaskProperties.WhenToEnd.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenToEnd, entity.WhenToEnd));
                }
                if (fields.Contains(TTaskProperties.WhenStart.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenStart, entity.WhenStart));
                }
                if (fields.Contains(TTaskProperties.WhenEnd.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.WhenEnd, entity.WhenEnd));
                }
                if (fields.Contains(TTaskProperties.DealStatus.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTaskProperties.DealStatus, entity.DealStatus));
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TTask>(session, query);
        }
        #endregion
        #region 读
        public static TTask DbSelect(this TTask entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTaskProperties.TaskId, OperatorType.Equal, entity.TaskId));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TTask>(session, query);
        }
        public static List<TTask> DbSelect(this List<TTask> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            var Ids = entities.Select(c =>c.TaskId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTaskProperties.TaskId, OperatorType.In, Ids));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TTask>(session, query);
        }
        #endregion
        #endregion
    }
}
