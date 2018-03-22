using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public partial class TEarthworkBlocking : IPDMTBase
    {
        #region Properties
        /// <summary>
        /// 数据时间
        /// </summary>
        public DateTime IssueDateTime { get; set; }
        /// <summary>
        /// Earthwork的编号
        /// </summary>
        public Int16 EarthworkBlockMaxId { get; set; }
        /// <summary>
        /// 颜色(未完工)
        /// </summary>
        public String ColorForUnsettled { get; set; }
        /// <summary>
        /// 颜色(已完工)
        /// </summary>
        public String ColorForSettled { get; set; }
        /// <summary>
        /// 是否分段内容有变动
        /// </summary>
        public Boolean IsImplementationInfoConflicted { get; set; }
        #endregion

        #region Constructors
        public TEarthworkBlocking()
        {
        }
        public TEarthworkBlocking(DateTime issueDateTime)
        {
            IssueDateTime = issueDateTime;
        }
        public TEarthworkBlocking(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.IssueDateTime = Convert.ToDateTime(reader[nameof(this.IssueDateTime)]);
            this.EarthworkBlockMaxId = Convert.ToInt16(reader[nameof(this.EarthworkBlockMaxId)]);
            this.ColorForUnsettled = Convert.ToString(reader[nameof(this.ColorForUnsettled)]);
            this.ColorForSettled = Convert.ToString(reader[nameof(this.ColorForSettled)]);
            this.IsImplementationInfoConflicted = Convert.ToBoolean(reader[nameof(this.IsImplementationInfoConflicted)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(IssueDateTime)))
            {
                this.IssueDateTime = Convert.ToDateTime(reader[nameof(this.IssueDateTime)]);
            }
            if (fields.Contains(nameof(EarthworkBlockMaxId)))
            {
                this.EarthworkBlockMaxId = Convert.ToInt16(reader[nameof(this.EarthworkBlockMaxId)]);
            }
            if (fields.Contains(nameof(ColorForUnsettled)))
            {
                this.ColorForUnsettled = Convert.ToString(reader[nameof(this.ColorForUnsettled)]);
            }
            if (fields.Contains(nameof(ColorForSettled)))
            {
                this.ColorForSettled = Convert.ToString(reader[nameof(this.ColorForSettled)]);
            }
            if (fields.Contains(nameof(IsImplementationInfoConflicted)))
            {
                this.IsImplementationInfoConflicted = Convert.ToBoolean(reader[nameof(this.IsImplementationInfoConflicted)]);
            }
        }
        public override string TableName
        {
            get
            {
                return nameof(TEarthworkBlocking);
            }
        }
        #endregion

        #region Manual
        /// <summary>
        /// 获取EarthworkBlock的最新Id
        /// </summary>
        /// <returns></returns>
        public short GetEarthworkBlockMaxId()
        {
            var value = EarthworkBlockMaxId;
            EarthworkBlockMaxId++;
            return value;
        }
        #endregion
    }
}
