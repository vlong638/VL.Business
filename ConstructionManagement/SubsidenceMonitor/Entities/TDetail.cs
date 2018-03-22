﻿using PmSoft.ConstructionManagement.SubsidenceMonitor.Interfaces;
using PmSoft.ConstructionManagement.SubsidenceMonitor.Operators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmSoft.ConstructionManagement.SubsidenceMonitor.Entities
{
    public partial class TDetail : IPDMTBase, ILazyLoadData
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
        /// 监测时间
        /// </summary>
        public DateTime IssueDateTime { get; set; }
        /// <summary>
        /// 监测时间跨度(分钟)
        /// </summary>
        public Int16 IssueTimeRange { get; set; }
        /// <summary>
        /// 报告名称
        /// </summary>
        public String ReportName { get; set; }
        /// <summary>
        /// 承包单位
        /// </summary>
        public String Contractor { get; set; }
        /// <summary>
        /// 监理单位
        /// </summary>
        public String Supervisor { get; set; }
        /// <summary>
        /// 监测单位
        /// </summary>
        public String Monitor { get; set; }
        /// <summary>
        /// 仪器名称
        /// </summary>
        public String InstrumentName { get; set; }
        /// <summary>
        /// 仪器编号
        /// </summary>
        public String InstrumentCode { get; set; }
        /// <summary>
        /// 接近预警值(颜色/透明度配置)
        /// </summary>
        public String CloseCTSettings { get; set; }
        /// <summary>
        /// 超出预警值(颜色/透明度配置)
        /// </summary>
        public String OverCTSettings { get; set; }
        /// <summary>
        /// 附加值
        /// </summary>
        public Int16? ExtraValue1 { get; set; }
        /// <summary>
        /// 附加值
        /// </summary>
        public Int16? ExtraValue2 { get; set; }
        /// <summary>
        /// 附加值
        /// </summary>
        public Int16? ExtraValue3 { get; set; }
        #endregion

        #region Constructors
        public TDetail()
        {
        }
        public TDetail( EIssueType issueType, DateTime issueDateTime)
        {
            IssueType = issueType;
            IssueDateTime = issueDateTime;
        }
        public TDetail(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.Segregation = Convert.ToString(reader[nameof(this.Segregation)]);
            this.IssueType = (EIssueType)Enum.Parse(typeof(EIssueType), reader[nameof(this.IssueType)].ToString());
            this.IssueDateTime = Convert.ToDateTime(reader[nameof(this.IssueDateTime)]);
            this.IssueTimeRange = Convert.ToInt16(reader[nameof(this.IssueTimeRange)]);
            this.ReportName = Convert.ToString(reader[nameof(this.ReportName)]);
            this.Contractor = Convert.ToString(reader[nameof(this.Contractor)]);
            this.Supervisor = Convert.ToString(reader[nameof(this.Supervisor)]);
            this.Monitor = Convert.ToString(reader[nameof(this.Monitor)]);
            this.InstrumentName = Convert.ToString(reader[nameof(this.InstrumentName)]);
            this.InstrumentCode = Convert.ToString(reader[nameof(this.InstrumentCode)]);
            this.CloseCTSettings = Convert.ToString(reader[nameof(this.CloseCTSettings)]);
            this.OverCTSettings = Convert.ToString(reader[nameof(this.OverCTSettings)]);
            if (reader[nameof(this.ExtraValue1)] != DBNull.Value)
            {
                this.ExtraValue1 = Convert.ToInt16(reader[nameof(this.ExtraValue1)]);
            }
            if (reader[nameof(this.ExtraValue2)] != DBNull.Value)
            {
                this.ExtraValue2 = Convert.ToInt16(reader[nameof(this.ExtraValue2)]);
            }
            if (reader[nameof(this.ExtraValue3)] != DBNull.Value)
            {
                this.ExtraValue3 = Convert.ToInt16(reader[nameof(this.ExtraValue3)]);
            }
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
            if (fields.Contains(nameof(IssueDateTime)))
            {
                this.IssueDateTime = Convert.ToDateTime(reader[nameof(this.IssueDateTime)]);
            }
            if (fields.Contains(nameof(IssueTimeRange)))
            {
                this.IssueTimeRange = Convert.ToInt16(reader[nameof(this.IssueTimeRange)]);
            }
            if (fields.Contains(nameof(ReportName)))
            {
                this.ReportName = Convert.ToString(reader[nameof(this.ReportName)]);
            }
            if (fields.Contains(nameof(Contractor)))
            {
                this.Contractor = Convert.ToString(reader[nameof(this.Contractor)]);
            }
            if (fields.Contains(nameof(Supervisor)))
            {
                this.Supervisor = Convert.ToString(reader[nameof(this.Supervisor)]);
            }
            if (fields.Contains(nameof(Monitor)))
            {
                this.Monitor = Convert.ToString(reader[nameof(this.Monitor)]);
            }
            if (fields.Contains(nameof(InstrumentName)))
            {
                this.InstrumentName = Convert.ToString(reader[nameof(this.InstrumentName)]);
            }
            if (fields.Contains(nameof(InstrumentCode)))
            {
                this.InstrumentCode = Convert.ToString(reader[nameof(this.InstrumentCode)]);
            }
            if (fields.Contains(nameof(CloseCTSettings)))
            {
                this.CloseCTSettings = Convert.ToString(reader[nameof(this.CloseCTSettings)]);
            }
            if (fields.Contains(nameof(OverCTSettings)))
            {
                this.OverCTSettings = Convert.ToString(reader[nameof(this.OverCTSettings)]);
            }
            if (fields.Contains(nameof(ExtraValue1)))
            {
                if (reader[nameof(this.ExtraValue1)] != DBNull.Value)
                {
                    this.ExtraValue1 = Convert.ToInt16(reader[nameof(this.ExtraValue1)]);
                }
            }
            if (fields.Contains(nameof(ExtraValue2)))
            {
                if (reader[nameof(this.ExtraValue2)] != DBNull.Value)
                {
                    this.ExtraValue2 = Convert.ToInt16(reader[nameof(this.ExtraValue2)]);
                }
            }
            if (fields.Contains(nameof(ExtraValue3)))
            {
                if (reader[nameof(this.ExtraValue3)] != DBNull.Value)
                {
                    this.ExtraValue3 = Convert.ToInt16(reader[nameof(this.ExtraValue3)]);
                }
            }
        }
        public override string TableName
        {
            get
            {
                return nameof(TDetail);
            }
        }
        #endregion

        #region Manual
        /// <summary>
        /// 是否已加载(延迟加载机制)
        /// </summary>
        public bool IsLoad { set; get; }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadData(int type)
        {
            switch (type)
            {
                case 0:
                    //节点配置
                    if (IssueType == EIssueType.侧斜监测)
                        Facade.FetchDepthNodes(this);
                    else
                        Facade.FetchNodes(this);
                    IsLoad = true;
                    break;
                case 1:
                    //节点配置
                    if (IssueType == EIssueType.侧斜监测)
                        Facade.FetchDepthNodeElements(this);
                    else
                        Facade.FetchNodeElements(this);
                    IsLoad = true;
                    break;
                default:
                    break;
            }
        }
    /// <summary>
    /// 相关联的List
    /// </summary>
    public TList List { set; get; }
        /// <summary>
        /// 相关联的Nodes
        /// </summary>
        public List<TNode> Nodes { get; set; } = new List<TNode>();
        ITNodeDataCollection<ITNodeData> _NodeDatas;
        public ITNodeDataCollection<ITNodeData> NodeDatas
        {
            get
            {
                if (_NodeDatas == null)
                {
                    _NodeDatas = IssueType.GetEntity().GetNodeDataCollection();
                    foreach (var node in Nodes)
                        _NodeDatas.Add(node.NodeCode, node.Data);
                }
                return _NodeDatas;
            }
        }
        public List<TDepthNode> DepthNodes { get; set; } = new List<TDepthNode>();
        ITDepthNodeDataCollection<ITDepthNodeData> _DepthNodeDatas;
        public ITDepthNodeDataCollection<ITDepthNodeData> DepthNodeDatas
        {
            get
            {
                if (_DepthNodeDatas == null)
                {
                    _DepthNodeDatas = new SkewBackCollection<SkewBackDataV1>();
                    foreach (var depthNode in DepthNodes)
                        _DepthNodeDatas.Add(depthNode.NodeCode, depthNode.Depth, depthNode.Data);
                }
                return _DepthNodeDatas;
            }
        }
        #endregion
    }
}
