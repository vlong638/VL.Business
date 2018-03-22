using Autodesk.Revit.DB;
using PmSoft.ConstructionManagement.EarthWork.UI;
using PmSoft.ConstructionManagement.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VL.Common.Core.Object.Subsidence;

namespace PmSoft.ConstructionManagement.EarthWork.Entity
{
    /// <summary>
    /// 颜色/透明度配置
    /// </summary>
    public class EarthworkBlockCPSettings : MemorableData<EarthworkBlockingForm, EarthworkBlockCPSettings>
    {
        public EarthworkBlockCPSettings()
        {
        }

        #region 属性
        /// <summary>
        /// 图元可见
        /// </summary>
        public bool IsVisible { set; get; } = true;
        /// <summary>
        /// 半色调
        /// </summary>
        public bool IsHalftone { set; get; } = false;
        /// <summary>
        /// 表面可见
        /// </summary>
        public bool IsSurfaceVisible { set; get; } = true;
        /// <summary>
        /// 颜色 Surface即Projection
        /// </summar>y
        public System.Drawing.Color Color { set; get; } = System.Drawing.Color.FromArgb(137, 200, 245);
        /// <summary>
        /// 填充物 Surface即Projection
        /// </summary>
        public int FillerId { set; get; } = -1;
        /// <summary>
        /// 曲面透明度
        /// </summary>
        public int SurfaceTransparency { set; get; } = 90;
        #endregion

        #region MemorableData
        public override void Preview(EarthworkBlockingForm storage)
        {
            //更新视图内容
            ApplySetting(storage.Blocking,storage.Block.ElementIds.Select(c => new ElementId(c)).ToList());
        }
        public override void Commit(EarthworkBlockingForm storage)
        {
            //更新视图内容
            ApplySetting(storage.Blocking, storage.Block.ElementIds.Select(c => new ElementId(c)).ToList());
            //更新数据
            storage.Block.CPSettings = JsonConvert.SerializeObject(this);

            //TODO1009 保存Earthwork的局部数据

            ////保存数据
            //PmSoft.Common.CommonClass.FaceRecorderForRevit recorder = PMSoftHelper.GetRecorder(nameof(EarthworkBlockingForm), storage.m_Doc);
            //var jsonObj = JsonConvert.SerializeObject(this);
            //recorder.WriteValue(SaveKeyHelper.GetSaveKey(SaveKeyHelper.SaveKeyTypeForEarthWork.EarthworkBlockCPSettings_Size, storage.Block.Id), jsonObj.Length.ToString());
            //recorder.WriteValue(SaveKeyHelper.GetSaveKey(SaveKeyHelper.SaveKeyTypeForEarthWork.EarthworkBlockCPSettings, storage.Block.Id), jsonObj);
        }
        public override void Rollback()
        {
            IsVisible = Memo.IsVisible;
            IsSurfaceVisible = Memo.IsSurfaceVisible;
            IsHalftone = Memo.IsHalftone;
            Color = Memo.Color;
            FillerId = Memo.FillerId;
            SurfaceTransparency = Memo.SurfaceTransparency;
        }
        protected override EarthworkBlockCPSettings Clone()
        {
            return new EarthworkBlockCPSettings()
            {
                IsVisible = IsVisible,
                IsSurfaceVisible = IsSurfaceVisible,
                IsHalftone = IsHalftone,
                Color = Color,
                FillerId = FillerId,
                SurfaceTransparency = SurfaceTransparency,
            };
        }
        public override int GetSimpleHashCode()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(IsVisible);
            sb.Append(IsHalftone);
            sb.Append(IsSurfaceVisible);
            sb.Append(Color.R);
            sb.Append(Color.G);
            sb.Append(Color.B);
            sb.Append(FillerId);
            sb.Append(SurfaceTransparency);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 行为
        /// <summary>
        /// 对元素增加节点的配置
        /// </summary>
        /// <param name="element"></param>
        //void ApplySetting(View view, ElementId elementId, OverrideGraphicSettings setting)
        //{
        //    var group = view.Document.GetElement(elementId) as Group;
        //    if (group != null)
        //    {
        //        foreach (var memberId in group.GetMemberIds())
        //            view.SetElementOverrides(memberId, setting);
        //    }
        //    else
        //    {
        //        view.SetElementOverrides(elementId, setting);
        //    }
        //}
        void ApplySetting(View view, ElementId elementId)
        {
            OverrideGraphicSettings setting = GetOverrideGraphicSettings(view.Document);
            Revit_Helper.ApplyOverrideGraphicSettings(view, elementId, setting);
        }
        public void ApplySetting(TEarthworkBlocking blocking, List<ElementId> elementIds)
        {
            using (var transaction = new Transaction(VLConstraints.Doc, "EarthworkBlocking." + nameof(ApplySetting)))
            {
                transaction.Start();
                ApplySettingWithoutTransaction(blocking, elementIds);
                transaction.Commit();
            }
        }
        public void ApplySettingForDisplay(View view, List<ElementId> elementIds)
        {
            OverrideGraphicSettings setting = GetOverrideGraphicSettings(view.Document);
            foreach (var elementId in elementIds)
                Revit_Helper.ApplyOverrideGraphicSettings(view, elementId, setting);
        }
        
