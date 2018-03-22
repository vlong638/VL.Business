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
        public static bool DbDelete(this TList entity, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.Segregation, entity.Segregation, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.IssueType, entity.IssueType, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.IssueDate, entity.IssueDate, LocateType.Equal));
            return session.GetQueryOperator().Delete<TList>(query);
        }
        public static bool DbDelete(this List<TList> entities, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            var Ids = entities.Select(c =>c.Segregation );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.Segregation, Ids, LocateType.In));
            return session.GetQueryOperator().Delete<TList>(query);
        }
        public static bool DbInsert(this TList entity, DbSession session)
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
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TListProperties.Segregation, entity.Segregation));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TListProperties.IssueType, entity.IssueType));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TListProperties.IssueDate, entity.IssueDate));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TListProperties.DataCount, entity.DataCount));
            query.InsertBuilders.Add(builder);
            return session.GetQueryOperator().Insert<TList>(query);
        }
        public static bool DbInsert(this List<TList> entities, DbSession session)
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
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TListProperties.Segregation, entity.Segregation));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TListProperties.IssueType, entity.IssueType));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TListProperties.IssueDate, entity.IssueDate));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TListProperties.DataCount, entity.DataCount));
                query.InsertBuilders.Add(builder);
            }
            return session.GetQueryOperator().InsertAll<TList>(query);
        }
        public static bool DbUpdate(this TList entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.Segregation, entity.Segregation, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.IssueType, entity.IssueType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.IssueDate, entity.IssueDate, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TListProperties.DataCount, entity.DataCount));
            }
            else
            {
                if (fields.Contains(TListProperties.DataCount))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TListProperties.DataCount, entity.DataCount));
                }
            }
            query.UpdateBuilders.Add(builder);
            return session.GetQueryOperator().Update<TList>(query);
        }
        public static bool DbUpdate(this List<TList> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.Segregation, entity.Segregation, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.IssueType, entity.IssueType, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.IssueDate, entity.IssueDate, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TListProperties.DataCount, entity.DataCount));
                }
                else
                {
                    if (fields.Contains(TListProperties.DataCount))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TListProperties.DataCount, entity.DataCount));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return session.GetQueryOperator().UpdateAll<TList>(query);
        }
        #endregion
        #region 读
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TList DbSelect(this TList entity, DbSession session, SelectBuilder select)
        {
            var query = session.GetDbQueryBuilder();
            query.SelectBuilder = select;
            return session.GetQueryOperator().Select<TList>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TList DbSelect(this TList entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TListProperties.Segregation);
                builder.ComponentSelect.Add(TListProperties.IssueType);
                builder.ComponentSelect.Add(TListProperties.IssueDate);
                builder.ComponentSelect.Add(TListProperties.DataCount);
            }
            else
            {
                builder.ComponentSelect.Add(TListProperties.Segregation);
                builder.ComponentSelect.Add(TListProperties.IssueType);
                builder.ComponentSelect.Add(TListProperties.IssueDate);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.Segregation, entity.Segregation, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.IssueType, entity.IssueType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.IssueDate, entity.IssueDate, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().Select<TList>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 new List<T>()
        /// </summary>
        public static List<TList> DbSelect(this List<TList> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TListProperties.Segregation);
                builder.ComponentSelect.Add(TListProperties.IssueType);
                builder.ComponentSelect.Add(TListProperties.IssueDate);
                builder.ComponentSelect.Add(TListProperties.DataCount);
            }
            else
            {
                builder.ComponentSelect.Add(TListProperties.Segregation);
                builder.ComponentSelect.Add(TListProperties.IssueType);
                builder.ComponentSelect.Add(TListProperties.IssueDate);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.Segregation );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TListProperties.Segregation, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().SelectAll<TList>(query);
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this TList entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (result == null)
            {
                return false;
            }
            if (fields.Count() == 0)
            {
                entity.DataCount = result.DataCount;
            }
            else
            {
                if (fields.Contains(TListProperties.DataCount))
                {
                    entity.DataCount = result.DataCount;
                }
            }
            return true;
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this List<TList> entities, DbSession session, params PDMDbProperty[] fields)
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
