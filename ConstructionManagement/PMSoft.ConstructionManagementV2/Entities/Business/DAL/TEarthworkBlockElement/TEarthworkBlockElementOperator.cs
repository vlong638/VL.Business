using System;
using System.Collections.Generic;
using System.Linq;
using VL.Common.Core.DAS;
using VL.Common.Core.ORM;
using VL.Common.Core.Protocol;
using PMSoft.ConstructionManagementV2.DomainModel;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TEarthworkBlockElement entity, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.Id, entity.Id, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.GroupId, entity.GroupId, LocateType.Equal));
            return session.GetQueryOperator().Delete<TEarthworkBlockElement>(query);
        }
        public static bool DbDelete(this List<TEarthworkBlockElement> entities, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            var Ids = entities.Select(c =>c.IssueDateTime );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.IssueDateTime, Ids, LocateType.In));
            return session.GetQueryOperator().Delete<TEarthworkBlockElement>(query);
        }
        public static bool DbInsert(this TEarthworkBlockElement entity, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockElementProperties.IssueDateTime, entity.IssueDateTime));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockElementProperties.Id, entity.Id));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockElementProperties.GroupId, entity.GroupId));
            if (entity.ElementIds == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ElementIds));
            }
            if (entity.ElementIds.Length > 1000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ElementIds), entity.ElementIds.Length, 1000));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockElementProperties.ElementIds, entity.ElementIds));
            query.InsertBuilders.Add(builder);
            return session.GetQueryOperator().Insert<TEarthworkBlockElement>(query);
        }
        public static bool DbInsert(this List<TEarthworkBlockElement> entities, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockElementProperties.IssueDateTime, entity.IssueDateTime));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockElementProperties.Id, entity.Id));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockElementProperties.GroupId, entity.GroupId));
            if (entity.ElementIds == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ElementIds));
            }
            if (entity.ElementIds.Length > 1000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ElementIds), entity.ElementIds.Length, 1000));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockElementProperties.ElementIds, entity.ElementIds));
                query.InsertBuilders.Add(builder);
            }
            return session.GetQueryOperator().InsertAll<TEarthworkBlockElement>(query);
        }
        public static bool DbUpdate(this TEarthworkBlockElement entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.Id, entity.Id, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.GroupId, entity.GroupId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockElementProperties.ElementIds, entity.ElementIds));
            }
            else
            {
                if (fields.Contains(TEarthworkBlockElementProperties.ElementIds))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockElementProperties.ElementIds, entity.ElementIds));
                }
            }
            query.UpdateBuilders.Add(builder);
            return session.GetQueryOperator().Update<TEarthworkBlockElement>(query);
        }
        public static bool DbUpdate(this List<TEarthworkBlockElement> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.Id, entity.Id, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.GroupId, entity.GroupId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockElementProperties.ElementIds, entity.ElementIds));
                }
                else
                {
                    if (fields.Contains(TEarthworkBlockElementProperties.ElementIds))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockElementProperties.ElementIds, entity.ElementIds));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return session.GetQueryOperator().UpdateAll<TEarthworkBlockElement>(query);
        }
        #endregion
        #region 读
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TEarthworkBlockElement DbSelect(this TEarthworkBlockElement entity, DbSession session, SelectBuilder select)
        {
            var query = session.GetDbQueryBuilder();
            query.SelectBuilder = select;
            return session.GetQueryOperator().Select<TEarthworkBlockElement>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TEarthworkBlockElement DbSelect(this TEarthworkBlockElement entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.IssueDateTime);
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.Id);
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.GroupId);
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.ElementIds);
            }
            else
            {
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.IssueDateTime);
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.Id);
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.GroupId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.Id, entity.Id, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.GroupId, entity.GroupId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().Select<TEarthworkBlockElement>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 new List<T>()
        /// </summary>
        public static List<TEarthworkBlockElement> DbSelect(this List<TEarthworkBlockElement> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.IssueDateTime);
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.Id);
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.GroupId);
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.ElementIds);
            }
            else
            {
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.IssueDateTime);
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.Id);
                builder.ComponentSelect.Add(TEarthworkBlockElementProperties.GroupId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.IssueDateTime );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockElementProperties.IssueDateTime, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().SelectAll<TEarthworkBlockElement>(query);
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this TEarthworkBlockElement entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (result == null)
            {
                return false;
            }
            if (fields.Count() == 0)
            {
                entity.ElementIds = result.ElementIds;
            }
            else
            {
                if (fields.Contains(TEarthworkBlockElementProperties.ElementIds))
                {
                    entity.ElementIds = result.ElementIds;
                }
            }
            return true;
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this List<TEarthworkBlockElement> entities, DbSession session, params PDMDbProperty[] fields)
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
