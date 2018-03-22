using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using PmSoft.ConstructionManagement.SubsidenceMonitor.UI;
using PmSoft.Common.Controls.RevitMethod;
using PmSoft.Common.RevitClass;
using PmSoft.MainModel.EntData;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PmSoft.ConstructionManagement.Commands
{
    //[Transaction(TransactionMode.Manual)]
    //public class SubsidenceMonitorCommand : IExternalCommand
    //{
    //    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    //    {
    //        return new SubsidenceMonitorExe().Execute(commandData, ref message, elements);
    //    }
    //}
    public class SubsidenceMonitorExe
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            SubsidenceMonitorSet set = new SubsidenceMonitorSet(commandData);
            if (!set.DoCmd())
            {
                return Result.Failed;
            }
            return Result.Succeeded;
        }
    }
    public class SubsidenceMonitorSet : CToolCmd
    {
        public SubsidenceMonitorSet(ExternalCommandData revit) : base(revit)
        {
        }

        protected override bool Analyse()
        {
            return true;
        }
        protected override void Reset()
        {
            //监测并创建数据表
            Utilities.SQLiteHelper.PrepareTables();
            Utilities.Revit_Document_Helper.PrepareSharedParameter(m_doc);
            Utilities.UniqueIdHelper.PrepareUniqueId(m_doc);
        }
        ListForm Form;
        protected override bool DoUI()
        {
            Form = new ListForm(this.m_app.ActiveUIDocument);
            PickObjectsMouseHook mouseHook = new PickObjectsMouseHook();
            DialogResult result = DialogResult.Retry;
            while ((result = Form.ShowDialog(new RevitHandle(Process.GetCurrentProcess().MainWindowHandle))) == DialogResult.Retry)
            {
                switch (Form.ShowDialogType) 
                {
                    case ShowDialogType.AddElements:
                    case ShowDialogType.DeleleElements:
                        switch (Form.SubFormType)
                        {
                            case SubFormType.Subsidence:
                                MouseHook.VLHooker.Hooker.DelegateCompletingAction(() =>
                                {
                                    Form.SubFormForSubsidence.SelectedElementIds = new List<ElementId>() { m_uiDoc.Selection.PickObject(ObjectType.Element, "选择要添加的构件").ElementId };
                                });
                                //try
                                //{
                                //    mouseHook.InstallHook();
                                //    Form.SubFormForSubsidence.SelectedElementIds = new List<ElementId>() { m_uiDoc.Selection.PickObject(ObjectType.Element, "选择要添加的构件").ElementId };
                                //    mouseHook.UninstallHook();
                                //}
                                //catch
                                //{
                                //    mouseHook.UninstallHook();
                                //}
                                Form.SubFormForSubsidence.FinishElementSelection();
                                break;
                            case SubFormType.SkewBack:
                                MouseHook.VLHooker.Hooker.DelegateCompletingAction(() =>
                                {
                                    Form.SubFormForSkewBack.SelectedElementIds = new List<ElementId>() { m_uiDoc.Selection.PickObject(ObjectType.Element, "选择要添加的构件").ElementId };
                                });
                                //try
                                //{
                                //    mouseHook.InstallHook();
                                //    Form.SubFormForSkewBack.SelectedElementIds = new List<ElementId>() { m_uiDoc.Selection.PickObject(ObjectType.Element, "选择要添加的构件").ElementId };
                                //    mouseHook.UninstallHook();
                                //}
                                //catch
                                //{
                                //    mouseHook.UninstallHook();
                                //}
                                Form.SubFormForSkewBack.FinishElementSelection();
                                break;
                        }
                        break;
                    case ShowDialogType.ViewElementsBySelectedNodes:
                    case ShowDialogType.ViewElementsByAllNodes:
                    case ShowDialogType.ViewCurrentMaxByRed:
                    case ShowDialogType.ViewCurrentMaxByAll:
                    case ShowDialogType.ViewTotalMaxByRed:
                    case ShowDialogType.ViewTotalMaxByAll:
                    case ShowDialogType.ViewCloseWarn:
                    case ShowDialogType.ViewOverWarn:
                        MouseHook.VLHooker.Hooker.DelegateCompletingAction(() =>
                        {
                            m_uiDoc.Selection.PickObjects(ObjectType.Element, "");
                        });
                        //try
                        //{
                        //    mouseHook.InstallHook();
                        //    m_uiDoc.Selection.PickObjects(ObjectType.Element, "");
                        //    mouseHook.UninstallHook();
                        //}
                        //catch
                        //{
                        //    mouseHook.UninstallHook();
                        //}
                        break;
                }
            }
            return true;
        }
    }
}
