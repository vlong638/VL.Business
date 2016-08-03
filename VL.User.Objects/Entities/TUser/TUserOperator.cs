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
        public static bool DbDelete(this TUser entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.UserId, entity.UserId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TUser>(session, query);
        }
        public static bool DbDelete(this List<TUser> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.UserId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.UserId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TUser>(session, query);
        }
        public static bool DbInsert(this TUser entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.UserId, entity.UserId));
            if (entity.UserName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.UserName));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.UserName, entity.UserName));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.Mobile, entity.Mobile));
            if (entity.Email == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Email));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.Email, entity.Email));
            if (entity.IdCardNumber == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.IdCardNumber));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.IdCardNumber, entity.IdCardNumber));
            if (entity.Password == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Password));
            }
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.Password, entity.Password));
            builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.CreateTime, entity.CreateTime));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TUser>(session, query);
        }
        public static bool DbInsert(this List<TUser> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.UserId, entity.UserId));
            if (entity.UserName == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.UserName));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.UserName, entity.UserName));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.Mobile, entity.Mobile));
            if (entity.Email == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Email));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.Email, entity.Email));
            if (entity.IdCardNumber == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.IdCardNumber));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.IdCardNumber, entity.IdCardNumber));
            if (entity.Password == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Password));
            }
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.Password, entity.Password));
                builder.ComponentInsert.Values.Add(new ComponentValueOfInsert(TUserProperties.CreateTime, entity.CreateTime));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TUser>(session, query);
        }
        public static bool DbUpdate(this TUser entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.UserId, entity.UserId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.UserId, entity.UserId));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.UserName, entity.UserName));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.Mobile, entity.Mobile));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.Email, entity.Email));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.IdCardNumber, entity.IdCardNumber));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.Password, entity.Password));
                builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.CreateTime, entity.CreateTime));
            }
            else
            {
                if (fields.Contains(TUserProperties.UserName))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.UserName, entity.UserName));
                }
                if (fields.Contains(TUserProperties.Mobile))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.Mobile, entity.Mobile));
                }
                if (fields.Contains(TUserProperties.Email))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.Email, entity.Email));
                }
                if (fields.Contains(TUserProperties.IdCardNumber))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.IdCardNumber, entity.IdCardNumber));
                }
                if (fields.Contains(TUserProperties.Password))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.Password, entity.Password));
                }
                if (fields.Contains(TUserProperties.CreateTime))
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.CreateTime, entity.CreateTime));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TUser>(session, query);
        }
        public static bool DbUpdate(this List<TUser> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.UserId, entity.UserId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.UserId, entity.UserId));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.UserName, entity.UserName));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.Mobile, entity.Mobile));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.Email, entity.Email));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.IdCardNumber, entity.IdCardNumber));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.Password, entity.Password));
                    builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.CreateTime, entity.CreateTime));
                }
                else
                {
                    if (fields.Contains(TUserProperties.UserName))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.UserName, entity.UserName));
                    }
                    if (fields.Contains(TUserProperties.Mobile))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.Mobile, entity.Mobile));
                    }
                    if (fields.Contains(TUserProperties.Email))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.Email, entity.Email));
                    }
                    if (fields.Contains(TUserProperties.IdCardNumber))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.IdCardNumber, entity.IdCardNumber));
                    }
                    if (fields.Contains(TUserProperties.Password))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.Password, entity.Password));
                    }
                    if (fields.Contains(TUserProperties.CreateTime))
                    {
                        builder.ComponentSet.Values.Add(new ComponentValueOfSet(TUserProperties.CreateTime, entity.CreateTime));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TUser>(session, query);
        }
        #endregion
        #region 读
        public static TUser DbSelect(this TUser entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TUserProperties.UserId);
                builder.ComponentSelect.Values.Add(TUserProperties.UserName);
                builder.ComponentSelect.Values.Add(TUserProperties.Mobile);
                builder.ComponentSelect.Values.Add(TUserProperties.Email);
                builder.ComponentSelect.Values.Add(TUserProperties.IdCardNumber);
                builder.ComponentSelect.Values.Add(TUserProperties.Password);
                builder.ComponentSelect.Values.Add(TUserProperties.CreateTime);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TUserProperties.UserId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.UserId, entity.UserId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TUser>(session, query);
        }
        public static List<TUser> DbSelect(this List<TUser> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Values.Add(TUserProperties.UserId);
                builder.ComponentSelect.Values.Add(TUserProperties.UserName);
                builder.ComponentSelect.Values.Add(TUserProperties.Mobile);
                builder.ComponentSelect.Values.Add(TUserProperties.Email);
                builder.ComponentSelect.Values.Add(TUserProperties.IdCardNumber);
                builder.ComponentSelect.Values.Add(TUserProperties.Password);
                builder.ComponentSelect.Values.Add(TUserProperties.CreateTime);
            }
            else
            {
                builder.ComponentSelect.Values.Add(TUserProperties.UserId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Values.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.UserId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new ComponentValueOfWhere(TUserProperties.UserId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TUser>(session, query);
        }
        public static void DbLoad(this TUser entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TUserProperties.UserName))
            {
                entity.UserName = result.UserName;
            }
            if (fields.Contains(TUserProperties.Mobile))
            {
                entity.Mobile = result.Mobile;
            }
            if (fields.Contains(TUserProperties.Email))
            {
                entity.Email = result.Email;
            }
            if (fields.Contains(TUserProperties.IdCardNumber))
            {
                entity.IdCardNumber = result.IdCardNumber;
            }
            if (fields.Contains(TUserProperties.Password))
            {
                entity.Password = result.Password;
            }
            if (fields.Contains(TUserProperties.CreateTime))
            {
                entity.CreateTime = result.CreateTime;
            }
        }
        public static void DbLoad(this List<TUser> entities, DbSession session, params PDMDbProperty[] fields)
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
