using VL.Common.ORM.Objects;

namespace VL.User.Objects.Entities
{
    public class TUserProperties
    {
        #region Properties
        public static PDMDbProperty UserId { get; set; } = new PDMDbProperty(nameof(UserId), "UserId", "用户Id", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty UserName { get; set; } = new PDMDbProperty(nameof(UserName), "UserName", "用户名", false, PDMDataType.nvarchar, 10, 0, true, null);
        public static PDMDbProperty Mobile { get; set; } = new PDMDbProperty(nameof(Mobile), "Mobile", "手机", false, PDMDataType.numeric, 11, 0, true, null);
        public static PDMDbProperty Email { get; set; } = new PDMDbProperty(nameof(Email), "Email", "电子邮箱(不区分大小写)", false, PDMDataType.nvarchar, 32, 0, true, null);
        public static PDMDbProperty IdCardNumber { get; set; } = new PDMDbProperty(nameof(IdCardNumber), "IdCardNumber", "身份证号码", false, PDMDataType.nvarchar, 18, 0, true, null);
        public static PDMDbProperty Password { get; set; } = new PDMDbProperty(nameof(Password), "Password", "支付密码", false, PDMDataType.nvarchar, 16, 0, true, null);
        public static PDMDbProperty CreateTime { get; set; } = new PDMDbProperty(nameof(CreateTime), "CreateTime", "创建时间", false, PDMDataType.datetime, 0, 0, true, null);
        #endregion
    }
}
