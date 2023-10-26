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

                var materialWhite = MaterialUtils.CreateMaterialWhite(document);

                var materialBlue2 = MaterialUtils.CreateMaterial(document, Colors.Index.Color_150);
                var materialBlue3 = MaterialUtils.CreateMaterial(document, Colors.Index.Color_151);
                var materialBlue4 = MaterialUtils.CreateMaterial(document, Colors.Index.Color_152);

                var shape1 = ShapeCreator.CreateBox(XYZ.Zero, 1);
                var shape2 = ShapeCreator.CreateBox(XYZ.Zero, 1)
                    .CreateTransformed(Transform.CreateTranslation(2 * XYZ.BasisX).ScaleBasis(0.5));

                var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                    shape1.GetTriangleVertices().Concat(shape2.GetTriangleVertices()).ToArray(), materialIds: new[] { materialGreen.Id, materialGreen.Id, materialBlue.Id, materialBlue.Id });

                document.CreateDirectShape(tessellatedShape.GetGeometricalObjects());

                var shape3 = ShapeCreator.CreateBox(XYZ.Zero, 1)
                    .CreateTransformed(Transform.CreateTranslation(2.0 * XYZ.BasisX + 2 * XYZ.BasisY + 1e-6 * XYZ.BasisZ));

                var tessellatedShape2 = TessellatedShapeCreator.CreateMesh(
                    shape1.GetTriangleVertices().Concat(shape3.GetTriangleVertices()).ToArray(), materialIds: new[] { materialBlue2.Id, materialBlue2.Id, materialBlue3.Id, materialBlue3.Id, materialBlue4.Id, materialBlue4.Id });

                var meshShape = document.CreateDirectShape(tessellatedShape2.GetGeometricalObjects());
                meshShape.Location.Move(2 * XYZ.BasisZ);

                var mesh = meshShape.get_Geometry(new Options()).OfType<Mesh>().FirstOrDefault();
                if (mesh != null)
                {
                    document.CreateDirectShape(TessellatedShapeCreator.CreateMesh(mesh.GetTriangleVertices().ToArray(), materialIds: new[] { materialGreen.Id, materialBlue.Id, materialRed.Id }).GetGeometricalObjects())
                        .Location.Move(2 * XYZ.BasisZ);
                }

                var solid = meshShape.get_Geometry(new Options()).OfType<Solid>().FirstOrDefault();
                if (solid != null)
                {
                    document.CreateDirectShape(TessellatedShapeCreator.CreateMesh(solid.GetTriangleVertices().ToArray(), materialIds: new[] { materialGreen.Id, materialBlue.Id, materialRed.Id, materialWhite.Id }).GetGeometricalObjects())
                        .Location.Move(2 * XYZ.BasisZ);
                }

                transaction.Commit();
            }
            return Result.Succeeded;
        }
    }

}
