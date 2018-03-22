using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using VL.Common.Core.ORM;

namespace PMSoft.ConstructionManagementV2.DomainModel
{
    public partial class TNodeElement : IPDMTBase
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
        /// 测点构件
        /// </summary>
        public String ElementIds { get; set; }
        #endregion

        #region Constructors
        public TNodeElement()
        {
        }
        public TNodeElement(String segregation, String nodeCode)
        {
            Segregation = segregation;
            NodeCode = nodeCode;
        }
        public TNodeElement(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.Segregation = Convert.ToString(reader[nameof(this.Segregation)]);
            this.NodeCode = Convert.ToString(reader[nameof(this.NodeCode)]);
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
            if (fields.Contains(nameof(ElementIds)))
            {
                this.ElementIds = Convert.ToString(reader[nameof(this.ElementIds)]);
            }
        }
        public override string TableName
        {
            get
            {
                return nameof(TNodeElement);
            }
        }
        #endregion

        #region Manual
        #endregion
    }
}
