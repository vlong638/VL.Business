using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.LostInJungle.Objects.Enums;

namespace VL.LostInJungle.Objects.Entities
{
    [DataContract]
    public partial class TCreatureSkill : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid CreatureId { get; set; }
        [DataMember]
        public String SurvivalSkill { get; set; }
        [DataMember]
        public String WarriorSkills { get; set; }
        [DataMember]
        public String ExplorerSkills { get; set; }
        [DataMember]
        public String FarmingSkills { get; set; }
        [DataMember]
        public String RasingSkills { get; set; }
        [DataMember]
        public String BowmanSkills { get; set; }
        [DataMember]
        public String FishingSkills { get; set; }
        #endregion

        #region Constructors
        public TCreatureSkill()
        {
        }
        public TCreatureSkill(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.CreatureId = new Guid(reader[nameof(this.CreatureId)].ToString());
            this.SurvivalSkill = Convert.ToString(reader[nameof(this.SurvivalSkill)]);
            this.WarriorSkills = Convert.ToString(reader[nameof(this.WarriorSkills)]);
            this.ExplorerSkills = Convert.ToString(reader[nameof(this.ExplorerSkills)]);
            this.FarmingSkills = Convert.ToString(reader[nameof(this.FarmingSkills)]);
            this.RasingSkills = Convert.ToString(reader[nameof(this.RasingSkills)]);
            this.BowmanSkills = Convert.ToString(reader[nameof(this.BowmanSkills)]);
            this.FishingSkills = Convert.ToString(reader[nameof(this.FishingSkills)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(CreatureId)))
            {
                this.CreatureId = new Guid(reader[nameof(this.CreatureId)].ToString());
            }
            if (fields.Contains(nameof(SurvivalSkill)))
            {
                this.SurvivalSkill = Convert.ToString(reader[nameof(this.SurvivalSkill)]);
            }
            if (fields.Contains(nameof(WarriorSkills)))
            {
                this.WarriorSkills = Convert.ToString(reader[nameof(this.WarriorSkills)]);
            }
            if (fields.Contains(nameof(ExplorerSkills)))
            {
                this.ExplorerSkills = Convert.ToString(reader[nameof(this.ExplorerSkills)]);
            }
            if (fields.Contains(nameof(FarmingSkills)))
            {
                this.FarmingSkills = Convert.ToString(reader[nameof(this.FarmingSkills)]);
            }
            if (fields.Contains(nameof(RasingSkills)))
            {
                this.RasingSkills = Convert.ToString(reader[nameof(this.RasingSkills)]);
            }
            if (fields.Contains(nameof(BowmanSkills)))
            {
                this.BowmanSkills = Convert.ToString(reader[nameof(this.BowmanSkills)]);
            }
            if (fields.Contains(nameof(FishingSkills)))
            {
                this.FishingSkills = Convert.ToString(reader[nameof(this.FishingSkills)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TCreatureSkill);
            }
        }
        #endregion
    }
}
