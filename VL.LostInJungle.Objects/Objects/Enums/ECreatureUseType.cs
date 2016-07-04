using System.Runtime.Serialization;

namespace VL.LostInJungle.Objects.Enums
{
    [DataContract]
    public enum ECreatureUseType
    {
        /// <summary>
        /// 未指定
        /// </summary>
        [EnumMember]
        None = 0,
        /// <summary>
        /// 可选角色
        /// </summary>
        [EnumMember]
        Player = 1,
        /// <summary>
        /// 非玩家角色
        /// </summary>
        [EnumMember]
        NPC = 2,
        /// <summary>
        /// 野外怪物
        /// </summary>
        [EnumMember]
        Monster = 3,
        /// <summary>
        /// 精英怪物
        /// </summary>
        [EnumMember]
        EliteMonster = 4,
        /// <summary>
        /// 领主怪物
        /// </summary>
        [EnumMember]
        LordMonster = 5,
    }
}
