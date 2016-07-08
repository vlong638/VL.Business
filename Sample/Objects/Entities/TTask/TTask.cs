using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using TODOTask.Objects.Enums;

namespace TODOTask.Objects.Entities
{
    [DataContract]
    public partial class TTask : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid TaskId { get; set; }
        [DataMember]
        public String What { get; set; }
        [DataMember]
        public String Where { get; set; }
        [DataMember]
        public String Who { get; set; }
        [DataMember]
        public DateTime? WhenToStart { get; set; }
        [DataMember]
        public DateTime? WhenToEnd { get; set; }
        [DataMember]
        public DateTime? WhenStart { get; set; }
        [DataMember]
        public DateTime? WhenEnd { get; set; }
        [DataMember]
        public EDealStatus DealStatus { get; set; }
        #endregion

        #region Constructors
        public TTask()
        {
        }
        public TTask(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.TaskId = new Guid(reader[nameof(this.TaskId)].ToString());
            this.What = Convert.ToString(reader[nameof(this.What)]);
            this.Where = Convert.ToString(reader[nameof(this.Where)]);
            this.Who = Convert.ToString(reader[nameof(this.Who)]);
            if (reader[nameof(this.WhenToStart)] != DBNull.Value)
            {
                this.WhenToStart = Convert.ToDateTime(reader[nameof(this.WhenToStart)]);
            }
            if (reader[nameof(this.WhenToEnd)] != DBNull.Value)
            {
                this.WhenToEnd = Convert.ToDateTime(reader[nameof(this.WhenToEnd)]);
            }
            if (reader[nameof(this.WhenStart)] != DBNull.Value)
            {
                this.WhenStart = Convert.ToDateTime(reader[nameof(this.WhenStart)]);
            }
            if (reader[nameof(this.WhenEnd)] != DBNull.Value)
            {
                this.WhenEnd = Convert.ToDateTime(reader[nameof(this.WhenEnd)]);
            }
            this.DealStatus = (EDealStatus)Enum.Parse(typeof(EDealStatus), reader[nameof(this.DealStatus)].ToString());
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(TaskId)))
            {
                this.TaskId = new Guid(reader[nameof(this.TaskId)].ToString());
            }
            if (fields.Contains(nameof(What)))
            {
                this.What = Convert.ToString(reader[nameof(this.What)]);
            }
            if (fields.Contains(nameof(Where)))
            {
                this.Where = Convert.ToString(reader[nameof(this.Where)]);
            }
            if (fields.Contains(nameof(Who)))
            {
                this.Who = Convert.ToString(reader[nameof(this.Who)]);
            }
            if (fields.Contains(nameof(WhenToStart)))
            {
                if (reader[nameof(this.WhenToStart)] != DBNull.Value)
                {
                    this.WhenToStart = Convert.ToDateTime(reader[nameof(this.WhenToStart)]);
                }
            }
            if (fields.Contains(nameof(WhenToEnd)))
            {
                if (reader[nameof(this.WhenToEnd)] != DBNull.Value)
                {
                    this.WhenToEnd = Convert.ToDateTime(reader[nameof(this.WhenToEnd)]);
                }
            }
            if (fields.Contains(nameof(WhenStart)))
            {
                if (reader[nameof(this.WhenStart)] != DBNull.Value)
                {
                    this.WhenStart = Convert.ToDateTime(reader[nameof(this.WhenStart)]);
                }
            }
            if (fields.Contains(nameof(WhenEnd)))
            {
                if (reader[nameof(this.WhenEnd)] != DBNull.Value)
                {
                    this.WhenEnd = Convert.ToDateTime(reader[nameof(this.WhenEnd)]);
                }
            }
            if (fields.Contains(nameof(DealStatus)))
            {
                this.DealStatus = (EDealStatus)Enum.Parse(typeof(EDealStatus), reader[nameof(this.DealStatus)].ToString());
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TTask);
            }
        }
        #endregion
    }
}
