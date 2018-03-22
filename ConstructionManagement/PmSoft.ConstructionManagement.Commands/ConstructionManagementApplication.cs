using Autodesk.Revit.UI;
using System.IO;
using System.Windows.Media.Imaging;

namespace PmSoft.ConstructionManagement.Commands
{
    public class ConstructionManagementApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            application.CreateRibbonTab("施工信息管理");
            var panel = application.CreateRibbonPanel("施工信息管理", "施工信息管理");
            var fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directoryPath = fullPath.Substring(0, fullPath.LastIndexOf("\\"));
            panel.AddItem(new PushButtonData("土方分块", "土方分块", fullPath, "PmSoft.ConstructionManagement.Commands.EarthworkBlockingCommand") { LargeImage = new BitmapImage(new System.Uri(Path.Combine(directoryPath, "Icons", "土方分块.png"))) });
            panel.AddItem(new PushButtonData("监测系统", "监测系统", fullPath, "PmSoft.ConstructionManagement.Commands.SubsidenceMonitorCommand") { LargeImage = new BitmapImage(new System.Uri(Path.Combine(directoryPath, "Icons", "预警系统.png"))) });
            panel.AddItem(new PushButtonData("预警值配置", "预警值配置", fullPath, "PmSoft.ConstructionManagement.Commands.WarnSettingsCommand") { LargeImage = new BitmapImage(new System.Uri(Path.Combine(directoryPath, "Icons", "预警值设置.png"))) });
            return Result.Succeeded;
        }
    }
}
