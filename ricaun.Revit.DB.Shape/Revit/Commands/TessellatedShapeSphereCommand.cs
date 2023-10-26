using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.DB.Shape.Extensions;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{
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

                if (mesh != null)
                {
                    document.CreateDirectShape(mesh);

                    document.CreateDirectShape(
                        TessellatedShapeCreator.CreateMesh(mesh.GetTriangleVertices().ToArray()).GetGeometricalObjects()
                    ).Location.Move(2 * XYZ.BasisX);
                }

                document.Regenerate();

                document.CreateDirectShape(
                    TessellatedShapeCreator.CreateMesh(shape.Clone().GetTriangleVertices(0.3).ToArray(),
                    materialIds: new ElementId[] { MaterialUtils.CreateMaterial(document, Colors.Index.Color_131).Id }).GetGeometricalObjects()
                ).Location.Move(4 * XYZ.BasisX);

                shape = shape.Clone();

                //for (double i = 0; i <= 1; i += 0.1)
                //{
                //    var vertices = shape.GetVertices(i).ToArray();
                //    var indices = shape.GetIndices(i).ToArray();
                //    System.Console.WriteLine($"[{i:0.00}] {vertices.Length} {indices.Length}");
                //}

                var count = 0;
                for (double i = 0; i <= 1; i += 0.1)
                {
                    var vertices = shape.GetVertices(i).ToArray();
                    var indices = shape.GetIndices(i).ToArray();
                    System.Console.WriteLine($"[{i:0.00}] {vertices.Length} {indices.Length}");
                    document.CreateDirectShape(
                        TessellatedShapeCreator.CreateMesh(vertices, indices,
                        materialIds: new ElementId[] { MaterialUtils.CreateMaterial(document, Colors.Index.Color_11).Id }).GetGeometricalObjects()
                    ).Location.Move((2 * count++) * XYZ.BasisX + 5 * XYZ.BasisY);
                }

                count = 0;
                for (double i = 0; i <= 1; i += 0.1)
                {
                    var verticeTriangles = shape.GetTriangleVertices(i).ToArray();
                    document.CreateDirectShape(
                        TessellatedShapeCreator.CreateMesh(verticeTriangles,
                        materialIds: new ElementId[] { MaterialUtils.CreateMaterial(document, Colors.Index.Color_21).Id }).GetGeometricalObjects()
                    ).Location.Move((2 * count++) * XYZ.BasisX + 10 * XYZ.BasisY);
                }

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }

}
