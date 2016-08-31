using VL.Common.ORM.Objects;

namespace VL.Spider.Objects.Entities
{
    public class TGrabRequestProperties
    {
        #region Properties
        public static PDMDbProperty RequestId { get; set; } = new PDMDbProperty(nameof(RequestId), "RequestId", "请求Id", false, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty SpiderId { get; set; } = new PDMDbProperty(nameof(SpiderId), "SpiderId", "爬虫Id", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty GrabType { get; set; } = new PDMDbProperty(nameof(GrabType), "GrabType", "请求类型", true, PDMDataType.numeric, 16, 0, true, null);
        public static PDMDbProperty IssueName { get; set; } = new PDMDbProperty(nameof(IssueName), "IssueName", "批次号", true, PDMDataType.varchar, 200, 0, true, null);
        public static PDMDbProperty SpiderName { get; set; } = new PDMDbProperty(nameof(SpiderName), "SpiderName", "爬虫名称", false, PDMDataType.varchar, 200, 0, true, null);
        public static PDMDbProperty IsSuccess { get; set; } = new PDMDbProperty(nameof(IsSuccess), "IsSuccess", "处理结果", false, PDMDataType.boolean, 0, 0, true, null);
        #endregion
    }
}
