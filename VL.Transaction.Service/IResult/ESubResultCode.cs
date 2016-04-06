using System.Runtime.Serialization;

namespace VL.Transaction.Service.IResult
{
    [DataContract]
    public enum ESubResultCode
    {
        /// <summary>
        /// 未指定
        /// </summary>
        [EnumMember]
        None = 0,
        /// <summary>
        /// 本地
        /// </summary>
        [EnumMember]
        Local = 1,
    }
}
