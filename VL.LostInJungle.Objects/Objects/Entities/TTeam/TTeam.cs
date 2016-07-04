using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.LostInJungle.Objects.Enums;

namespace VL.LostInJungle.Objects.Entities
{
    [DataContract]
    public partial class TTeam : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid TeamId { get; set; }
        [DataMember]
        public String Name { get; set; }
        #endregion

        #region Constructors
        public TTeam()
        {
        }
        public TTeam(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.TeamId = new Guid(reader[nameof(this.TeamId)].ToString());
            this.Name = Convert.ToString(reader[nameof(this.Name)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(TeamId)))
            {
                this.TeamId = new Guid(reader[nameof(this.TeamId)].ToString());
            }
            if (fields.Contains(nameof(Name)))
            {
                this.Name = Convert.ToString(reader[nameof(this.Name)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TTeam);
            }
        }
        #endregion
    }
}
