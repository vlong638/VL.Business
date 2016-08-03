using System;
using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace VL.Spider.Objects.Objects.Entities
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TTopic entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TTopicProperties.TopicId, entity.TopicId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TTopic>(session, query);
        }
        public static bool DbDelete(this List<TTopic> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.TopicId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TTopicProperties.TopicId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TTopic>(session, query);
        }
        public static bool DbInsert(this TTopic entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TTopicProperties.TopicId, entity.TopicId));
            if (entity.Title == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Title));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TTopicProperties.Title, entity.Title));
            if (entity.Content == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Content));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TTopicProperties.Content, entity.Content));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TTopic>(session, query);
        }
        public static bool DbInsert(this List<TTopic> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TTopicProperties.TopicId, entity.TopicId));
            if (entity.Title == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Title));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TTopicProperties.Title, entity.Title));
            if (entity.Content == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Content));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TTopicProperties.Content, entity.Content));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TTopic>(session, query);
        }
        public static bool DbUpdate(this TTopic entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TTopicProperties.TopicId, entity.TopicId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TTopicProperties.TopicId, entity.TopicId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TTopicProperties.Title, entity.Title));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TTopicProperties.Content, entity.Content));
            }
            else
            {
                if (fields.Contains(TTopicProperties.Title))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TTopicProperties.Title, entity.Title));
                }
                if (fields.Contains(TTopicProperties.Content))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TTopicProperties.Content, entity.Content));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TTopic>(session, query);
        }
        public static bool DbUpdate(this List<TTopic> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TTopicProperties.TopicId, entity.TopicId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TTopicProperties.TopicId, entity.TopicId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TTopicProperties.Title, entity.Title));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TTopicProperties.Content, entity.Content));
                }
                else
                {
                    if (fields.Contains(TTopicProperties.Title))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TTopicProperties.Title, entity.Title));
                    }
                    if (fields.Contains(TTopicProperties.Content))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TTopicProperties.Content, entity.Content));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TTopic>(session, query);
        }
        #endregion
        #region 读
        public static TTopic DbSelect(this TTopic entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TTopicProperties.TopicId);
                builder.ComponentSelect.Values.Add(TTopicProperties.Title);
                builder.ComponentSelect.Values.Add(TTopicProperties.Content);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TTopicProperties.TopicId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TTopicProperties.TopicId, entity.TopicId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TTopic>(session, query);
        }
        public static List<TTopic> DbSelect(this List<TTopic> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TTopicProperties.TopicId);
                builder.ComponentSelect.Values.Add(TTopicProperties.Title);
                builder.ComponentSelect.Values.Add(TTopicProperties.Content);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TTopicProperties.TopicId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.TopicId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TTopicProperties.TopicId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TTopic>(session, query);
        }
        public static void DbLoad(this TTopic entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TTopicProperties.Title))
            {
                entity.Title = result.Title;
            }
            if (fields.Contains(TTopicProperties.Content))
            {
                entity.Content = result.Content;
            }
        }
        public static void DbLoad(this List<TTopic> entities, DbSession session, params PDMDbProperty[] fields)
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
