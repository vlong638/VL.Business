using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.ORM.Utilities.QueryOperators;

namespace VL.User.Objects.Entities
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TUser entity, DbSession session)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.UserId, OperatorType.Equal, entity.UserId));
            return IDbQueryOperator.GetQueryOperator(session).Delete<TUser>(session, query);
        }
        public static bool DbDelete(this List<TUser> entities, DbSession session)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.UserId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.UserId, OperatorType.In, Ids));
            return IDbQueryOperator.GetQueryOperator(session).Delete<TUser>(session, query);
        }
        public static bool DbInsert(this TUser entity, DbSession session)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.UserId, entity.UserId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.UserName, entity.UserName));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.Mobile, entity.Mobile));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.Email, entity.Email));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.IdCardNumber, entity.IdCardNumber));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.Password, entity.Password));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.CreateTime, entity.CreateTime));
            query.InsertBuilders.Add(builder);
            return IDbQueryOperator.GetQueryOperator(session).Insert<TUser>(session, query);
        }
        public static bool DbInsert(this List<TUser> entities, DbSession session)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.UserId, entity.UserId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.UserName, entity.UserName));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.Mobile, entity.Mobile));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.Email, entity.Email));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.IdCardNumber, entity.IdCardNumber));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.Password, entity.Password));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.CreateTime, entity.CreateTime));
                query.InsertBuilders.Add(builder);
            }
            return IDbQueryOperator.GetQueryOperator(session).InsertAll<TUser>(session, query);
        }
        public static bool DbUpdate(this TUser entity, DbSession session, params string[] fields)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.UserId, OperatorType.Equal, entity.UserId));
            if (fields.Contains(TUserProperties.UserName.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.UserName, entity.UserName));
            }
            if (fields.Contains(TUserProperties.Mobile.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.Mobile, entity.Mobile));
            }
            if (fields.Contains(TUserProperties.Email.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.Email, entity.Email));
            }
            if (fields.Contains(TUserProperties.IdCardNumber.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.IdCardNumber, entity.IdCardNumber));
            }
            if (fields.Contains(TUserProperties.Password.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.Password, entity.Password));
            }
            if (fields.Contains(TUserProperties.CreateTime.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.CreateTime, entity.CreateTime));
            }
            query.UpdateBuilders.Add(builder);
            return IDbQueryOperator.GetQueryOperator(session).Update<TUser>(session, query);
        }
        public static bool DbUpdate(this List<TUser> entities, DbSession session, params string[] fields)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.UserId, OperatorType.Equal, entity.UserId));
                if (fields.Contains(TUserProperties.UserName.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.UserName, entity.UserName));
                }
                if (fields.Contains(TUserProperties.Mobile.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.Mobile, entity.Mobile));
                }
                if (fields.Contains(TUserProperties.Email.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.Email, entity.Email));
                }
                if (fields.Contains(TUserProperties.IdCardNumber.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.IdCardNumber, entity.IdCardNumber));
                }
                if (fields.Contains(TUserProperties.Password.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.Password, entity.Password));
                }
                if (fields.Contains(TUserProperties.CreateTime.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TUserProperties.CreateTime, entity.CreateTime));
                }
                query.UpdateBuilders.Add(builder);
            }
            return IDbQueryOperator.GetQueryOperator(session).UpdateAll<TUser>(session, query);
        }
        #endregion
        #region 读
        public static TUser DbSelect(this TUser entity, DbSession session, params string[] fields)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.UserId, OperatorType.Equal, entity.UserId));
            query.SelectBuilders.Add(builder);
            return IDbQueryOperator.GetQueryOperator(session).Select<TUser>(session, query);
        }
        public static List<TUser> DbSelect(this List<TUser> entities, DbSession session, params string[] fields)
        {
            var query = IDbQueryBuilder.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            var Ids = entities.Select(c =>c.UserId );
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TUserProperties.UserId, OperatorType.In, Ids));
            query.SelectBuilders.Add(builder);
            return IDbQueryOperator.GetQueryOperator(session).SelectAll<TUser>(session, query);
        }
        #endregion
        #endregion
    }
}
