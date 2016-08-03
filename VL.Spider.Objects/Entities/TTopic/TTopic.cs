using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.Spider.Objects.Objects.Enums;

namespace VL.Spider.Objects.Objects.Entities
{
    [DataContract]
    public partial class TTopic : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid TopicId { get; set; }
        [DataMember]
        public String Title { get; set; }
        [DataMember]
        public String Content { get; set; }
        #endregion

        #region Constructors
        public TTopic()
        {
        }
        public TTopic(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.TopicId = new Guid(reader[nameof(this.TopicId)].ToString());
            this.Title = Convert.ToString(reader[nameof(this.Title)]);
            this.Content = Convert.ToString(reader[nameof(this.Content)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(TopicId)))
            {
                this.TopicId = new Guid(reader[nameof(this.TopicId)].ToString());
            }
            if (fields.Contains(nameof(Title)))
            {
                this.Title = Convert.ToString(reader[nameof(this.Title)]);
            }
            if (fields.Contains(nameof(Content)))
            {
                this.Content = Convert.ToString(reader[nameof(this.Content)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TTopic);
            }
        }
        #endregion
    }
}
