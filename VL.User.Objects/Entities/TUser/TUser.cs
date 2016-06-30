using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using VL.User.Objects.Enums;

namespace VL.User.Objects.Entities
{
    [DataContract]
    public partial class TUser : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public String UserName { get; set; }
        [DataMember]
        public Int16 Mobile { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String IdCardNumber { get; set; }
        [DataMember]
        public String Password { get; set; }
        [DataMember]
        public DateTime CreateTime { get; set; }
        #endregion

        #region Constructors
        public TUser()
        {
        }
        public TUser(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.UserId = new Guid(reader[nameof(this.UserId)].ToString());
            this.UserName = Convert.ToString(reader[nameof(this.UserName)]);
            this.Mobile = Convert.ToInt16(reader[nameof(this.Mobile)]);
            this.Email = Convert.ToString(reader[nameof(this.Email)]);
            this.IdCardNumber = Convert.ToString(reader[nameof(this.IdCardNumber)]);
            this.Password = Convert.ToString(reader[nameof(this.Password)]);
            this.CreateTime = Convert.ToDateTime(reader[nameof(this.CreateTime)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(UserId)))
            {
                this.UserId = new Guid(reader[nameof(this.UserId)].ToString());
            }
            if (fields.Contains(nameof(UserName)))
            {
                this.UserName = Convert.ToString(reader[nameof(this.UserName)]);
            }
            if (fields.Contains(nameof(Mobile)))
            {
                this.Mobile = Convert.ToInt16(reader[nameof(this.Mobile)]);
            }
            if (fields.Contains(nameof(Email)))
            {
                this.Email = Convert.ToString(reader[nameof(this.Email)]);
            }
            if (fields.Contains(nameof(IdCardNumber)))
            {
                this.IdCardNumber = Convert.ToString(reader[nameof(this.IdCardNumber)]);
            }
            if (fields.Contains(nameof(Password)))
            {
                this.Password = Convert.ToString(reader[nameof(this.Password)]);
            }
            if (fields.Contains(nameof(CreateTime)))
            {
                this.CreateTime = Convert.ToDateTime(reader[nameof(this.CreateTime)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TUser);
            }
        }
        #endregion
    }
}
