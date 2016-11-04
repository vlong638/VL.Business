using System;
using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace VL.Spider.Objects.Entities
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TGrabList entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.SpiderId, entity.SpiderId, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.IssueName, entity.IssueName, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.OrderNumber, entity.OrderNumber, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TGrabList>(session, query);
        }
        public static bool DbDelete(this List<TGrabList> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.SpiderId );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.SpiderId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TGrabList>(session, query);
        }
        public static bool DbInsert(this TGrabList entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.ListItemId, entity.ListItemId));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.SpiderId, entity.SpiderId));
            if (entity.IssueName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.IssueName));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.IssueName, entity.IssueName));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.OrderNumber, entity.OrderNumber));
            if (entity.Title == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Title));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.Title, entity.Title));
            if (entity.URL == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.URL));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.URL, entity.URL));
            if (entity.Remark == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Remark));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.Remark, entity.Remark));
            if (entity.DetailFilePath == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.DetailFilePath));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.DetailFilePath, entity.DetailFilePath));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TGrabList>(session, query);
        }
        public static bool DbInsert(this List<TGrabList> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.ListItemId, entity.ListItemId));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.SpiderId, entity.SpiderId));
            if (entity.IssueName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.IssueName));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.IssueName, entity.IssueName));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.OrderNumber, entity.OrderNumber));
            if (entity.Title == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Title));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.Title, entity.Title));
            if (entity.URL == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.URL));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.URL, entity.URL));
            if (entity.Remark == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Remark));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.Remark, entity.Remark));
            if (entity.DetailFilePath == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.DetailFilePath));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabListProperties.DetailFilePath, entity.DetailFilePath));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TGrabList>(session, query);
        }
        public static bool DbUpdate(this TGrabList entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.SpiderId, entity.SpiderId, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.IssueName, entity.IssueName, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.OrderNumber, entity.OrderNumber, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.ListItemId, entity.ListItemId));
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.SpiderId, entity.SpiderId));
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.IssueName, entity.IssueName));
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.OrderNumber, entity.OrderNumber));
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.Title, entity.Title));
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.URL, entity.URL));
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.Remark, entity.Remark));
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.DetailFilePath, entity.DetailFilePath));
            }
            else
            {
                if (fields.Contains(TGrabListProperties.ListItemId))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.ListItemId, entity.ListItemId));
                }
                if (fields.Contains(TGrabListProperties.Title))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.Title, entity.Title));
                }
                if (fields.Contains(TGrabListProperties.URL))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.URL, entity.URL));
                }
                if (fields.Contains(TGrabListProperties.Remark))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.Remark, entity.Remark));
                }
                if (fields.Contains(TGrabListProperties.DetailFilePath))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.DetailFilePath, entity.DetailFilePath));
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
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.SpiderId, entity.SpiderId, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.IssueName, entity.IssueName, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.OrderNumber, entity.OrderNumber, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.ListItemId, entity.ListItemId));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.SpiderId, entity.SpiderId));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.IssueName, entity.IssueName));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.OrderNumber, entity.OrderNumber));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.Title, entity.Title));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.URL, entity.URL));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.Remark, entity.Remark));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.DetailFilePath, entity.DetailFilePath));
                }
                else
                {
                    if (fields.Contains(TGrabListProperties.ListItemId))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.ListItemId, entity.ListItemId));
                    }
                    if (fields.Contains(TGrabListProperties.Title))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.Title, entity.Title));
                    }
                    if (fields.Contains(TGrabListProperties.URL))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.URL, entity.URL));
                    }
                    if (fields.Contains(TGrabListProperties.Remark))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.Remark, entity.Remark));
                    }
                    if (fields.Contains(TGrabListProperties.DetailFilePath))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TGrabListProperties.DetailFilePath, entity.DetailFilePath));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TGrabList>(session, query);
        }
        #endregion
        #region 读
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TGrabList DbSelect(this TGrabList entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TGrabListProperties.ListItemId);
                builder.ComponentSelect.Add(TGrabListProperties.SpiderId);
                builder.ComponentSelect.Add(TGrabListProperties.IssueName);
                builder.ComponentSelect.Add(TGrabListProperties.OrderNumber);
                builder.ComponentSelect.Add(TGrabListProperties.Title);
                builder.ComponentSelect.Add(TGrabListProperties.URL);
                builder.ComponentSelect.Add(TGrabListProperties.Remark);
                builder.ComponentSelect.Add(TGrabListProperties.DetailFilePath);
            }
            else
            {
                builder.ComponentSelect.Add(TGrabListProperties.SpiderId);
                builder.ComponentSelect.Add(TGrabListProperties.IssueName);
                builder.ComponentSelect.Add(TGrabListProperties.OrderNumber);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.SpiderId, entity.SpiderId, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.IssueName, entity.IssueName, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.OrderNumber, entity.OrderNumber, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TGrabList>(session, query);
        }
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static List<TGrabList> DbSelect(this List<TGrabList> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TGrabListProperties.ListItemId);
                builder.ComponentSelect.Add(TGrabListProperties.SpiderId);
                builder.ComponentSelect.Add(TGrabListProperties.IssueName);
                builder.ComponentSelect.Add(TGrabListProperties.OrderNumber);
                builder.ComponentSelect.Add(TGrabListProperties.Title);
                builder.ComponentSelect.Add(TGrabListProperties.URL);
                builder.ComponentSelect.Add(TGrabListProperties.Remark);
                builder.ComponentSelect.Add(TGrabListProperties.DetailFilePath);
            }
            else
            {
                builder.ComponentSelect.Add(TGrabListProperties.SpiderId);
                builder.ComponentSelect.Add(TGrabListProperties.IssueName);
                builder.ComponentSelect.Add(TGrabListProperties.OrderNumber);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.SpiderId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabListProperties.SpiderId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TGrabList>(session, query);
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this TGrabList entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (result == null)
            {
                return false;
            }
            if (fields.Count() == 0)
            {
                entity.ListItemId = result.ListItemId;
                entity.Title = result.Title;
                entity.URL = result.URL;
                entity.Remark = result.Remark;
                entity.DetailFilePath = result.DetailFilePath;
            }
            else
            {
                if (fields.Contains(TGrabListProperties.ListItemId))
                {
                    entity.ListItemId = result.ListItemId;
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
                if (fields.Contains(TGrabListProperties.DetailFilePath))
                {
                    entity.DetailFilePath = result.DetailFilePath;
                }
            }
            return true;
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this List<TGrabList> entities, DbSession session, params PDMDbProperty[] fields)
        {
            bool result = true;
            foreach (var entity in entities)
            {
                result = result && entity.DbLoad(session, fields);
            }
            return result;
        }
        #endregion
        #endregion
    }
}
