using System.Runtime.Serialization;

namespace Dacai.MagicSquareAlgorithm.Objects.Enums
{
    [DataContract]
    public enum EAlgorithmSourceType
    {
        /// <summary>
        /// 未指定
        /// </summary>
        [EnumMember]
        None = 0,
        /// <summary>
        /// 英超
        /// </summary>
        [EnumMember]
        YC = 1,
        /// <summary>
        /// 德甲
        /// </summary>
        [EnumMember]
        DJ = 2,
        /// <summary>
        /// 意甲
        /// </summary>
        [EnumMember]
        YJ = 3,
        /// <summary>
        /// 法甲
        /// </summary>
        [EnumMember]
        FJ = 4,
        /// <summary>
        /// 西甲
        /// </summary>
        [EnumMember]
        XJ = 5,
        /// <summary>
        /// 欧冠欧联
        /// </summary>
        [EnumMember]
        OGOL = 6,
        /// <summary>
        /// 其他
        /// </summary>
        [EnumMember]
        Others = 7,
    }
}
