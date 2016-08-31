using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.Spider.Objects.Enums;

namespace VL.Spider.Objects.Entities
{
    [DataContract]
    public partial class TGrabList : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid ListItemId { get; set; }
        [DataMember]
        public Guid SpiderId { get; set; }
        [DataMember]
        public String IssueName { get; set; }
        [DataMember]
        public Int16 OrderNumber { get; set; }
        [DataMember]
        public String Title { get; set; }
        [DataMember]
        public String URL { get; set; }
        [DataMember]
        public String Remark { get; set; }
        #endregion

        #region Constructors
        public TGrabList()
        {
        }
        public TGrabList(Guid spiderId, String issueName, Int16 orderNumber)
        {
            SpiderId = spiderId;
            IssueName = issueName;
            OrderNumber = orderNumber;
        }
        public TGrabList(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.ListItemId = new Guid(reader[nameof(this.ListItemId)].ToString());
            this.SpiderId = new Guid(reader[nameof(this.SpiderId)].ToString());
            this.IssueName = Convert.ToString(reader[nameof(this.IssueName)]);
            this.OrderNumber = Convert.ToInt16(reader[nameof(this.OrderNumber)]);
            this.Title = Convert.ToString(reader[nameof(this.Title)]);
            this.URL = Convert.ToString(reader[nameof(this.URL)]);
            this.Remark = Convert.ToString(reader[nameof(this.Remark)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(ListItemId)))
            {
                this.ListItemId = new Guid(reader[nameof(this.ListItemId)].ToString());
            }
            if (fields.Contains(nameof(SpiderId)))
            {
                this.SpiderId = new Guid(reader[nameof(this.SpiderId)].ToString());
            }
            if (fields.Contains(nameof(IssueName)))
            {
                this.IssueName = Convert.ToString(reader[nameof(this.IssueName)]);
            }
            if (fields.Contains(nameof(OrderNumber)))
            {
                this.OrderNumber = Convert.ToInt16(reader[nameof(this.OrderNumber)]);
            }
            if (fields.Contains(nameof(Title)))
            {
                this.Title = Convert.ToString(reader[nameof(this.Title)]);
            }
            if (fields.Contains(nameof(URL)))
            {
                this.URL = Convert.ToString(reader[nameof(this.URL)]);
            }
            if (fields.Contains(nameof(Remark)))
            {
                this.Remark = Convert.ToString(reader[nameof(this.Remark)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TGrabList);
            }
        }
        #endregion
    }
}
