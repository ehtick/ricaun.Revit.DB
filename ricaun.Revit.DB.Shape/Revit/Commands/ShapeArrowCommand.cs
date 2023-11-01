using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.DB.Shape.Extensions;

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

                var arrowType = document.CreateDirectShapeType(ShapeCreator.CreateArrow());

                arrowType.Create();

                for (int i = 1; i <= 10; i++)
                {
                    var material2 = MaterialUtils.CreateMaterial(document, Colors.Index.Get((byte)(i)));

                    // Internal CreateArrow with sides, not work very well
                    var arrowTypeLow = document.CreateDirectShapeType(ShapeCreator.CreateArrow(i + 2, material2.Id));
                    arrowTypeLow.Create(Transform.CreateTranslation(i * 0.1 * XYZ.BasisX));
                }

                var materialRed = MaterialUtils.CreateMaterialRed(document);
                var materialGreen = MaterialUtils.CreateMaterialGreen(document);
                var materialBlue = MaterialUtils.CreateMaterialBlue(document);

                for (int sides = 3; sides <= 10; sides++)
                {
                    var arrowX = ShapeCreator.CreateArrow(sides, materialRed.Id)
                        .CreateTransformed(TransformUtils.CreateRotation(XYZ.BasisX));

                    var arrowY = ShapeCreator.CreateArrow(sides, materialGreen.Id)
                        .CreateTransformed(TransformUtils.CreateRotation(XYZ.BasisY));

                    var arrowZ = ShapeCreator.CreateArrow(sides, materialBlue.Id)
                       .CreateTransformed(TransformUtils.CreateRotation(XYZ.BasisZ));

                    var gizmo = document.CreateDirectShape(new[] { arrowX, arrowY, arrowZ });
                    gizmo.Location.Move(sides * 0.1 * XYZ.BasisY);

                    var gizmo2 = document.CreateDirectShape(new[] {
                    ShapeCreator.CreateArrow(sides, XYZ.BasisX, materialRed.Id),
                    ShapeCreator.CreateArrow(sides, XYZ.BasisY, materialGreen.Id),
                    ShapeCreator.CreateArrow(sides, XYZ.BasisZ, materialBlue.Id) });

                    gizmo2.Location.Move(sides * 0.1 * XYZ.BasisY + sides * 0.1 * XYZ.BasisX);
                }

                for (int sides = 3; sides <= 10; sides++)
                {
                    var gizmo = document.CreateDirectShape(ShapeCreator.CreateGizmo(document, sides));
                    gizmo.Location.Move(sides * 0.1 * XYZ.BasisY - 0.5 * XYZ.BasisZ);

                }

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }
}
