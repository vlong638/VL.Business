using System.Runtime.Serialization;

namespace Dacai.MagicSquareAlgorithm.Objects.Enums
{
    [DataContract]
    public enum EResultType
    {
        /// <summary>
        /// 未指定
        /// </summary>
        [EnumMember]
        None = 0,
        /// <summary>
        /// 主队优于客队
        /// </summary>
        [EnumMember]
        HomeBetter = 1,
        /// <summary>
        /// 主队劣于客队
        /// </summary>
        [EnumMember]
        Fair = 2,
        /// <summary>
        /// 主队等于客队
        /// </summary>
        [EnumMember]
        GuestBetter = 3,
        /// <summary>
        /// 目标达成
        /// </summary>
        [EnumMember]
        Qualified = 4,
    }
}
