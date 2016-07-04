using System.Runtime.Serialization;

namespace LostInJungle.Objects.Enums
{
    [DataContract]
    public enum ESecondLevelQuality
    {
        /// <summary>
        /// 未传承
        /// </summary>
        [EnumMember]
        None = 0,
    }
}
