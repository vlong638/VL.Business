using VL.Common.ORM.Objects;

namespace VL.Spider.Objects.Objects.Entities
{
    public class TTopicProperties
    {
        #region Properties
        public static PDMDbProperty TopicId { get; set; } = new PDMDbProperty(nameof(TopicId), "TopicId", "标识符", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty Title { get; set; } = new PDMDbProperty(nameof(Title), "Title", "标题", false, PDMDataType.nvarchar, 100, 0, true, null);
        public static PDMDbProperty Content { get; set; } = new PDMDbProperty(nameof(Content), "Content", "内容", false, PDMDataType.nvarchar, 1000, 0, true, null);
        #endregion
    }
}
