using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.LostInJungle.Objects.Enums;

namespace VL.LostInJungle.Objects.Entities
{
    [DataContract]
    public partial class TCreatureProperty : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid CreatureId { get; set; }
        [DataMember]
        public Int16 HitPoint { get; set; }
        [DataMember]
        public Int16 MagicPoint { get; set; }
        [DataMember]
        public Int16 Strength { get; set; }
        [DataMember]
        public Int16 Stamina { get; set; }
        [DataMember]
        public Int16 Agility { get; set; }
        [DataMember]
        public Int16 Intelligence { get; set; }
        [DataMember]
        public Int16 Mentality { get; set; }
        #endregion

        #region Constructors
        public TCreatureProperty()
        {
        }
        public TCreatureProperty(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.CreatureId = new Guid(reader[nameof(this.CreatureId)].ToString());
            this.HitPoint = Convert.ToInt16(reader[nameof(this.HitPoint)]);
            this.MagicPoint = Convert.ToInt16(reader[nameof(this.MagicPoint)]);
            this.Strength = Convert.ToInt16(reader[nameof(this.Strength)]);
            this.Stamina = Convert.ToInt16(reader[nameof(this.Stamina)]);
            this.Agility = Convert.ToInt16(reader[nameof(this.Agility)]);
            this.Intelligence = Convert.ToInt16(reader[nameof(this.Intelligence)]);
            this.Mentality = Convert.ToInt16(reader[nameof(this.Mentality)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(CreatureId)))
            {
                this.CreatureId = new Guid(reader[nameof(this.CreatureId)].ToString());
            }
            if (fields.Contains(nameof(HitPoint)))
            {
                this.HitPoint = Convert.ToInt16(reader[nameof(this.HitPoint)]);
            }
            if (fields.Contains(nameof(MagicPoint)))
            {
                this.MagicPoint = Convert.ToInt16(reader[nameof(this.MagicPoint)]);
            }
            if (fields.Contains(nameof(Strength)))
            {
                this.Strength = Convert.ToInt16(reader[nameof(this.Strength)]);
            }
            if (fields.Contains(nameof(Stamina)))
            {
                this.Stamina = Convert.ToInt16(reader[nameof(this.Stamina)]);
            }
            if (fields.Contains(nameof(Agility)))
            {
                this.Agility = Convert.ToInt16(reader[nameof(this.Agility)]);
            }
            if (fields.Contains(nameof(Intelligence)))
            {
                this.Intelligence = Convert.ToInt16(reader[nameof(this.Intelligence)]);
            }
            if (fields.Contains(nameof(Mentality)))
            {
                this.Mentality = Convert.ToInt16(reader[nameof(this.Mentality)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TCreatureProperty);
            }
        }
        #endregion
    }
}
