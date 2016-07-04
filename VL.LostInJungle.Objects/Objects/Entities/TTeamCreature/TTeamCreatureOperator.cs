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
        public static bool DbDelete(this TTeamCreature entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTeamCreatureProperties.TeamId, OperatorType.Equal, entity.TeamId));
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTeamCreatureProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            return IORMProvider.GetQueryOperator(session).Delete<TTeamCreature>(session, query);
        }
        public static bool DbDelete(this List<TTeamCreature> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.TeamId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTeamCreatureProperties.TeamId, OperatorType.In, Ids));
            return IORMProvider.GetQueryOperator(session).Delete<TTeamCreature>(session, query);
        }
        public static bool DbInsert(this TTeamCreature entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTeamCreatureProperties.TeamId, entity.TeamId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTeamCreatureProperties.CreatureId, entity.CreatureId));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TTeamCreature>(session, query);
        }
        public static bool DbInsert(this List<TTeamCreature> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTeamCreatureProperties.TeamId, entity.TeamId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TTeamCreatureProperties.CreatureId, entity.CreatureId));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TTeamCreature>(session, query);
        }
        public static bool DbUpdate(this TTeamCreature entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTeamCreatureProperties.TeamId, OperatorType.Equal, entity.TeamId));
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTeamCreatureProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TTeamCreature>(session, query);
        }
        public static bool DbUpdate(this List<TTeamCreature> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTeamCreatureProperties.TeamId, OperatorType.Equal, entity.TeamId));
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTeamCreatureProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TTeamCreature>(session, query);
        }
        #endregion
        #region 读
        public static TTeamCreature DbSelect(this TTeamCreature entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTeamCreatureProperties.TeamId, OperatorType.Equal, entity.TeamId));
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTeamCreatureProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TTeamCreature>(session, query);
        }
        public static List<TTeamCreature> DbSelect(this List<TTeamCreature> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            var Ids = entities.Select(c =>c.TeamId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TTeamCreatureProperties.TeamId, OperatorType.In, Ids));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TTeamCreature>(session, query);
        }
        #endregion
        #endregion
    }
}
