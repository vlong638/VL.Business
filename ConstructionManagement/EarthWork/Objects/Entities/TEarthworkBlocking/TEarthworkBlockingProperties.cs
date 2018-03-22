using System;
using VL.Common.Core.ORM;

namespace VL.Common.Core.Object.Subsidence
{
    public class TEarthworkBlockingProperties
    {
        #region Properties
        public static PDMDbProperty<DateTime> IssueDateTime { get; set; } = new PDMDbProperty<DateTime>(nameof(IssueDateTime), "IssueDateTime", "数据时间", true, PDMDataType.datetime, 0, 0, true);
        public static PDMDbProperty<Int16> EarthworkBlockMaxId { get; set; } = new PDMDbProperty<Int16>(nameof(EarthworkBlockMaxId), "EarthworkBlockMaxId", "Earthwork的编号", false, PDMDataType.numeric, 16, 0, true);
        public static PDMDbProperty<String> ColorForUnsettled { get; set; } = new PDMDbProperty<String>(nameof(ColorForUnsettled), "ColorForUnsettled", "颜色(未完工)", false, PDMDataType.varchar, 20, 0, true);
        public static PDMDbProperty<String> ColorForSettled { get; set; } = new PDMDbProperty<String>(nameof(ColorForSettled), "ColorForSettled", "颜色(已完工)", false, PDMDataType.varchar, 20, 0, true);
        public static PDMDbProperty<Boolean> IsImplementationInfoConflicted { get; set; } = new PDMDbProperty<Boolean>(nameof(IsImplementationInfoConflicted), "IsImplementationInfoConflicted", "是否分段内容有变动", false, PDMDataType.numeric, 1, 0, true);
        #endregion
    }
}
