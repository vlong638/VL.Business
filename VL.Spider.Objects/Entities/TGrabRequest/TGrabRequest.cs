using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.Spider.Objects.Enums;

namespace VL.Spider.Objects.Entities
{
    [DataContract]
    public partial class TGrabRequest : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid RequestId { get; set; }
        [DataMember]
        public Guid SpiderId { get; set; }
        [DataMember]
        public EGrabType GrabType { get; set; }
        [DataMember]
        public String IssueName { get; set; }
        [DataMember]
        public String SpiderName { get; set; }
        [DataMember]
        public EProcessStatus ProcessStatus { get; set; }
        [DataMember]
        public String Message { get; set; }
        #endregion

        #region Constructors
        public TGrabRequest()
        {
        }
        public TGrabRequest(Guid spiderId, EGrabType grabType, String issueName)
        {
            SpiderId = spiderId;
            GrabType = grabType;
            IssueName = issueName;
        }
        public TGrabRequest(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.RequestId = new Guid(reader[nameof(this.RequestId)].ToString());
            this.SpiderId = new Guid(reader[nameof(this.SpiderId)].ToString());
            this.GrabType = (EGrabType)Enum.Parse(typeof(EGrabType), reader[nameof(this.GrabType)].ToString());
            this.IssueName = Convert.ToString(reader[nameof(this.IssueName)]);
            this.SpiderName = Convert.ToString(reader[nameof(this.SpiderName)]);
            this.ProcessStatus = (EProcessStatus)Enum.Parse(typeof(EProcessStatus), reader[nameof(this.ProcessStatus)].ToString());
            this.Message = Convert.ToString(reader[nameof(this.Message)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(RequestId)))
            {
                this.RequestId = new Guid(reader[nameof(this.RequestId)].ToString());
            }
            if (fields.Contains(nameof(SpiderId)))
            {
                this.SpiderId = new Guid(reader[nameof(this.SpiderId)].ToString());
            }
            if (fields.Contains(nameof(GrabType)))
            {
                this.GrabType = (EGrabType)Enum.Parse(typeof(EGrabType), reader[nameof(this.GrabType)].ToString());
            }
            if (fields.Contains(nameof(IssueName)))
            {
                this.IssueName = Convert.ToString(reader[nameof(this.IssueName)]);
            }
            if (fields.Contains(nameof(SpiderName)))
            {
                this.SpiderName = Convert.ToString(reader[nameof(this.SpiderName)]);
            }
            if (fields.Contains(nameof(ProcessStatus)))
            {
                this.ProcessStatus = (EProcessStatus)Enum.Parse(typeof(EProcessStatus), reader[nameof(this.ProcessStatus)].ToString());
            }
            if (fields.Contains(nameof(Message)))
            {
                this.Message = Convert.ToString(reader[nameof(this.Message)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TGrabRequest);
            }
        }
        #endregion
    }
}
