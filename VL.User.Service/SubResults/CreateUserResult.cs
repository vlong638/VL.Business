using System.Runtime.Serialization;

namespace VL.User.Service.SubResults
{
    [DataContract]
    public enum CreateUserResult
    {
        [EnumMember]
        UserNameExist,
        [EnumMember]
        MobileExist,
        [EnumMember]
        EmailExist,
        [EnumMember]
        InserFailed,
    }
}
