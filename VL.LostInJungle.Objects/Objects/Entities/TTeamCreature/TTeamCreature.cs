using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.LostInJungle.Objects.Enums;

namespace VL.LostInJungle.Objects.Entities
{
    [DataContract]
    public partial class TTeamCreature : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid TeamId { get; set; }
        [DataMember]
        public Guid CreatureId { get; set; }
        #endregion

        #region Constructors
        public TTeamCreature()
        {
        }
        public TTeamCreature(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.TeamId = new Guid(reader[nameof(this.TeamId)].ToString());
            this.CreatureId = new Guid(reader[nameof(this.CreatureId)].ToString());
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(TeamId)))
            {
                this.TeamId = new Guid(reader[nameof(this.TeamId)].ToString());
            }
            if (fields.Contains(nameof(CreatureId)))
            {
                this.CreatureId = new Guid(reader[nameof(this.CreatureId)].ToString());
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TTeamCreature);
            }
        }
        #endregion
    }
}
