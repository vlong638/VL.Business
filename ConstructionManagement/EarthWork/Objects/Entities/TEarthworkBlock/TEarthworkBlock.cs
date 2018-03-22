using Autodesk.Revit.DB;
using Newtonsoft.Json;
using PmSoft.ConstructionManagement.EarthWork.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VL.Common.Core.ORM;

namespace VL.Common.Core.Object.Subsidence
{
    public partial class TEarthworkBlock : IPDMTBase
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
        public String Description { get; set; } = "";
        /// <summary>
        /// 颜色透明度配置
        /// </summary>
        public String CPSettings { get; set; } = "";
        /// <summary>
        /// 节点施工信息
        /// </summary>
        public String EarthworkBlockImplementationInfo { get; set; } = "";
        #endregion

        #region Constructors
        public TEarthworkBlock()
        {
        }
        public TEarthworkBlock(DateTime issueDateTime, Int16 id)
        {
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
        public List<int> ElementIds { get; set; } = new List<int>();
        public int ElementCount { get { return ElementIds.Count(); } }
        /// <summary>
        /// 节点施工信息
        /// </summary>
        public EarthworkBlockImplementationInfo EarthworkBlockImplementationInfo_Obj
        {
            get
            {
                if (earthworkBlockImplementationInfo_Obj == null)
                {
                    if (!string.IsNullOrEmpty(EarthworkBlockImplementationInfo))
                        earthworkBlockImplementationInfo_Obj = JsonConvert.DeserializeObject<EarthworkBlockImplementationInfo>(EarthworkBlockImplementationInfo);
                    else
                        earthworkBlockImplementationInfo_Obj = new EarthworkBlockImplementationInfo();
                }
                return earthworkBlockImplementationInfo_Obj;
            }

            set
            {
                earthworkBlockImplementationInfo_Obj = value;
                //EarthworkBlockImplementationInfo = JsonConvert.SerializeObject(earthworkBlockImplementationInfo_Obj);
            }
        }

        private EarthworkBlockImplementationInfo earthworkBlockImplementationInfo_Obj = null;
        /// <summary>
        /// 颜色透明度配置
        /// </summary>
        public EarthworkBlockCPSettings CPSettings_Obj
        {
            get
            {
                if (cpSettings_Obj == null)
                {
                    if (!string.IsNullOrEmpty(CPSettings))
                        cpSettings_Obj = JsonConvert.DeserializeObject<EarthworkBlockCPSettings>(CPSettings);
                    else
                        cpSettings_Obj = new EarthworkBlockCPSettings();
                }
                return cpSettings_Obj;
            }

            set
            {
                cpSettings_Obj = value;
            }
        }

        private EarthworkBlockCPSettings cpSettings_Obj = null;



        public void Add(TEarthworkBlocking blocking, ElementId elementId)
        {
            var block = blocking.EarthworkBlocks.FirstOrDefault(c => c.ElementIds.Exists(p => p == elementId.IntegerValue));
            if (block != null)
            {
                if (block.Id == Id)
                    return;

                block.Delete(blocking, elementId);
            }
            ElementIds.Add(elementId.IntegerValue);
            CPSettings_Obj.ApplySetting(blocking, new List<ElementId>() { elementId });
        }
        public void Add(TEarthworkBlocking blocking, List<ElementId> elementIds)
        {
            foreach (var elementId in elementIds)
            {
                Add(blocking, elementId);
            }
        }
        public void Delete(TEarthworkBlocking blocking, ElementId elementId)
        {
            if (!ElementIds.Exists(p => p == elementId.IntegerValue))
                return;
            ElementIds.Remove(elementId.IntegerValue);
            CPSettings_Obj.DeapplySetting(blocking, new List<ElementId>() { elementId });
        }
        public void Delete(TEarthworkBlocking blocking, List<ElementId> elementIds)
        {
            foreach (var elementId in elementIds)
            {
                Delete(blocking, elementId);
            }
        }
        #endregion
    }
}
