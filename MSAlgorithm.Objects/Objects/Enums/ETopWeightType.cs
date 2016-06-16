using System.Runtime.Serialization;

namespace Dacai.MagicSquareAlgorithm.Objects.Enums
{
    [DataContract]
    public enum ETopWeightType
    {
        /// <summary>
        /// 未指定
        /// </summary>
        [EnumMember]
        None = 0,
        /// <summary>
        /// 基础
        /// </summary>
        [EnumMember]
        JC = 1,
        /// <summary>
        /// 对阵
        /// </summary>
        [EnumMember]
        DZ = 2,
        /// <summary>
        /// 赔率
        /// </summary>
        [EnumMember]
        PL = 3,
    }
}
