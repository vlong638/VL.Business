using VL.Common.ORM.Objects;

namespace VL.LostInJungle.Objects.Entities
{
    public class TCreatureSkillProperties
    {
        #region Properties
        public static PDMDbProperty CreatureId { get; set; } = new PDMDbProperty(nameof(CreatureId), "CreatureId", "标识", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty SurvivalSkill { get; set; } = new PDMDbProperty(nameof(SurvivalSkill), "SurvivalSkill", "基础生存", false, PDMDataType.varchar, 100, 0, true, null);
        public static PDMDbProperty WarriorSkills { get; set; } = new PDMDbProperty(nameof(WarriorSkills), "WarriorSkills", "战士", false, PDMDataType.varchar, 100, 0, true, null);
        public static PDMDbProperty ExplorerSkills { get; set; } = new PDMDbProperty(nameof(ExplorerSkills), "ExplorerSkills", "探险家", false, PDMDataType.varchar, 100, 0, true, null);
        public static PDMDbProperty FarmingSkills { get; set; } = new PDMDbProperty(nameof(FarmingSkills), "FarmingSkills", "耕作", false, PDMDataType.varchar, 100, 0, true, null);
        public static PDMDbProperty RasingSkills { get; set; } = new PDMDbProperty(nameof(RasingSkills), "RasingSkills", "养殖", false, PDMDataType.varchar, 100, 0, true, null);
        public static PDMDbProperty BowmanSkills { get; set; } = new PDMDbProperty(nameof(BowmanSkills), "BowmanSkills", "弓箭手", false, PDMDataType.varchar, 100, 0, true, null);
        public static PDMDbProperty FishingSkills { get; set; } = new PDMDbProperty(nameof(FishingSkills), "FishingSkills", "钓鱼", false, PDMDataType.varchar, 100, 0, true, null);
        #endregion
    }
}
