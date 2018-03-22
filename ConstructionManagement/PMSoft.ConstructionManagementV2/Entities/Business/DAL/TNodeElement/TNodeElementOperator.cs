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
        public static bool DbDelete(this TNodeElement entity, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeElementProperties.Segregation, entity.Segregation, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeElementProperties.NodeCode, entity.NodeCode, LocateType.Equal));
            return session.GetQueryOperator().Delete<TNodeElement>(query);
        }
        public static bool DbDelete(this List<TNodeElement> entities, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            var Ids = entities.Select(c =>c.Segregation );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeElementProperties.Segregation, Ids, LocateType.In));
            return session.GetQueryOperator().Delete<TNodeElement>(query);
        }
        public static bool DbInsert(this TNodeElement entity, DbSession session)
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
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeElementProperties.Segregation, entity.Segregation));
            if (entity.NodeCode == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.NodeCode));
            }
            if (entity.NodeCode.Length > 20)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.NodeCode), entity.NodeCode.Length, 20));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeElementProperties.NodeCode, entity.NodeCode));
            if (entity.ElementIds == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ElementIds));
            }
            if (entity.ElementIds.Length > 2000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ElementIds), entity.ElementIds.Length, 2000));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeElementProperties.ElementIds, entity.ElementIds));
            query.InsertBuilders.Add(builder);
            return session.GetQueryOperator().Insert<TNodeElement>(query);
        }
        public static bool DbInsert(this List<TNodeElement> entities, DbSession session)
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
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeElementProperties.Segregation, entity.Segregation));
            if (entity.NodeCode == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.NodeCode));
            }
            if (entity.NodeCode.Length > 20)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.NodeCode), entity.NodeCode.Length, 20));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeElementProperties.NodeCode, entity.NodeCode));
            if (entity.ElementIds == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ElementIds));
            }
            if (entity.ElementIds.Length > 2000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ElementIds), entity.ElementIds.Length, 2000));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TNodeElementProperties.ElementIds, entity.ElementIds));
                query.InsertBuilders.Add(builder);
            }
            return session.GetQueryOperator().InsertAll<TNodeElement>(query);
        }
        public static bool DbUpdate(this TNodeElement entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeElementProperties.Segregation, entity.Segregation, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeElementProperties.NodeCode, entity.NodeCode, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TNodeElementProperties.ElementIds, entity.ElementIds));
            }
            else
            {
                if (fields.Contains(TNodeElementProperties.ElementIds))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TNodeElementProperties.ElementIds, entity.ElementIds));
                }
            }
            query.UpdateBuilders.Add(builder);
            return session.GetQueryOperator().Update<TNodeElement>(query);
        }
        public static bool DbUpdate(this List<TNodeElement> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeElementProperties.Segregation, entity.Segregation, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeElementProperties.NodeCode, entity.NodeCode, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TNodeElementProperties.ElementIds, entity.ElementIds));
                }
                else
                {
                    if (fields.Contains(TNodeElementProperties.ElementIds))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TNodeElementProperties.ElementIds, entity.ElementIds));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return session.GetQueryOperator().UpdateAll<TNodeElement>(query);
        }
        #endregion
        #region 读
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TNodeElement DbSelect(this TNodeElement entity, DbSession session, SelectBuilder select)
        {
            var query = session.GetDbQueryBuilder();
            query.SelectBuilder = select;
            return session.GetQueryOperator().Select<TNodeElement>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TNodeElement DbSelect(this TNodeElement entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TNodeElementProperties.Segregation);
                builder.ComponentSelect.Add(TNodeElementProperties.NodeCode);
                builder.ComponentSelect.Add(TNodeElementProperties.ElementIds);
            }
            else
            {
                builder.ComponentSelect.Add(TNodeElementProperties.Segregation);
                builder.ComponentSelect.Add(TNodeElementProperties.NodeCode);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeElementProperties.Segregation, entity.Segregation, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeElementProperties.NodeCode, entity.NodeCode, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().Select<TNodeElement>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 new List<T>()
        /// </summary>
        public static List<TNodeElement> DbSelect(this List<TNodeElement> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TNodeElementProperties.Segregation);
                builder.ComponentSelect.Add(TNodeElementProperties.NodeCode);
                builder.ComponentSelect.Add(TNodeElementProperties.ElementIds);
            }
            else
            {
                builder.ComponentSelect.Add(TNodeElementProperties.Segregation);
                builder.ComponentSelect.Add(TNodeElementProperties.NodeCode);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.Segregation );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TNodeElementProperties.Segregation, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().SelectAll<TNodeElement>(query);
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this TNodeElement entity, DbSession session, params PDMDbProperty[] fields)
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
                if (fields.Contains(TNodeElementProperties.ElementIds))
                {
                    entity.ElementIds = result.ElementIds;
                }
            }
            return true;
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this List<TNodeElement> entities, DbSession session, params PDMDbProperty[] fields)
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
