using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
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

                Assert(familyCollector.FirstElement().Id == familyCollector.FirstElementId());
            }

            {
                // Element does not exist in the document
                var familySymbolCollector = document.Select<FamilySymbol>();
                var familyInstanceCollector = document.Select<FamilyInstance>();

                Assert(familySymbolCollector.FirstElement() is null);
                Assert(familySymbolCollector.FirstElementId() == ElementId.InvalidElementId);

                Assert(familyInstanceCollector.FirstElement() is null);
                Assert(familyInstanceCollector.FirstElementId() == ElementId.InvalidElementId);
            }

            {
                var elementCollector = document.Select<Element>();
                var selectElementCollector = document.SelectElements<Element>();

                Assert(elementCollector.FirstElementId() == selectElementCollector.FirstElementId());
                Assert(elementCollector.GetElementCount() == selectElementCollector.GetElementCount());

                var elementTypeCollector = document.Select<ElementType>();
                var selectElementTypeCollector = document.SelectElementTypes<ElementType>();

                Assert(elementTypeCollector.FirstElementId() == selectElementTypeCollector.FirstElementId());
                Assert(elementTypeCollector.GetElementCount() == selectElementTypeCollector.GetElementCount());
            }

            {
                var elements = document.GetElements<Element>();
                var firstElement = document.GetFirstElement<Element>();
                var elementIds = document.GetElementIds<Element>();
                var firstElementId = document.GetFirstElementId<Element>();

                Assert(elements.Count() == elementIds.Count());
                Assert(elements.First().Id == firstElementId);
                Assert(elements.First().Id == elementIds.First());
                Assert(firstElement.Id == firstElementId);

                var elementTypes = document.GetElementTypes<ElementType>();
                var firstElementType = document.GetFirstElementType<ElementType>();
                var elementTypeIds = document.GetElementTypeIds<ElementType>();
                var firstElementTypeId = document.GetFirstElementTypeId<ElementType>();

                Assert(elementTypes.Count() == elementTypeIds.Count());
                Assert(elementTypes.First().Id == firstElementTypeId);
                Assert(elementTypes.First().Id == elementTypeIds.First());
                Assert(firstElementType.Id == firstElementTypeId);
            }

            {
                var element = document.GetFirstElementType();

                var id = element.Id;
                var filterId = BuiltInParameter.ID_PARAM.Filter(id);
                var elementFilterId = document.GetFirstElementType(filterId);
                Console.WriteLine(id);

                Assert(element.Id == elementFilterId.Id);

                var name = element.Name;
                var filterTypeName = BuiltInParameter.ALL_MODEL_TYPE_NAME.Filter(name);
                var elementFilterName = document.GetFirstElementType(filterTypeName);
                Console.WriteLine(name);

                Assert(element.Id == elementFilterName.Id);

                var buildInCategory = element.Category.Id.GetBuiltInCategory();
                var elementCategory = document.GetFirstElementType(buildInCategory);
                Console.WriteLine(buildInCategory);

                Assert(element.Id == elementCategory.Id);
            }

            {
                var filterInverted = BuiltInParameter.SYMBOL_ID_PARAM.Rule(ElementId.InvalidElementId)
                    .ToElementFilter(true);

                var element = document.GetFirstElement(filterInverted);

                var typeId = element.GetTypeId();
                var filterTypeId = BuiltInParameter.SYMBOL_ID_PARAM.Filter(typeId);
                var elementFiltered = document.GetFirstElement(filterTypeId);
                System.Console.WriteLine(typeId);

                Debug.Assert(element.Id == elementFiltered.Id);
            }

            {
                var element = document.GetFirstElement<ProjectInfo>();
                Console.WriteLine(element.Id);

                Assert(element.Id == document.ProjectInformation.Id);

                var elementProjectInformation = document.GetFirstElement(BuiltInCategory.OST_ProjectInformation);
                Console.WriteLine(elementProjectInformation.Id);

                Assert(elementProjectInformation.Id == document.ProjectInformation.Id);


                var filterProjectName = BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS.Filter<FilterStringContains>(string.Empty);
                var elementNoProjectName = document.GetFirstElement(filterProjectName);
                Console.WriteLine(elementNoProjectName.Id);

                Assert(elementNoProjectName.Id == ElementId.InvalidElementId);


            }


            return Result.Succeeded;
        }

        public static void Assert(bool condition, [System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0)
        {
            if (!condition)
            {
                throw new System.Exception($"Assertion failed at line {lineNumber}");
            }
        }
    }
}
