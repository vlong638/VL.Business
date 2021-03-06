using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.LostInJungle.Objects.Enums;

namespace VL.LostInJungle.Objects.Entities
{
    [DataContract]
    public partial class TEvent : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid AreaId { get; set; }
        [DataMember]
        public Guid EventId { get; set; }
        [DataMember]
        public String Occurrence { get; set; }
        #endregion

        #region Constructors
        public TEvent()
        {
        }
        public TEvent(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.AreaId = new Guid(reader[nameof(this.AreaId)].ToString());
            this.EventId = new Guid(reader[nameof(this.EventId)].ToString());
            this.Occurrence = Convert.ToString(reader[nameof(this.Occurrence)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(AreaId)))
            {
                this.AreaId = new Guid(reader[nameof(this.AreaId)].ToString());
            }
            if (fields.Contains(nameof(EventId)))
            {
                this.EventId = new Guid(reader[nameof(this.EventId)].ToString());
            }
            if (fields.Contains(nameof(Occurrence)))
            {
                this.Occurrence = Convert.ToString(reader[nameof(this.Occurrence)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TEvent);
            }
        }
        #endregion
    }
}
