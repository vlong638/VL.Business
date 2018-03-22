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
        public static bool DbDelete(this TNode entity, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.Segregation, entity.Segregation, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.IssueType, entity.IssueType, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.NodeCode, entity.NodeCode, LocateType.Equal));
            return session.GetQueryOperator().Delete<TNode>(query);
        }
        public static bool DbDelete(this List<TNode> entities, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            var Ids = entities.Select(c =>c.Segregation );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.Segregation, Ids, LocateType.In));
            return session.GetQueryOperator().Delete<TNode>(query);
        }
        public static bool DbInsert(this TNode entity, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            InsertBuilder builder = new InsertBuilder();
            if (entity.Segregation == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Segregation));
            }
            if (entity.Segregation.Length > 36)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Segregation), entity.Segregation.Length, 36));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.Segregation, entity.Segregation));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.IssueType, entity.IssueType));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.IssueDateTime, entity.IssueDateTime));
            if (entity.NodeCode == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.NodeCode));
            }
            if (entity.NodeCode.Length > 20)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.NodeCode), entity.NodeCode.Length, 20));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.NodeCode, entity.NodeCode));
            if (entity.Data == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Data));
            }
            if (entity.Data.Length > 1000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Data), entity.Data.Length, 1000));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.Data, entity.Data));
            if (entity.ElementIds == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ElementIds));
            }
            if (entity.ElementIds.Length > 2000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ElementIds), entity.ElementIds.Length, 2000));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.ElementIds, entity.ElementIds));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.Index, entity.Index));
            query.InsertBuilders.Add(builder);
            return session.GetQueryOperator().Insert<TNode>(query);
        }
        public static bool DbInsert(this List<TNode> entities, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
            if (entity.Segregation == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Segregation));
            }
            if (entity.Segregation.Length > 36)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Segregation), entity.Segregation.Length, 36));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.Segregation, entity.Segregation));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.IssueType, entity.IssueType));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.IssueDateTime, entity.IssueDateTime));
            if (entity.NodeCode == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.NodeCode));
            }
            if (entity.NodeCode.Length > 20)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.NodeCode), entity.NodeCode.Length, 20));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.NodeCode, entity.NodeCode));
            if (entity.Data == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Data));
            }
            if (entity.Data.Length > 1000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Data), entity.Data.Length, 1000));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.Data, entity.Data));
            if (entity.ElementIds == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ElementIds));
            }
            if (entity.ElementIds.Length > 2000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ElementIds), entity.ElementIds.Length, 2000));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.ElementIds, entity.ElementIds));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeProperties.Index, entity.Index));
                query.InsertBuilders.Add(builder);
            }
            return session.GetQueryOperator().InsertAll<TNode>(query);
        }
        public static bool DbUpdate(this TNode entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.Segregation, entity.Segregation, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.IssueType, entity.IssueType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.NodeCode, entity.NodeCode, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TNodeProperties.Data, entity.Data));
                builder.ComponentSet.Add(new ComponentValueOfSet(TNodeProperties.ElementIds, entity.ElementIds));
                builder.ComponentSet.Add(new ComponentValueOfSet(TNodeProperties.Index, entity.Index));
            }
            else
            {
                if (fields.Contains(TNodeProperties.Data))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TNodeProperties.Data, entity.Data));
                }
                if (fields.Contains(TNodeProperties.ElementIds))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TNodeProperties.ElementIds, entity.ElementIds));
                }
                if (fields.Contains(TNodeProperties.Index))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TNodeProperties.Index, entity.Index));
                }
            }
            query.UpdateBuilders.Add(builder);
            return session.GetQueryOperator().Update<TNode>(query);
        }
        public static bool DbUpdate(this List<TNode> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.Segregation, entity.Segregation, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.IssueType, entity.IssueType, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.NodeCode, entity.NodeCode, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TNodeProperties.Data, entity.Data));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TNodeProperties.ElementIds, entity.ElementIds));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TNodeProperties.Index, entity.Index));
                }
                else
                {
                    if (fields.Contains(TNodeProperties.Data))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TNodeProperties.Data, entity.Data));
                    }
                    if (fields.Contains(TNodeProperties.ElementIds))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TNodeProperties.ElementIds, entity.ElementIds));
                    }
                    if (fields.Contains(TNodeProperties.Index))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TNodeProperties.Index, entity.Index));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return session.GetQueryOperator().UpdateAll<TNode>(query);
        }
        #endregion
        #region 读
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TNode DbSelect(this TNode entity, DbSession session, SelectBuilder select)
        {
            var query = session.GetDbQueryBuilder();
            query.SelectBuilder = select;
            return session.GetQueryOperator().Select<TNode>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TNode DbSelect(this TNode entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TNodeProperties.Segregation);
                builder.ComponentSelect.Add(TNodeProperties.IssueType);
                builder.ComponentSelect.Add(TNodeProperties.IssueDateTime);
                builder.ComponentSelect.Add(TNodeProperties.NodeCode);
                builder.ComponentSelect.Add(TNodeProperties.Data);
                builder.ComponentSelect.Add(TNodeProperties.ElementIds);
                builder.ComponentSelect.Add(TNodeProperties.Index);
            }
            else
            {
                builder.ComponentSelect.Add(TNodeProperties.Segregation);
                builder.ComponentSelect.Add(TNodeProperties.IssueType);
                builder.ComponentSelect.Add(TNodeProperties.IssueDateTime);
                builder.ComponentSelect.Add(TNodeProperties.NodeCode);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.Segregation, entity.Segregation, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.IssueType, entity.IssueType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.NodeCode, entity.NodeCode, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().Select<TNode>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 new List<T>()
        /// </summary>
        public static List<TNode> DbSelect(this List<TNode> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TNodeProperties.Segregation);
                builder.ComponentSelect.Add(TNodeProperties.IssueType);
                builder.ComponentSelect.Add(TNodeProperties.IssueDateTime);
                builder.ComponentSelect.Add(TNodeProperties.NodeCode);
                builder.ComponentSelect.Add(TNodeProperties.Data);
                builder.ComponentSelect.Add(TNodeProperties.ElementIds);
                builder.ComponentSelect.Add(TNodeProperties.Index);
            }
            else
            {
                builder.ComponentSelect.Add(TNodeProperties.Segregation);
                builder.ComponentSelect.Add(TNodeProperties.IssueType);
                builder.ComponentSelect.Add(TNodeProperties.IssueDateTime);
                builder.ComponentSelect.Add(TNodeProperties.NodeCode);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.Segregation );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeProperties.Segregation, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().SelectAll<TNode>(query);
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this TNode entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (result == null)
            {
                return false;
            }
            if (fields.Count() == 0)
            {
                entity.Data = result.Data;
                entity.ElementIds = result.ElementIds;
                entity.Index = result.Index;
            }
            else
            {
                if (fields.Contains(TNodeProperties.Data))
                {
                    entity.Data = result.Data;
                }
                if (fields.Contains(TNodeProperties.ElementIds))
                {
                    entity.ElementIds = result.ElementIds;
                }
                if (fields.Contains(TNodeProperties.Index))
                {
                    entity.Index = result.Index;
                }
            }
            return true;
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this List<TNode> entities, DbSession session, params PDMDbProperty[] fields)
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
