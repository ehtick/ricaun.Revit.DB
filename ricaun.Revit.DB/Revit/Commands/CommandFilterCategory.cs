using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ricaun.Revit.DB.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class CommandFilterCategory : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            BuiltInCategory.OST_Walls.Filter();
            new[] {
                BuiltInCategory.OST_Walls
            }.Filter();

            return Result.Succeeded;
        }
    }
}
