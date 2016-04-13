using System.Runtime.Serialization;

namespace VL.User.Objects.SubResults
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
