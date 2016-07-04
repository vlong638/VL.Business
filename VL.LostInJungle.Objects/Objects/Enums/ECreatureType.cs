using System.Runtime.Serialization;

namespace VL.LostInJungle.Objects.Enums
{
    [DataContract]
    public enum ECreatureType
    {
        /// <summary>
        /// 未指定
        /// </summary>
        [EnumMember]
        None = 0,
        /// <summary>
        /// 暗夜精灵
        /// </summary>
        [EnumMember]
        NightElf = 101,
        /// <summary>
        /// 人类
        /// </summary>
        [EnumMember]
        Human = 102,
        /// <summary>
        /// 兽人
        /// </summary>
        [EnumMember]
        Orc = 103,
        /// <summary>
        /// 牛头人
        /// </summary>
        [EnumMember]
        Minotaur = 104,
        /// <summary>
        /// 矮人
        /// </summary>
        [EnumMember]
        Dwarf = 105,
        /// <summary>
        /// 亡灵
        /// </summary>
        [EnumMember]
        Undead = 106,
        /// <summary>
        /// 巨魔
        /// </summary>
        [EnumMember]
        Trolls = 107,
        /// <summary>
        /// 侏儒
        /// </summary>
        [EnumMember]
        Dwarfism = 108,
        /// <summary>
        /// 血精灵
        /// </summary>
        [EnumMember]
        BloodElf = 109,
        /// <summary>
        /// 德鲁伊
        /// </summary>
        [EnumMember]
        Delaney = 110,
        /// <summary>
        /// 狼人
        /// </summary>
        [EnumMember]
        Werewolf = 111,
        /// <summary>
        /// 野兽
        /// </summary>
        [EnumMember]
        Animal = 200,
        /// <summary>
        /// 老鼠
        /// </summary>
        [EnumMember]
        Mouse = 201,
        /// <summary>
        /// 野鸡
        /// </summary>
        [EnumMember]
        Pheasant = 202,
        /// <summary>
        /// 野猪
        /// </summary>
        [EnumMember]
        WildBoar = 203,
        /// <summary>
        /// 毒蛇
        /// </summary>
        [EnumMember]
        Snake = 204,
        /// <summary>
        /// 黑熊
        /// </summary>
        [EnumMember]
        Bear	 = 205,
        /// <summary>
        /// 魔兽
        /// </summary>
        [EnumMember]
        Monster		 = 300,
        /// <summary>
        /// 异族
        /// </summary>
        [EnumMember]
        WildPeople = 400,
        /// <summary>
        /// 地精
        /// </summary>
        [EnumMember]
        Goblin = 401,
    }
}
