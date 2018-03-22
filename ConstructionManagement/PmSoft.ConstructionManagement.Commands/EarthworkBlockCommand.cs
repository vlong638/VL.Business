using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace PmSoft.ConstructionManagement.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class EarthworkBlockingCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            return new EarthworkBlockingExe().Execute(commandData, ref message, elements);
        }
    }
}
