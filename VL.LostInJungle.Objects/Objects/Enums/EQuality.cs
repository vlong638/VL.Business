using System.Runtime.Serialization;

namespace VL.LostInJungle.Objects.Enums
{
    [DataContract]
    public enum EQuality
    {
        /// <summary>
        /// 未传承
        /// </summary>
        [EnumMember]
        None = 0,
        /// <summary>
        /// 一级传承品质
        /// </summary>
        [EnumMember]
        FirstLevelQuality = 101,
        /// <summary>
        /// 二级传承品质
        /// </summary>
        [EnumMember]
        SecondLevelQuality = 201,
        /// <summary>
        /// 三级传承品质
        /// </summary>
        [EnumMember]
        ThirdLevelQuality = 301,
    }
}
