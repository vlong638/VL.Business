using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace VL.User.Objects.Entities
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TUserBasicInfo entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserBasicInfoProperties.UserId, OperatorType.Equal, entity.UserId));
            return IORMProvider.GetQueryOperator(session).Delete<TUserBasicInfo>(session, query);
        }
        public static bool DbDelete(this List<TUserBasicInfo> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.UserId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserBasicInfoProperties.UserId, OperatorType.In, Ids));
            return IORMProvider.GetQueryOperator(session).Delete<TUserBasicInfo>(session, query);
        }
        public static bool DbInsert(this TUserBasicInfo entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.UserId, entity.UserId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Gender, entity.Gender));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Birthday, entity.Birthday));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Mobile, entity.Mobile));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Email, entity.Email));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TUserBasicInfo>(session, query);
        }
        public static bool DbInsert(this List<TUserBasicInfo> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.UserId, entity.UserId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Gender, entity.Gender));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Birthday, entity.Birthday));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Mobile, entity.Mobile));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Email, entity.Email));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TUserBasicInfo>(session, query);
        }
        public static bool DbUpdate(this TUserBasicInfo entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserBasicInfoProperties.UserId, OperatorType.Equal, entity.UserId));
            if (fields.Contains(TUserBasicInfoProperties.Gender.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Gender, entity.Gender));
            }
            if (fields.Contains(TUserBasicInfoProperties.Birthday.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Birthday, entity.Birthday));
            }
            if (fields.Contains(TUserBasicInfoProperties.Mobile.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Mobile, entity.Mobile));
            }
            if (fields.Contains(TUserBasicInfoProperties.Email.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Email, entity.Email));
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TUserBasicInfo>(session, query);
        }
        public static bool DbUpdate(this List<TUserBasicInfo> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserBasicInfoProperties.UserId, OperatorType.Equal, entity.UserId));
                if (fields.Contains(TUserBasicInfoProperties.Gender.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Gender, entity.Gender));
                }
                if (fields.Contains(TUserBasicInfoProperties.Birthday.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Birthday, entity.Birthday));
                }
                if (fields.Contains(TUserBasicInfoProperties.Mobile.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Mobile, entity.Mobile));
                }
                if (fields.Contains(TUserBasicInfoProperties.Email.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserBasicInfoProperties.Email, entity.Email));
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TUserBasicInfo>(session, query);
        }
        #endregion
        #region 读
        public static TUserBasicInfo DbSelect(this TUserBasicInfo entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserBasicInfoProperties.UserId, OperatorType.Equal, entity.UserId));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TUserBasicInfo>(session, query);
        }
        public static List<TUserBasicInfo> DbSelect(this List<TUserBasicInfo> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            var Ids = entities.Select(c =>c.UserId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserBasicInfoProperties.UserId, OperatorType.In, Ids));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TUserBasicInfo>(session, query);
        }
        #endregion
        #endregion
    }
}
