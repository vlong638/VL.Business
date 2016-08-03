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
        public static bool DbDelete(this TCreatureProperty entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TCreaturePropertyProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TCreatureProperty>(session, query);
        }
        public static bool DbDelete(this List<TCreatureProperty> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.CreatureId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TCreaturePropertyProperties.CreatureId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TCreatureProperty>(session, query);
        }
        public static bool DbInsert(this TCreatureProperty entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.CreatureId, entity.CreatureId));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.HitPoint, entity.HitPoint));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.MagicPoint, entity.MagicPoint));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.Strength, entity.Strength));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.Stamina, entity.Stamina));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.Agility, entity.Agility));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.Intelligence, entity.Intelligence));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.Mentality, entity.Mentality));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TCreatureProperty>(session, query);
        }
        public static bool DbInsert(this List<TCreatureProperty> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.CreatureId, entity.CreatureId));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.HitPoint, entity.HitPoint));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.MagicPoint, entity.MagicPoint));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.Strength, entity.Strength));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.Stamina, entity.Stamina));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.Agility, entity.Agility));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.Intelligence, entity.Intelligence));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TCreaturePropertyProperties.Mentality, entity.Mentality));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TCreatureProperty>(session, query);
        }
        public static bool DbUpdate(this TCreatureProperty entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TCreaturePropertyProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.CreatureId, entity.CreatureId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.HitPoint, entity.HitPoint));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.MagicPoint, entity.MagicPoint));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Strength, entity.Strength));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Stamina, entity.Stamina));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Agility, entity.Agility));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Intelligence, entity.Intelligence));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Mentality, entity.Mentality));
            }
            else
            {
                if (fields.Contains(TCreaturePropertyProperties.HitPoint))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.HitPoint, entity.HitPoint));
                }
                if (fields.Contains(TCreaturePropertyProperties.MagicPoint))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.MagicPoint, entity.MagicPoint));
                }
                if (fields.Contains(TCreaturePropertyProperties.Strength))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Strength, entity.Strength));
                }
                if (fields.Contains(TCreaturePropertyProperties.Stamina))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Stamina, entity.Stamina));
                }
                if (fields.Contains(TCreaturePropertyProperties.Agility))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Agility, entity.Agility));
                }
                if (fields.Contains(TCreaturePropertyProperties.Intelligence))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Intelligence, entity.Intelligence));
                }
                if (fields.Contains(TCreaturePropertyProperties.Mentality))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Mentality, entity.Mentality));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TCreatureProperty>(session, query);
        }
        public static bool DbUpdate(this List<TCreatureProperty> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TCreaturePropertyProperties.CreatureId, entity.CreatureId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.CreatureId, entity.CreatureId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.HitPoint, entity.HitPoint));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.MagicPoint, entity.MagicPoint));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Strength, entity.Strength));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Stamina, entity.Stamina));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Agility, entity.Agility));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Intelligence, entity.Intelligence));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Mentality, entity.Mentality));
                }
                else
                {
                    if (fields.Contains(TCreaturePropertyProperties.HitPoint))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.HitPoint, entity.HitPoint));
                    }
                    if (fields.Contains(TCreaturePropertyProperties.MagicPoint))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.MagicPoint, entity.MagicPoint));
                    }
                    if (fields.Contains(TCreaturePropertyProperties.Strength))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Strength, entity.Strength));
                    }
                    if (fields.Contains(TCreaturePropertyProperties.Stamina))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Stamina, entity.Stamina));
                    }
                    if (fields.Contains(TCreaturePropertyProperties.Agility))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Agility, entity.Agility));
                    }
                    if (fields.Contains(TCreaturePropertyProperties.Intelligence))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Intelligence, entity.Intelligence));
                    }
                    if (fields.Contains(TCreaturePropertyProperties.Mentality))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TCreaturePropertyProperties.Mentality, entity.Mentality));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TCreatureProperty>(session, query);
        }
        #endregion
        #region 读
        public static TCreatureProperty DbSelect(this TCreatureProperty entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.CreatureId);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.HitPoint);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.MagicPoint);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.Strength);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.Stamina);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.Agility);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.Intelligence);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.Mentality);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.CreatureId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TCreaturePropertyProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TCreatureProperty>(session, query);
        }
        public static List<TCreatureProperty> DbSelect(this List<TCreatureProperty> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.CreatureId);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.HitPoint);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.MagicPoint);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.Strength);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.Stamina);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.Agility);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.Intelligence);
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.Mentality);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TCreaturePropertyProperties.CreatureId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.CreatureId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TCreaturePropertyProperties.CreatureId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TCreatureProperty>(session, query);
        }
        public static void DbLoad(this TCreatureProperty entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TCreaturePropertyProperties.HitPoint))
            {
                entity.HitPoint = result.HitPoint;
            }
            if (fields.Contains(TCreaturePropertyProperties.MagicPoint))
            {
                entity.MagicPoint = result.MagicPoint;
            }
            if (fields.Contains(TCreaturePropertyProperties.Strength))
            {
                entity.Strength = result.Strength;
            }
            if (fields.Contains(TCreaturePropertyProperties.Stamina))
            {
                entity.Stamina = result.Stamina;
            }
            if (fields.Contains(TCreaturePropertyProperties.Agility))
            {
                entity.Agility = result.Agility;
            }
            if (fields.Contains(TCreaturePropertyProperties.Intelligence))
            {
                entity.Intelligence = result.Intelligence;
            }
            if (fields.Contains(TCreaturePropertyProperties.Mentality))
            {
                entity.Mentality = result.Mentality;
            }
        }
        public static void DbLoad(this List<TCreatureProperty> entities, DbSession session, params PDMDbProperty[] fields)
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
