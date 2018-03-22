using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public partial class TEarthworkBlockElement : IPDMTBase
    {
        #region Properties
        /// <summary>
        /// 数据时间
        /// </summary>
        public DateTime IssueDateTime { get; set; }
        /// <summary>
        /// Earthwork的编号
        /// </summary>
        public Int16 Id { get; set; }
        /// <summary>
        /// 组包号
        /// </summary>
        public Int16 GroupId { get; set; }
        /// <summary>
        /// 构件Id集合,每个组包存储100个,6+1*100
        /// </summary>
        public String ElementIds { get; set; }
        #endregion

        #region Constructors
        public TEarthworkBlockElement()
        {
        }
        public TEarthworkBlockElement(DateTime issueDateTime, Int16 id, Int16 groupId)
        {
            IssueDateTime = issueDateTime;
            Id = id;
            GroupId = groupId;
        }
        public TEarthworkBlockElement(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.IssueDateTime = Convert.ToDateTime(reader[nameof(this.IssueDateTime)]);
            this.Id = Convert.ToInt16(reader[nameof(this.Id)]);
            this.GroupId = Convert.ToInt16(reader[nameof(this.GroupId)]);
            this.ElementIds = Convert.ToString(reader[nameof(this.ElementIds)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(IssueDateTime)))
            {
                this.IssueDateTime = Convert.ToDateTime(reader[nameof(this.IssueDateTime)]);
            }
            if (fields.Contains(nameof(Id)))
            {
                this.Id = Convert.ToInt16(reader[nameof(this.Id)]);
            }
            if (fields.Contains(nameof(GroupId)))
            {
                this.GroupId = Convert.ToInt16(reader[nameof(this.GroupId)]);
            }
            if (fields.Contains(nameof(ElementIds)))
            {
                this.ElementIds = Convert.ToString(reader[nameof(this.ElementIds)]);
            }
        }
        public override string TableName
        {
            get
            {
                return nameof(TEarthworkBlockElement);
            }
        }
        #endregion

        #region Manual
        #endregion
    }
}
