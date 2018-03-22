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
        public static bool DbDelete(this TEarthworkBlock entity, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockProperties.Id, entity.Id, LocateType.Equal));
            return session.GetQueryOperator().Delete<TEarthworkBlock>(query);
        }
        public static bool DbDelete(this List<TEarthworkBlock> entities, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            var Ids = entities.Select(c => c.IssueDateTime);
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockProperties.IssueDateTime, Ids, LocateType.In));
            return session.GetQueryOperator().Delete<TEarthworkBlock>(query);
        }
        public static bool DbInsert(this TEarthworkBlock entity, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.IssueDateTime, entity.IssueDateTime));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.Id, entity.Id));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.Indexer, entity.Indexer));
            if (entity.Name == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Name));
            }
            if (entity.Name.Length > 100)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Name), entity.Name.Length, 100));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.Name, entity.Name));
            if (entity.Description == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Description));
            }
            if (entity.Description.Length > 1000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Description), entity.Description.Length, 1000));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.Description, entity.Description));
            if (entity.CPSettings == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.CPSettings));
            }
            if (entity.CPSettings.Length > 1000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.CPSettings), entity.CPSettings.Length, 1000));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.CPSettings, entity.CPSettings));
            if (entity.EarthworkBlockImplementationInfo == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.EarthworkBlockImplementationInfo));
            }
            if (entity.EarthworkBlockImplementationInfo.Length > 1000)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.EarthworkBlockImplementationInfo), entity.EarthworkBlockImplementationInfo.Length, 1000));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.EarthworkBlockImplementationInfo, entity.EarthworkBlockImplementationInfo));
            query.InsertBuilders.Add(builder);
            return session.GetQueryOperator().Insert<TEarthworkBlock>(query);
        }
        public static bool DbInsert(this List<TEarthworkBlock> entities, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.IssueDateTime, entity.IssueDateTime));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.Id, entity.Id));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.Indexer, entity.Indexer));
                if (entity.Name == null)
                {
                    throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Name));
                }
                if (entity.Name.Length > 100)
                {
                    throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Name), entity.Name.Length, 100));
                }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.Name, entity.Name));
                if (entity.Description == null)
                {
                    throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Description));
                }
                if (entity.Description.Length > 1000)
                {
                    throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Description), entity.Description.Length, 1000));
                }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.Description, entity.Description));
                if (entity.CPSettings == null)
                {
                    throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.CPSettings));
                }
                if (entity.CPSettings.Length > 1000)
                {
                    throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.CPSettings), entity.CPSettings.Length, 1000));
                }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.CPSettings, entity.CPSettings));
                if (entity.EarthworkBlockImplementationInfo == null)
                {
                    throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.EarthworkBlockImplementationInfo));
                }
                if (entity.EarthworkBlockImplementationInfo.Length > 1000)
                {
                    throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.EarthworkBlockImplementationInfo), entity.EarthworkBlockImplementationInfo.Length, 1000));
                }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TEarthworkBlockProperties.EarthworkBlockImplementationInfo, entity.EarthworkBlockImplementationInfo));
                query.InsertBuilders.Add(builder);
            }
            return session.GetQueryOperator().InsertAll<TEarthworkBlock>(query);
        }
        public static bool DbUpdate(this TEarthworkBlock entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockProperties.Id, entity.Id, LocateType.Equal));
            if (fields == null || fields.Length == 0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.Indexer, entity.Indexer));
                builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.Name, entity.Name));
                builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.Description, entity.Description));
                builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.CPSettings, entity.CPSettings));
                builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.EarthworkBlockImplementationInfo, entity.EarthworkBlockImplementationInfo));
            }
            else
            {
                if (fields.Contains(TEarthworkBlockProperties.Indexer))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.Indexer, entity.Indexer));
                }
                if (fields.Contains(TEarthworkBlockProperties.Name))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.Name, entity.Name));
                }
                if (fields.Contains(TEarthworkBlockProperties.Description))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.Description, entity.Description));
                }
                if (fields.Contains(TEarthworkBlockProperties.CPSettings))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.CPSettings, entity.CPSettings));
                }
                if (fields.Contains(TEarthworkBlockProperties.EarthworkBlockImplementationInfo))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.EarthworkBlockImplementationInfo, entity.EarthworkBlockImplementationInfo));
                }
            }
            query.UpdateBuilders.Add(builder);
            return session.GetQueryOperator().Update<TEarthworkBlock>(query);
        }
        public static bool DbUpdate(this List<TEarthworkBlock> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockProperties.Id, entity.Id, LocateType.Equal));
                if (fields == null || fields.Length == 0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.Indexer, entity.Indexer));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.Name, entity.Name));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.Description, entity.Description));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.CPSettings, entity.CPSettings));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.EarthworkBlockImplementationInfo, entity.EarthworkBlockImplementationInfo));
                }
                else
                {
                    if (fields.Contains(TEarthworkBlockProperties.Indexer))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.Indexer, entity.Indexer));
                    }
                    if (fields.Contains(TEarthworkBlockProperties.Name))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.Name, entity.Name));
                    }
                    if (fields.Contains(TEarthworkBlockProperties.Description))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.Description, entity.Description));
                    }
                    if (fields.Contains(TEarthworkBlockProperties.CPSettings))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.CPSettings, entity.CPSettings));
                    }
                    if (fields.Contains(TEarthworkBlockProperties.EarthworkBlockImplementationInfo))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TEarthworkBlockProperties.EarthworkBlockImplementationInfo, entity.EarthworkBlockImplementationInfo));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return session.GetQueryOperator().UpdateAll<TEarthworkBlock>(query);
        }
        #endregion
        #region 读
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TEarthworkBlock DbSelect(this TEarthworkBlock entity, DbSession session, SelectBuilder select)
        {
            var query = session.GetDbQueryBuilder();
            query.SelectBuilder = select;
            return session.GetQueryOperator().Select<TEarthworkBlock>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TEarthworkBlock DbSelect(this TEarthworkBlock entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TEarthworkBlockProperties.IssueDateTime);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.Id);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.Indexer);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.Name);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.Description);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.CPSettings);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.EarthworkBlockImplementationInfo);
            }
            else
            {
                builder.ComponentSelect.Add(TEarthworkBlockProperties.IssueDateTime);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.Id);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockProperties.Id, entity.Id, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().Select<TEarthworkBlock>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 new List<T>()
        /// </summary>
        public static List<TEarthworkBlock> DbSelect(this List<TEarthworkBlock> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TEarthworkBlockProperties.IssueDateTime);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.Id);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.Indexer);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.Name);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.Description);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.CPSettings);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.EarthworkBlockImplementationInfo);
            }
            else
            {
                builder.ComponentSelect.Add(TEarthworkBlockProperties.IssueDateTime);
                builder.ComponentSelect.Add(TEarthworkBlockProperties.Id);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c => c.IssueDateTime);
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TEarthworkBlockProperties.IssueDateTime, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().SelectAll<TEarthworkBlock>(query);
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this TEarthworkBlock entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (result == null)
            {
                return false;
            }
            if (fields.Count() == 0)
            {
                entity.Indexer = result.Indexer;
                entity.Name = result.Name;
                entity.Description = result.Description;
                entity.CPSettings = result.CPSettings;
                entity.EarthworkBlockImplementationInfo = result.EarthworkBlockImplementationInfo;
            }
            else
            {
                if (fields.Contains(TEarthworkBlockProperties.Indexer))
                {
                    entity.Indexer = result.Indexer;
                }
                if (fields.Contains(TEarthworkBlockProperties.Name))
                {
                    entity.Name = result.Name;
                }
                if (fields.Contains(TEarthworkBlockProperties.Description))
                {
                    entity.Description = result.Description;
                }
                if (fields.Contains(TEarthworkBlockProperties.CPSettings))
                {
                    entity.CPSettings = result.CPSettings;
                }
                if (fields.Contains(TEarthworkBlockProperties.EarthworkBlockImplementationInfo))
                {
                    entity.EarthworkBlockImplementationInfo = result.EarthworkBlockImplementationInfo;
                }
            }
            return true;
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this List<TEarthworkBlock> entities, DbSession session, params PDMDbProperty[] fields)
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
