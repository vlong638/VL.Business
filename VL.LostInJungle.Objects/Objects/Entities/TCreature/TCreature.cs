using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.LostInJungle.Objects.Enums;

namespace VL.LostInJungle.Objects.Entities
{
    [DataContract]
    public partial class TCreature : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid CreatureId { get; set; }
        [DataMember]
        public ECreatureType CreatureType { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public Int32 Experience { get; set; }
        [DataMember]
        public Int16 Level { get; set; }
        [DataMember]
        public EProfession Profession { get; set; }
        #endregion

        #region Constructors
        public TCreature()
        {
        }
        public TCreature(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.CreatureId = new Guid(reader[nameof(this.CreatureId)].ToString());
            this.CreatureType = (ECreatureType)Enum.Parse(typeof(ECreatureType), reader[nameof(this.CreatureType)].ToString());
            this.Name = Convert.ToString(reader[nameof(this.Name)]);
            this.Experience = Convert.ToInt32(reader[nameof(this.Experience)]);
            this.Level = Convert.ToInt16(reader[nameof(this.Level)]);
            this.Profession = (EProfession)Enum.Parse(typeof(EProfession), reader[nameof(this.Profession)].ToString());
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(CreatureId)))
            {
                this.CreatureId = new Guid(reader[nameof(this.CreatureId)].ToString());
            }
            if (fields.Contains(nameof(CreatureType)))
            {
                this.CreatureType = (ECreatureType)Enum.Parse(typeof(ECreatureType), reader[nameof(this.CreatureType)].ToString());
            }
            if (fields.Contains(nameof(Name)))
            {
                this.Name = Convert.ToString(reader[nameof(this.Name)]);
            }
            if (fields.Contains(nameof(Experience)))
            {
                this.Experience = Convert.ToInt32(reader[nameof(this.Experience)]);
            }
            if (fields.Contains(nameof(Level)))
            {
                this.Level = Convert.ToInt16(reader[nameof(this.Level)]);
            }
            if (fields.Contains(nameof(Profession)))
            {
                this.Profession = (EProfession)Enum.Parse(typeof(EProfession), reader[nameof(this.Profession)].ToString());
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TCreature);
            }
        }
        #endregion
    }
}
