using VL.Common.ORM.Objects;

namespace TODOTask.Objects.Entities
{
    public class TTaskProperties
    {
        #region Properties
        public static PDMDbProperty TaskId { get; set; } = new PDMDbProperty(nameof(TaskId), "TaskId", "标识符", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty What { get; set; } = new PDMDbProperty(nameof(What), "What", "做什么(主题)", false, PDMDataType.nvarchar, 1000, 0, true, null);
        public static PDMDbProperty Where { get; set; } = new PDMDbProperty(nameof(Where), "Where", "哪里做(地点)(归纳)", false, PDMDataType.nvarchar, 1000, 0, true, null);
        public static PDMDbProperty Who { get; set; } = new PDMDbProperty(nameof(Who), "Who", "参与者(人)(归纳)", false, PDMDataType.nvarchar, 1000, 0, true, null);
        public static PDMDbProperty WhenToStart { get; set; } = new PDMDbProperty(nameof(WhenToStart), "WhenToStart", "预计开始时间(归纳)", false, PDMDataType.datetime, 0, 0, false, null);
        public static PDMDbProperty WhenToEnd { get; set; } = new PDMDbProperty(nameof(WhenToEnd), "WhenToEnd", "预计结束时间(归纳)", false, PDMDataType.datetime, 0, 0, false, null);
        public static PDMDbProperty WhenStart { get; set; } = new PDMDbProperty(nameof(WhenStart), "WhenStart", "实际开始时间(归纳)", false, PDMDataType.datetime, 0, 0, false, null);
        public static PDMDbProperty WhenEnd { get; set; } = new PDMDbProperty(nameof(WhenEnd), "WhenEnd", "实际结束时间(归纳)", false, PDMDataType.datetime, 0, 0, false, null);
        public static PDMDbProperty DealStatus { get; set; } = new PDMDbProperty(nameof(DealStatus), "DealStatus", "执行情况", false, PDMDataType.numeric, 2, 0, true, null);
        #endregion
    }
}
