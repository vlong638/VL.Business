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
        public static bool DbDelete(this TDepthNode entity, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.Segregation, entity.Segregation, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.IssueType, entity.IssueType, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.NodeCode, entity.NodeCode, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.Depth, entity.Depth, LocateType.Equal));
            return session.GetQueryOperator().Delete<TDepthNode>(query);
        }
        public static bool DbDelete(this List<TDepthNode> entities, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            var Ids = entities.Select(c =>c.Segregation );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.Segregation, Ids, LocateType.In));
            return session.GetQueryOperator().Delete<TDepthNode>(query);
        }
        public static bool DbInsert(this TDepthNode entity, DbSession session)
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
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.Segregation, entity.Segregation));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.IssueType, entity.IssueType));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.IssueDateTime, entity.IssueDateTime));
            if (entity.NodeCode == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.NodeCode));
            }
            if (entity.NodeCode.Length > 20)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.NodeCode), entity.NodeCode.Length, 20));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.NodeCode, entity.NodeCode));
            if (entity.Depth == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Depth));
            }
            if (entity.Depth.Length > 10)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Depth), entity.Depth.Length, 10));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.Depth, entity.Depth));
            if (entity.Data == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Data));
            }
            if (entity.Data.Length > 1000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Data), entity.Data.Length, 1000));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.Data, entity.Data));
            if (entity.ElementIds == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ElementIds));
            }
            if (entity.ElementIds.Length > 2000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ElementIds), entity.ElementIds.Length, 2000));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.ElementIds, entity.ElementIds));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.Index, entity.Index));
            query.InsertBuilders.Add(builder);
            return session.GetQueryOperator().Insert<TDepthNode>(query);
        }
        public static bool DbInsert(this List<TDepthNode> entities, DbSession session)
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
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.Segregation, entity.Segregation));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.IssueType, entity.IssueType));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.IssueDateTime, entity.IssueDateTime));
            if (entity.NodeCode == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.NodeCode));
            }
            if (entity.NodeCode.Length > 20)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.NodeCode), entity.NodeCode.Length, 20));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.NodeCode, entity.NodeCode));
            if (entity.Depth == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Depth));
            }
            if (entity.Depth.Length > 10)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Depth), entity.Depth.Length, 10));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.Depth, entity.Depth));
            if (entity.Data == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Data));
            }
            if (entity.Data.Length > 1000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Data), entity.Data.Length, 1000));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.Data, entity.Data));
            if (entity.ElementIds == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ElementIds));
            }
            if (entity.ElementIds.Length > 2000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ElementIds), entity.ElementIds.Length, 2000));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.ElementIds, entity.ElementIds));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDepthNodeProperties.Index, entity.Index));
                query.InsertBuilders.Add(builder);
            }
            return session.GetQueryOperator().InsertAll<TDepthNode>(query);
        }
        public static bool DbUpdate(this TDepthNode entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.Segregation, entity.Segregation, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.IssueType, entity.IssueType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.NodeCode, entity.NodeCode, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.Depth, entity.Depth, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TDepthNodeProperties.Data, entity.Data));
                builder.ComponentSet.Add(new ComponentValueOfSet(TDepthNodeProperties.ElementIds, entity.ElementIds));
                builder.ComponentSet.Add(new ComponentValueOfSet(TDepthNodeProperties.Index, entity.Index));
            }
            else
            {
                if (fields.Contains(TDepthNodeProperties.Data))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDepthNodeProperties.Data, entity.Data));
                }
                if (fields.Contains(TDepthNodeProperties.ElementIds))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDepthNodeProperties.ElementIds, entity.ElementIds));
                }
                if (fields.Contains(TDepthNodeProperties.Index))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDepthNodeProperties.Index, entity.Index));
                }
            }
            query.UpdateBuilders.Add(builder);
            return session.GetQueryOperator().Update<TDepthNode>(query);
        }
        public static bool DbUpdate(this List<TDepthNode> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.Segregation, entity.Segregation, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.IssueType, entity.IssueType, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.NodeCode, entity.NodeCode, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.Depth, entity.Depth, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDepthNodeProperties.Data, entity.Data));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDepthNodeProperties.ElementIds, entity.ElementIds));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDepthNodeProperties.Index, entity.Index));
                }
                else
                {
                    if (fields.Contains(TDepthNodeProperties.Data))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDepthNodeProperties.Data, entity.Data));
                    }
                    if (fields.Contains(TDepthNodeProperties.ElementIds))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDepthNodeProperties.ElementIds, entity.ElementIds));
                    }
                    if (fields.Contains(TDepthNodeProperties.Index))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDepthNodeProperties.Index, entity.Index));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return session.GetQueryOperator().UpdateAll<TDepthNode>(query);
        }
        #endregion
        #region 读
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TDepthNode DbSelect(this TDepthNode entity, DbSession session, SelectBuilder select)
        {
            var query = session.GetDbQueryBuilder();
            query.SelectBuilder = select;
            return session.GetQueryOperator().Select<TDepthNode>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TDepthNode DbSelect(this TDepthNode entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TDepthNodeProperties.Segregation);
                builder.ComponentSelect.Add(TDepthNodeProperties.IssueType);
                builder.ComponentSelect.Add(TDepthNodeProperties.IssueDateTime);
                builder.ComponentSelect.Add(TDepthNodeProperties.NodeCode);
                builder.ComponentSelect.Add(TDepthNodeProperties.Depth);
                builder.ComponentSelect.Add(TDepthNodeProperties.Data);
                builder.ComponentSelect.Add(TDepthNodeProperties.ElementIds);
                builder.ComponentSelect.Add(TDepthNodeProperties.Index);
            }
            else
            {
                builder.ComponentSelect.Add(TDepthNodeProperties.Segregation);
                builder.ComponentSelect.Add(TDepthNodeProperties.IssueType);
                builder.ComponentSelect.Add(TDepthNodeProperties.IssueDateTime);
                builder.ComponentSelect.Add(TDepthNodeProperties.NodeCode);
                builder.ComponentSelect.Add(TDepthNodeProperties.Depth);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.Segregation, entity.Segregation, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.IssueType, entity.IssueType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.NodeCode, entity.NodeCode, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.Depth, entity.Depth, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().Select<TDepthNode>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 new List<T>()
        /// </summary>
        public static List<TDepthNode> DbSelect(this List<TDepthNode> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TDepthNodeProperties.Segregation);
                builder.ComponentSelect.Add(TDepthNodeProperties.IssueType);
                builder.ComponentSelect.Add(TDepthNodeProperties.IssueDateTime);
                builder.ComponentSelect.Add(TDepthNodeProperties.NodeCode);
                builder.ComponentSelect.Add(TDepthNodeProperties.Depth);
                builder.ComponentSelect.Add(TDepthNodeProperties.Data);
                builder.ComponentSelect.Add(TDepthNodeProperties.ElementIds);
                builder.ComponentSelect.Add(TDepthNodeProperties.Index);
            }
            else
            {
                builder.ComponentSelect.Add(TDepthNodeProperties.Segregation);
                builder.ComponentSelect.Add(TDepthNodeProperties.IssueType);
                builder.ComponentSelect.Add(TDepthNodeProperties.IssueDateTime);
                builder.ComponentSelect.Add(TDepthNodeProperties.NodeCode);
                builder.ComponentSelect.Add(TDepthNodeProperties.Depth);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.Segregation );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TDepthNodeProperties.Segregation, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().SelectAll<TDepthNode>(query);
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this TDepthNode entity, DbSession session, params PDMDbProperty[] fields)
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
                if (fields.Contains(TDepthNodeProperties.Data))
                {
                    entity.Data = result.Data;
                }
                if (fields.Contains(TDepthNodeProperties.ElementIds))
                {
                    entity.ElementIds = result.ElementIds;
                }
                if (fields.Contains(TDepthNodeProperties.Index))
                {
                    entity.Index = result.Index;
                }
            }
            return true;
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this List<TDepthNode> entities, DbSession session, params PDMDbProperty[] fields)
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
