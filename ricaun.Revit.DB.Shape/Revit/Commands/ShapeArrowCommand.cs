using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ShapeArrowCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document document = uidoc.Document;

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("DirectShapeType");

                document.DeleteDirectShape();

                var material = MaterialUtils.CreateMaterial(document, Colors.Magenta);
                var arrowType = document.CreateDirectShapeType(ShapeCreator.CreateArrow(material.Id));

                arrowType.Create();

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }
}
