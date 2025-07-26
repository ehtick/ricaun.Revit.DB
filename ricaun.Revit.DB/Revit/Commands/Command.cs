using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Diagnostics;

namespace ricaun.Revit.DB.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            Document document = uiapp.ActiveUIDocument.Document;

            // Element exists in the document
            var familyCollector = document.Select<Family>();
            
            Debug.Assert(familyCollector.FirstElement().Id == familyCollector.FirstElementId());

            // Element does not exist in the document
            var familySymbolCollector = document.Select<FamilySymbol>();
            var familyInstanceCollector = document.Select<FamilyInstance>();

            Debug.Assert(familySymbolCollector.FirstElement() is null);
            Debug.Assert(familySymbolCollector.FirstElementId() == ElementId.InvalidElementId);

            Debug.Assert(familyInstanceCollector.FirstElement() is null);
            Debug.Assert(familyInstanceCollector.FirstElementId() == ElementId.InvalidElementId);

            


            return Result.Succeeded;
        }
    }
}
