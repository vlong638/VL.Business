using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using PmSoft.MainModel.EntData;
using PmSoft.ConstructionManagement.EarthWork.UI;
using System.Windows.Forms;
using PmSoft.Common.Controls.RevitMethod;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.UI.Selection;
using PmSoft.ConstructionManagement.Hook;
using System;
using MouseHook.VLHooker;
using System.Runtime.InteropServices;

namespace PmSoft.ConstructionManagement.Commands
{
    //[Transaction(TransactionMode.Manual)]
    //public class EarthworkBlockingCommand : IExternalCommand
    //{
    //    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    //    {
    //        return new EarthworkBlockingExe().Execute(commandData, ref message, elements);
    //    }
    //}
    public class EarthworkBlockingExe
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            EarthworkBlockingSet set = new EarthworkBlockingSet(commandData);
            if (!set.DoCmd())
            {
                return Result.Failed;
            }
            return Result.Succeeded;
        }
    }
    public class EarthworkBlockingSet : CToolCmd
    {
        public EarthworkBlockingSet(ExternalCommandData revit) : base(revit)
        {
        }

        protected override bool Analyse()
        {
            return true;
        }
        protected override void Reset()
        {
            Utilities.SQLiteHelper.PrepareTables();
        }

        EarthworkBlockingForm Form;

        protected override bool DoUI()
        {
            var directory = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //string directory = System.AppDomain.CurrentDomain.BaseDirectory;
            //MessageBox.Show(directory);
            System.IO.Directory.SetCurrentDirectory(directory.Substring(0, directory.LastIndexOf("\\")));

            Form = new EarthworkBlockingForm(this.m_app);
            PickObjectsMouseHook mouseHook = new PickObjectsMouseHook();
            DialogResult result = DialogResult.Retry;
            while ((result = Form.ShowDialog(new Hook.RevitHandle(Process.GetCurrentProcess().MainWindowHandle))) == DialogResult.Retry)
            {
                if (result == DialogResult.Cancel)
                    return false;
                if (result == DialogResult.OK)
                    return true;
                if (Form.ShowDialogType == ShowDialogType.AddElements || Form.ShowDialogType == ShowDialogType.DeleleElements)
                {
                    Hooker.DelegateCompletingAction(() =>
                    {
                        Form.SelectedElementIds = m_uiDoc.Selection.PickObjects(ObjectType.Element, "选择要添加的构件")
                            .Select(p => m_doc.GetElement(p.ElementId).Id).ToList();
                    });
                    Form.FinishElementSelection();

                    //Hooker Hooker = new Hooker();
                    //try
                    //{
                    //    Hooker.MouseHookProcedure = new Hooker.HookProc(MouseHookProc);
                    //    Hooker.Start();
                    //    Form.SelectedElementIds = m_uiDoc.Selection.PickObjects(ObjectType.Element, "选择要添加的构件")
                    //        .Select(p => m_doc.GetElement(p.ElementId).Id).ToList();
                    //    Hooker.Stop();
                    //}
                    //catch (Exception ex)
                    //{
                    //    Hooker.Stop();
                    //}

                    //try
                    //{
                    //    mouseHook.InstallHook();
                    //    Form.SelectedElementIds = m_uiDoc.Selection.PickObjects(ObjectType.Element, "选择要添加的构件")
                    //        .Select(p => m_doc.GetElement(p.ElementId).Id).ToList();
                    //    mouseHook.UninstallHook();
                    //}
                    //catch
                    //{
                    //    mouseHook.UninstallHook();
                    //}
                }
                if (Form.ShowDialogType == ShowDialogType.ViewGT6 || Form.ShowDialogType == ShowDialogType.ViewCompletion)
                {
                    Hooker.DelegateCompletingAction(() =>
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
                }
            }
            return true;

            #region 非模态
            //try
            //{
            //    if (ConfigPathManager.IniProjectDB(this.m_doc))
            //    {
            //        Form = new EarthworkBlockingForm(this.m_app);
            //        Form.ShowDialog();
            //        return true;
            //    }
            //    else
            //        return false;
            //}
            //catch(Exception ex)
            //{
            //    TaskDialog.Show("错误", ex.Message);
            //    return false;
            //} 
            #endregion
        }
    }
}
