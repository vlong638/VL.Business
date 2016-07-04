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
        public static bool DbDelete(this TCreatureQuality entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureQualityProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            return IORMProvider.GetQueryOperator(session).Delete<TCreatureQuality>(session, query);
        }
        public static bool DbDelete(this List<TCreatureQuality> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.CreatureId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureQualityProperties.CreatureId, OperatorType.In, Ids));
            return IORMProvider.GetQueryOperator(session).Delete<TCreatureQuality>(session, query);
        }
        public static bool DbInsert(this TCreatureQuality entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.CreatureId, entity.CreatureId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.FirstLevelQuality, entity.FirstLevelQuality));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.SecondLevelQuality, entity.SecondLevelQuality));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.ThirdLevelQuality, entity.ThirdLevelQuality));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TCreatureQuality>(session, query);
        }
        public static bool DbInsert(this List<TCreatureQuality> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.CreatureId, entity.CreatureId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.FirstLevelQuality, entity.FirstLevelQuality));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.SecondLevelQuality, entity.SecondLevelQuality));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.ThirdLevelQuality, entity.ThirdLevelQuality));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TCreatureQuality>(session, query);
        }
        public static bool DbUpdate(this TCreatureQuality entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureQualityProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            if (fields.Contains(TCreatureQualityProperties.FirstLevelQuality.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.FirstLevelQuality, entity.FirstLevelQuality));
            }
            if (fields.Contains(TCreatureQualityProperties.SecondLevelQuality.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.SecondLevelQuality, entity.SecondLevelQuality));
            }
            if (fields.Contains(TCreatureQualityProperties.ThirdLevelQuality.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.ThirdLevelQuality, entity.ThirdLevelQuality));
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TCreatureQuality>(session, query);
        }
        public static bool DbUpdate(this List<TCreatureQuality> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureQualityProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
                if (fields.Contains(TCreatureQualityProperties.FirstLevelQuality.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.FirstLevelQuality, entity.FirstLevelQuality));
                }
                if (fields.Contains(TCreatureQualityProperties.SecondLevelQuality.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.SecondLevelQuality, entity.SecondLevelQuality));
                }
                if (fields.Contains(TCreatureQualityProperties.ThirdLevelQuality.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureQualityProperties.ThirdLevelQuality, entity.ThirdLevelQuality));
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TCreatureQuality>(session, query);
        }
        #endregion
        #region 读
        public static TCreatureQuality DbSelect(this TCreatureQuality entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureQualityProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TCreatureQuality>(session, query);
        }
        public static List<TCreatureQuality> DbSelect(this List<TCreatureQuality> entities, DbSession session, params string[] fields)
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
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureQualityProperties.CreatureId, OperatorType.In, Ids));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TCreatureQuality>(session, query);
        }
        #endregion
        #endregion
    }
}
