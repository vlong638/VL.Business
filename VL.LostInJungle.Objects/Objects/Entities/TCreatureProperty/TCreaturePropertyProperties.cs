using VL.Common.ORM.Objects;

namespace VL.LostInJungle.Objects.Entities
{
    public class TCreaturePropertyProperties
    {
        #region Properties
        public static PDMDbProperty CreatureId { get; set; } = new PDMDbProperty(nameof(CreatureId), "CreatureId", "标识", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty HitPoint { get; set; } = new PDMDbProperty(nameof(HitPoint), "HitPoint", "生命值", false, PDMDataType.numeric, 10, 0, true, null);
        public static PDMDbProperty MagicPoint { get; set; } = new PDMDbProperty(nameof(MagicPoint), "MagicPoint", "魔法值", false, PDMDataType.numeric, 10, 0, true, null);
        public static PDMDbProperty Strength { get; set; } = new PDMDbProperty(nameof(Strength), "Strength", "力量", false, PDMDataType.numeric, 10, 0, true, null);
        public static PDMDbProperty Stamina { get; set; } = new PDMDbProperty(nameof(Stamina), "Stamina", "耐力", false, PDMDataType.numeric, 10, 0, true, null);
        public static PDMDbProperty Agility { get; set; } = new PDMDbProperty(nameof(Agility), "Agility", "敏捷", false, PDMDataType.numeric, 10, 0, true, null);
        public static PDMDbProperty Intelligence { get; set; } = new PDMDbProperty(nameof(Intelligence), "Intelligence", "智力", false, PDMDataType.numeric, 10, 0, true, null);
        public static PDMDbProperty Mentality { get; set; } = new PDMDbProperty(nameof(Mentality), "Mentality", "精神", false, PDMDataType.numeric, 10, 0, true, null);
        #endregion
    }
}
