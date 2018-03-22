using System;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public class TListProperties
    {
        #region Properties
        public static PDMDbProperty<String> Segregation { get; set; } = new PDMDbProperty<String>(nameof(Segregation), "Segregation", "隔离区间", true, PDMDataType.varchar, 36, 0, true);
        public static PDMDbProperty<Int16> IssueType { get; set; } = new PDMDbProperty<Int16>(nameof(IssueType), "IssueType", "监测类型", true, PDMDataType.numeric, 16, 0, true);
        public static PDMDbProperty<DateTime> IssueDate { get; set; } = new PDMDbProperty<DateTime>(nameof(IssueDate), "IssueDate", "监测日期", true, PDMDataType.datetime, 0, 0, true);
        public static PDMDbProperty<Int16> DataCount { get; set; } = new PDMDbProperty<Int16>(nameof(DataCount), "DataCount", "下级数据量", false, PDMDataType.numeric, 16, 0, true);
        #endregion
    }
}
