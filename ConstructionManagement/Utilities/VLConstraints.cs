using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmSoft.ConstructionManagement.Utilities
{
    class VLConstraints
    {
        public static OverrideGraphicSettings DefaultCPSettings = new OverrideGraphicSettings();
        public static Document Doc { set; get; }
        public static UIDocument UIDoc { set; get; }
        public static View3D View3D { private set; get; }

        public static bool InitByDocument(UIDocument uidoc)
        {
            UIDoc = uidoc;
            Doc = UIDoc.Document;
            string viewName = "土方分块";
            View3D = Revit_Document_Helper.GetElementByNameAs<View3D>(Doc, viewName);
            if (View3D == null)
            {
                using (var transaction = new Transaction(Doc, "EarthworkBlocking." + nameof(InitByDocument)))
                {
                    transaction.Start();
                    try
                    {
                        var viewFamilyType = new FilteredElementCollector(Doc).OfClass(typeof(ViewFamilyType)).ToElements().FirstOrDefault(c => (c as ViewFamilyType).FamilyName == "三维视图" || (c as ViewFamilyType).FamilyName == "3D View");
                        if (viewFamilyType == null)
                        {
                            TaskDialog.Show("消息", "该功能需在三维视图下操作");
                            return false;
                        }
                        View3D = View3D.CreateIsometric(Doc, viewFamilyType.Id);
                        View3D.Name = viewName;
                        transaction.Commit();
                        TaskDialog.Show("消息", "三维视图(土方分块)新建成功");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.RollBack();
                        TaskDialog.Show("消息", "视图(土方分块)新建失败,错误详情:" + ex.ToString());
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }
    }
}
