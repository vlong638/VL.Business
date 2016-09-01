using System.Runtime.Serialization;

namespace VL.Spider.Objects.Enums
{
    [DataContract]
    public enum EProcessStatus
    {
        /// <summary>
        /// 未执行处理
        /// </summary>
        [EnumMember]
        Ready = 0,
        /// <summary>
        /// 处理成功
        /// </summary>
        [EnumMember]
        Success,
        /// <summary>
        /// 处理失败
        /// </summary>
        [EnumMember]
        Failure,
        /// <summary>
        /// 结果异常
        /// </summary>
        [EnumMember]
        Error,
    }
}
