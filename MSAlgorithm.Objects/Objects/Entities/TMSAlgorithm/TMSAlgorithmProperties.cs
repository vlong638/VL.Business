using VL.Common.ORM.Objects;

namespace Dacai.MagicSquareAlgorithm.Objects.Entities
{
    public class TMSAlgorithmProperties
    {
        #region Properties
        public static PDMDbProperty AlgorithmId { get; set; } = new PDMDbProperty(nameof(AlgorithmId), "AlgorithmId", "数据魔方Id", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty Name { get; set; } = new PDMDbProperty(nameof(Name), "Name", "用户名", false, PDMDataType.nvarchar, 20, 0, true, null);
        public static PDMDbProperty Type { get; set; } = new PDMDbProperty(nameof(Type), "Type", "手机", false, PDMDataType.numeric, 13, 0, true, null);
        public static PDMDbProperty DZWeight { get; set; } = new PDMDbProperty(nameof(DZWeight), "DZWeight", "对阵信息权重", false, PDMDataType.numeric, 4, 0, true, null);
        public static PDMDbProperty JCWeight { get; set; } = new PDMDbProperty(nameof(JCWeight), "JCWeight", "基础信息权重", false, PDMDataType.numeric, 4, 0, true, null);
        public static PDMDbProperty PLWeight { get; set; } = new PDMDbProperty(nameof(PLWeight), "PLWeight", "赔率信息权重", false, PDMDataType.numeric, 4, 0, true, null);
        #endregion
    }
}
