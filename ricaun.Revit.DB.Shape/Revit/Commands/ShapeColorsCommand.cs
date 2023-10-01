using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ShapeColorsCommand : IExternalCommand
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

                for (int i = 0; i <= 255; i++)
                {
                    var move = -(i % 16) * (2 * scale) * XYZ.BasisX - (i / 16) * (2 * scale) * XYZ.BasisY;
                    var material = MaterialUtils.CreateMaterial(document, Colors.Index.Get((byte)i));
                    var box = document.CreateDirectShape(ShapeCreator.CreateBox(XYZ.Zero, scale * 0.75, materialId: material.Id));
                    box.Location.Move(move);

                    var parameter = box.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                    parameter.Set($"[{i}]: {material.Name}");

                }

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }
}
