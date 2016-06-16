using VL.Common.ORM.Objects;

namespace Dacai.MagicSquareAlgorithm.Objects.Entities
{
    public class TMSAlgorithmSettingsProperties
    {
        #region Properties
        public static PDMDbProperty AlgorithmId { get; set; } = new PDMDbProperty(nameof(AlgorithmId), "AlgorithmId", "数据魔方Id", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty TopWeightType { get; set; } = new PDMDbProperty(nameof(TopWeightType), "TopWeightType", "主权重类别", true, PDMDataType.numeric, 4, 0, true, null);
        public static PDMDbProperty SubWeightType { get; set; } = new PDMDbProperty(nameof(SubWeightType), "SubWeightType", "子权重类别", true, PDMDataType.numeric, 4, 0, true, null);
        public static PDMDbProperty ResultType { get; set; } = new PDMDbProperty(nameof(ResultType), "ResultType", "结果类型", false, PDMDataType.numeric, 4, 0, true, null);
        public static PDMDbProperty WeightValue { get; set; } = new PDMDbProperty(nameof(WeightValue), "WeightValue", "权值", false, PDMDataType.numeric, 4, 0, true, null);
        #endregion
    }
}
