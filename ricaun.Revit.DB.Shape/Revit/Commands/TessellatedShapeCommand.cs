using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class TessellatedShapeCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            Document document = uiapp.ActiveUIDocument.Document;

            var verticesCube = new[] { new XYZ(0.25, -0.25, 0.25), new XYZ(0.25, 0.25, 0.25), new XYZ(-0.25, 0.25, 0.25), new XYZ(-0.25, -0.25, 0.25), new XYZ(-0.25, 0.25, -0.25), new XYZ(0.25, 0.25, -0.25), new XYZ(0.25, -0.25, -0.25), new XYZ(-0.25, -0.25, -0.25), new XYZ(-0.25, -0.25, 0.25), new XYZ(-0.25, -0.25, -0.25), new XYZ(0.25, -0.25, -0.25), new XYZ(0.25, -0.25, 0.25), new XYZ(0.25, -0.25, 0.25), new XYZ(0.25, -0.25, -0.25), new XYZ(0.25, 0.25, -0.25), new XYZ(0.25, 0.25, 0.25), new XYZ(0.25, 0.25, 0.25), new XYZ(0.25, 0.25, -0.25), new XYZ(-0.25, 0.25, -0.25), new XYZ(-0.25, 0.25, 0.25), new XYZ(-0.25, 0.25, 0.25), new XYZ(-0.25, 0.25, -0.25), new XYZ(-0.25, -0.25, -0.25), new XYZ(-0.25, -0.25, 0.25) };
            var indexesCube = new[] { 0, 1, 2, 2, 3, 0, 4, 5, 6, 6, 7, 4, 8, 9, 10, 10, 11, 8, 12, 13, 14, 14, 15, 12, 16, 17, 18, 18, 19, 16, 20, 21, 22, 22, 23, 20 };

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("Tessellated Cube");

                document.DeleteDirectShape();

                var materialIds = new ElementId[] { MaterialUtils.CreateMaterial(document, Colors.Index.Color_161).Id };

                var solids = TessellatedShapeCreator.CreateMesh(verticesCube, indexesCube, materialIds).OfType<Solid>();
                document.CreateDirectShape(solids);

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }

}
