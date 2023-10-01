using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ricaun.Revit.DB.Quaternion;
using ricaun.Revit.DB.Quaternion.Extensions;
using System;

namespace ricaun.Revit.DB.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class QuaternionCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document document = uidoc.Document;
            View view = uidoc.ActiveView;
            Selection selection = uidoc.Selection;

            var tranform = view.CropBox.Transform;

            var quaternion = tranform.GetQuaternion();

            Console.WriteLine(quaternion.AsString());

            //System.Windows.MessageBox.Show(uiapp.Application.VersionName);

            return Result.Succeeded;
        }
    }
}
