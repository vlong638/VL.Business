using System;
using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace VL.Spider.Objects.Objects.Entities
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TGrabList entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabListProperties.IssueTime, entity.IssueTime, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabListProperties.OrderNumber, entity.OrderNumber, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TGrabList>(session, query);
        }
        public static bool DbDelete(this List<TGrabList> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.IssueTime );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabListProperties.IssueTime, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TGrabList>(session, query);
        }
        public static bool DbInsert(this TGrabList entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabListProperties.SpiderId, entity.SpiderId));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabListProperties.IssueTime, entity.IssueTime));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabListProperties.OrderNumber, entity.OrderNumber));
            if (entity.Title == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Title));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabListProperties.Title, entity.Title));
            if (entity.URL == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.URL));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabListProperties.URL, entity.URL));
            if (entity.Remark == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Remark));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabListProperties.Remark, entity.Remark));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TGrabList>(session, query);
        }
        public static bool DbInsert(this List<TGrabList> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabListProperties.SpiderId, entity.SpiderId));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabListProperties.IssueTime, entity.IssueTime));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabListProperties.OrderNumber, entity.OrderNumber));
            if (entity.Title == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Title));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabListProperties.Title, entity.Title));
            if (entity.URL == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.URL));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabListProperties.URL, entity.URL));
            if (entity.Remark == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Remark));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabListProperties.Remark, entity.Remark));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TGrabList>(session, query);
        }
        public static bool DbUpdate(this TGrabList entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabListProperties.IssueTime, entity.IssueTime, LocateType.Equal));
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabListProperties.OrderNumber, entity.OrderNumber, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.SpiderId, entity.SpiderId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.IssueTime, entity.IssueTime));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.OrderNumber, entity.OrderNumber));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.Title, entity.Title));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.URL, entity.URL));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.Remark, entity.Remark));
            }
            else
            {
                if (fields.Contains(TGrabListProperties.SpiderId))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.SpiderId, entity.SpiderId));
                }
                if (fields.Contains(TGrabListProperties.Title))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.Title, entity.Title));
                }
                if (fields.Contains(TGrabListProperties.URL))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.URL, entity.URL));
                }
                if (fields.Contains(TGrabListProperties.Remark))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.Remark, entity.Remark));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TGrabList>(session, query);
        }
        public static bool DbUpdate(this List<TGrabList> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabListProperties.IssueTime, entity.IssueTime, LocateType.Equal));
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabListProperties.OrderNumber, entity.OrderNumber, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.SpiderId, entity.SpiderId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.IssueTime, entity.IssueTime));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.OrderNumber, entity.OrderNumber));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.Title, entity.Title));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.URL, entity.URL));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.Remark, entity.Remark));
                }
                else
                {
                    if (fields.Contains(TGrabListProperties.SpiderId))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.SpiderId, entity.SpiderId));
                    }
                    if (fields.Contains(TGrabListProperties.Title))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.Title, entity.Title));
                    }
                    if (fields.Contains(TGrabListProperties.URL))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.URL, entity.URL));
                    }
                    if (fields.Contains(TGrabListProperties.Remark))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabListProperties.Remark, entity.Remark));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TGrabList>(session, query);
        }
        #endregion
        #region 读
        public static TGrabList DbSelect(this TGrabList entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TGrabListProperties.SpiderId);
                builder.ComponentSelect.Values.Add(TGrabListProperties.IssueTime);
                builder.ComponentSelect.Values.Add(TGrabListProperties.OrderNumber);
                builder.ComponentSelect.Values.Add(TGrabListProperties.Title);
                builder.ComponentSelect.Values.Add(TGrabListProperties.URL);
                builder.ComponentSelect.Values.Add(TGrabListProperties.Remark);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TGrabListProperties.IssueTime);
                builder.ComponentSelect.Values.Add(TGrabListProperties.OrderNumber);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabListProperties.IssueTime, entity.IssueTime, LocateType.Equal));
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabListProperties.OrderNumber, entity.OrderNumber, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TGrabList>(session, query);
        }
        public static List<TGrabList> DbSelect(this List<TGrabList> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TGrabListProperties.SpiderId);
                builder.ComponentSelect.Values.Add(TGrabListProperties.IssueTime);
                builder.ComponentSelect.Values.Add(TGrabListProperties.OrderNumber);
                builder.ComponentSelect.Values.Add(TGrabListProperties.Title);
                builder.ComponentSelect.Values.Add(TGrabListProperties.URL);
                builder.ComponentSelect.Values.Add(TGrabListProperties.Remark);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TGrabListProperties.IssueTime);
                builder.ComponentSelect.Values.Add(TGrabListProperties.OrderNumber);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.IssueTime );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabListProperties.IssueTime, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TGrabList>(session, query);
        }
        public static void DbLoad(this TGrabList entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TGrabListProperties.SpiderId))
            {
                entity.SpiderId = result.SpiderId;
            }
            if (fields.Contains(TGrabListProperties.Title))
            {
                entity.Title = result.Title;
            }
            if (fields.Contains(TGrabListProperties.URL))
            {
                entity.URL = result.URL;
            }
            if (fields.Contains(TGrabListProperties.Remark))
            {
                entity.Remark = result.Remark;
            }
        }
        public static void DbLoad(this List<TGrabList> entities, DbSession session, params PDMDbProperty[] fields)
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
