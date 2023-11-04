using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ShapeGizmoFullCommand : IExternalCommand
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

                var gizmoType = document.CreateDirectShapeType(ShapeCreator.CreateGizmo(document));

                gizmoType.Create();

                var transform = Transform.CreateTranslation(XYZ.Zero);
                for (double i = 0; i <= 2 * Math.PI; i += Math.PI / 8)
                {
                    var transformX = Transform.CreateTranslation((1 + i) * XYZ.BasisX);
                    gizmoType.Create(transform * transformX * Transform.CreateRotation(XYZ.BasisX, i));

                    var transformY = Transform.CreateTranslation((1 + i) * XYZ.BasisY);
                    gizmoType.Create(transform * transformY * Transform.CreateRotation(XYZ.BasisY, i));

                    var transformZ = Transform.CreateTranslation((1 + i) * XYZ.BasisZ);
                    gizmoType.Create(transform * transformZ * Transform.CreateRotation(XYZ.BasisZ, i));
                }

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }
}
