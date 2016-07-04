using VL.Common.ORM.Objects;

namespace VL.LostInJungle.Objects.Entities
{
    public class TAreaEventProperties
    {
        #region Properties
        public static PDMDbProperty AreaId { get; set; } = new PDMDbProperty(nameof(AreaId), "AreaId", "地区Id", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty EventId { get; set; } = new PDMDbProperty(nameof(EventId), "EventId", "事件Id", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty RoundNum { get; set; } = new PDMDbProperty(nameof(RoundNum), "RoundNum", "回合数", true, PDMDataType.numeric, 4, 0, true, null);
        #endregion
    }
}
