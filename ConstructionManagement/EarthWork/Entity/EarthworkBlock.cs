//using Autodesk.Revit.DB;
//using PmSoft.ConstructionManagement.EarthWork.UI;
//using PmSoft.ConstructionManagement.Utilities;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace PmSoft.ConstructionManagement.EarthWork.Entity
//{
//    /// <summary>
//    /// 土方分块节点
//    /// </summary>
//    [JsonObject(MemberSerialization.OptOut)]
//    public class EarthworkBlock : SectionalData<EarthworkBlockingForm, EarthworkBlocking, EarthworkBlock, ElementId>
//    {
//        public EarthworkBlock(int id, string name)
//        {
//            //Parent = parent;
//            CPSettings = new EarthworkBlockCPSettings();
//            ImplementationInfo = new EarthworkBlockImplementationInfo();

//            Id = id;
//            Name = name;
//        }

//        #region 属性
//        /// <summary>
//        /// Earthwork的编号
//        /// </summary>
//        public int Id { get; set; }
//        /// <summary>
//        /// 名称
//        /// </summary>
//        public string Name { get; set; }
//        /// <summary>
//        /// 描述
//        /// </summary>
//        public string Description { get; set; }
//        /// <summary>
//        /// 颜色透明度配置
//        /// </summary>
//        [JsonIgnore]//InitByDocument()中根据Document初始化
//        public EarthworkBlockCPSettings CPSettings { set; get; }
//        /// <summary>
//        /// 节点施工的信息
//        /// </summary>
//        public EarthworkBlockImplementationInfo ImplementationInfo { set; get; }
//        /// <summary>
//        /// 测点下的构件集合
//        /// </summary>
//        public List<int> ElementIdValues { get; set; } = new List<int>();
//        [JsonIgnore]//InitByDocument()中根据Document初始化
//        public List<ElementId> ElementIds { get; set; } = new List<ElementId>();
//        [JsonIgnore]
//        public int ElementCount { get { return ElementIds.Count(); } }
//        #endregion

//        #region SectionalData
//        protected override EarthworkBlock Clone()
//        {
//            var block = new EarthworkBlock(Id, Name);
//            block.ElementIds.AddRange(ElementIds);
//            block.ElementIdValues.AddRange(ElementIdValues);
//            return block;
//        }
//        public override int GetSimpleHashCode()
//        {
//            StringBuilder sb = new StringBuilder();
//            sb.Append(Id);
//            sb.Append(Name);
//            sb.Append("Adds:" + string.Join(",", Adds.Select(c => c.IntegerValue)));
//            sb.Append("Deletes:" + string.Join(",", Deletes.Select(c => c.IntegerValue)));
//            sb.Append(ImplementationInfo.StartTime);
//            sb.Append(ImplementationInfo.ExposureTime);
//            sb.Append(ImplementationInfo.EndTime);
//            sb.Append(ImplementationInfo.IsConflicted);
//            return sb.ToString().GetHashCode();
//        }
//        public override void Commit(EarthworkBlockingForm storage)
//        {
//            PmSoft.Common.CommonClass.FaceRecorderForRevit recorder = PMSoftHelper.GetRecorder(nameof(EarthworkBlockingForm), storage.m_Doc);
//            var jsonObj = JsonConvert.SerializeObject(this);
//            recorder.WriteValue(SaveKeyHelper.GetSaveKey(SaveKeyHelper.SaveKeyTypeForEarthWork.EarthworkBlock_Size, Id), jsonObj.Length.ToString());
//            recorder.WriteValue(SaveKeyHelper.GetSaveKey(SaveKeyHelper.SaveKeyTypeForEarthWork.EarthworkBlock, Id), jsonObj);
//        }
//        public override void Rollback()
//        {
//            Name = Memo.Name;
//            Adds.Clear();
//            Deletes.Clear();
//        }
//        public override void Add(EarthworkBlocking blocking, ElementId elementId)
//        {
//            var block = blocking.Blocks.FirstOrDefault(c => c.ElementIds.Exists(p => p.IntegerValue == elementId.IntegerValue));
//            if (block != null)
//            {
//                if (block.Id == Id)
//                    return;

//                block.Delete(blocking, new List<ElementId>() { elementId });
//            }
//            ElementIds.Add(elementId);
//            ElementIdValues.Add(elementId.IntegerValue);
//            Adds.Add(elementId);
//            CPSettings.ApplySetting(blocking, new List<ElementId>() { elementId });
//        }
//        public override void Delete(EarthworkBlocking blocking, ElementId elementId)
//        {
//            if (!ElementIds.Exists(p => p.IntegerValue == elementId.IntegerValue))
//                return;
//            ElementIds.Remove(elementId);
//            ElementIdValues.Remove(elementId.IntegerValue);
//            Deletes.Add(elementId);
//            CPSettings.DeapplySetting(blocking, new List<ElementId>() { elementId });
//        }
//        #endregion
//    }
//}
