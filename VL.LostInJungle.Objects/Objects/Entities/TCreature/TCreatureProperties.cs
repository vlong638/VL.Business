using VL.Common.ORM.Objects;

namespace VL.LostInJungle.Objects.Entities
{
    public class TCreatureProperties
    {
        #region Properties
        public static PDMDbProperty CreatureId { get; set; } = new PDMDbProperty(nameof(CreatureId), "CreatureId", "标识", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty CreatureType { get; set; } = new PDMDbProperty(nameof(CreatureType), "CreatureType", "种族类型", false, PDMDataType.numeric, 10, 0, true, null);
        public static PDMDbProperty Name { get; set; } = new PDMDbProperty(nameof(Name), "Name", "名称", false, PDMDataType.nvarchar, 20, 0, true, null);
        public static PDMDbProperty Experience { get; set; } = new PDMDbProperty(nameof(Experience), "Experience", "经验", false, PDMDataType.numeric, 20, 0, true, null);
        public static PDMDbProperty Level { get; set; } = new PDMDbProperty(nameof(Level), "Level", "等级", false, PDMDataType.numeric, 10, 0, true, null);
        public static PDMDbProperty Profession { get; set; } = new PDMDbProperty(nameof(Profession), "Profession", "职业", false, PDMDataType.numeric, 4, 0, true, null);
        #endregion
    }
}
