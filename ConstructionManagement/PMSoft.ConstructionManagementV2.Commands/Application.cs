using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System.IO;
using System.Windows.Media.Imaging;

namespace PMSoft.ConstructionManagementV2.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class CMApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            application.CreateRibbonTab("施工信息管理V2");
            var panel = application.CreateRibbonPanel("施工信息管理V2", "施工信息管理V2");
            var fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directoryPath = fullPath.Substring(0, fullPath.LastIndexOf("\\"));
            panel.AddItem(new PushButtonData("土方分块", "土方分块", fullPath, "PMSoft.ConstructionManagementV2.Commands.CMCommand")
            { LargeImage = new BitmapImage(new System.Uri(Path.Combine(directoryPath, "Icons", "土方分块.png"))) });
            return Result.Succeeded;
        }
    }
}
