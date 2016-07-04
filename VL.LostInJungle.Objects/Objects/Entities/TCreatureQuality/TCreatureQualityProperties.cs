using VL.Common.ORM.Objects;

namespace VL.LostInJungle.Objects.Entities
{
    public class TCreatureQualityProperties
    {
        #region Properties
        public static PDMDbProperty CreatureId { get; set; } = new PDMDbProperty(nameof(CreatureId), "CreatureId", "标识", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty FirstLevelQuality { get; set; } = new PDMDbProperty(nameof(FirstLevelQuality), "FirstLevelQuality", "一级传承品质", false, PDMDataType.numeric, 4, 0, true, null);
        public static PDMDbProperty SecondLevelQuality { get; set; } = new PDMDbProperty(nameof(SecondLevelQuality), "SecondLevelQuality", "二级传承品质", false, PDMDataType.numeric, 4, 0, true, null);
        public static PDMDbProperty ThirdLevelQuality { get; set; } = new PDMDbProperty(nameof(ThirdLevelQuality), "ThirdLevelQuality", "三级传承品质", false, PDMDataType.numeric, 4, 0, true, null);
        #endregion
    }
}
