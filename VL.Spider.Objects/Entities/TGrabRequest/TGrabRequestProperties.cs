using VL.Common.ORM.Objects;

namespace VL.Spider.Objects.Entities
{
    public class TGrabRequestProperties
    {
        #region Properties
        public static PDMDbProperty RequestId { get; set; } = new PDMDbProperty(nameof(RequestId), "RequestId", "请求Id", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty SpiderId { get; set; } = new PDMDbProperty(nameof(SpiderId), "SpiderId", "爬虫Id", false, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty GrabType { get; set; } = new PDMDbProperty(nameof(GrabType), "GrabType", "请求配置", false, PDMDataType.varchar, 1000, 0, true, null);
        public static PDMDbProperty IssueTime { get; set; } = new PDMDbProperty(nameof(IssueTime), "IssueTime", "批次号", false, PDMDataType.datetime, 0, 0, true, null);
        public static PDMDbProperty SpiderName { get; set; } = new PDMDbProperty(nameof(SpiderName), "SpiderName", "爬虫名称", false, PDMDataType.varchar, 200, 0, true, null);
        public static PDMDbProperty IsSuccess { get; set; } = new PDMDbProperty(nameof(IsSuccess), "IsSuccess", "处理结果", false, PDMDataType.boolean, 0, 0, true, null);
        #endregion
    }
}
