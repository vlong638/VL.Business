using System;
using System.Collections.Generic;
using System.Linq;
using VL.Common.Core.DAS;
using VL.Common.Core.ORM;
using VL.Common.Core.Protocol;
using VL.Common.Core.Object.Subsidence;

namespace Subsidence.Business
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TEarthworkBlocking entity, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockingProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            return session.GetQueryOperator().Delete<TEarthworkBlocking>(query);
        }
        public static bool DbDelete(this List<TEarthworkBlocking> entities, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            var Ids = entities.Select(c =>c.IssueDateTime );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockingProperties.IssueDateTime, Ids, LocateType.In));
            return session.GetQueryOperator().Delete<TEarthworkBlocking>(query);
        }
        public static bool DbInsert(this TEarthworkBlocking entity, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockingProperties.IssueDateTime, entity.IssueDateTime));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockingProperties.EarthworkBlockMaxId, entity.EarthworkBlockMaxId));
            if (entity.ColorForUnsettled == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ColorForUnsettled));
            }
            if (entity.ColorForUnsettled.Length > 20)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ColorForUnsettled), entity.ColorForUnsettled.Length, 20));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockingProperties.ColorForUnsettled, entity.ColorForUnsettled));
            if (entity.ColorForSettled == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ColorForSettled));
            }
            if (entity.ColorForSettled.Length > 20)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ColorForSettled), entity.ColorForSettled.Length, 20));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockingProperties.ColorForSettled, entity.ColorForSettled));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockingProperties.IsImplementationInfoConflicted, entity.IsImplementationInfoConflicted));
            query.InsertBuilders.Add(builder);
            return session.GetQueryOperator().Insert<TEarthworkBlocking>(query);
        }
        public static bool DbInsert(this List<TEarthworkBlocking> entities, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockingProperties.IssueDateTime, entity.IssueDateTime));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockingProperties.EarthworkBlockMaxId, entity.EarthworkBlockMaxId));
            if (entity.ColorForUnsettled == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ColorForUnsettled));
            }
            if (entity.ColorForUnsettled.Length > 20)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ColorForUnsettled), entity.ColorForUnsettled.Length, 20));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockingProperties.ColorForUnsettled, entity.ColorForUnsettled));
            if (entity.ColorForSettled == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ColorForSettled));
            }
            if (entity.ColorForSettled.Length > 20)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ColorForSettled), entity.ColorForSettled.Length, 20));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockingProperties.ColorForSettled, entity.ColorForSettled));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockingProperties.IsImplementationInfoConflicted, entity.IsImplementationInfoConflicted));
                query.InsertBuilders.Add(builder);
            }
            return session.GetQueryOperator().InsertAll<TEarthworkBlocking>(query);
        }
        public static bool DbUpdate(this TEarthworkBlocking entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockingProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.EarthworkBlockMaxId, entity.EarthworkBlockMaxId));
                builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.ColorForUnsettled, entity.ColorForUnsettled));
                builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.ColorForSettled, entity.ColorForSettled));
                builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.IsImplementationInfoConflicted, entity.IsImplementationInfoConflicted));
            }
            else
            {
                if (fields.Contains(TEarthworkBlockingProperties.EarthworkBlockMaxId))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.EarthworkBlockMaxId, entity.EarthworkBlockMaxId));
                }
                if (fields.Contains(TEarthworkBlockingProperties.ColorForUnsettled))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.ColorForUnsettled, entity.ColorForUnsettled));
                }
                if (fields.Contains(TEarthworkBlockingProperties.ColorForSettled))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.ColorForSettled, entity.ColorForSettled));
                }
                if (fields.Contains(TEarthworkBlockingProperties.IsImplementationInfoConflicted))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.IsImplementationInfoConflicted, entity.IsImplementationInfoConflicted));
                }
            }
            query.UpdateBuilders.Add(builder);
            return session.GetQueryOperator().Update<TEarthworkBlocking>(query);
        }
        public static bool DbUpdate(this List<TEarthworkBlocking> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockingProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.EarthworkBlockMaxId, entity.EarthworkBlockMaxId));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.ColorForUnsettled, entity.ColorForUnsettled));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.ColorForSettled, entity.ColorForSettled));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.IsImplementationInfoConflicted, entity.IsImplementationInfoConflicted));
                }
                else
                {
                    if (fields.Contains(TEarthworkBlockingProperties.EarthworkBlockMaxId))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.EarthworkBlockMaxId, entity.EarthworkBlockMaxId));
                    }
                    if (fields.Contains(TEarthworkBlockingProperties.ColorForUnsettled))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.ColorForUnsettled, entity.ColorForUnsettled));
                    }
                    if (fields.Contains(TEarthworkBlockingProperties.ColorForSettled))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.ColorForSettled, entity.ColorForSettled));
                    }
                    if (fields.Contains(TEarthworkBlockingProperties.IsImplementationInfoConflicted))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockingProperties.IsImplementationInfoConflicted, entity.IsImplementationInfoConflicted));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return session.GetQueryOperator().UpdateAll<TEarthworkBlocking>(query);
        }
        #endregion
        #region 读
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TEarthworkBlocking DbSelect(this TEarthworkBlocking entity, DbSession session, SelectBuilder select)
        {
            var query = session.GetDbQueryBuilder();
            query.SelectBuilder = select;
            return session.GetQueryOperator().Select<TEarthworkBlocking>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TEarthworkBlocking DbSelect(this TEarthworkBlocking entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TEarthworkBlockingProperties.IssueDateTime);
                builder.ComponentSelect.Add(TEarthworkBlockingProperties.EarthworkBlockMaxId);
                builder.ComponentSelect.Add(TEarthworkBlockingProperties.ColorForUnsettled);
                builder.ComponentSelect.Add(TEarthworkBlockingProperties.ColorForSettled);
                builder.ComponentSelect.Add(TEarthworkBlockingProperties.IsImplementationInfoConflicted);
            }
            else
            {
                builder.ComponentSelect.Add(TEarthworkBlockingProperties.IssueDateTime);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockingProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().Select<TEarthworkBlocking>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 new List<T>()
        /// </summary>
        public static List<TEarthworkBlocking> DbSelect(this List<TEarthworkBlocking> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TEarthworkBlockingProperties.IssueDateTime);
                builder.ComponentSelect.Add(TEarthworkBlockingProperties.EarthworkBlockMaxId);
                builder.ComponentSelect.Add(TEarthworkBlockingProperties.ColorForUnsettled);
                builder.ComponentSelect.Add(TEarthworkBlockingProperties.ColorForSettled);
                builder.ComponentSelect.Add(TEarthworkBlockingProperties.IsImplementationInfoConflicted);
            }
            else
            {
                builder.ComponentSelect.Add(TEarthworkBlockingProperties.IssueDateTime);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.IssueDateTime );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockingProperties.IssueDateTime, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().SelectAll<TEarthworkBlocking>(query);
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this TEarthworkBlocking entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (result == null)
            {
                return false;
            }
            if (fields.Count() == 0)
            {
                entity.EarthworkBlockMaxId = result.EarthworkBlockMaxId;
                entity.ColorForUnsettled = result.ColorForUnsettled;
                entity.ColorForSettled = result.ColorForSettled;
                entity.IsImplementationInfoConflicted = result.IsImplementationInfoConflicted;
            }
            else
            {
                if (fields.Contains(TEarthworkBlockingProperties.EarthworkBlockMaxId))
                {
                    entity.EarthworkBlockMaxId = result.EarthworkBlockMaxId;
                }
                if (fields.Contains(TEarthworkBlockingProperties.ColorForUnsettled))
                {
                    entity.ColorForUnsettled = result.ColorForUnsettled;
                }
                if (fields.Contains(TEarthworkBlockingProperties.ColorForSettled))
                {
                    entity.ColorForSettled = result.ColorForSettled;
                }
                if (fields.Contains(TEarthworkBlockingProperties.IsImplementationInfoConflicted))
                {
                    entity.IsImplementationInfoConflicted = result.IsImplementationInfoConflicted;
                }
            }
            return true;
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this List<TEarthworkBlocking> entities, DbSession session, params PDMDbProperty[] fields)
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
