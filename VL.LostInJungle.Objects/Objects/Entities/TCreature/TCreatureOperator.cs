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
        public static bool DbDelete(this TCreature entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            return IORMProvider.GetQueryOperator(session).Delete<TCreature>(session, query);
        }
        public static bool DbDelete(this List<TCreature> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.CreatureId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureProperties.CreatureId, OperatorType.In, Ids));
            return IORMProvider.GetQueryOperator(session).Delete<TCreature>(session, query);
        }
        public static bool DbInsert(this TCreature entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.CreatureId, entity.CreatureId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.CreatureType, entity.CreatureType));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Name, entity.Name));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Experience, entity.Experience));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Level, entity.Level));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Profession, entity.Profession));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TCreature>(session, query);
        }
        public static bool DbInsert(this List<TCreature> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.CreatureId, entity.CreatureId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.CreatureType, entity.CreatureType));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Name, entity.Name));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Experience, entity.Experience));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Level, entity.Level));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Profession, entity.Profession));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TCreature>(session, query);
        }
        public static bool DbUpdate(this TCreature entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            if (fields.Contains(TCreatureProperties.CreatureType.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.CreatureType, entity.CreatureType));
            }
            if (fields.Contains(TCreatureProperties.Name.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Name, entity.Name));
            }
            if (fields.Contains(TCreatureProperties.Experience.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Experience, entity.Experience));
            }
            if (fields.Contains(TCreatureProperties.Level.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Level, entity.Level));
            }
            if (fields.Contains(TCreatureProperties.Profession.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Profession, entity.Profession));
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TCreature>(session, query);
        }
        public static bool DbUpdate(this List<TCreature> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
                if (fields.Contains(TCreatureProperties.CreatureType.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.CreatureType, entity.CreatureType));
                }
                if (fields.Contains(TCreatureProperties.Name.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Name, entity.Name));
                }
                if (fields.Contains(TCreatureProperties.Experience.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Experience, entity.Experience));
                }
                if (fields.Contains(TCreatureProperties.Level.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Level, entity.Level));
                }
                if (fields.Contains(TCreatureProperties.Profession.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureProperties.Profession, entity.Profession));
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TCreature>(session, query);
        }
        #endregion
        #region 读
        public static TCreature DbSelect(this TCreature entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TCreature>(session, query);
        }
        public static List<TCreature> DbSelect(this List<TCreature> entities, DbSession session, params string[] fields)
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
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureProperties.CreatureId, OperatorType.In, Ids));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TCreature>(session, query);
        }
        #endregion
        #endregion
    }
}
