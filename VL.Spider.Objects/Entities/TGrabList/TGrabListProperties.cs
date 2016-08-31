using VL.Common.ORM.Objects;

namespace VL.Spider.Objects.Entities
{
    public class TGrabListProperties
    {
        #region Properties
        public static PDMDbProperty ListItemId { get; set; } = new PDMDbProperty(nameof(ListItemId), "ListItemId", "列表项Id", false, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty SpiderId { get; set; } = new PDMDbProperty(nameof(SpiderId), "SpiderId", "抓取请求Id", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty IssueName { get; set; } = new PDMDbProperty(nameof(IssueName), "IssueName", "批次号", true, PDMDataType.varchar, 200, 0, true, null);
        public static PDMDbProperty OrderNumber { get; set; } = new PDMDbProperty(nameof(OrderNumber), "OrderNumber", "批内序号", true, PDMDataType.numeric, 16, 0, true, null);
        public static PDMDbProperty Title { get; set; } = new PDMDbProperty(nameof(Title), "Title", "标题", false, PDMDataType.varchar, 200, 0, true, null);
        public static PDMDbProperty URL { get; set; } = new PDMDbProperty(nameof(URL), "URL", "链接", false, PDMDataType.varchar, 1000, 0, true, null);
        public static PDMDbProperty Remark { get; set; } = new PDMDbProperty(nameof(Remark), "Remark", "备注", false, PDMDataType.varchar, 2000, 0, true, null);
        #endregion
    }
}
