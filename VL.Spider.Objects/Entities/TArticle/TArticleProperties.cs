using VL.Common.ORM.Objects;

namespace VL.Spider.Objects.Objects.Entities
{
    public class TArticleProperties
    {
        #region Properties
        public static PDMDbProperty SouceId { get; set; } = new PDMDbProperty(nameof(SouceId), "SouceId", "数据源(标志了从何而来)", false, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty ArticleId { get; set; } = new PDMDbProperty(nameof(ArticleId), "ArticleId", "标识符", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty Title { get; set; } = new PDMDbProperty(nameof(Title), "Title", "标题", false, PDMDataType.nvarchar, 100, 0, true, null);
        public static PDMDbProperty Content { get; set; } = new PDMDbProperty(nameof(Content), "Content", "内容", false, PDMDataType.nvarchar, 4000, 0, true, null);
        #endregion
    }
}
