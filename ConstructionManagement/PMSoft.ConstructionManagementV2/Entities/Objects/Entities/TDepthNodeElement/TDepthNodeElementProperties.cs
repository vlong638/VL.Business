using System;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public class TDepthNodeElementProperties
    {
        #region Properties
        public static PDMDbProperty<String> Segregation { get; set; } = new PDMDbProperty<String>(nameof(Segregation), "Segregation", "隔离区间", true, PDMDataType.varchar, 36, 0, true);
        public static PDMDbProperty<String> NodeCode { get; set; } = new PDMDbProperty<String>(nameof(NodeCode), "NodeCode", "测点编号", true, PDMDataType.varchar, 20, 0, true);
        public static PDMDbProperty<String> Depth { get; set; } = new PDMDbProperty<String>(nameof(Depth), "Depth", "测点深度", true, PDMDataType.varchar, 10, 0, true);
        public static PDMDbProperty<String> ElementIds { get; set; } = new PDMDbProperty<String>(nameof(ElementIds), "ElementIds", "测点构件", false, PDMDataType.varchar, 2000, 0, true);
        #endregion
    }
}
