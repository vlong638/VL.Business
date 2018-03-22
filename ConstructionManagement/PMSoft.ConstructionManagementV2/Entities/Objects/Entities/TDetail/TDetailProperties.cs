using System;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public class TDetailProperties
    {
        #region Properties
        public static PDMDbProperty<String> Segregation { get; set; } = new PDMDbProperty<String>(nameof(Segregation), "Segregation", "隔离区间", true, PDMDataType.varchar, 36, 0, true);
        public static PDMDbProperty<Int16> IssueType { get; set; } = new PDMDbProperty<Int16>(nameof(IssueType), "IssueType", "监测类型", true, PDMDataType.numeric, 8, 0, true);
        public static PDMDbProperty<DateTime> IssueDateTime { get; set; } = new PDMDbProperty<DateTime>(nameof(IssueDateTime), "IssueDateTime", "监测时间", true, PDMDataType.datetime, 0, 0, true);
        public static PDMDbProperty<Int16> IssueTimeRange { get; set; } = new PDMDbProperty<Int16>(nameof(IssueTimeRange), "IssueTimeRange", "监测时间跨度(分钟)", false, PDMDataType.numeric, 16, 0, true);
        public static PDMDbProperty<String> ReportName { get; set; } = new PDMDbProperty<String>(nameof(ReportName), "ReportName", "报告名称", false, PDMDataType.varchar, 200, 0, true);
        public static PDMDbProperty<String> Contractor { get; set; } = new PDMDbProperty<String>(nameof(Contractor), "Contractor", "承包单位", false, PDMDataType.varchar, 100, 0, true);
        public static PDMDbProperty<String> Supervisor { get; set; } = new PDMDbProperty<String>(nameof(Supervisor), "Supervisor", "监理单位", false, PDMDataType.varchar, 100, 0, true);
        public static PDMDbProperty<String> Monitor { get; set; } = new PDMDbProperty<String>(nameof(Monitor), "Monitor", "监测单位", false, PDMDataType.varchar, 100, 0, true);
        public static PDMDbProperty<String> InstrumentName { get; set; } = new PDMDbProperty<String>(nameof(InstrumentName), "InstrumentName", "仪器名称", false, PDMDataType.varchar, 100, 0, true);
        public static PDMDbProperty<String> InstrumentCode { get; set; } = new PDMDbProperty<String>(nameof(InstrumentCode), "InstrumentCode", "仪器编号", false, PDMDataType.varchar, 100, 0, true);
        public static PDMDbProperty<String> CloseCTSettings { get; set; } = new PDMDbProperty<String>(nameof(CloseCTSettings), "CloseCTSettings", "接近预警值(颜色/透明度配置)", false, PDMDataType.varchar, 500, 0, true);
        public static PDMDbProperty<String> OverCTSettings { get; set; } = new PDMDbProperty<String>(nameof(OverCTSettings), "OverCTSettings", "超出预警值(颜色/透明度配置)", false, PDMDataType.varchar, 500, 0, true);
        public static PDMDbProperty<Int16> ExtraValue1 { get; set; } = new PDMDbProperty<Int16>(nameof(ExtraValue1), "ExtraValue1", "附加值", false, PDMDataType.numeric, 16, 0, false);
        public static PDMDbProperty<Int16> ExtraValue2 { get; set; } = new PDMDbProperty<Int16>(nameof(ExtraValue2), "ExtraValue2", "附加值", false, PDMDataType.numeric, 16, 0, false);
        public static PDMDbProperty<Int16> ExtraValue3 { get; set; } = new PDMDbProperty<Int16>(nameof(ExtraValue3), "ExtraValue3", "附加值", false, PDMDataType.numeric, 16, 0, false);
        #endregion
    }
}
