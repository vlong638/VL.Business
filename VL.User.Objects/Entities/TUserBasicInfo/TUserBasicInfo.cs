using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.User.Objects.Enums;

namespace VL.User.Objects.Entities
{
    [DataContract]
    public partial class TUserBasicInfo : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public ESample Gender { get; set; }
        [DataMember]
        public DateTime? Birthday { get; set; }
        [DataMember]
        public Int16? Mobile { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String IdCardNumber { get; set; }
        #endregion

        #region Constructors
        public TUserBasicInfo()
        {
        }
        public TUserBasicInfo(Guid userId)
        {
            UserId = userId;
        }
        public TUserBasicInfo(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.UserId = new Guid(reader[nameof(this.UserId)].ToString());
            if (reader[nameof(this.Gender)] != DBNull.Value)
            {
                this.Gender = (ESample)Enum.Parse(typeof(ESample), reader[nameof(this.Gender)].ToString());
            }
            if (reader[nameof(this.Birthday)] != DBNull.Value)
            {
                this.Birthday = Convert.ToDateTime(reader[nameof(this.Birthday)]);
            }
            if (reader[nameof(this.Mobile)] != DBNull.Value)
            {
                this.Mobile = Convert.ToInt16(reader[nameof(this.Mobile)]);
            }
            if (reader[nameof(this.Email)] != DBNull.Value)
            {
                this.Email = Convert.ToString(reader[nameof(this.Email)]);
            }
            if (reader[nameof(this.IdCardNumber)] != DBNull.Value)
            {
                this.IdCardNumber = Convert.ToString(reader[nameof(this.IdCardNumber)]);
            }
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(UserId)))
            {
                this.UserId = new Guid(reader[nameof(this.UserId)].ToString());
            }
            if (fields.Contains(nameof(Gender)))
            {
                if (reader[nameof(this.Gender)] != DBNull.Value)
                {
                    this.Gender = (ESample)Enum.Parse(typeof(ESample), reader[nameof(this.Gender)].ToString());
                }
            }
            if (fields.Contains(nameof(Birthday)))
            {
                if (reader[nameof(this.Birthday)] != DBNull.Value)
                {
                    this.Birthday = Convert.ToDateTime(reader[nameof(this.Birthday)]);
                }
            }
            if (fields.Contains(nameof(Mobile)))
            {
                if (reader[nameof(this.Mobile)] != DBNull.Value)
                {
                    this.Mobile = Convert.ToInt16(reader[nameof(this.Mobile)]);
                }
            }
            if (fields.Contains(nameof(Email)))
            {
                if (reader[nameof(this.Email)] != DBNull.Value)
                {
                    this.Email = Convert.ToString(reader[nameof(this.Email)]);
                }
            }
            if (fields.Contains(nameof(IdCardNumber)))
            {
                if (reader[nameof(this.IdCardNumber)] != DBNull.Value)
                {
                    this.IdCardNumber = Convert.ToString(reader[nameof(this.IdCardNumber)]);
                }
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TUserBasicInfo);
            }
        }
        #endregion
    }
}
