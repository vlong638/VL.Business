using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.Spider.Objects.Objects.Enums;

namespace VL.Spider.Objects.Objects.Entities
{
    [DataContract]
    public partial class TArticle : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid SouceId { get; set; }
        [DataMember]
        public Guid ArticleId { get; set; }
        [DataMember]
        public String Title { get; set; }
        [DataMember]
        public String Content { get; set; }
        #endregion

        #region Constructors
        public TArticle()
        {
        }
        public TArticle(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.SouceId = new Guid(reader[nameof(this.SouceId)].ToString());
            this.ArticleId = new Guid(reader[nameof(this.ArticleId)].ToString());
            this.Title = Convert.ToString(reader[nameof(this.Title)]);
            this.Content = Convert.ToString(reader[nameof(this.Content)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(SouceId)))
            {
                this.SouceId = new Guid(reader[nameof(this.SouceId)].ToString());
            }
            if (fields.Contains(nameof(ArticleId)))
            {
                this.ArticleId = new Guid(reader[nameof(this.ArticleId)].ToString());
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
                return nameof(TArticle);
            }
        }
        #endregion
    }
}
