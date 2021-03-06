using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public partial class TEarthworkBlock : IPDMTBase
    {
        #region Properties
        /// <summary>
        /// 隔离区间
        /// </summary>
        public String Segregation { get; set; }
        /// <summary>
        /// 数据时间
        /// </summary>
        public DateTime IssueDateTime { get; set; }
        /// <summary>
        /// Earthwork的编号
        /// </summary>
        public Int16 Id { get; set; }
        /// <summary>
        /// Earthwork的顺序号
        /// </summary>
        public Int16 Indexer { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// 颜色透明度配置
        /// </summary>
        public String CPSettings { get; set; }
        /// <summary>
        /// 节点施工信息
        /// </summary>
        public String EarthworkBlockImplementationInfo { get; set; }
        #endregion

        #region Constructors
        public TEarthworkBlock()
        {
        }
        public TEarthworkBlock(String segregation, DateTime issueDateTime, Int16 id)
        {
            Segregation = segregation;
            IssueDateTime = issueDateTime;
            Id = id;
        }
        public TEarthworkBlock(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.Segregation = Convert.ToString(reader[nameof(this.Segregation)]);
            this.IssueDateTime = Convert.ToDateTime(reader[nameof(this.IssueDateTime)]);
            this.Id = Convert.ToInt16(reader[nameof(this.Id)]);
            this.Indexer = Convert.ToInt16(reader[nameof(this.Indexer)]);
            this.Name = Convert.ToString(reader[nameof(this.Name)]);
            this.Description = Convert.ToString(reader[nameof(this.Description)]);
            this.CPSettings = Convert.ToString(reader[nameof(this.CPSettings)]);
            this.EarthworkBlockImplementationInfo = Convert.ToString(reader[nameof(this.EarthworkBlockImplementationInfo)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(Segregation)))
            {
                this.Segregation = Convert.ToString(reader[nameof(this.Segregation)]);
            }
            if (fields.Contains(nameof(IssueDateTime)))
            {
                this.IssueDateTime = Convert.ToDateTime(reader[nameof(this.IssueDateTime)]);
            }
            if (fields.Contains(nameof(Id)))
            {
                this.Id = Convert.ToInt16(reader[nameof(this.Id)]);
            }
            if (fields.Contains(nameof(Indexer)))
            {
                this.Indexer = Convert.ToInt16(reader[nameof(this.Indexer)]);
            }
            if (fields.Contains(nameof(Name)))
            {
                this.Name = Convert.ToString(reader[nameof(this.Name)]);
            }
            if (fields.Contains(nameof(Description)))
            {
                this.Description = Convert.ToString(reader[nameof(this.Description)]);
            }
            if (fields.Contains(nameof(CPSettings)))
            {
                this.CPSettings = Convert.ToString(reader[nameof(this.CPSettings)]);
            }
            if (fields.Contains(nameof(EarthworkBlockImplementationInfo)))
            {
                this.EarthworkBlockImplementationInfo = Convert.ToString(reader[nameof(this.EarthworkBlockImplementationInfo)]);
            }
        }
        public override string TableName
        {
            get
            {
                return nameof(TEarthworkBlock);
            }
        }
        #endregion

        #region Manual
        #endregion
    }
}
