using System;
using VL.Common.Core.ORM;

namespace VL.Common.Core.Object.Subsidence
{
    public class TEarthworkBlockElementProperties
    {
        #region Properties
        public static PDMDbProperty<DateTime> IssueDateTime { get; set; } = new PDMDbProperty<DateTime>(nameof(IssueDateTime), "IssueDateTime", "数据时间", true, PDMDataType.datetime, 0, 0, true);
        public static PDMDbProperty<Int16> Id { get; set; } = new PDMDbProperty<Int16>(nameof(Id), "Id", "Earthwork的编号", true, PDMDataType.numeric, 16, 0, true);
        public static PDMDbProperty<Int16> GroupId { get; set; } = new PDMDbProperty<Int16>(nameof(GroupId), "GroupId", "组包号", true, PDMDataType.numeric, 16, 0, true);
        public static PDMDbProperty<String> ElementIds { get; set; } = new PDMDbProperty<String>(nameof(ElementIds), "ElementIds", "构件Id集合,每个组包存储100个,6+1*100", false, PDMDataType.varchar, 1000, 0, true);
        #endregion
    }
}
