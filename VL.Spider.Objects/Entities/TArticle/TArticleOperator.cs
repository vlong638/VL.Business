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
        public static bool DbDelete(this TArticle entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TArticleProperties.ArticleId, entity.ArticleId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TArticle>(session, query);
        }
        public static bool DbDelete(this List<TArticle> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.ArticleId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TArticleProperties.ArticleId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TArticle>(session, query);
        }
        public static bool DbInsert(this TArticle entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TArticleProperties.SouceId, entity.SouceId));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TArticleProperties.ArticleId, entity.ArticleId));
            if (entity.Title == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Title));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TArticleProperties.Title, entity.Title));
            if (entity.Content == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Content));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TArticleProperties.Content, entity.Content));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TArticle>(session, query);
        }
        public static bool DbInsert(this List<TArticle> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TArticleProperties.SouceId, entity.SouceId));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TArticleProperties.ArticleId, entity.ArticleId));
            if (entity.Title == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Title));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TArticleProperties.Title, entity.Title));
            if (entity.Content == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Content));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TArticleProperties.Content, entity.Content));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TArticle>(session, query);
        }
        public static bool DbUpdate(this TArticle entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TArticleProperties.ArticleId, entity.ArticleId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.SouceId, entity.SouceId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.ArticleId, entity.ArticleId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.Title, entity.Title));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.Content, entity.Content));
            }
            else
            {
                if (fields.Contains(TArticleProperties.SouceId))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.SouceId, entity.SouceId));
                }
                if (fields.Contains(TArticleProperties.Title))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.Title, entity.Title));
                }
                if (fields.Contains(TArticleProperties.Content))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.Content, entity.Content));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TArticle>(session, query);
        }
        public static bool DbUpdate(this List<TArticle> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TArticleProperties.ArticleId, entity.ArticleId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.SouceId, entity.SouceId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.ArticleId, entity.ArticleId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.Title, entity.Title));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.Content, entity.Content));
                }
                else
                {
                    if (fields.Contains(TArticleProperties.SouceId))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.SouceId, entity.SouceId));
                    }
                    if (fields.Contains(TArticleProperties.Title))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.Title, entity.Title));
                    }
                    if (fields.Contains(TArticleProperties.Content))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TArticleProperties.Content, entity.Content));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TArticle>(session, query);
        }
        #endregion
        #region 读
        public static TArticle DbSelect(this TArticle entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TArticleProperties.SouceId);
                builder.ComponentSelect.Values.Add(TArticleProperties.ArticleId);
                builder.ComponentSelect.Values.Add(TArticleProperties.Title);
                builder.ComponentSelect.Values.Add(TArticleProperties.Content);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TArticleProperties.ArticleId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TArticleProperties.ArticleId, entity.ArticleId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TArticle>(session, query);
        }
        public static List<TArticle> DbSelect(this List<TArticle> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TArticleProperties.SouceId);
                builder.ComponentSelect.Values.Add(TArticleProperties.ArticleId);
                builder.ComponentSelect.Values.Add(TArticleProperties.Title);
                builder.ComponentSelect.Values.Add(TArticleProperties.Content);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TArticleProperties.ArticleId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.ArticleId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TArticleProperties.ArticleId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TArticle>(session, query);
        }
        public static void DbLoad(this TArticle entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TArticleProperties.SouceId))
            {
                entity.SouceId = result.SouceId;
            }
            if (fields.Contains(TArticleProperties.Title))
            {
                entity.Title = result.Title;
            }
            if (fields.Contains(TArticleProperties.Content))
            {
                entity.Content = result.Content;
            }
        }
        public static void DbLoad(this List<TArticle> entities, DbSession session, params PDMDbProperty[] fields)
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
