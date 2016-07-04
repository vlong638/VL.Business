using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.LostInJungle.Objects.Enums;

namespace VL.LostInJungle.Objects.Entities
{
    [DataContract]
    public partial class TArea : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid AreaId { get; set; }
        [DataMember]
        public String AreaName { get; set; }
        [DataMember]
        public Int16 AreaLevel { get; set; }
        [DataMember]
        public EAreaType AreaType { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String DescriptionEx { get; set; }
        #endregion

        #region Constructors
        public TArea()
        {
        }
        public TArea(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.AreaId = new Guid(reader[nameof(this.AreaId)].ToString());
            this.AreaName = Convert.ToString(reader[nameof(this.AreaName)]);
            this.AreaLevel = Convert.ToInt16(reader[nameof(this.AreaLevel)]);
            this.AreaType = (EAreaType)Enum.Parse(typeof(EAreaType), reader[nameof(this.AreaType)].ToString());
            this.Description = Convert.ToString(reader[nameof(this.Description)]);
            this.DescriptionEx = Convert.ToString(reader[nameof(this.DescriptionEx)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(AreaId)))
            {
                this.AreaId = new Guid(reader[nameof(this.AreaId)].ToString());
            }
            if (fields.Contains(nameof(AreaName)))
            {
                this.AreaName = Convert.ToString(reader[nameof(this.AreaName)]);
            }
            if (fields.Contains(nameof(AreaLevel)))
            {
                this.AreaLevel = Convert.ToInt16(reader[nameof(this.AreaLevel)]);
            }
            if (fields.Contains(nameof(AreaType)))
            {
                this.AreaType = (EAreaType)Enum.Parse(typeof(EAreaType), reader[nameof(this.AreaType)].ToString());
            }
            if (fields.Contains(nameof(Description)))
            {
                this.Description = Convert.ToString(reader[nameof(this.Description)]);
            }
            if (fields.Contains(nameof(DescriptionEx)))
            {
                this.DescriptionEx = Convert.ToString(reader[nameof(this.DescriptionEx)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TArea);
            }
        }
        #endregion
    }
}
