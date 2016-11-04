using System;
using System.Collections.Generic;
using System.Linq;
using VL.Common.DAS.Objects;
using VL.Common.ORM.Objects;
using VL.Common.ORM.Utilities.QueryBuilders;
using VL.Common.Protocol.IService.IORM;

namespace VL.LostInJungle.Objects.Entities
{
    public static partial class EntityOperator
    {
        #region Methods
        #region 写
        public static bool DbDelete(this TTeam entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamProperties.TeamId, entity.TeamId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TTeam>(session, query);
        }
        public static bool DbDelete(this List<TTeam> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.TeamId );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamProperties.TeamId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TTeam>(session, query);
        }
        public static bool DbInsert(this TTeam entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TTeamProperties.TeamId, entity.TeamId));
            if (entity.Name == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Name));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TTeamProperties.Name, entity.Name));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TTeam>(session, query);
        }
        public static bool DbInsert(this List<TTeam> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TTeamProperties.TeamId, entity.TeamId));
            if (entity.Name == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.Name));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TTeamProperties.Name, entity.Name));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TTeam>(session, query);
        }
        public static bool DbUpdate(this TTeam entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamProperties.TeamId, entity.TeamId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TTeamProperties.TeamId, entity.TeamId));
                builder.ComponentSet.Add(new ComponentValueOfSet(TTeamProperties.Name, entity.Name));
            }
            else
            {
                if (fields.Contains(TTeamProperties.Name))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TTeamProperties.Name, entity.Name));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TTeam>(session, query);
        }
        public static bool DbUpdate(this List<TTeam> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamProperties.TeamId, entity.TeamId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TTeamProperties.TeamId, entity.TeamId));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TTeamProperties.Name, entity.Name));
                }
                else
                {
                    if (fields.Contains(TTeamProperties.Name))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TTeamProperties.Name, entity.Name));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TTeam>(session, query);
        }
        #endregion
        #region 读
        public static TTeam DbSelect(this TTeam entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TTeamProperties.TeamId);
                builder.ComponentSelect.Add(TTeamProperties.Name);
            }
            else
            {
                builder.ComponentSelect.Add(TTeamProperties.TeamId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamProperties.TeamId, entity.TeamId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TTeam>(session, query);
        }
        public static List<TTeam> DbSelect(this List<TTeam> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TTeamProperties.TeamId);
                builder.ComponentSelect.Add(TTeamProperties.Name);
            }
            else
            {
                builder.ComponentSelect.Add(TTeamProperties.TeamId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.TeamId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamProperties.TeamId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TTeam>(session, query);
        }
        public static void DbLoad(this TTeam entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TTeamProperties.Name))
            {
                entity.Name = result.Name;
            }
        }
        public static void DbLoad(this List<TTeam> entities, DbSession session, params PDMDbProperty[] fields)
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
