using VL.Common.ORM.Objects;

namespace VL.LostInJungle.Objects.Entities
{
    public class TAreaProperties
    {
        #region Properties
        public static PDMDbProperty AreaId { get; set; } = new PDMDbProperty(nameof(AreaId), "AreaId", "Id", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty AreaName { get; set; } = new PDMDbProperty(nameof(AreaName), "AreaName", "地区名称", false, PDMDataType.nvarchar, 20, 0, true, null);
        public static PDMDbProperty AreaLevel { get; set; } = new PDMDbProperty(nameof(AreaLevel), "AreaLevel", "地区等级", false, PDMDataType.numeric, 4, 0, true, null);
        public static PDMDbProperty AreaType { get; set; } = new PDMDbProperty(nameof(AreaType), "AreaType", "地区类型", false, PDMDataType.numeric, 4, 0, true, null);
        public static PDMDbProperty Description { get; set; } = new PDMDbProperty(nameof(Description), "Description", "地点描述", false, PDMDataType.nvarchar, 100, 0, true, null);
        public static PDMDbProperty DescriptionEx { get; set; } = new PDMDbProperty(nameof(DescriptionEx), "DescriptionEx", "地点描述(额外)", false, PDMDataType.nvarchar, 100, 0, true, null);
        #endregion
    }
}
