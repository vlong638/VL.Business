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
        public static bool DbDelete(this TCreatureSkill entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureSkillProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            return IORMProvider.GetQueryOperator(session).Delete<TCreatureSkill>(session, query);
        }
        public static bool DbDelete(this List<TCreatureSkill> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            var Ids = entities.Select(c =>c.CreatureId );
            query.DeleteBuilder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureSkillProperties.CreatureId, Ids, LocateType.In));
            return IORMProvider.GetQueryOperator(session).Delete<TCreatureSkill>(session, query);
        }
        public static bool DbInsert(this TCreatureSkill entity, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            InsertBuilder builder = new InsertBuilder();
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.CreatureId, entity.CreatureId));
            if (entity.SurvivalSkill == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.SurvivalSkill));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.SurvivalSkill, entity.SurvivalSkill));
            if (entity.WarriorSkills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.WarriorSkills));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.WarriorSkills, entity.WarriorSkills));
            if (entity.ExplorerSkills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ExplorerSkills));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.ExplorerSkills, entity.ExplorerSkills));
            if (entity.FarmingSkills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.FarmingSkills));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.FarmingSkills, entity.FarmingSkills));
            if (entity.RasingSkills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.RasingSkills));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.RasingSkills, entity.RasingSkills));
            if (entity.BowmanSkills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.BowmanSkills));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.BowmanSkills, entity.BowmanSkills));
            if (entity.FishingSkills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.FishingSkills));
            }
            builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.FishingSkills, entity.FishingSkills));
            query.InsertBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Insert<TCreatureSkill>(session, query);
        }
        public static bool DbInsert(this List<TCreatureSkill> entities, DbSession session)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                InsertBuilder builder = new InsertBuilder();
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.CreatureId, entity.CreatureId));
            if (entity.SurvivalSkill == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.SurvivalSkill));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.SurvivalSkill, entity.SurvivalSkill));
            if (entity.WarriorSkills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.WarriorSkills));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.WarriorSkills, entity.WarriorSkills));
            if (entity.ExplorerSkills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.ExplorerSkills));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.ExplorerSkills, entity.ExplorerSkills));
            if (entity.FarmingSkills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.FarmingSkills));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.FarmingSkills, entity.FarmingSkills));
            if (entity.RasingSkills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.RasingSkills));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.RasingSkills, entity.RasingSkills));
            if (entity.BowmanSkills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.BowmanSkills));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.BowmanSkills, entity.BowmanSkills));
            if (entity.FishingSkills == null)
            {
                throw new NotImplementedException("缺少必填的参数项值, 参数项: " + nameof(entity.FishingSkills));
            }
                builder.ComponentInsert.Add(new ComponentValueOfInsert(TCreatureSkillProperties.FishingSkills, entity.FishingSkills));
                query.InsertBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).InsertAll<TCreatureSkill>(session, query);
        }
        public static bool DbUpdate(this TCreatureSkill entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            UpdateBuilder builder = new UpdateBuilder();
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureSkillProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            if (fields==null|| fields.Length==0)
            {
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.CreatureId, entity.CreatureId));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.SurvivalSkill, entity.SurvivalSkill));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.WarriorSkills, entity.WarriorSkills));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.ExplorerSkills, entity.ExplorerSkills));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.FarmingSkills, entity.FarmingSkills));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.RasingSkills, entity.RasingSkills));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.BowmanSkills, entity.BowmanSkills));
                builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.FishingSkills, entity.FishingSkills));
            }
            else
            {
                if (fields.Contains(TCreatureSkillProperties.SurvivalSkill))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.SurvivalSkill, entity.SurvivalSkill));
                }
                if (fields.Contains(TCreatureSkillProperties.WarriorSkills))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.WarriorSkills, entity.WarriorSkills));
                }
                if (fields.Contains(TCreatureSkillProperties.ExplorerSkills))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.ExplorerSkills, entity.ExplorerSkills));
                }
                if (fields.Contains(TCreatureSkillProperties.FarmingSkills))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.FarmingSkills, entity.FarmingSkills));
                }
                if (fields.Contains(TCreatureSkillProperties.RasingSkills))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.RasingSkills, entity.RasingSkills));
                }
                if (fields.Contains(TCreatureSkillProperties.BowmanSkills))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.BowmanSkills, entity.BowmanSkills));
                }
                if (fields.Contains(TCreatureSkillProperties.FishingSkills))
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.FishingSkills, entity.FishingSkills));
                }
            }
            query.UpdateBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Update<TCreatureSkill>(session, query);
        }
        public static bool DbUpdate(this List<TCreatureSkill> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            foreach (var entity in entities)
            {
                UpdateBuilder builder = new UpdateBuilder();
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureSkillProperties.CreatureId, entity.CreatureId, LocateType.Equal));
                if (fields==null|| fields.Length==0)
                {
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.CreatureId, entity.CreatureId));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.SurvivalSkill, entity.SurvivalSkill));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.WarriorSkills, entity.WarriorSkills));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.ExplorerSkills, entity.ExplorerSkills));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.FarmingSkills, entity.FarmingSkills));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.RasingSkills, entity.RasingSkills));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.BowmanSkills, entity.BowmanSkills));
                    builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.FishingSkills, entity.FishingSkills));
                }
                else
                {
                    if (fields.Contains(TCreatureSkillProperties.SurvivalSkill))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.SurvivalSkill, entity.SurvivalSkill));
                    }
                    if (fields.Contains(TCreatureSkillProperties.WarriorSkills))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.WarriorSkills, entity.WarriorSkills));
                    }
                    if (fields.Contains(TCreatureSkillProperties.ExplorerSkills))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.ExplorerSkills, entity.ExplorerSkills));
                    }
                    if (fields.Contains(TCreatureSkillProperties.FarmingSkills))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.FarmingSkills, entity.FarmingSkills));
                    }
                    if (fields.Contains(TCreatureSkillProperties.RasingSkills))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.RasingSkills, entity.RasingSkills));
                    }
                    if (fields.Contains(TCreatureSkillProperties.BowmanSkills))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.BowmanSkills, entity.BowmanSkills));
                    }
                    if (fields.Contains(TCreatureSkillProperties.FishingSkills))
                    {
                        builder.ComponentSet.Add(new ComponentValueOfSet(TCreatureSkillProperties.FishingSkills, entity.FishingSkills));
                    }
                }
                query.UpdateBuilders.Add(builder);
            }
            return IORMProvider.GetQueryOperator(session).UpdateAll<TCreatureSkill>(session, query);
        }
        #endregion
        #region 读
        public static TCreatureSkill DbSelect(this TCreatureSkill entity, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TCreatureSkillProperties.CreatureId);
                builder.ComponentSelect.Add(TCreatureSkillProperties.SurvivalSkill);
                builder.ComponentSelect.Add(TCreatureSkillProperties.WarriorSkills);
                builder.ComponentSelect.Add(TCreatureSkillProperties.ExplorerSkills);
                builder.ComponentSelect.Add(TCreatureSkillProperties.FarmingSkills);
                builder.ComponentSelect.Add(TCreatureSkillProperties.RasingSkills);
                builder.ComponentSelect.Add(TCreatureSkillProperties.BowmanSkills);
                builder.ComponentSelect.Add(TCreatureSkillProperties.FishingSkills);
            }
            else
            {
                builder.ComponentSelect.Add(TCreatureSkillProperties.CreatureId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            builder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureSkillProperties.CreatureId, entity.CreatureId, LocateType.Equal));
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).Select<TCreatureSkill>(session, query);
        }
        public static List<TCreatureSkill> DbSelect(this List<TCreatureSkill> entities, DbSession session, params PDMDbProperty[] fields)
        {
            var query = IORMProvider.GetDbQueryBuilder(session);
            SelectBuilder builder = new SelectBuilder();
            if (fields.Count() == 0)
            {
                builder.ComponentSelect.Add(TCreatureSkillProperties.CreatureId);
                builder.ComponentSelect.Add(TCreatureSkillProperties.SurvivalSkill);
                builder.ComponentSelect.Add(TCreatureSkillProperties.WarriorSkills);
                builder.ComponentSelect.Add(TCreatureSkillProperties.ExplorerSkills);
                builder.ComponentSelect.Add(TCreatureSkillProperties.FarmingSkills);
                builder.ComponentSelect.Add(TCreatureSkillProperties.RasingSkills);
                builder.ComponentSelect.Add(TCreatureSkillProperties.BowmanSkills);
                builder.ComponentSelect.Add(TCreatureSkillProperties.FishingSkills);
            }
            else
            {
                builder.ComponentSelect.Add(TCreatureSkillProperties.CreatureId);
                foreach (var field in fields)
                {
                    builder.ComponentSelect.Add(field);
                }
            }
            var Ids = entities.Select(c =>c.CreatureId );
            if (Ids.Count() != 0)
            {
                builder.ComponentWhere.Add(new ComponentValueOfWhere(TCreatureSkillProperties.CreatureId, Ids, LocateType.In));
            }
            query.SelectBuilders.Add(builder);
            return IORMProvider.GetQueryOperator(session).SelectAll<TCreatureSkill>(session, query);
        }
        public static void DbLoad(this TCreatureSkill entity, DbSession session, params PDMDbProperty[] fields)
        {
            var result = entity.DbSelect(session, fields);
            if (fields.Contains(TCreatureSkillProperties.SurvivalSkill))
            {
                entity.SurvivalSkill = result.SurvivalSkill;
            }
            if (fields.Contains(TCreatureSkillProperties.WarriorSkills))
            {
                entity.WarriorSkills = result.WarriorSkills;
            }
            if (fields.Contains(TCreatureSkillProperties.ExplorerSkills))
            {
                entity.ExplorerSkills = result.ExplorerSkills;
            }
            if (fields.Contains(TCreatureSkillProperties.FarmingSkills))
            {
                entity.FarmingSkills = result.FarmingSkills;
            }
            if (fields.Contains(TCreatureSkillProperties.RasingSkills))
            {
                entity.RasingSkills = result.RasingSkills;
            }
            if (fields.Contains(TCreatureSkillProperties.BowmanSkills))
            {
                entity.BowmanSkills = result.BowmanSkills;
            }
            if (fields.Contains(TCreatureSkillProperties.FishingSkills))
            {
                entity.FishingSkills = result.FishingSkills;
            }
        }
        public static void DbLoad(this List<TCreatureSkill> entities, DbSession session, params PDMDbProperty[] fields)
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
