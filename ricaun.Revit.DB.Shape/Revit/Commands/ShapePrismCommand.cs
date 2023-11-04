using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ShapePrismCommand : IExternalCommand
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
                document.CreateDirectShape(ShapeCreator.CreateBox(-XYZ.BasisY, scale));
                for (int i = 0; i <= 12; i++)
                {
                    var prims = document.CreateDirectShape(ShapeCreator.CreatePrism(i + 3, i * XYZ.BasisX, scale));
                    var pyramid = document.CreateDirectShape(ShapeCreator.CreatePyramid(i + 3, i * XYZ.BasisX + XYZ.BasisY, scale));
                }

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }


}
