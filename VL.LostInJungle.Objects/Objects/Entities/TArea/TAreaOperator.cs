using System;
using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace VL.LostInJungle.Objects.Entities
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TArea entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaProperties.AreaId, entity.AreaId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TArea>(session, query);
        }
        public static bool DbDelete(this List<TArea> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.AreaId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaProperties.AreaId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TArea>(session, query);
        }
        public static bool DbInsert(this TArea entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaProperties.AreaId, entity.AreaId));
            if (entity.AreaName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.AreaName));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaProperties.AreaName, entity.AreaName));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaProperties.AreaLevel, entity.AreaLevel));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaProperties.AreaType, entity.AreaType));
            if (entity.Description == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Description));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaProperties.Description, entity.Description));
            if (entity.DescriptionEx == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.DescriptionEx));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaProperties.DescriptionEx, entity.DescriptionEx));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TArea>(session, query);
        }
        public static bool DbInsert(this List<TArea> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaProperties.AreaId, entity.AreaId));
            if (entity.AreaName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.AreaName));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaProperties.AreaName, entity.AreaName));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaProperties.AreaLevel, entity.AreaLevel));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaProperties.AreaType, entity.AreaType));
            if (entity.Description == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Description));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaProperties.Description, entity.Description));
            if (entity.DescriptionEx == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.DescriptionEx));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TAreaProperties.DescriptionEx, entity.DescriptionEx));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TArea>(session, query);
        }
        public static bool DbUpdate(this TArea entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaProperties.AreaId, entity.AreaId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaId, entity.AreaId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaName, entity.AreaName));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaLevel, entity.AreaLevel));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaType, entity.AreaType));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.Description, entity.Description));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.DescriptionEx, entity.DescriptionEx));
            }
            else
            {
                if (fields.Contains(TAreaProperties.AreaName))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaName, entity.AreaName));
                }
                if (fields.Contains(TAreaProperties.AreaLevel))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaLevel, entity.AreaLevel));
                }
                if (fields.Contains(TAreaProperties.AreaType))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaType, entity.AreaType));
                }
                if (fields.Contains(TAreaProperties.Description))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.Description, entity.Description));
                }
                if (fields.Contains(TAreaProperties.DescriptionEx))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.DescriptionEx, entity.DescriptionEx));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TArea>(session, query);
        }
        public static bool DbUpdate(this List<TArea> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaProperties.AreaId, entity.AreaId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaId, entity.AreaId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaName, entity.AreaName));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaLevel, entity.AreaLevel));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaType, entity.AreaType));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.Description, entity.Description));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.DescriptionEx, entity.DescriptionEx));
                }
                else
                {
                    if (fields.Contains(TAreaProperties.AreaName))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaName, entity.AreaName));
                    }
                    if (fields.Contains(TAreaProperties.AreaLevel))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaLevel, entity.AreaLevel));
                    }
                    if (fields.Contains(TAreaProperties.AreaType))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.AreaType, entity.AreaType));
                    }
                    if (fields.Contains(TAreaProperties.Description))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.Description, entity.Description));
                    }
                    if (fields.Contains(TAreaProperties.DescriptionEx))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TAreaProperties.DescriptionEx, entity.DescriptionEx));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TArea>(session, query);
        }
        #endregion
        #region 读
        public static TArea DbSelect(this TArea entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TAreaProperties.AreaId);
                builder.ComponentSelect.Values.Add(TAreaProperties.AreaName);
                builder.ComponentSelect.Values.Add(TAreaProperties.AreaLevel);
                builder.ComponentSelect.Values.Add(TAreaProperties.AreaType);
                builder.ComponentSelect.Values.Add(TAreaProperties.Description);
                builder.ComponentSelect.Values.Add(TAreaProperties.DescriptionEx);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TAreaProperties.AreaId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaProperties.AreaId, entity.AreaId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TArea>(session, query);
        }
        public static List<TArea> DbSelect(this List<TArea> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TAreaProperties.AreaId);
                builder.ComponentSelect.Values.Add(TAreaProperties.AreaName);
                builder.ComponentSelect.Values.Add(TAreaProperties.AreaLevel);
                builder.ComponentSelect.Values.Add(TAreaProperties.AreaType);
                builder.ComponentSelect.Values.Add(TAreaProperties.Description);
                builder.ComponentSelect.Values.Add(TAreaProperties.DescriptionEx);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TAreaProperties.AreaId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.AreaId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TAreaProperties.AreaId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TArea>(session, query);
        }
        public static void DbLoad(this TArea entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TAreaProperties.AreaName))
            {
                entity.AreaName = result.AreaName;
            }
            if (fields.Contains(TAreaProperties.AreaLevel))
            {
                entity.AreaLevel = result.AreaLevel;
            }
            if (fields.Contains(TAreaProperties.AreaType))
            {
                entity.AreaType = result.AreaType;
            }
            if (fields.Contains(TAreaProperties.Description))
            {
                entity.Description = result.Description;
            }
            if (fields.Contains(TAreaProperties.DescriptionEx))
            {
                entity.DescriptionEx = result.DescriptionEx;
            }
        }
        public static void DbLoad(this List<TArea> entities, DbSession session, params PDMDbProperty[] fields)
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
