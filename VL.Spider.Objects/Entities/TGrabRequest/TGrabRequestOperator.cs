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
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.SpiderId, entity.SpiderId, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.GrabType, entity.GrabType, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.IssueName, entity.IssueName, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TGrabRequest>(session, query);
        }
        public static bool DbDelete(this List<TGrabRequest> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.SpiderId );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.SpiderId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TGrabRequest>(session, query);
        }
        public static bool DbInsert(this TGrabRequest entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.RequestId, entity.RequestId));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.SpiderId, entity.SpiderId));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.GrabType, entity.GrabType));
            if (entity.IssueName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.IssueName));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.IssueName, entity.IssueName));
            if (entity.SpiderName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.SpiderName));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.SpiderName, entity.SpiderName));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.ProcessStatus, entity.ProcessStatus));
            if (entity.Message == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Message));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.Message, entity.Message));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TGrabRequest>(session, query);
        }
        public static bool DbInsert(this List<TGrabRequest> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.RequestId, entity.RequestId));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.SpiderId, entity.SpiderId));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.GrabType, entity.GrabType));
            if (entity.IssueName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.IssueName));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.IssueName, entity.IssueName));
            if (entity.SpiderName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.SpiderName));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.SpiderName, entity.SpiderName));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.ProcessStatus, entity.ProcessStatus));
            if (entity.Message == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Message));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TGrabRequestProperties.Message, entity.Message));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TGrabRequest>(session, query);
        }
        public static bool DbUpdate(this TGrabRequest entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.SpiderId, entity.SpiderId, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.GrabType, entity.GrabType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.IssueName, entity.IssueName, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.RequestId, entity.RequestId));
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderId, entity.SpiderId));
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.GrabType, entity.GrabType));
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.IssueName, entity.IssueName));
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderName, entity.SpiderName));
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.ProcessStatus, entity.ProcessStatus));
                builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.Message, entity.Message));
            }
            else
            {
                if (fields.Contains(TGrabRequestProperties.RequestId))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.RequestId, entity.RequestId));
                }
                if (fields.Contains(TGrabRequestProperties.SpiderName))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderName, entity.SpiderName));
                }
                if (fields.Contains(TGrabRequestProperties.ProcessStatus))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.ProcessStatus, entity.ProcessStatus));
                }
                if (fields.Contains(TGrabRequestProperties.Message))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.Message, entity.Message));
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
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.SpiderId, entity.SpiderId, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.GrabType, entity.GrabType, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.IssueName, entity.IssueName, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.RequestId, entity.RequestId));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderId, entity.SpiderId));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.GrabType, entity.GrabType));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.IssueName, entity.IssueName));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderName, entity.SpiderName));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.ProcessStatus, entity.ProcessStatus));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.Message, entity.Message));
                }
                else
                {
                    if (fields.Contains(TGrabRequestProperties.RequestId))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.RequestId, entity.RequestId));
                    }
                    if (fields.Contains(TGrabRequestProperties.SpiderName))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.SpiderName, entity.SpiderName));
                    }
                    if (fields.Contains(TGrabRequestProperties.ProcessStatus))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.ProcessStatus, entity.ProcessStatus));
                    }
                    if (fields.Contains(TGrabRequestProperties.Message))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TGrabRequestProperties.Message, entity.Message));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TGrabRequest>(session, query);
        }
        #endregion
        #region 读
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TGrabRequest DbSelect(this TGrabRequest entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TGrabRequestProperties.RequestId);
                builder.ComponentSelect.Add(TGrabRequestProperties.SpiderId);
                builder.ComponentSelect.Add(TGrabRequestProperties.GrabType);
                builder.ComponentSelect.Add(TGrabRequestProperties.IssueName);
                builder.ComponentSelect.Add(TGrabRequestProperties.SpiderName);
                builder.ComponentSelect.Add(TGrabRequestProperties.ProcessStatus);
                builder.ComponentSelect.Add(TGrabRequestProperties.Message);
            }
            else
            {
                builder.ComponentSelect.Add(TGrabRequestProperties.SpiderId);
                builder.ComponentSelect.Add(TGrabRequestProperties.GrabType);
                builder.ComponentSelect.Add(TGrabRequestProperties.IssueName);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.SpiderId, entity.SpiderId, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.GrabType, entity.GrabType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.IssueName, entity.IssueName, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TGrabRequest>(session, query);
        }
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static List<TGrabRequest> DbSelect(this List<TGrabRequest> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TGrabRequestProperties.RequestId);
                builder.ComponentSelect.Add(TGrabRequestProperties.SpiderId);
                builder.ComponentSelect.Add(TGrabRequestProperties.GrabType);
                builder.ComponentSelect.Add(TGrabRequestProperties.IssueName);
                builder.ComponentSelect.Add(TGrabRequestProperties.SpiderName);
                builder.ComponentSelect.Add(TGrabRequestProperties.ProcessStatus);
                builder.ComponentSelect.Add(TGrabRequestProperties.Message);
            }
            else
            {
                builder.ComponentSelect.Add(TGrabRequestProperties.SpiderId);
                builder.ComponentSelect.Add(TGrabRequestProperties.GrabType);
                builder.ComponentSelect.Add(TGrabRequestProperties.IssueName);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.SpiderId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TGrabRequestProperties.SpiderId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TGrabRequest>(session, query);
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this TGrabRequest entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (result == null)
            {
                return false;
            }
            if (fields.Count() == 0)
            {
                entity.RequestId = result.RequestId;
                entity.SpiderName = result.SpiderName;
                entity.ProcessStatus = result.ProcessStatus;
                entity.Message = result.Message;
            }
            else
            {
                if (fields.Contains(TGrabRequestProperties.RequestId))
                {
                    entity.RequestId = result.RequestId;
                }
                if (fields.Contains(TGrabRequestProperties.SpiderName))
                {
                    entity.SpiderName = result.SpiderName;
                }
                if (fields.Contains(TGrabRequestProperties.ProcessStatus))
                {
                    entity.ProcessStatus = result.ProcessStatus;
                }
                if (fields.Contains(TGrabRequestProperties.Message))
                {
                    entity.Message = result.Message;
                }
            }
            return true;
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this List<TGrabRequest> entities, DbSession session, params PDMDbProperty[] fields)
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
