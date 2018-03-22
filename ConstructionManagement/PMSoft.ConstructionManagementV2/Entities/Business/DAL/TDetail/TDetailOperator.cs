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
        public static bool DbDelete(this TDetail entity, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.Segregation, entity.Segregation, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.IssueType, entity.IssueType, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            return session.GetQueryOperator().Delete<TDetail>(query);
        }
        public static bool DbDelete(this List<TDetail> entities, DbSession session)
        {
            var query = session.GetDbQueryBuilder();
            var Ids = entities.Select(c =>c.Segregation );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.Segregation, Ids, LocateType.In));
            return session.GetQueryOperator().Delete<TDetail>(query);
        }
        public static bool DbInsert(this TDetail entity, DbSession session)
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
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.Segregation, entity.Segregation));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.IssueType, entity.IssueType));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.IssueDateTime, entity.IssueDateTime));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.IssueTimeRange, entity.IssueTimeRange));
            if (entity.ReportName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ReportName));
            }
            if (entity.ReportName.Length > 200)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ReportName), entity.ReportName.Length, 200));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.ReportName, entity.ReportName));
            if (entity.Contractor == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Contractor));
            }
            if (entity.Contractor.Length > 100)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Contractor), entity.Contractor.Length, 100));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.Contractor, entity.Contractor));
            if (entity.Supervisor == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Supervisor));
            }
            if (entity.Supervisor.Length > 100)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Supervisor), entity.Supervisor.Length, 100));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.Supervisor, entity.Supervisor));
            if (entity.Monitor == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Monitor));
            }
            if (entity.Monitor.Length > 100)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Monitor), entity.Monitor.Length, 100));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.Monitor, entity.Monitor));
            if (entity.InstrumentName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.InstrumentName));
            }
            if (entity.InstrumentName.Length > 100)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.InstrumentName), entity.InstrumentName.Length, 100));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.InstrumentName, entity.InstrumentName));
            if (entity.InstrumentCode == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.InstrumentCode));
            }
            if (entity.InstrumentCode.Length > 100)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.InstrumentCode), entity.InstrumentCode.Length, 100));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.InstrumentCode, entity.InstrumentCode));
            if (entity.CloseCTSettings == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.CloseCTSettings));
            }
            if (entity.CloseCTSettings.Length > 500)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.CloseCTSettings), entity.CloseCTSettings.Length, 500));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.CloseCTSettings, entity.CloseCTSettings));
            if (entity.OverCTSettings == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.OverCTSettings));
            }
            if (entity.OverCTSettings.Length > 500)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.OverCTSettings), entity.OverCTSettings.Length, 500));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.OverCTSettings, entity.OverCTSettings));
            if (entity.ExtraValue1.HasValue)
            {
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.ExtraValue1, entity.ExtraValue1.Value));
            }
            if (entity.ExtraValue2.HasValue)
            {
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.ExtraValue2, entity.ExtraValue2.Value));
            }
            if (entity.ExtraValue3.HasValue)
            {
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.ExtraValue3, entity.ExtraValue3.Value));
            }
            query.InsertBuilders.Add(builder);
            return session.GetQueryOperator().Insert<TDetail>(query);
        }
        public static bool DbInsert(this List<TDetail> entities, DbSession session)
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
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.Segregation, entity.Segregation));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.IssueType, entity.IssueType));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.IssueDateTime, entity.IssueDateTime));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.IssueTimeRange, entity.IssueTimeRange));
            if (entity.ReportName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ReportName));
            }
            if (entity.ReportName.Length > 200)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.ReportName), entity.ReportName.Length, 200));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.ReportName, entity.ReportName));
            if (entity.Contractor == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Contractor));
            }
            if (entity.Contractor.Length > 100)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Contractor), entity.Contractor.Length, 100));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.Contractor, entity.Contractor));
            if (entity.Supervisor == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Supervisor));
            }
            if (entity.Supervisor.Length > 100)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Supervisor), entity.Supervisor.Length, 100));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.Supervisor, entity.Supervisor));
            if (entity.Monitor == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Monitor));
            }
            if (entity.Monitor.Length > 100)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.Monitor), entity.Monitor.Length, 100));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.Monitor, entity.Monitor));
            if (entity.InstrumentName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.InstrumentName));
            }
            if (entity.InstrumentName.Length > 100)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.InstrumentName), entity.InstrumentName.Length, 100));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.InstrumentName, entity.InstrumentName));
            if (entity.InstrumentCode == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.InstrumentCode));
            }
            if (entity.InstrumentCode.Length > 100)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.InstrumentCode), entity.InstrumentCode.Length, 100));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.InstrumentCode, entity.InstrumentCode));
            if (entity.CloseCTSettings == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.CloseCTSettings));
            }
            if (entity.CloseCTSettings.Length > 500)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.CloseCTSettings), entity.CloseCTSettings.Length, 500));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.CloseCTSettings, entity.CloseCTSettings));
            if (entity.OverCTSettings == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.OverCTSettings));
            }
            if (entity.OverCTSettings.Length > 500)
            {
                throw new NotImplementedException(string.Format("参数项:{0}长度:{1}超过额定限制:{2}", nameof(entity.OverCTSettings), entity.OverCTSettings.Length, 500));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.OverCTSettings, entity.OverCTSettings));
                if (entity.ExtraValue1.HasValue)
                {
                    builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.ExtraValue1, entity.ExtraValue1.Value));
                }
                if (entity.ExtraValue2.HasValue)
                {
                    builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.ExtraValue2, entity.ExtraValue2.Value));
                }
                if (entity.ExtraValue3.HasValue)
                {
                    builder.ComponentInsert.Add(new ComponentValueOfInsert(TDetailProperties.ExtraValue3, entity.ExtraValue3.Value));
                }
                query.InsertBuilders.Add(builder);
            }
            return session.GetQueryOperator().InsertAll<TDetail>(query);
        }
        public static bool DbUpdate(this TDetail entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.Segregation, entity.Segregation, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.IssueType, entity.IssueType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.IssueTimeRange, entity.IssueTimeRange));
                builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ReportName, entity.ReportName));
                builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.Contractor, entity.Contractor));
                builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.Supervisor, entity.Supervisor));
                builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.Monitor, entity.Monitor));
                builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.InstrumentName, entity.InstrumentName));
                builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.InstrumentCode, entity.InstrumentCode));
                builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.CloseCTSettings, entity.CloseCTSettings));
                builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.OverCTSettings, entity.OverCTSettings));
                builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ExtraValue1, entity.ExtraValue1));
                builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ExtraValue2, entity.ExtraValue2));
                builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ExtraValue3, entity.ExtraValue3));
            }
            else
            {
                if (fields.Contains(TDetailProperties.IssueTimeRange))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.IssueTimeRange, entity.IssueTimeRange));
                }
                if (fields.Contains(TDetailProperties.ReportName))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ReportName, entity.ReportName));
                }
                if (fields.Contains(TDetailProperties.Contractor))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.Contractor, entity.Contractor));
                }
                if (fields.Contains(TDetailProperties.Supervisor))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.Supervisor, entity.Supervisor));
                }
                if (fields.Contains(TDetailProperties.Monitor))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.Monitor, entity.Monitor));
                }
                if (fields.Contains(TDetailProperties.InstrumentName))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.InstrumentName, entity.InstrumentName));
                }
                if (fields.Contains(TDetailProperties.InstrumentCode))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.InstrumentCode, entity.InstrumentCode));
                }
                if (fields.Contains(TDetailProperties.CloseCTSettings))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.CloseCTSettings, entity.CloseCTSettings));
                }
                if (fields.Contains(TDetailProperties.OverCTSettings))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.OverCTSettings, entity.OverCTSettings));
                }
                if (fields.Contains(TDetailProperties.ExtraValue1))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ExtraValue1, entity.ExtraValue1));
                }
                if (fields.Contains(TDetailProperties.ExtraValue2))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ExtraValue2, entity.ExtraValue2));
                }
                if (fields.Contains(TDetailProperties.ExtraValue3))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ExtraValue3, entity.ExtraValue3));
                }
            }
            query.UpdateBuilders.Add(builder);
            return session.GetQueryOperator().Update<TDetail>(query);
        }
        public static bool DbUpdate(this List<TDetail> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.Segregation, entity.Segregation, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.IssueType, entity.IssueType, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.IssueTimeRange, entity.IssueTimeRange));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ReportName, entity.ReportName));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.Contractor, entity.Contractor));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.Supervisor, entity.Supervisor));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.Monitor, entity.Monitor));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.InstrumentName, entity.InstrumentName));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.InstrumentCode, entity.InstrumentCode));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.CloseCTSettings, entity.CloseCTSettings));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.OverCTSettings, entity.OverCTSettings));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ExtraValue1, entity.ExtraValue1));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ExtraValue2, entity.ExtraValue2));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ExtraValue3, entity.ExtraValue3));
                }
                else
                {
                    if (fields.Contains(TDetailProperties.IssueTimeRange))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.IssueTimeRange, entity.IssueTimeRange));
                    }
                    if (fields.Contains(TDetailProperties.ReportName))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ReportName, entity.ReportName));
                    }
                    if (fields.Contains(TDetailProperties.Contractor))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.Contractor, entity.Contractor));
                    }
                    if (fields.Contains(TDetailProperties.Supervisor))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.Supervisor, entity.Supervisor));
                    }
                    if (fields.Contains(TDetailProperties.Monitor))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.Monitor, entity.Monitor));
                    }
                    if (fields.Contains(TDetailProperties.InstrumentName))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.InstrumentName, entity.InstrumentName));
                    }
                    if (fields.Contains(TDetailProperties.InstrumentCode))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.InstrumentCode, entity.InstrumentCode));
                    }
                    if (fields.Contains(TDetailProperties.CloseCTSettings))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.CloseCTSettings, entity.CloseCTSettings));
                    }
                    if (fields.Contains(TDetailProperties.OverCTSettings))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.OverCTSettings, entity.OverCTSettings));
                    }
                    if (fields.Contains(TDetailProperties.ExtraValue1))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ExtraValue1, entity.ExtraValue1));
                    }
                    if (fields.Contains(TDetailProperties.ExtraValue2))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ExtraValue2, entity.ExtraValue2));
                    }
                    if (fields.Contains(TDetailProperties.ExtraValue3))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TDetailProperties.ExtraValue3, entity.ExtraValue3));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return session.GetQueryOperator().UpdateAll<TDetail>(query);
        }
        #endregion
        #region 读
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TDetail DbSelect(this TDetail entity, DbSession session, SelectBuilder select)
        {
            var query = session.GetDbQueryBuilder();
            query.SelectBuilder = select;
            return session.GetQueryOperator().Select<TDetail>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 null
        /// </summary>
        public static TDetail DbSelect(this TDetail entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TDetailProperties.Segregation);
                builder.ComponentSelect.Add(TDetailProperties.IssueType);
                builder.ComponentSelect.Add(TDetailProperties.IssueDateTime);
                builder.ComponentSelect.Add(TDetailProperties.IssueTimeRange);
                builder.ComponentSelect.Add(TDetailProperties.ReportName);
                builder.ComponentSelect.Add(TDetailProperties.Contractor);
                builder.ComponentSelect.Add(TDetailProperties.Supervisor);
                builder.ComponentSelect.Add(TDetailProperties.Monitor);
                builder.ComponentSelect.Add(TDetailProperties.InstrumentName);
                builder.ComponentSelect.Add(TDetailProperties.InstrumentCode);
                builder.ComponentSelect.Add(TDetailProperties.CloseCTSettings);
                builder.ComponentSelect.Add(TDetailProperties.OverCTSettings);
                builder.ComponentSelect.Add(TDetailProperties.ExtraValue1);
                builder.ComponentSelect.Add(TDetailProperties.ExtraValue2);
                builder.ComponentSelect.Add(TDetailProperties.ExtraValue3);
            }
            else
            {
                builder.ComponentSelect.Add(TDetailProperties.Segregation);
                builder.ComponentSelect.Add(TDetailProperties.IssueType);
                builder.ComponentSelect.Add(TDetailProperties.IssueDateTime);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.Segregation, entity.Segregation, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.IssueType, entity.IssueType, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.IssueDateTime, entity.IssueDateTime, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().Select<TDetail>(query);
        }
        /// <summary>
        /// 未查询到数据时返回 new List<T>()
        /// </summary>
        public static List<TDetail> DbSelect(this List<TDetail> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = session.GetDbQueryBuilder();
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TDetailProperties.Segregation);
                builder.ComponentSelect.Add(TDetailProperties.IssueType);
                builder.ComponentSelect.Add(TDetailProperties.IssueDateTime);
                builder.ComponentSelect.Add(TDetailProperties.IssueTimeRange);
                builder.ComponentSelect.Add(TDetailProperties.ReportName);
                builder.ComponentSelect.Add(TDetailProperties.Contractor);
                builder.ComponentSelect.Add(TDetailProperties.Supervisor);
                builder.ComponentSelect.Add(TDetailProperties.Monitor);
                builder.ComponentSelect.Add(TDetailProperties.InstrumentName);
                builder.ComponentSelect.Add(TDetailProperties.InstrumentCode);
                builder.ComponentSelect.Add(TDetailProperties.CloseCTSettings);
                builder.ComponentSelect.Add(TDetailProperties.OverCTSettings);
                builder.ComponentSelect.Add(TDetailProperties.ExtraValue1);
                builder.ComponentSelect.Add(TDetailProperties.ExtraValue2);
                builder.ComponentSelect.Add(TDetailProperties.ExtraValue3);
            }
            else
            {
                builder.ComponentSelect.Add(TDetailProperties.Segregation);
                builder.ComponentSelect.Add(TDetailProperties.IssueType);
                builder.ComponentSelect.Add(TDetailProperties.IssueDateTime);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.Segregation );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TDetailProperties.Segregation, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return session.GetQueryOperator().SelectAll<TDetail>(query);
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this TDetail entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (result == null)
            {
                return false;
            }
            if (fields.Count() == 0)
            {
                entity.IssueTimeRange = result.IssueTimeRange;
                entity.ReportName = result.ReportName;
                entity.Contractor = result.Contractor;
                entity.Supervisor = result.Supervisor;
                entity.Monitor = result.Monitor;
                entity.InstrumentName = result.InstrumentName;
                entity.InstrumentCode = result.InstrumentCode;
                entity.CloseCTSettings = result.CloseCTSettings;
                entity.OverCTSettings = result.OverCTSettings;
                entity.ExtraValue1 = result.ExtraValue1;
                entity.ExtraValue2 = result.ExtraValue2;
                entity.ExtraValue3 = result.ExtraValue3;
            }
            else
            {
                if (fields.Contains(TDetailProperties.IssueTimeRange))
                {
                    entity.IssueTimeRange = result.IssueTimeRange;
                }
                if (fields.Contains(TDetailProperties.ReportName))
                {
                    entity.ReportName = result.ReportName;
                }
                if (fields.Contains(TDetailProperties.Contractor))
                {
                    entity.Contractor = result.Contractor;
                }
                if (fields.Contains(TDetailProperties.Supervisor))
                {
                    entity.Supervisor = result.Supervisor;
                }
                if (fields.Contains(TDetailProperties.Monitor))
                {
                    entity.Monitor = result.Monitor;
                }
                if (fields.Contains(TDetailProperties.InstrumentName))
                {
                    entity.InstrumentName = result.InstrumentName;
                }
                if (fields.Contains(TDetailProperties.InstrumentCode))
                {
                    entity.InstrumentCode = result.InstrumentCode;
                }
                if (fields.Contains(TDetailProperties.CloseCTSettings))
                {
                    entity.CloseCTSettings = result.CloseCTSettings;
                }
                if (fields.Contains(TDetailProperties.OverCTSettings))
                {
                    entity.OverCTSettings = result.OverCTSettings;
                }
                if (fields.Contains(TDetailProperties.ExtraValue1))
                {
                    entity.ExtraValue1 = result.ExtraValue1;
                }
                if (fields.Contains(TDetailProperties.ExtraValue2))
                {
                    entity.ExtraValue2 = result.ExtraValue2;
                }
                if (fields.Contains(TDetailProperties.ExtraValue3))
                {
                    entity.ExtraValue3 = result.ExtraValue3;
                }
            }
            return true;
        }
        /// <summary>
        /// 存在相应对象时返回true,缺少对象时返回false
        /// </summary>
        public static bool DbLoad(this List<TDetail> entities, DbSession session, params PDMDbProperty[] fields)
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
