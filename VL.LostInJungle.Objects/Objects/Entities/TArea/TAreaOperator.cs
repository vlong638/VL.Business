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
        public static bool DbDelete(this TArea entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaProperties.AreaId, OperatorType.Equal, entity.AreaId));
            return IORMProvider.GetQueryOperator(session).Delete<TArea>(session, query);
        }
        public static bool DbDelete(this List<TArea> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.AreaId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaProperties.AreaId, OperatorType.In, Ids));
            return IORMProvider.GetQueryOperator(session).Delete<TArea>(session, query);
        }
        public static bool DbInsert(this TArea entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaId, entity.AreaId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaName, entity.AreaName));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaLevel, entity.AreaLevel));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaType, entity.AreaType));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.Description, entity.Description));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.DescriptionEx, entity.DescriptionEx));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TArea>(session, query);
        }
        public static bool DbInsert(this List<TArea> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaId, entity.AreaId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaName, entity.AreaName));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaLevel, entity.AreaLevel));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaType, entity.AreaType));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.Description, entity.Description));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.DescriptionEx, entity.DescriptionEx));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TArea>(session, query);
        }
        public static bool DbUpdate(this TArea entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaProperties.AreaId, OperatorType.Equal, entity.AreaId));
            if (fields.Contains(TAreaProperties.AreaName.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaName, entity.AreaName));
            }
            if (fields.Contains(TAreaProperties.AreaLevel.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaLevel, entity.AreaLevel));
            }
            if (fields.Contains(TAreaProperties.AreaType.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaType, entity.AreaType));
            }
            if (fields.Contains(TAreaProperties.Description.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.Description, entity.Description));
            }
            if (fields.Contains(TAreaProperties.DescriptionEx.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.DescriptionEx, entity.DescriptionEx));
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TArea>(session, query);
        }
        public static bool DbUpdate(this List<TArea> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaProperties.AreaId, OperatorType.Equal, entity.AreaId));
                if (fields.Contains(TAreaProperties.AreaName.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaName, entity.AreaName));
                }
                if (fields.Contains(TAreaProperties.AreaLevel.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaLevel, entity.AreaLevel));
                }
                if (fields.Contains(TAreaProperties.AreaType.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.AreaType, entity.AreaType));
                }
                if (fields.Contains(TAreaProperties.Description.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.Description, entity.Description));
                }
                if (fields.Contains(TAreaProperties.DescriptionEx.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TAreaProperties.DescriptionEx, entity.DescriptionEx));
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TArea>(session, query);
        }
        #endregion
        #region 读
        public static TArea DbSelect(this TArea entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaProperties.AreaId, OperatorType.Equal, entity.AreaId));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TArea>(session, query);
        }
        public static List<TArea> DbSelect(this List<TArea> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            var Ids = entities.Select(c =>c.AreaId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TAreaProperties.AreaId, OperatorType.In, Ids));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TArea>(session, query);
        }
        #endregion
        #endregion
    }
}
