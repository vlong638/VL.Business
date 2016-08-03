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
        //public static bool DbDelete(this TSubtask entity, DbSession session)
        //{
        //    var query = IORMProvider.GetDbQueryBuilder(session);
        //    query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TSubtaskProperties.TaskId, OperatorType.Equal, entity.TaskId));
        //    return IORMProvider.GetQueryOperator(session).Delete<TSubtask>(session, query);
        //}
        //public static bool DbDelete(this List<TSubtask> entities, DbSession session)
        //{
        //    var query = IORMProvider.GetDbQueryBuilder(session);
        //    var Ids = entities.Select(c =>c.TaskId );
        //    query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TSubtaskProperties.TaskId, OperatorType.In, Ids));
        //    return IORMProvider.GetQueryOperator(session).Delete<TSubtask>(session, query);
        //}
        //public static bool DbInsert(this TSubtask entity, DbSession session)
        //{
        //    var query = IORMProvider.GetDbQueryBuilder(session);
        //    InsertBuilder builder = new InsertBuilder();
        //    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.TaskId, entity.TaskId));
        //    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.What, entity.What));
        //    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.Where, entity.Where));
        //    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.Who, entity.Who));
        //    if (entity.WhenToStart.HasValue)
        //    {
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenToStart, entity.WhenToStart.Value));
        //    }
        //    if (entity.WhenToEnd.HasValue)
        //    {
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenToEnd, entity.WhenToEnd.Value));
        //    }
        //    if (entity.WhenStart.HasValue)
        //    {
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenStart, entity.WhenStart.Value));
        //    }
        //    if (entity.WhenEnd.HasValue)
        //    {
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenEnd, entity.WhenEnd.Value));
        //    }
        //    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.DealStatus, entity.DealStatus));
        //    query.InsertBuilders.Add(builder);
        //    return IORMProvider.GetQueryOperator(session).Insert<TSubtask>(session, query);
        //}
        //public static bool DbInsert(this List<TSubtask> entities, DbSession session)
        //{
        //    var query = IORMProvider.GetDbQueryBuilder(session);
        //    foreach (var entity in entities)
        //    {
        //        InsertBuilder builder = new InsertBuilder();
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.TaskId, entity.TaskId));
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.What, entity.What));
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.Where, entity.Where));
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.Who, entity.Who));
        //        if (entity.WhenToStart.HasValue)
        //        {
        //            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenToStart, entity.WhenToStart.Value));
        //        }
        //        if (entity.WhenToEnd.HasValue)
        //        {
        //            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenToEnd, entity.WhenToEnd.Value));
        //        }
        //        if (entity.WhenStart.HasValue)
        //        {
        //            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenStart, entity.WhenStart.Value));
        //        }
        //        if (entity.WhenEnd.HasValue)
        //        {
        //            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenEnd, entity.WhenEnd.Value));
        //        }
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.DealStatus, entity.DealStatus));
        //        query.InsertBuilders.Add(builder);
        //    }
        //    return IORMProvider.GetQueryOperator(session).InsertAll<TSubtask>(session, query);
        //}
        //public static bool DbUpdate(this TSubtask entity, DbSession session, params string[] fields)
        //{
        //    var query = IORMProvider.GetDbQueryBuilder(session);
        //    UpdateBuilder builder = new UpdateBuilder();
        //    builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TSubtaskProperties.TaskId, OperatorType.Equal, entity.TaskId));
        //    if (fields.Contains(TSubtaskProperties.What.Title))
        //    {
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.What, entity.What));
        //    }
        //    if (fields.Contains(TSubtaskProperties.Where.Title))
        //    {
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.Where, entity.Where));
        //    }
        //    if (fields.Contains(TSubtaskProperties.Who.Title))
        //    {
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.Who, entity.Who));
        //    }
        //    if (fields.Contains(TSubtaskProperties.WhenToStart.Title))
        //    {
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenToStart, entity.WhenToStart));
        //    }
        //    if (fields.Contains(TSubtaskProperties.WhenToEnd.Title))
        //    {
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenToEnd, entity.WhenToEnd));
        //    }
        //    if (fields.Contains(TSubtaskProperties.WhenStart.Title))
        //    {
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenStart, entity.WhenStart));
        //    }
        //    if (fields.Contains(TSubtaskProperties.WhenEnd.Title))
        //    {
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenEnd, entity.WhenEnd));
        //    }
        //    if (fields.Contains(TSubtaskProperties.DealStatus.Title))
        //    {
        //        builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.DealStatus, entity.DealStatus));
        //    }
        //    query.UpdateBuilders.Add(builder);
        //    return IORMProvider.GetQueryOperator(session).Update<TSubtask>(session, query);
        //}
        //public static bool DbUpdate(this List<TSubtask> entities, DbSession session, params string[] fields)
        //{
        //    var query = IORMProvider.GetDbQueryBuilder(session);
        //    foreach (var entity in entities)
        //    {
        //        UpdateBuilder builder = new UpdateBuilder();
        //        builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TSubtaskProperties.TaskId, OperatorType.Equal, entity.TaskId));
        //        if (fields.Contains(TSubtaskProperties.What.Title))
        //        {
        //            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.What, entity.What));
        //        }
        //        if (fields.Contains(TSubtaskProperties.Where.Title))
        //        {
        //            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.Where, entity.Where));
        //        }
        //        if (fields.Contains(TSubtaskProperties.Who.Title))
        //        {
        //            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.Who, entity.Who));
        //        }
        //        if (fields.Contains(TSubtaskProperties.WhenToStart.Title))
        //        {
        //            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenToStart, entity.WhenToStart));
        //        }
        //        if (fields.Contains(TSubtaskProperties.WhenToEnd.Title))
        //        {
        //            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenToEnd, entity.WhenToEnd));
        //        }
        //        if (fields.Contains(TSubtaskProperties.WhenStart.Title))
        //        {
        //            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenStart, entity.WhenStart));
        //        }
        //        if (fields.Contains(TSubtaskProperties.WhenEnd.Title))
        //        {
        //            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.WhenEnd, entity.WhenEnd));
        //        }
        //        if (fields.Contains(TSubtaskProperties.DealStatus.Title))
        //        {
        //            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TSubtaskProperties.DealStatus, entity.DealStatus));
        //        }
        //        query.UpdateBuilders.Add(builder);
        //    }
        //    return IORMProvider.GetQueryOperator(session).UpdateAll<TSubtask>(session, query);
        //}
        #endregion
        #region 读
        //public static TSubtask DbSelect(this TSubtask entity, DbSession session, params string[] fields)
        //{
        //    var query = IORMProvider.GetDbQueryBuilder(session);
        //    SelectBuilder builder = new SelectBuilder();
        //    foreach (var field in fields)
        //    {
        //        builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
        //    }
        //    builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TSubtaskProperties.TaskId, OperatorType.Equal, entity.TaskId));
        //    query.SelectBuilders.Add(builder);
        //    return IORMProvider.GetQueryOperator(session).Select<TSubtask>(session, query);
        //}
        //public static List<TSubtask> DbSelect(this List<TSubtask> entities, DbSession session, params string[] fields)
        //{
        //    var query = IORMProvider.GetDbQueryBuilder(session);
        //    SelectBuilder builder = new SelectBuilder();
        //    foreach (var field in fields)
        //    {
        //        builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
        //    }
        //    var Ids = entities.Select(c =>c.TaskId );
        //    if (Ids.Count() != 0)
        //    {
        //        builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TSubtaskProperties.TaskId, OperatorType.In, Ids));
        //    }
        //    query.SelectBuilders.Add(builder);
        //    return IORMProvider.GetQueryOperator(session).SelectAll<TSubtask>(session, query);
        //}
        #endregion
        #endregion
    }
}
