using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ShapeSweptCommand : IExternalCommand
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
                document.CreateDirectShape(ShapeCreator.CreateSwept(new[] { -scale * XYZ.BasisZ, scale * XYZ.BasisZ }, scale));

                for (int i = 3; i < 10; i++)
                {
                    var lines = ShapeCreator.CreateLines(new[] {
                        -scale * XYZ.BasisZ + i * XYZ.BasisX,
                        scale * XYZ.BasisZ + i * XYZ.BasisX
                    });
                    var curve = lines.First();
                    var curveLoop = CurveLoopUtils.CreatePrismLoop(curve, scale, i);
                    var swept = ShapeCreator.CreateSwept(lines, curveLoop);
                    document.CreateDirectShape(swept);
                }

                for (int i = 3; i < 10; i++)
                {
                    var lines = ShapeCreator.CreateLines(new[] {
                        -scale * XYZ.BasisX + i * XYZ.BasisY,
                        scale * XYZ.BasisX + i * XYZ.BasisY
                    });
                    var curve = lines.First();
                    var curveLoop = CurveLoopUtils.CreatePrismLoop(curve, scale, i);
                    var swept = ShapeCreator.CreateSwept(lines, curveLoop);
                    document.CreateDirectShape(swept);
                }

                for (int i = 3; i < 10; i++)
                {
                    var lines = ShapeCreator.CreateLines(new[] {
                        -scale * XYZ.BasisY + i * XYZ.BasisZ,
                        scale * XYZ.BasisY + i * XYZ.BasisZ
                    });
                    var curve = lines.First();
                    var curveLoop = CurveLoopUtils.CreatePrismLoop(curve, scale, i);
                    var swept = ShapeCreator.CreateSwept(lines, curveLoop);
                    document.CreateDirectShape(swept);
                }

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }
}
