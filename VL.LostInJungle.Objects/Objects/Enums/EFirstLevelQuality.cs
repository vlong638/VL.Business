using System.Runtime.Serialization;

namespace LostInJungle.Objects.Enums
{
    [DataContract]
    public enum EFirstLevelQuality
    {
        /// <summary>
        /// 未传承
        /// </summary>
        [EnumMember]
        None = 0,
    }
}
