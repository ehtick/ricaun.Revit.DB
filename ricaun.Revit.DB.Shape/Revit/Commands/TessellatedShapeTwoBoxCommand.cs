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

                var materialRed = MaterialUtils.CreateMaterialRed(document);
                var materialGreen = MaterialUtils.CreateMaterialGreen(document);
                var materialBlue = MaterialUtils.CreateMaterialBlue(document);

                var shape1 = ShapeCreator.CreateBox(XYZ.Zero, 1);
                var shape2 = ShapeCreator.CreateBox(XYZ.Zero, 1)
                    .CreateTransformed(Transform.CreateTranslation(10 * XYZ.BasisX));

                var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                    shape1.GetTriangleVertices().Concat(shape2.GetTriangleVertices()).ToArray(), materialIds: new[] { materialGreen.Id, materialGreen.Id, materialBlue.Id, materialBlue.Id });

                document.CreateDirectShape(tessellatedShape.GetGeometricalObjects());

                var shape3 = ShapeCreator.CreateBox(XYZ.Zero, 1)
                    .CreateTransformed(Transform.CreateTranslation(2 * XYZ.BasisX));

                var tessellatedShape2 = TessellatedShapeCreator.CreateMesh(
                    shape1.GetTriangleVertices().Concat(shape3.GetTriangleVertices()).ToArray(), materialIds: new[] { materialBlue.Id });

                var meshShape = document.CreateDirectShape(tessellatedShape2.GetGeometricalObjects());
                meshShape.Location.Move(2 * XYZ.BasisZ);

                var mesh = meshShape.get_Geometry(new Options()).OfType<Mesh>().FirstOrDefault();
                if (mesh != null)
                {
                    document.CreateDirectShape(TessellatedShapeCreator.CreateMesh(mesh.GetTriangleVertices().ToArray(), materialIds: new[] { materialGreen.Id, materialBlue.Id, materialRed.Id }).GetGeometricalObjects())
                        .Location.Move(2 * XYZ.BasisZ);
                }

                transaction.Commit();
            }
            return Result.Succeeded;
        }
    }

}
