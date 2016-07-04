using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.LostInJungle.Objects.Enums;

namespace VL.LostInJungle.Objects.Entities
{
    [DataContract]
    public partial class TPrototypeCreature : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid CreatureId { get; set; }
        [DataMember]
        public ECreatureType CreatureType { get; set; }
        [DataMember]
        public ECreatureUseType CreatureUseType { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public Int16 Level { get; set; }
        [DataMember]
        public EProfession Profession { get; set; }
        [DataMember]
        public String Properties { get; set; }
        [DataMember]
        public String Skills { get; set; }
        [DataMember]
        public String Qualities { get; set; }
        #endregion

        #region Constructors
        public TPrototypeCreature()
        {
        }
        public TPrototypeCreature(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.CreatureId = new Guid(reader[nameof(this.CreatureId)].ToString());
            this.CreatureType = (ECreatureType)Enum.Parse(typeof(ECreatureType), reader[nameof(this.CreatureType)].ToString());
            this.CreatureUseType = (ECreatureUseType)Enum.Parse(typeof(ECreatureUseType), reader[nameof(this.CreatureUseType)].ToString());
            this.Name = Convert.ToString(reader[nameof(this.Name)]);
            this.Level = Convert.ToInt16(reader[nameof(this.Level)]);
            this.Profession = (EProfession)Enum.Parse(typeof(EProfession), reader[nameof(this.Profession)].ToString());
            this.Properties = Convert.ToString(reader[nameof(this.Properties)]);
            this.Skills = Convert.ToString(reader[nameof(this.Skills)]);
            this.Qualities = Convert.ToString(reader[nameof(this.Qualities)]);
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
            if (fields.Contains(nameof(CreatureUseType)))
            {
                this.CreatureUseType = (ECreatureUseType)Enum.Parse(typeof(ECreatureUseType), reader[nameof(this.CreatureUseType)].ToString());
            }
            if (fields.Contains(nameof(Name)))
            {
                this.Name = Convert.ToString(reader[nameof(this.Name)]);
            }
            if (fields.Contains(nameof(Level)))
            {
                this.Level = Convert.ToInt16(reader[nameof(this.Level)]);
            }
            if (fields.Contains(nameof(Profession)))
            {
                this.Profession = (EProfession)Enum.Parse(typeof(EProfession), reader[nameof(this.Profession)].ToString());
            }
            if (fields.Contains(nameof(Properties)))
            {
                this.Properties = Convert.ToString(reader[nameof(this.Properties)]);
            }
            if (fields.Contains(nameof(Skills)))
            {
                this.Skills = Convert.ToString(reader[nameof(this.Skills)]);
            }
            if (fields.Contains(nameof(Qualities)))
            {
                this.Qualities = Convert.ToString(reader[nameof(this.Qualities)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TPrototypeCreature);
            }
        }
        #endregion
    }
}
