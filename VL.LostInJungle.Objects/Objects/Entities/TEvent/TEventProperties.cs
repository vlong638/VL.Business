using VL.Common.ORM.Objects;

namespace VL.LostInJungle.Objects.Entities
{
    public class TEventProperties
    {
        #region Properties
        public static PDMDbProperty AreaId { get; set; } = new PDMDbProperty(nameof(AreaId), "AreaId", "所属地区Id", false, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty EventId { get; set; } = new PDMDbProperty(nameof(EventId), "EventId", "Id", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty Occurrence { get; set; } = new PDMDbProperty(nameof(Occurrence), "Occurrence", "出现几率", false, PDMDataType.nvarchar, 100, 0, true, null);
        #endregion
    }
}
