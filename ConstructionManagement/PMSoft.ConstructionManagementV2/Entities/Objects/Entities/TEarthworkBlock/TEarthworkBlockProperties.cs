using System;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public class TEarthworkBlockProperties
    {
        #region Properties
        public static PDMDbProperty<String> Segregation { get; set; } = new PDMDbProperty<String>(nameof(Segregation), "Segregation", "隔离区间", true, PDMDataType.varchar, 36, 0, true);
        public static PDMDbProperty<DateTime> IssueDateTime { get; set; } = new PDMDbProperty<DateTime>(nameof(IssueDateTime), "IssueDateTime", "数据时间", true, PDMDataType.datetime, 0, 0, true);
        public static PDMDbProperty<Int16> Id { get; set; } = new PDMDbProperty<Int16>(nameof(Id), "Id", "Earthwork的编号", true, PDMDataType.numeric, 16, 0, true);
        public static PDMDbProperty<Int16> Indexer { get; set; } = new PDMDbProperty<Int16>(nameof(Indexer), "Indexer", "Earthwork的顺序号", false, PDMDataType.numeric, 16, 0, true);
        public static PDMDbProperty<String> Name { get; set; } = new PDMDbProperty<String>(nameof(Name), "Name", "名称", false, PDMDataType.varchar, 100, 0, true);
        public static PDMDbProperty<String> Description { get; set; } = new PDMDbProperty<String>(nameof(Description), "Description", "描述", false, PDMDataType.varchar, 1000, 0, true);
        public static PDMDbProperty<String> CPSettings { get; set; } = new PDMDbProperty<String>(nameof(CPSettings), "CPSettings", "颜色透明度配置", false, PDMDataType.varchar, 1000, 0, true);
        public static PDMDbProperty<String> EarthworkBlockImplementationInfo { get; set; } = new PDMDbProperty<String>(nameof(EarthworkBlockImplementationInfo), "EarthworkBlockImplementationInfo", "节点施工信息", false, PDMDataType.varchar, 1000, 0, true);
        #endregion
    }
}
