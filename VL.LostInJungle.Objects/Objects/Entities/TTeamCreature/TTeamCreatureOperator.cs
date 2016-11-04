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
        public static bool DbDelete(this TTeamCreature entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamCreatureProperties.TeamId, entity.TeamId, LocateType.Equal));
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamCreatureProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TTeamCreature>(session, query);
        }
        public static bool DbDelete(this List<TTeamCreature> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.TeamId );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamCreatureProperties.TeamId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TTeamCreature>(session, query);
        }
        public static bool DbInsert(this TTeamCreature entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TTeamCreatureProperties.TeamId, entity.TeamId));
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TTeamCreatureProperties.CreatureId, entity.CreatureId));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TTeamCreature>(session, query);
        }
        public static bool DbInsert(this List<TTeamCreature> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TTeamCreatureProperties.TeamId, entity.TeamId));
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TTeamCreatureProperties.CreatureId, entity.CreatureId));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TTeamCreature>(session, query);
        }
        public static bool DbUpdate(this TTeamCreature entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamCreatureProperties.TeamId, entity.TeamId, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamCreatureProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TTeamCreatureProperties.TeamId, entity.TeamId));
                builder.ComponentSet.Add(new ComponentValueOfSet(TTeamCreatureProperties.CreatureId, entity.CreatureId));
            }
            else
            {
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TTeamCreature>(session, query);
        }
        public static bool DbUpdate(this List<TTeamCreature> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamCreatureProperties.TeamId, entity.TeamId, LocateType.Equal));
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamCreatureProperties.CreatureId, entity.CreatureId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TTeamCreatureProperties.TeamId, entity.TeamId));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TTeamCreatureProperties.CreatureId, entity.CreatureId));
                }
                else
                {
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TTeamCreature>(session, query);
        }
        #endregion
        #region 读
        public static TTeamCreature DbSelect(this TTeamCreature entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TTeamCreatureProperties.TeamId);
                builder.ComponentSelect.Add(TTeamCreatureProperties.CreatureId);
            }
            else
            {
                builder.ComponentSelect.Add(TTeamCreatureProperties.TeamId);
                builder.ComponentSelect.Add(TTeamCreatureProperties.CreatureId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamCreatureProperties.TeamId, entity.TeamId, LocateType.Equal));
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamCreatureProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TTeamCreature>(session, query);
        }
        public static List<TTeamCreature> DbSelect(this List<TTeamCreature> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TTeamCreatureProperties.TeamId);
                builder.ComponentSelect.Add(TTeamCreatureProperties.CreatureId);
            }
            else
            {
                builder.ComponentSelect.Add(TTeamCreatureProperties.TeamId);
                builder.ComponentSelect.Add(TTeamCreatureProperties.CreatureId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.TeamId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TTeamCreatureProperties.TeamId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TTeamCreature>(session, query);
        }
        public static void DbLoad(this TTeamCreature entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
        }
        public static void DbLoad(this List<TTeamCreature> entities, DbSession session, params PDMDbProperty[] fields)
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
