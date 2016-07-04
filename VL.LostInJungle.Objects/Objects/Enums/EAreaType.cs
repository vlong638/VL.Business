using System.Runtime.Serialization;

namespace VL.LostInJungle.Objects.Enums
{
    [DataContract]
    public enum EAreaType
    {
        /// <summary>
        /// 常规
        /// </summary>
        [EnumMember]
        None = 0,
        /// <summary>
        /// 沼泽
        /// </summary>
        [EnumMember]
        Swamp = 1,
        /// <summary>
        /// 草地
        /// </summary>
        [EnumMember]
        GrassLand = 2,
        /// <summary>
        /// 林地
        /// </summary>
        [EnumMember]
        ForestLand = 3,
        /// <summary>
        /// 矿区
        /// </summary>
        [EnumMember]
        MineArea = 4,
        /// <summary>
        /// 水域
        /// </summary>
        [EnumMember]
        WaterArea = 5,
    }
}
