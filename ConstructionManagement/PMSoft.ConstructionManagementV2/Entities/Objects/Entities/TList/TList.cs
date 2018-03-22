using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public partial class TList : IPDMTBase
    {
        #region Properties
        /// <summary>
        /// 隔离区间
        /// </summary>
        public String Segregation { get; set; }
        /// <summary>
        /// 监测类型
        /// </summary>
        public EIssueType IssueType { get; set; }
        /// <summary>
        /// 监测日期
        /// </summary>
        public DateTime IssueDate { get; set; }
        /// <summary>
        /// 下级数据量
        /// </summary>
        public Int16 DataCount { get; set; }
        #endregion

        #region Constructors
        public TList()
        {
        }
        public TList(String segregation, EIssueType issueType, DateTime issueDate)
        {
            Segregation = segregation;
            IssueType = issueType;
            IssueDate = issueDate;
        }
        public TList(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.Segregation = Convert.ToString(reader[nameof(this.Segregation)]);
            this.IssueType = (EIssueType)Enum.Parse(typeof(EIssueType), reader[nameof(this.IssueType)].ToString());
            this.IssueDate = Convert.ToDateTime(reader[nameof(this.IssueDate)]);
            this.DataCount = Convert.ToInt16(reader[nameof(this.DataCount)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(Segregation)))
            {
                this.Segregation = Convert.ToString(reader[nameof(this.Segregation)]);
            }
            if (fields.Contains(nameof(IssueType)))
            {
                this.IssueType = (EIssueType)Enum.Parse(typeof(EIssueType), reader[nameof(this.IssueType)].ToString());
            }
            if (fields.Contains(nameof(IssueDate)))
            {
                this.IssueDate = Convert.ToDateTime(reader[nameof(this.IssueDate)]);
            }
            if (fields.Contains(nameof(DataCount)))
            {
                this.DataCount = Convert.ToInt16(reader[nameof(this.DataCount)]);
            }
        }
        public override string TableName
        {
            get
            {
                return nameof(TList);
            }
        }
        #endregion

        #region Manual
        #endregion
    }
}
