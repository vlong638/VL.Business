using VL.Common.ORM.Objects;

namespace VL.LostInJungle.Objects.Entities
{
    public class TTeamCreatureProperties
    {
        #region Properties
        public static PDMDbProperty TeamId { get; set; } = new PDMDbProperty(nameof(TeamId), "TeamId", "队伍标识", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        public static PDMDbProperty CreatureId { get; set; } = new PDMDbProperty(nameof(CreatureId), "CreatureId", "生物标识", true, PDMDataType.uniqueidentifier, 0, 0, true, null);
        #endregion
    }
}
