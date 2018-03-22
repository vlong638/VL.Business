using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace PmSoft.ConstructionManagement.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class WarnSettingsCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            return new WarnSettingsExe().Execute(commandData, ref message, elements);
        }
    }
}
