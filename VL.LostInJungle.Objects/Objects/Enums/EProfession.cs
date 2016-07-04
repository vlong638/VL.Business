using System.Runtime.Serialization;

namespace VL.LostInJungle.Objects.Enums
{
    [DataContract]
    public enum EProfession
    {
        /// <summary>
        /// 无职业
        /// </summary>
        [EnumMember]
        None = 0,
        /// <summary>
        /// 战士
        /// </summary>
        [EnumMember]
        Warrior = 1,
        /// <summary>
        /// 猎人
        /// </summary>
        [EnumMember]
        Hunter = 2,
        /// <summary>
        /// 探索者
        /// </summary>
        [EnumMember]
        Explorer = 3,
        /// <summary>
        /// 魔法师
        /// </summary>
        [EnumMember]
        Magician = 4,
    }
}
