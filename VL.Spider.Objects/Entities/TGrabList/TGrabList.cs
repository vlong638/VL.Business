using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.Spider.Objects.Objects.Enums;

namespace VL.Spider.Objects.Objects.Entities
{
    [DataContract]
    public partial class TGrabList : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid SpiderId { get; set; }
        [DataMember]
        public DateTime IssueTime { get; set; }
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
        public TGrabList(DateTime issueTime, Int16 orderNumber)
        {
            IssueTime = issueTime;
            OrderNumber = orderNumber;
        }
        public TGrabList(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.SpiderId = new Guid(reader[nameof(this.SpiderId)].ToString());
            this.IssueTime = Convert.ToDateTime(reader[nameof(this.IssueTime)]);
            this.OrderNumber = Convert.ToInt16(reader[nameof(this.OrderNumber)]);
            this.Title = Convert.ToString(reader[nameof(this.Title)]);
            this.URL = Convert.ToString(reader[nameof(this.URL)]);
            this.Remark = Convert.ToString(reader[nameof(this.Remark)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(SpiderId)))
            {
                this.SpiderId = new Guid(reader[nameof(this.SpiderId)].ToString());
            }
            if (fields.Contains(nameof(IssueTime)))
            {
                this.IssueTime = Convert.ToDateTime(reader[nameof(this.IssueTime)]);
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
