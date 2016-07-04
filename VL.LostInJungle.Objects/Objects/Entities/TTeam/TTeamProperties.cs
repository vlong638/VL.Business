using VL.Common.ORM.Objects;

namespace VL.LostInJungle.Objects.Entities
{
    public class TTeamProperties
    {
        #region Properties
        public static PDMDbProperty TeamId { get; set; } = new PDMDbProperty(nameof(TeamId), "TeamId", "标识", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty Name { get; set; } = new PDMDbProperty(nameof(Name), "Name", "队伍名", false, PDMDataType.nvarchar, 20, 0, true, null);
        #endregion
    }
}
