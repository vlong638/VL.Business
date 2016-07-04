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
        public static bool DbDelete(this TCreatureSkill entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureSkillProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            return IORMProvider.GetQueryOperator(session).Delete<TCreatureSkill>(session, query);
        }
        public static bool DbDelete(this List<TCreatureSkill> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.CreatureId );
            query.DeleteBuilder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureSkillProperties.CreatureId, OperatorType.In, Ids));
            return IORMProvider.GetQueryOperator(session).Delete<TCreatureSkill>(session, query);
        }
        public static bool DbInsert(this TCreatureSkill entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.CreatureId, entity.CreatureId));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.SurvivalSkill, entity.SurvivalSkill));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.WarriorSkills, entity.WarriorSkills));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.ExplorerSkills, entity.ExplorerSkills));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.FarmingSkills, entity.FarmingSkills));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.RasingSkills, entity.RasingSkills));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.BowmanSkills, entity.BowmanSkills));
            builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.FishingSkills, entity.FishingSkills));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TCreatureSkill>(session, query);
        }
        public static bool DbInsert(this List<TCreatureSkill> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.CreatureId, entity.CreatureId));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.SurvivalSkill, entity.SurvivalSkill));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.WarriorSkills, entity.WarriorSkills));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.ExplorerSkills, entity.ExplorerSkills));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.FarmingSkills, entity.FarmingSkills));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.RasingSkills, entity.RasingSkills));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.BowmanSkills, entity.BowmanSkills));
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.FishingSkills, entity.FishingSkills));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TCreatureSkill>(session, query);
        }
        public static bool DbUpdate(this TCreatureSkill entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureSkillProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            if (fields.Contains(TCreatureSkillProperties.SurvivalSkill.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.SurvivalSkill, entity.SurvivalSkill));
            }
            if (fields.Contains(TCreatureSkillProperties.WarriorSkills.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.WarriorSkills, entity.WarriorSkills));
            }
            if (fields.Contains(TCreatureSkillProperties.ExplorerSkills.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.ExplorerSkills, entity.ExplorerSkills));
            }
            if (fields.Contains(TCreatureSkillProperties.FarmingSkills.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.FarmingSkills, entity.FarmingSkills));
            }
            if (fields.Contains(TCreatureSkillProperties.RasingSkills.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.RasingSkills, entity.RasingSkills));
            }
            if (fields.Contains(TCreatureSkillProperties.BowmanSkills.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.BowmanSkills, entity.BowmanSkills));
            }
            if (fields.Contains(TCreatureSkillProperties.FishingSkills.Title))
            {
                builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.FishingSkills, entity.FishingSkills));
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TCreatureSkill>(session, query);
        }
        public static bool DbUpdate(this List<TCreatureSkill> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureSkillProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
                if (fields.Contains(TCreatureSkillProperties.SurvivalSkill.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.SurvivalSkill, entity.SurvivalSkill));
                }
                if (fields.Contains(TCreatureSkillProperties.WarriorSkills.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.WarriorSkills, entity.WarriorSkills));
                }
                if (fields.Contains(TCreatureSkillProperties.ExplorerSkills.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.ExplorerSkills, entity.ExplorerSkills));
                }
                if (fields.Contains(TCreatureSkillProperties.FarmingSkills.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.FarmingSkills, entity.FarmingSkills));
                }
                if (fields.Contains(TCreatureSkillProperties.RasingSkills.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.RasingSkills, entity.RasingSkills));
                }
                if (fields.Contains(TCreatureSkillProperties.BowmanSkills.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.BowmanSkills, entity.BowmanSkills));
                }
                if (fields.Contains(TCreatureSkillProperties.FishingSkills.Title))
                {
                    builder.ComponentValue.Values.Add(new PDMDbPropertyValue(TCreatureSkillProperties.FishingSkills, entity.FishingSkills));
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TCreatureSkill>(session, query);
        }
        #endregion
        #region 读
        public static TCreatureSkill DbSelect(this TCreatureSkill entity, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureSkillProperties.CreatureId, OperatorType.Equal, entity.CreatureId));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TCreatureSkill>(session, query);
        }
        public static List<TCreatureSkill> DbSelect(this List<TCreatureSkill> entities, DbSession session, params string[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            foreach (var field in fields)
            {
                builder.ComponentFieldAliases.FieldAliases.Add(new FieldAlias(field));
            }
            var Ids = entities.Select(c =>c.CreatureId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Wheres.Add(new PDMDbPropertyOperateValue(TCreatureSkillProperties.CreatureId, OperatorType.In, Ids));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TCreatureSkill>(session, query);
        }
        #endregion
        #endregion
    }
}
