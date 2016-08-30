using System.Runtime.Serialization;

namespace VL.Spider.Objects.Enums
{
    [DataContract]
    public enum EGrabType
    {
        /// <summary>
        /// 文件
        /// </summary>
        [EnumMember]
        File = 0,
        /// <summary>
        /// 静态列表
        /// </summary>
        [EnumMember]
        StaticList,
        /// <summary>
        /// 动态列表
        /// </summary>
        [EnumMember]
        DynamicList,
        /// <summary>
        /// 详情
        /// </summary>
        [EnumMember]
        Detail,
    }
}
