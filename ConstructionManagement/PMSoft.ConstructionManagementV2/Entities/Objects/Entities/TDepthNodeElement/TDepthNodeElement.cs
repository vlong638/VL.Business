using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public partial class TDepthNodeElement : IPDMTBase
    {
        #region Properties
        /// <summary>
        /// 隔离区间
        /// </summary>
        public String Segregation { get; set; }
        /// <summary>
        /// 测点编号
        /// </summary>
        public String NodeCode { get; set; }
        /// <summary>
        /// 测点深度
        /// </summary>
        public String Depth { get; set; }
        /// <summary>
        /// 测点构件
        /// </summary>
        public String ElementIds { get; set; }
        #endregion

        #region Constructors
        public TDepthNodeElement()
        {
        }
        public TDepthNodeElement(String segregation, String nodeCode, String depth)
        {
            Segregation = segregation;
            NodeCode = nodeCode;
            Depth = depth;
        }
        public TDepthNodeElement(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.Segregation = Convert.ToString(reader[nameof(this.Segregation)]);
            this.NodeCode = Convert.ToString(reader[nameof(this.NodeCode)]);
            this.Depth = Convert.ToString(reader[nameof(this.Depth)]);
            this.ElementIds = Convert.ToString(reader[nameof(this.ElementIds)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(Segregation)))
            {
                this.Segregation = Convert.ToString(reader[nameof(this.Segregation)]);
            }
            if (fields.Contains(nameof(NodeCode)))
            {
                this.NodeCode = Convert.ToString(reader[nameof(this.NodeCode)]);
            }
            if (fields.Contains(nameof(Depth)))
            {
                this.Depth = Convert.ToString(reader[nameof(this.Depth)]);
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
                return nameof(TDepthNodeElement);
            }
        }
        #endregion

        #region Manual
        #endregion
    }
}
