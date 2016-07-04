using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
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
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TPrototypeCreatureProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            return IORMProvider.GetQueryOperator(session).Delete<TPrototypeCreature>(session, query);
        }
        public static bool DbDelete(this List<TPrototypeCreature> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.CreatureId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TPrototypeCreatureProperties.CreatureId, OperatorType.In, Ids));
            return IORMProvider.GetQueryOperator(session).Delete<TPrototypeCreature>(session, query);
        }
        public static bool DbInsert(this TPrototypeCreature entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.CreatureId, entity.CreatureId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.CreatureType, entity.CreatureType));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.CreatureUseType, entity.CreatureUseType));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Name, entity.Name));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Level, entity.Level));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Profession, entity.Profession));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Properties, entity.Properties));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Skills, entity.Skills));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Qualities, entity.Qualities));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TPrototypeCreature>(session, query);
        }
        public static bool DbInsert(this List<TPrototypeCreature> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.CreatureId, entity.CreatureId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.CreatureType, entity.CreatureType));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.CreatureUseType, entity.CreatureUseType));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Name, entity.Name));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Level, entity.Level));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Profession, entity.Profession));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Properties, entity.Properties));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Skills, entity.Skills));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Qualities, entity.Qualities));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TPrototypeCreature>(session, query);
        }
        public static bool DbUpdate(this TPrototypeCreature entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TPrototypeCreatureProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            if (fields.Contains(TPrototypeCreatureProperties.CreatureType.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.CreatureType, entity.CreatureType));
            }
            if (fields.Contains(TPrototypeCreatureProperties.CreatureUseType.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.CreatureUseType, entity.CreatureUseType));
            }
            if (fields.Contains(TPrototypeCreatureProperties.Name.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Name, entity.Name));
            }
            if (fields.Contains(TPrototypeCreatureProperties.Level.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Level, entity.Level));
            }
            if (fields.Contains(TPrototypeCreatureProperties.Profession.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Profession, entity.Profession));
            }
            if (fields.Contains(TPrototypeCreatureProperties.Properties.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Properties, entity.Properties));
            }
            if (fields.Contains(TPrototypeCreatureProperties.Skills.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Skills, entity.Skills));
            }
            if (fields.Contains(TPrototypeCreatureProperties.Qualities.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Qualities, entity.Qualities));
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TPrototypeCreature>(session, query);
        }
        public static bool DbUpdate(this List<TPrototypeCreature> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TPrototypeCreatureProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
                if (fields.Contains(TPrototypeCreatureProperties.CreatureType.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.CreatureType, entity.CreatureType));
                }
                if (fields.Contains(TPrototypeCreatureProperties.CreatureUseType.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.CreatureUseType, entity.CreatureUseType));
                }
                if (fields.Contains(TPrototypeCreatureProperties.Name.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Name, entity.Name));
                }
                if (fields.Contains(TPrototypeCreatureProperties.Level.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Level, entity.Level));
                }
                if (fields.Contains(TPrototypeCreatureProperties.Profession.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Profession, entity.Profession));
                }
                if (fields.Contains(TPrototypeCreatureProperties.Properties.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Properties, entity.Properties));
                }
                if (fields.Contains(TPrototypeCreatureProperties.Skills.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Skills, entity.Skills));
                }
                if (fields.Contains(TPrototypeCreatureProperties.Qualities.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TPrototypeCreatureProperties.Qualities, entity.Qualities));
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TPrototypeCreature>(session, query);
        }
        #endregion
        #region 读
        public static TPrototypeCreature DbSelect(this TPrototypeCreature entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TPrototypeCreatureProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TPrototypeCreature>(session, query);
        }
        public static List<TPrototypeCreature> DbSelect(this List<TPrototypeCreature> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            var Ids = entities.Select(c =>c.CreatureId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TPrototypeCreatureProperties.CreatureId, OperatorType.In, Ids));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TPrototypeCreature>(session, query);
        }
        #endregion
        #endregion
    }
}
