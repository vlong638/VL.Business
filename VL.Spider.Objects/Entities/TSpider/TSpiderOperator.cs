using System;
using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace VL.Spider.Objects.Entities
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TSpider entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TSpiderProperties.SpiderId, entity.SpiderId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TSpider>(session, query);
        }
        public static bool DbDelete(this List<TSpider> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.SpiderId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TSpiderProperties.SpiderId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TSpider>(session, query);
        }
        public static bool DbInsert(this TSpider entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TSpiderProperties.SpiderId, entity.SpiderId));
            if (entity.SpiderName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.SpiderName));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TSpiderProperties.SpiderName, entity.SpiderName));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TSpider>(session, query);
        }
        public static bool DbInsert(this List<TSpider> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TSpiderProperties.SpiderId, entity.SpiderId));
            if (entity.SpiderName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.SpiderName));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TSpiderProperties.SpiderName, entity.SpiderName));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TSpider>(session, query);
        }
        public static bool DbUpdate(this TSpider entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TSpiderProperties.SpiderId, entity.SpiderId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TSpiderProperties.SpiderId, entity.SpiderId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TSpiderProperties.SpiderName, entity.SpiderName));
            }
            else
            {
                if (fields.Contains(TSpiderProperties.SpiderName))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TSpiderProperties.SpiderName, entity.SpiderName));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TSpider>(session, query);
        }
        public static bool DbUpdate(this List<TSpider> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TSpiderProperties.SpiderId, entity.SpiderId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TSpiderProperties.SpiderId, entity.SpiderId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TSpiderProperties.SpiderName, entity.SpiderName));
                }
                else
                {
                    if (fields.Contains(TSpiderProperties.SpiderName))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TSpiderProperties.SpiderName, entity.SpiderName));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TSpider>(session, query);
        }
        #endregion
        #region 读
        public static TSpider DbSelect(this TSpider entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TSpiderProperties.SpiderId);
                builder.ComponentSelect.Values.Add(TSpiderProperties.SpiderName);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TSpiderProperties.SpiderId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TSpiderProperties.SpiderId, entity.SpiderId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TSpider>(session, query);
        }
        public static List<TSpider> DbSelect(this List<TSpider> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TSpiderProperties.SpiderId);
                builder.ComponentSelect.Values.Add(TSpiderProperties.SpiderName);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TSpiderProperties.SpiderId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.SpiderId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TSpiderProperties.SpiderId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TSpider>(session, query);
        }
        public static void DbLoad(this TSpider entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TSpiderProperties.SpiderName))
            {
                entity.SpiderName = result.SpiderName;
            }
        }
        public static void DbLoad(this List<TSpider> entities, DbSession session, params PDMDbProperty[] fields)
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
