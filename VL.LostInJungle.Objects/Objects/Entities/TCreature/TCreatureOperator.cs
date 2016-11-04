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
        public static bool DbDelete(this TCreature entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TCreature>(session, query);
        }
        public static bool DbDelete(this List<TCreature> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.CreatureId );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureProperties.CreatureId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TCreature>(session, query);
        }
        public static bool DbInsert(this TCreature entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureProperties.CreatureId, entity.CreatureId));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureProperties.CreatureType, entity.CreatureType));
            if (entity.Name == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Name));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureProperties.Name, entity.Name));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureProperties.Experience, entity.Experience));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureProperties.Level, entity.Level));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureProperties.Profession, entity.Profession));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TCreature>(session, query);
        }
        public static bool DbInsert(this List<TCreature> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureProperties.CreatureId, entity.CreatureId));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureProperties.CreatureType, entity.CreatureType));
            if (entity.Name == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Name));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureProperties.Name, entity.Name));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureProperties.Experience, entity.Experience));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureProperties.Level, entity.Level));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureProperties.Profession, entity.Profession));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TCreature>(session, query);
        }
        public static bool DbUpdate(this TCreature entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.CreatureId, entity.CreatureId));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.CreatureType, entity.CreatureType));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Name, entity.Name));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Experience, entity.Experience));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Level, entity.Level));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Profession, entity.Profession));
            }
            else
            {
                if (fields.Contains(TCreatureProperties.CreatureType))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.CreatureType, entity.CreatureType));
                }
                if (fields.Contains(TCreatureProperties.Name))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Name, entity.Name));
                }
                if (fields.Contains(TCreatureProperties.Experience))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Experience, entity.Experience));
                }
                if (fields.Contains(TCreatureProperties.Level))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Level, entity.Level));
                }
                if (fields.Contains(TCreatureProperties.Profession))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Profession, entity.Profession));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TCreature>(session, query);
        }
        public static bool DbUpdate(this List<TCreature> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureProperties.CreatureId, entity.CreatureId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.CreatureId, entity.CreatureId));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.CreatureType, entity.CreatureType));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Name, entity.Name));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Experience, entity.Experience));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Level, entity.Level));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Profession, entity.Profession));
                }
                else
                {
                    if (fields.Contains(TCreatureProperties.CreatureType))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.CreatureType, entity.CreatureType));
                    }
                    if (fields.Contains(TCreatureProperties.Name))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Name, entity.Name));
                    }
                    if (fields.Contains(TCreatureProperties.Experience))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Experience, entity.Experience));
                    }
                    if (fields.Contains(TCreatureProperties.Level))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Level, entity.Level));
                    }
                    if (fields.Contains(TCreatureProperties.Profession))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureProperties.Profession, entity.Profession));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TCreature>(session, query);
        }
        #endregion
        #region 读
        public static TCreature DbSelect(this TCreature entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TCreatureProperties.CreatureId);
                builder.ComponentSelect.Add(TCreatureProperties.CreatureType);
                builder.ComponentSelect.Add(TCreatureProperties.Name);
                builder.ComponentSelect.Add(TCreatureProperties.Experience);
                builder.ComponentSelect.Add(TCreatureProperties.Level);
                builder.ComponentSelect.Add(TCreatureProperties.Profession);
            }
            else
            {
                builder.ComponentSelect.Add(TCreatureProperties.CreatureId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TCreature>(session, query);
        }
        public static List<TCreature> DbSelect(this List<TCreature> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TCreatureProperties.CreatureId);
                builder.ComponentSelect.Add(TCreatureProperties.CreatureType);
                builder.ComponentSelect.Add(TCreatureProperties.Name);
                builder.ComponentSelect.Add(TCreatureProperties.Experience);
                builder.ComponentSelect.Add(TCreatureProperties.Level);
                builder.ComponentSelect.Add(TCreatureProperties.Profession);
            }
            else
            {
                builder.ComponentSelect.Add(TCreatureProperties.CreatureId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.CreatureId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureProperties.CreatureId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TCreature>(session, query);
        }
        public static void DbLoad(this TCreature entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TCreatureProperties.CreatureType))
            {
                entity.CreatureType = result.CreatureType;
            }
            if (fields.Contains(TCreatureProperties.Name))
            {
                entity.Name = result.Name;
            }
            if (fields.Contains(TCreatureProperties.Experience))
            {
                entity.Experience = result.Experience;
            }
            if (fields.Contains(TCreatureProperties.Level))
            {
                entity.Level = result.Level;
            }
            if (fields.Contains(TCreatureProperties.Profession))
            {
                entity.Profession = result.Profession;
            }
        }
        public static void DbLoad(this List<TCreature> entities, DbSession session, params PDMDbProperty[] fields)
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
