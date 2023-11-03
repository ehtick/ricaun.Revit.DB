using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ricaun.Revit.DB.Shape.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class TessellatedShapeCopyCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document document = uidoc.Document;
            View view = uidoc.ActiveView;
            Selection selection = uidoc.Selection;

            var elements = selection.GetElementIds().Select(id => document.GetElement(id));
            var instances = elements.OfType<FamilyInstance>();


            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("TransactionName");

                document.DeleteDirectShape();

                foreach (var instance in instances)
                {
                    var options = new Options() { View = view };
                    var solids = instance.get_Geometry(options)
                        .OfType<GeometryInstance>()
                        .SelectMany(e => e.GetInstanceGeometry())
                        .OfType<Solid>()
                        .Where(e => e.Volume > 0);

                    System.Console.WriteLine($"Solids: {solids.Count()}");
                    var box = instance.get_BoundingBox(view);
                    if (box == null) { box = new BoundingBoxXYZ() { Min = XYZ.Zero, Max = new XYZ(1, 1, 1) }; }
                    var size = (box.Max - box.Min);

                    size += 0.1 * XYZ.BasisX;

                    var shapes = new List<GeometryObject>();
                    foreach (var solid in solids)
                    {
                        var creator = TessellatedShapeCreator.CreateMesh(
                            solid.GetVertices().ToArray(),
                            solid.GetIndices().ToArray(),
                            solid.GetTriangleMaterialIds().ToArray());
                        shapes.AddRange(creator.GetGeometricalObjects());
                    }
                    var shape = document.CreateDirectShape(shapes);
                    shape.Location.Move(XYZ.BasisX * size.X);

                    for (double i = 0; i < 1.0; i += 0.2)
                    {
                        var shapesDetail = new List<GeometryObject>();
                        foreach (var solid in solids)
                        {
                            var creator = TessellatedShapeCreator.CreateMesh(
                                solid.GetVertices(i).ToArray(),
                                solid.GetIndices(i).ToArray(),
                                solid.GetTriangleMaterialIds(i).ToArray());
                            shapesDetail.AddRange(creator.GetGeometricalObjects());
                        }
                        var shapeDetail = document.CreateDirectShape(shapesDetail);
                        shapeDetail.Location.Move((2 + i * 5) * XYZ.BasisX * size.X);
                    }
                }

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }

}
