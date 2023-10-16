using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.DB.Shape.Extensions;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{

    [Transaction(TransactionMode.Manual)]
    public class TessellatedShapeTwoBoxCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            Document document = uiapp.ActiveUIDocument.Document;

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("Tessellated Sphere");

                document.DeleteDirectShape();

                var shape1 = ShapeCreator.CreateBox(XYZ.Zero, 1);
                var shape2 = ShapeCreator.CreateBox(XYZ.Zero, 1)
                    .CreateTransformed(Transform.CreateTranslation(10 * XYZ.BasisX));

                var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                    shape1.GetTriangleVertices().Concat(shape2.GetTriangleVertices()).ToArray());

                document.CreateDirectShape(tessellatedShape.GetGeometricalObjects());

                transaction.Commit();
            }
            return Result.Succeeded;
        }
    }


    [Transaction(TransactionMode.Manual)]
    public class TessellatedShapeSphereCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            Document document = uiapp.ActiveUIDocument.Document;

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("Tessellated Sphere");

                document.DeleteDirectShape();

                var shape = ShapeCreator.CreateSphere(XYZ.Zero, 1,
                    materialId: MaterialUtils.CreateMaterial(document, Colors.Index.Color_151).Id);

                document.CreateDirectShape(shape).Location.Move(-2 * XYZ.BasisX);

                var materialIds = new ElementId[] { MaterialUtils.CreateMaterial(document, Colors.Index.Color_161).Id };

                var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                    shape.GetTriangleVertices().ToArray(), materialIds: materialIds);

                var mesh = tessellatedShape.OfType<Mesh>().FirstOrDefault();

                document.CreateDirectShape(mesh);

                document.CreateDirectShape(
                    TessellatedShapeCreator.CreateMesh(mesh.GetTriangleVertices().ToArray()).GetGeometricalObjects()
                ).Location.Move(2 * XYZ.BasisX);

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }

}
