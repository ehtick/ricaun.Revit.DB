using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ShapeCommandCategory : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            Document document = uiapp.ActiveUIDocument.Document;

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("DirectShape");

                document.DeleteDirectShape();
                document.DeleteDirectShape(BuiltInCategory.OST_Conduit);
                document.DeleteDirectShape(BuiltInCategory.OST_CableTray);

                var materialRed = MaterialUtils.CreateMaterialRed(document);
                var materialGreen = MaterialUtils.CreateMaterialGreen(document);
                var materialBlue = MaterialUtils.CreateMaterialBlue(document);

                var scale = 0.5;

                var box = document.CreateDirectShape(ShapeCreator.CreateBox(XYZ.Zero, scale, materialId: materialRed.Id));
                box.Location.Move(-(2 * scale) * XYZ.BasisX);

                var sphere = document.CreateDirectShape(ShapeCreator.CreateSphere(XYZ.Zero, scale, materialId: materialGreen.Id), BuiltInCategory.OST_Conduit);
                sphere.Location.Move(-(4 * scale) * XYZ.BasisX);

                var cylinder = document.CreateDirectShape(ShapeCreator.CreateCylinder(XYZ.Zero, scale, materialId: materialBlue.Id), BuiltInCategory.OST_CableTray);
                cylinder.Location.Move(-(6 * scale) * XYZ.BasisX);

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }

}
