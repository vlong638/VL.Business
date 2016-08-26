using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.Spider.Objects.Objects.Enums;

namespace VL.Spider.Objects.Objects.Entities
{
    [DataContract]
    public partial class TSpider : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid SpiderId { get; set; }
        [DataMember]
        public String SpiderName { get; set; }
        #endregion

        #region Constructors
        public TSpider()
        {
        }
        public TSpider(Guid spiderId)
        {
            SpiderId = spiderId;
        }
        public TSpider(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.SpiderId = new Guid(reader[nameof(this.SpiderId)].ToString());
            this.SpiderName = Convert.ToString(reader[nameof(this.SpiderName)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(SpiderId)))
            {
                this.SpiderId = new Guid(reader[nameof(this.SpiderId)].ToString());
            }
            if (fields.Contains(nameof(SpiderName)))
            {
                this.SpiderName = Convert.ToString(reader[nameof(this.SpiderName)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TSpider);
            }
        }
        #endregion
    }
}
