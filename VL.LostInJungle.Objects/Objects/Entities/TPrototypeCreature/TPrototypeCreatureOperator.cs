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
        public static bool DbDelete(this TPrototypeCreature entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TPrototypeCreatureProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TPrototypeCreature>(session, query);
        }
        public static bool DbDelete(this List<TPrototypeCreature> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.CreatureId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TPrototypeCreatureProperties.CreatureId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TPrototypeCreature>(session, query);
        }
        public static bool DbInsert(this TPrototypeCreature entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.CreatureId, entity.CreatureId));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.CreatureType, entity.CreatureType));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.CreatureUseType, entity.CreatureUseType));
            if (entity.Name == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Name));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.Name, entity.Name));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.Level, entity.Level));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.Profession, entity.Profession));
            if (entity.Properties == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Properties));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.Properties, entity.Properties));
            if (entity.Skills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Skills));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.Skills, entity.Skills));
            if (entity.Qualities == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Qualities));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.Qualities, entity.Qualities));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TPrototypeCreature>(session, query);
        }
        public static bool DbInsert(this List<TPrototypeCreature> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.CreatureId, entity.CreatureId));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.CreatureType, entity.CreatureType));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.CreatureUseType, entity.CreatureUseType));
            if (entity.Name == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Name));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.Name, entity.Name));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.Level, entity.Level));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.Profession, entity.Profession));
            if (entity.Properties == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Properties));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.Properties, entity.Properties));
            if (entity.Skills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Skills));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.Skills, entity.Skills));
            if (entity.Qualities == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Qualities));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TPrototypeCreatureProperties.Qualities, entity.Qualities));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TPrototypeCreature>(session, query);
        }
        public static bool DbUpdate(this TPrototypeCreature entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TPrototypeCreatureProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.CreatureId, entity.CreatureId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.CreatureType, entity.CreatureType));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.CreatureUseType, entity.CreatureUseType));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Name, entity.Name));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Level, entity.Level));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Profession, entity.Profession));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Properties, entity.Properties));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Skills, entity.Skills));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Qualities, entity.Qualities));
            }
            else
            {
                if (fields.Contains(TPrototypeCreatureProperties.CreatureType))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.CreatureType, entity.CreatureType));
                }
                if (fields.Contains(TPrototypeCreatureProperties.CreatureUseType))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.CreatureUseType, entity.CreatureUseType));
                }
                if (fields.Contains(TPrototypeCreatureProperties.Name))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Name, entity.Name));
                }
                if (fields.Contains(TPrototypeCreatureProperties.Level))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Level, entity.Level));
                }
                if (fields.Contains(TPrototypeCreatureProperties.Profession))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Profession, entity.Profession));
                }
                if (fields.Contains(TPrototypeCreatureProperties.Properties))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Properties, entity.Properties));
                }
                if (fields.Contains(TPrototypeCreatureProperties.Skills))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Skills, entity.Skills));
                }
                if (fields.Contains(TPrototypeCreatureProperties.Qualities))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Qualities, entity.Qualities));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TPrototypeCreature>(session, query);
        }
        public static bool DbUpdate(this List<TPrototypeCreature> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TPrototypeCreatureProperties.CreatureId, entity.CreatureId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.CreatureId, entity.CreatureId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.CreatureType, entity.CreatureType));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.CreatureUseType, entity.CreatureUseType));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Name, entity.Name));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Level, entity.Level));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Profession, entity.Profession));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Properties, entity.Properties));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Skills, entity.Skills));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Qualities, entity.Qualities));
                }
                else
                {
                    if (fields.Contains(TPrototypeCreatureProperties.CreatureType))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.CreatureType, entity.CreatureType));
                    }
                    if (fields.Contains(TPrototypeCreatureProperties.CreatureUseType))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.CreatureUseType, entity.CreatureUseType));
                    }
                    if (fields.Contains(TPrototypeCreatureProperties.Name))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Name, entity.Name));
                    }
                    if (fields.Contains(TPrototypeCreatureProperties.Level))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Level, entity.Level));
                    }
                    if (fields.Contains(TPrototypeCreatureProperties.Profession))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Profession, entity.Profession));
                    }
                    if (fields.Contains(TPrototypeCreatureProperties.Properties))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Properties, entity.Properties));
                    }
                    if (fields.Contains(TPrototypeCreatureProperties.Skills))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Skills, entity.Skills));
                    }
                    if (fields.Contains(TPrototypeCreatureProperties.Qualities))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TPrototypeCreatureProperties.Qualities, entity.Qualities));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TPrototypeCreature>(session, query);
        }
        #endregion
        #region 读
        public static TPrototypeCreature DbSelect(this TPrototypeCreature entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.CreatureId);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.CreatureType);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.CreatureUseType);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.Name);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.Level);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.Profession);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.Properties);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.Skills);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.Qualities);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.CreatureId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TPrototypeCreatureProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TPrototypeCreature>(session, query);
        }
        public static List<TPrototypeCreature> DbSelect(this List<TPrototypeCreature> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.CreatureId);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.CreatureType);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.CreatureUseType);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.Name);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.Level);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.Profession);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.Properties);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.Skills);
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.Qualities);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TPrototypeCreatureProperties.CreatureId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.CreatureId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TPrototypeCreatureProperties.CreatureId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TPrototypeCreature>(session, query);
        }
        public static void DbLoad(this TPrototypeCreature entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TPrototypeCreatureProperties.CreatureType))
            {
                entity.CreatureType = result.CreatureType;
            }
            if (fields.Contains(TPrototypeCreatureProperties.CreatureUseType))
            {
                entity.CreatureUseType = result.CreatureUseType;
            }
            if (fields.Contains(TPrototypeCreatureProperties.Name))
            {
                entity.Name = result.Name;
            }
            if (fields.Contains(TPrototypeCreatureProperties.Level))
            {
                entity.Level = result.Level;
            }
            if (fields.Contains(TPrototypeCreatureProperties.Profession))
            {
                entity.Profession = result.Profession;
            }
            if (fields.Contains(TPrototypeCreatureProperties.Properties))
            {
                entity.Properties = result.Properties;
            }
            if (fields.Contains(TPrototypeCreatureProperties.Skills))
            {
                entity.Skills = result.Skills;
            }
            if (fields.Contains(TPrototypeCreatureProperties.Qualities))
            {
                entity.Qualities = result.Qualities;
            }
        }
        public static void DbLoad(this List<TPrototypeCreature> entities, DbSession session, params PDMDbProperty[] fields)
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