        public void ApplySettingWithoutTransaction(TEarthworkBlocking blocking, List<ElementId> elementIds)
        {
            if (elementIds == null || elementIds.Count == 0)
                return;
            OverrideGraphicSettings setting = GetOverrideGraphicSettings(VLConstraints.Doc);
            //元素可见性
            if (IsVisible)
                VLConstraints.View3D.UnhideElements(elementIds);
            else
                VLConstraints.View3D.HideElements(elementIds);
            //元素表面填充物配置
            foreach (var elementId in elementIds)
                Revit_Helper.ApplyOverrideGraphicSettings(VLConstraints.View3D, elementId, setting);
        }

        public static ElementId _DefaultFillPatternId = null;
        public static ElementId GetDefaultFillPatternId(Document doc)
        {
            if (_DefaultFillPatternId != null)
                return _DefaultFillPatternId;

            _DefaultFillPatternId = new FilteredElementCollector(doc).OfClass(typeof(FillPatternElement)).ToElements().First(c => c.Name == "实体填充").Id;
            return _DefaultFillPatternId;
        }
        OverrideGraphicSettings GetOverrideGraphicSettings(Document doc)
        {
            var setting = Revit_Helper.GetOverrideGraphicSettings(new Color(Color.R, Color.G, Color.B), FillerId == -1 ? GetDefaultFillPatternId(doc) : new ElementId(FillerId), SurfaceTransparency);
            setting.SetHalftone(IsHalftone);
            return setting;

            //var setting = new OverrideGraphicSettings();
            //setting.SetHalftone(IsHalftone);
            //setting.SetProjectionFillPatternVisible(IsSurfaceVisible);
            //setting.SetProjectionFillColor(new Color(Color.R, Color.G, Color.B));
            //if (FillerId == -1)
            //    setting.SetProjectionFillPatternId(GetDefaultFillPatternId(doc));
            //else
            //    setting.SetProjectionFillPatternId(new ElementId(FillerId));
            //setting.SetSurfaceTransparency(SurfaceTransparency);
            //return setting;
        }
        /// <summary>
        /// 解除对元素增加的节点的配置
        /// </summary>
        /// <param name="element"></param>
        void DeapplySetting(View view, ElementId elementId)
        {
            Revit_Helper.ApplyOverrideGraphicSettings(view, elementId, VLConstraints.DefaultCPSettings);

            //var group = view.Document.GetElement(elementId) as Group;
            //if (group != null)
            //{
            //    foreach (var memberId in group.GetMemberIds())
            //        view.SetElementOverrides(memberId, EarthworkBlockingConstraints.DefaultCPSettings);
            //}
            //else
            //{
            //    view.SetElementOverrides(elementId, EarthworkBlockingConstraints.DefaultCPSettings);
            //}
        }
        /// <summary>
        /// 解除对元素增加的节点的配置
        /// </summary>
        /// <param name="element"></param>
        public void DeapplySetting(TEarthworkBlocking blocking, List<ElementId> elementIds)
        {
            using (var transaction = new Transaction(VLConstraints.Doc, "EarthworkBlocking." + nameof(DeapplySetting)))
            {
                OverrideGraphicSettings setting = GetOverrideGraphicSettings(VLConstraints.Doc);
                transaction.Start();
                //元素可见性
                VLConstraints.View3D.UnhideElements(elementIds);
                //元素表面填充物配置
                foreach (var elementId in elementIds)
                    DeapplySetting(VLConstraints.View3D, elementId);
                transaction.Commit();
            }
        }
        #endregion
    }
}
