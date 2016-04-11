using System.Runtime.Serialization;

namespace VL.User.Service.SubResults
{
    [DataContract]
    public enum AuthenticateResult
    {
        [EnumMember]
        None,
        [EnumMember]
        UserNameUnexist,
        [EnumMember]
        PasswordError
    }
}
