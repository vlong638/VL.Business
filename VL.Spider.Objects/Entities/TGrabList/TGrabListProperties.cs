using VL.Common.ORM.Objects;

namespace VL.Spider.Objects.Entities
{
    public class TGrabListProperties
    {
        #region Properties
        public static PDMDbProperty ListItemId { get; set; } = new PDMDbProperty(nameof(ListItemId), "ListItemId", "列表项Id", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty SpiderId { get; set; } = new PDMDbProperty(nameof(SpiderId), "SpiderId", "抓取请求Id", false, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty IssueTime { get; set; } = new PDMDbProperty(nameof(IssueTime), "IssueTime", "批次号", false, PDMDataType.datetime, 0, 0, true, null);
        public static PDMDbProperty OrderNumber { get; set; } = new PDMDbProperty(nameof(OrderNumber), "OrderNumber", "批内序号", false, PDMDataType.numeric, 16, 0, true, null);
        public static PDMDbProperty Title { get; set; } = new PDMDbProperty(nameof(Title), "Title", "标题", false, PDMDataType.varchar, 200, 0, true, null);
        public static PDMDbProperty URL { get; set; } = new PDMDbProperty(nameof(URL), "URL", "链接", false, PDMDataType.varchar, 1000, 0, true, null);
        public static PDMDbProperty Remark { get; set; } = new PDMDbProperty(nameof(Remark), "Remark", "备注", false, PDMDataType.varchar, 2000, 0, true, null);
        #endregion
    }
}
