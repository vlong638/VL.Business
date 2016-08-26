using VL.Common.ORM.Objects;

namespace VL.Spider.Objects.Objects.Entities
{
    public class TSpiderProperties
    {
        #region Properties
        public static PDMDbProperty SpiderId { get; set; } = new PDMDbProperty(nameof(SpiderId), "SpiderId", "抓取请求Id", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty SpiderName { get; set; } = new PDMDbProperty(nameof(SpiderName), "SpiderName", "爬虫名称", false, PDMDataType.varchar, 200, 0, true, null);
        #endregion
    }
}
