using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ShapeGizmoSidesCommand : IExternalCommand
    {
        private static int sides = 3;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document document = uidoc.Document;

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("DirectShapeType");

                document.DeleteDirectShape();

                var gizmoType = document.CreateDirectShapeType(ShapeCreator.CreateGizmo(document, sides));
                if (++sides == 10) sides = 3;

                gizmoType.Create();

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }
}
