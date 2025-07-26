using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Diagnostics;
using System.Linq;

namespace ricaun.Revit.DB.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            Document document = uiapp.ActiveUIDocument.Document;

            {
                // Element exists in the document
                var familyCollector = document.Select<Family>();

                Debug.Assert(familyCollector.FirstElement().Id == familyCollector.FirstElementId());
            }

            {
                // Element does not exist in the document
                var familySymbolCollector = document.Select<FamilySymbol>();
                var familyInstanceCollector = document.Select<FamilyInstance>();

                Debug.Assert(familySymbolCollector.FirstElement() is null);
                Debug.Assert(familySymbolCollector.FirstElementId() == ElementId.InvalidElementId);

                Debug.Assert(familyInstanceCollector.FirstElement() is null);
                Debug.Assert(familyInstanceCollector.FirstElementId() == ElementId.InvalidElementId);
            }

            {
                var elementCollector = document.Select<Element>();
                var selectElementCollector = document.SelectElements<Element>();

                Debug.Assert(elementCollector.FirstElementId() == selectElementCollector.FirstElementId());
                Debug.Assert(elementCollector.GetElementCount() == selectElementCollector.GetElementCount());

                var elementTypeCollector = document.Select<ElementType>();
                var selectElementTypeCollector = document.SelectElementTypes<ElementType>();

                Debug.Assert(elementTypeCollector.FirstElementId() == selectElementTypeCollector.FirstElementId());
                Debug.Assert(elementTypeCollector.GetElementCount() == selectElementTypeCollector.GetElementCount());
            }

            {
                var elements = document.GetElements<Element>();
                var firstElement = document.GetFirstElement<Element>();
                var elementIds = document.GetElementIds<Element>();
                var firstElementId = document.GetFirstElementId<Element>();

                Debug.Assert(elements.Count() == elementIds.Count());
                Debug.Assert(elements.First().Id == firstElementId);
                Debug.Assert(elements.First().Id == elementIds.First());
                Debug.Assert(firstElement.Id == firstElementId);

                var elementTypes = document.GetElementTypes<ElementType>();
                var firstElementType = document.GetFirstElementType<ElementType>();
                var elementTypeIds = document.GetElementTypeIds<ElementType>();
                var firstElementTypeId = document.GetFirstElementTypeId<ElementType>();

                Debug.Assert(elementTypes.Count() == elementTypeIds.Count());
                Debug.Assert(elementTypes.First().Id == firstElementTypeId);
                Debug.Assert(elementTypes.First().Id == elementTypeIds.First());
                Debug.Assert(firstElementType.Id == firstElementTypeId);
            }

            {
                var element = document.GetFirstElementType(new ElementCategoryFilter(BuiltInCategory.INVALID, true));

                var id = element.Id;
                var filterId = BuiltInParameter.ID_PARAM.Filter<FilterNumericEquals>(id);
                var elementSymbol = document.GetFirstElementType(filterId);
                System.Console.WriteLine(id);

                Debug.Assert(element.Id == elementSymbol.Id);

                var name = element.Name;
                var filterFamilyName = BuiltInParameter.ALL_MODEL_TYPE_NAME.Filter<FilterStringEquals>(name);
                var elementName = document.GetFirstElementType(filterFamilyName);
                System.Console.WriteLine(name);

                Debug.Assert(element.Id == elementName.Id);

                var buildInCategory = element.Category.Id.GetBuiltInCategory();
                var elementCategory = document.GetFirstElementType(buildInCategory);
                System.Console.WriteLine(buildInCategory);

                Debug.Assert(element.Id == elementCategory.Id);
            }

            return Result.Succeeded;
        }
    }
}
