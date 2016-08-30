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
        public static bool DbDelete(this TGrabRequest entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabRequestProperties.RequestId, entity.RequestId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TGrabRequest>(session, query);
        }
        public static bool DbDelete(this List<TGrabRequest> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.RequestId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabRequestProperties.RequestId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TGrabRequest>(session, query);
        }
        public static bool DbInsert(this TGrabRequest entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabRequestProperties.RequestId, entity.RequestId));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabRequestProperties.SpiderId, entity.SpiderId));
            if (entity.GrabType == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.GrabType));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabRequestProperties.GrabType, entity.GrabType));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabRequestProperties.IssueTime, entity.IssueTime));
            if (entity.SpiderName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.SpiderName));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabRequestProperties.SpiderName, entity.SpiderName));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabRequestProperties.IsSuccess, entity.IsSuccess));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TGrabRequest>(session, query);
        }
        public static bool DbInsert(this List<TGrabRequest> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabRequestProperties.RequestId, entity.RequestId));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabRequestProperties.SpiderId, entity.SpiderId));
            if (entity.GrabType == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.GrabType));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabRequestProperties.GrabType, entity.GrabType));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabRequestProperties.IssueTime, entity.IssueTime));
            if (entity.SpiderName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.SpiderName));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabRequestProperties.SpiderName, entity.SpiderName));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TGrabRequestProperties.IsSuccess, entity.IsSuccess));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TGrabRequest>(session, query);
        }
        public static bool DbUpdate(this TGrabRequest entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabRequestProperties.RequestId, entity.RequestId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.RequestId, entity.RequestId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderId, entity.SpiderId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.GrabType, entity.GrabType));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.IssueTime, entity.IssueTime));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderName, entity.SpiderName));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.IsSuccess, entity.IsSuccess));
            }
            else
            {
                if (fields.Contains(TGrabRequestProperties.SpiderId))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderId, entity.SpiderId));
                }
                if (fields.Contains(TGrabRequestProperties.GrabType))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.GrabType, entity.GrabType));
                }
                if (fields.Contains(TGrabRequestProperties.IssueTime))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.IssueTime, entity.IssueTime));
                }
                if (fields.Contains(TGrabRequestProperties.SpiderName))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderName, entity.SpiderName));
                }
                if (fields.Contains(TGrabRequestProperties.IsSuccess))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.IsSuccess, entity.IsSuccess));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TGrabRequest>(session, query);
        }
        public static bool DbUpdate(this List<TGrabRequest> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabRequestProperties.RequestId, entity.RequestId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.RequestId, entity.RequestId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderId, entity.SpiderId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.GrabType, entity.GrabType));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.IssueTime, entity.IssueTime));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderName, entity.SpiderName));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.IsSuccess, entity.IsSuccess));
                }
                else
                {
                    if (fields.Contains(TGrabRequestProperties.SpiderId))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderId, entity.SpiderId));
                    }
                    if (fields.Contains(TGrabRequestProperties.GrabType))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.GrabType, entity.GrabType));
                    }
                    if (fields.Contains(TGrabRequestProperties.IssueTime))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.IssueTime, entity.IssueTime));
                    }
                    if (fields.Contains(TGrabRequestProperties.SpiderName))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderName, entity.SpiderName));
                    }
                    if (fields.Contains(TGrabRequestProperties.IsSuccess))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TGrabRequestProperties.IsSuccess, entity.IsSuccess));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TGrabRequest>(session, query);
        }
        #endregion
        #region 读
        public static TGrabRequest DbSelect(this TGrabRequest entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.RequestId);
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.SpiderId);
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.GrabType);
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.IssueTime);
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.SpiderName);
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.IsSuccess);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.RequestId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabRequestProperties.RequestId, entity.RequestId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TGrabRequest>(session, query);
        }
        public static List<TGrabRequest> DbSelect(this List<TGrabRequest> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.RequestId);
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.SpiderId);
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.GrabType);
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.IssueTime);
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.SpiderName);
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.IsSuccess);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TGrabRequestProperties.RequestId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.RequestId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TGrabRequestProperties.RequestId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TGrabRequest>(session, query);
        }
        public static void DbLoad(this TGrabRequest entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TGrabRequestProperties.SpiderId))
            {
                entity.SpiderId = result.SpiderId;
            }
            if (fields.Contains(TGrabRequestProperties.GrabType))
            {
                entity.GrabType = result.GrabType;
            }
            if (fields.Contains(TGrabRequestProperties.IssueTime))
            {
                entity.IssueTime = result.IssueTime;
            }
            if (fields.Contains(TGrabRequestProperties.SpiderName))
            {
                entity.SpiderName = result.SpiderName;
            }
            if (fields.Contains(TGrabRequestProperties.IsSuccess))
            {
                entity.IsSuccess = result.IsSuccess;
            }
        }
        public static void DbLoad(this List<TGrabRequest> entities, DbSession session, params PDMDbProperty[] fields)
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
