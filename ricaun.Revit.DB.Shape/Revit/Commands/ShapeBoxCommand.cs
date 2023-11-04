using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ShapeBoxCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document document = uidoc.Document;

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("DirectShape");

                document.DeleteDirectShape();

                var scale = 0.5;

                var box = document.CreateDirectShape(ShapeCreator.CreateBox(XYZ.Zero, scale));

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }
}
