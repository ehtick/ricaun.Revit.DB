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

                var cylinderHeight = 1.0 / 4.0;
                var cylinderRadius = 1.0 / 48.0 / 4.0;
                var coneHeight = 1.0 / 12.0;
                var coneRadius = 1.0 / 48.0;

                var cylinderCenter = XYZ.BasisZ * (cylinderHeight) / 2;
                var coneCenter = cylinderCenter + XYZ.BasisZ * (cylinderHeight + coneHeight) / 2;

                var cylinder = ShapeCreator.CreatePrism(cylinderCenter, cylinderRadius, cylinderHeight);
                var cone = ShapeCreator.CreatePyramid(coneCenter, coneRadius, coneHeight);

                document.CreateDirectShape(ShapeCreator.CreateSolid(cone, cylinder));

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }
}
