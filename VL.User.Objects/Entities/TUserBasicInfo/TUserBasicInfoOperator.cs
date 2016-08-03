using System;
using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Objects;
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
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserBasicInfoProperties.UserId, entity.UserId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TUserBasicInfo>(session, query);
        }
        public static bool DbDelete(this List<TUserBasicInfo> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.UserId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserBasicInfoProperties.UserId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TUserBasicInfo>(session, query);
        }
        public static bool DbInsert(this TUserBasicInfo entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserBasicInfoProperties.UserId, entity.UserId));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserBasicInfoProperties.Gender, entity.Gender));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserBasicInfoProperties.Birthday, entity.Birthday));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserBasicInfoProperties.Mobile, entity.Mobile));
            if (entity.Email == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Email));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserBasicInfoProperties.Email, entity.Email));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TUserBasicInfo>(session, query);
        }
        public static bool DbInsert(this List<TUserBasicInfo> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserBasicInfoProperties.UserId, entity.UserId));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserBasicInfoProperties.Gender, entity.Gender));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserBasicInfoProperties.Birthday, entity.Birthday));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserBasicInfoProperties.Mobile, entity.Mobile));
            if (entity.Email == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Email));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserBasicInfoProperties.Email, entity.Email));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TUserBasicInfo>(session, query);
        }
        public static bool DbUpdate(this TUserBasicInfo entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserBasicInfoProperties.UserId, entity.UserId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.UserId, entity.UserId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Gender, entity.Gender));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Birthday, entity.Birthday));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Mobile, entity.Mobile));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Email, entity.Email));
            }
            else
            {
                if (fields.Contains(TUserBasicInfoProperties.Gender))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Gender, entity.Gender));
                }
                if (fields.Contains(TUserBasicInfoProperties.Birthday))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Birthday, entity.Birthday));
                }
                if (fields.Contains(TUserBasicInfoProperties.Mobile))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Mobile, entity.Mobile));
                }
                if (fields.Contains(TUserBasicInfoProperties.Email))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Email, entity.Email));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TUserBasicInfo>(session, query);
        }
        public static bool DbUpdate(this List<TUserBasicInfo> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserBasicInfoProperties.UserId, entity.UserId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.UserId, entity.UserId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Gender, entity.Gender));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Birthday, entity.Birthday));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Mobile, entity.Mobile));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Email, entity.Email));
                }
                else
                {
                    if (fields.Contains(TUserBasicInfoProperties.Gender))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Gender, entity.Gender));
                    }
                    if (fields.Contains(TUserBasicInfoProperties.Birthday))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Birthday, entity.Birthday));
                    }
                    if (fields.Contains(TUserBasicInfoProperties.Mobile))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Mobile, entity.Mobile));
                    }
                    if (fields.Contains(TUserBasicInfoProperties.Email))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserBasicInfoProperties.Email, entity.Email));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TUserBasicInfo>(session, query);
        }
        #endregion
        #region 读
        public static TUserBasicInfo DbSelect(this TUserBasicInfo entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TUserBasicInfoProperties.UserId);
                builder.ComponentSelect.Values.Add(TUserBasicInfoProperties.Gender);
                builder.ComponentSelect.Values.Add(TUserBasicInfoProperties.Birthday);
                builder.ComponentSelect.Values.Add(TUserBasicInfoProperties.Mobile);
                builder.ComponentSelect.Values.Add(TUserBasicInfoProperties.Email);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TUserBasicInfoProperties.UserId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserBasicInfoProperties.UserId, entity.UserId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TUserBasicInfo>(session, query);
        }
        public static List<TUserBasicInfo> DbSelect(this List<TUserBasicInfo> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TUserBasicInfoProperties.UserId);
                builder.ComponentSelect.Values.Add(TUserBasicInfoProperties.Gender);
                builder.ComponentSelect.Values.Add(TUserBasicInfoProperties.Birthday);
                builder.ComponentSelect.Values.Add(TUserBasicInfoProperties.Mobile);
                builder.ComponentSelect.Values.Add(TUserBasicInfoProperties.Email);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TUserBasicInfoProperties.UserId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.UserId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserBasicInfoProperties.UserId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TUserBasicInfo>(session, query);
        }
        public static void DbLoad(this TUserBasicInfo entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TUserBasicInfoProperties.Gender))
            {
                entity.Gender = result.Gender;
            }
            if (fields.Contains(TUserBasicInfoProperties.Birthday))
            {
                entity.Birthday = result.Birthday;
            }
            if (fields.Contains(TUserBasicInfoProperties.Mobile))
            {
                entity.Mobile = result.Mobile;
            }
            if (fields.Contains(TUserBasicInfoProperties.Email))
            {
                entity.Email = result.Email;
            }
        }
        public static void DbLoad(this List<TUserBasicInfo> entities, DbSession session, params PDMDbProperty[] fields)
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
