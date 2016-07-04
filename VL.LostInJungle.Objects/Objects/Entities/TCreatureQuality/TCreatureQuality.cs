using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.LostInJungle.Objects.Enums;

namespace VL.LostInJungle.Objects.Entities
{
    [DataContract]
    public partial class TCreatureQuality : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid CreatureId { get; set; }
        [DataMember]
        public Int16 FirstLevelQuality { get; set; }
        [DataMember]
        public Int16 SecondLevelQuality { get; set; }
        [DataMember]
        public Int16 ThirdLevelQuality { get; set; }
        #endregion

        #region Constructors
        public TCreatureQuality()
        {
        }
        public TCreatureQuality(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.CreatureId = new Guid(reader[nameof(this.CreatureId)].ToString());
            this.FirstLevelQuality = Convert.ToInt16(reader[nameof(this.FirstLevelQuality)]);
            this.SecondLevelQuality = Convert.ToInt16(reader[nameof(this.SecondLevelQuality)]);
            this.ThirdLevelQuality = Convert.ToInt16(reader[nameof(this.ThirdLevelQuality)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(CreatureId)))
            {
                this.CreatureId = new Guid(reader[nameof(this.CreatureId)].ToString());
            }
            if (fields.Contains(nameof(FirstLevelQuality)))
            {
                this.FirstLevelQuality = Convert.ToInt16(reader[nameof(this.FirstLevelQuality)]);
            }
            if (fields.Contains(nameof(SecondLevelQuality)))
            {
                this.SecondLevelQuality = Convert.ToInt16(reader[nameof(this.SecondLevelQuality)]);
            }
            if (fields.Contains(nameof(ThirdLevelQuality)))
            {
                this.ThirdLevelQuality = Convert.ToInt16(reader[nameof(this.ThirdLevelQuality)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TCreatureQuality);
            }
        }
        #endregion
    }
}
