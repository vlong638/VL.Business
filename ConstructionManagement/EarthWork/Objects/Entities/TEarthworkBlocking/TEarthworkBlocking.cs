using Autodesk.Revit.DB;
using PmSoft.ConstructionManagement.EarthWork.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using VL.Common.Core.ORM;

namespace VL.Common.Core.Object.Subsidence
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
        public string ColorForUnsettled { get; set; } = "";
        /// <summary>
        /// 颜色(已完工)
        /// </summary>
        public string ColorForSettled { get; set; } = "";
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

        #region Init By Doc
        public void RemoveInvalidElementId(Document doc)
        {
            foreach (var EarthworkBlock in EarthworkBlocks)
            {
                for (int i = EarthworkBlock.ElementIds.Count-1; i >=0 ; i--)
                {
                    var elementId = EarthworkBlock.ElementIds[i];
                    var element = doc.GetElement(new ElementId(elementId));
                    if (element == null)
                        EarthworkBlock.ElementIds.Remove(elementId);
                }
            }
        }
        #endregion

        #region 辅助属性
        private System.Drawing.Color colorForUnsettled_Color = System.Drawing.Color.Empty;
        /// <summary>
        /// 颜色(未完工)
        /// </summary>
        public System.Drawing.Color ColorForUnsettled_Color
        {
            get
            {
                if (colorForUnsettled_Color == System.Drawing.Color.Empty)
                {
                    colorForUnsettled_Color = ColorTranslator.FromHtml(ColorForUnsettled);
                }
                return colorForUnsettled_Color;
            }
            set
            {
                colorForUnsettled_Color = value;
                ColorForUnsettled = ColorTranslator.ToHtml(colorForUnsettled_Color);
            }
        }
        private System.Drawing.Color colorForSettled_Color = System.Drawing.Color.Empty;
        /// <summary>
        /// 颜色(已完工)
        /// </summary>
        public System.Drawing.Color ColorForSettled_Color
        {
            get
            {
                if (colorForSettled_Color == System.Drawing.Color.Empty)
                {
                    colorForSettled_Color = ColorTranslator.FromHtml(ColorForSettled);
                }
                return colorForSettled_Color;
            }
            set
            {
                colorForSettled_Color = value;
                ColorForSettled = ColorTranslator.ToHtml(colorForSettled_Color);
            }
        }
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

        public List<EarthworkBlockImplementationInfo> GetBlockingImplementationInfos()
        {
            var result = new List<EarthworkBlockImplementationInfo>();
            foreach (var Block in EarthworkBlocks)
            {
                if (Block.EarthworkBlockImplementationInfo_Obj.Name == null)
                    Block.EarthworkBlockImplementationInfo_Obj.Name = Block.Name;
                if (Block.EarthworkBlockImplementationInfo_Obj.Name != Block.Name)
                {
                    Block.EarthworkBlockImplementationInfo_Obj.Name = Block.Name;
                    if (Block.EarthworkBlockImplementationInfo_Obj.IsSettled)
                        Block.EarthworkBlockImplementationInfo_Obj.IsConflicted = true;
                }
                Block.EarthworkBlockImplementationInfo_Obj.ElementCount = Block.ElementIds.Count();
                result.Add(Block.EarthworkBlockImplementationInfo_Obj);
            }
            return result;
        }
        #endregion

        #region Add,Insert,Delete
        public List<TEarthworkBlock> Adds { set; get; } = new List<TEarthworkBlock>();
        public List<TEarthworkBlock> Deletes { set; get; } = new List<TEarthworkBlock>();
        void add(int index, TEarthworkBlock block)
        {
            this.EarthworkBlocks.Insert(index, block);
            Adds.Add(block);
        }
        /// <summary>
        /// 在选择节点后面插入(默认)
        /// </summary>
        /// <param name="index">所选节点Index,从0开始</param>
        /// <returns></returns>
        public void Add(TEarthworkBlock element)
        {
            add(EarthworkBlocks.Count(), element);
        }
        /// <summary>
        /// 在指定位置前面插入
        /// </summary>
        /// <param name="index"></param>
        /// <param name="block"></param>
        public void InsertBefore(int index, TEarthworkBlock block)
        {
            add(index, block);
        }
        //在指定位置后面插入
        public void InsertAfter(int index, TEarthworkBlock block)
        {
            add(index + 1, block);
        }
        public void Delete(TEarthworkBlock block)
        {
            //移除节点的所有元素(目的:解除图形配置),然后移除节点
            block.Delete(this, block.ElementIds.Select(c => new ElementId(c)).ToList());
            EarthworkBlocks.Remove(block);
            Deletes.Add(block);
        }
        public void Delete(List<TEarthworkBlock> elements)
        {
            if (elements != null && elements.Count > 0)
            {
                for (int i = elements.Count; i > 0; i--)
                {
                    Delete(elements[i - 1]);
                }
            }
        } 
        #endregion

        #region Combine
        /// <summary>
        /// 合并节点
        /// </summary>
        /// <param name="index1">所选节点Index1,从0开始</param>
        /// <param name="index2">所选节点Index2,从0开始</param>
        /// <returns></returns>
        public bool Combine(TEarthworkBlocking blocking, int index1, int index2)
        {
            if (index1 == index2 ||
                (index1 < 0 || index1 >= EarthworkBlocks.Count) ||
                (index2 < 0 || index2 >= EarthworkBlocks.Count))
            {
                return false;
            }
            //合并处理
            var b1 = EarthworkBlocks[index1];
            var b2 = EarthworkBlocks[index2];
            b1.Add(blocking, b2.ElementIds.Select(c => new ElementId(c)).ToList());
            Delete(b2);
            return true;
        }
        public bool CombineBefore(int index)
        {
            return Combine(this, index, index - 1);
        }
        public bool CombineAfter(int index)
        {
            return Combine(this, index, index + 1);
        }
        #endregion

        #region Move
        public bool Move(int indexOrient, int indexTarget)
        {
            if (indexTarget < 0 || indexTarget >= EarthworkBlocks.Count())
                return false;
            if (indexOrient < 0 || indexOrient >= EarthworkBlocks.Count())
                return false;
            var item = EarthworkBlocks[indexOrient];
            EarthworkBlocks.Remove(item);
            EarthworkBlocks.Insert(indexTarget, item);
            return true;
        }
        public bool MoveStep1Foward(TEarthworkBlock block)
        {
            var index = EarthworkBlocks.IndexOf(block);
            return Move(index, index - 1);
        }
        public bool MoveStep1Backward(TEarthworkBlock block)
        {
            var index = EarthworkBlocks.IndexOf(block);
            return Move(index, index + 1);
        }
        #endregion

        public TEarthworkBlock CreateNew()
        {
            var index = GetEarthworkBlockMaxId();
            var block = new TEarthworkBlock(DateTime.MinValue,index);
            block.Name = "节点" + index;
            return block;
        }
        #endregion
    }
}
