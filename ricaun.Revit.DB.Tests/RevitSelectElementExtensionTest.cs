using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Tests
{
    public class RevitSelectElementExtensionTest : OneTimeOpenDocumentTest
    {
        [Test]
        public void SelectProjectInfo()
        {
            var projectInfo = document.ProjectInformation;
            var category = projectInfo.Category.Id.GetBuiltInCategory();

            var element = document.GetFirstElement<ProjectInfo>();
            var elementId = document.GetFirstElementId<ProjectInfo>();
            var elementCategory = document.GetFirstElement(category);
            var elementCategoryId = document.GetFirstElementId(category);

            Assert.IsNotNull(element);
            Assert.IsNotNull(elementId);
            Assert.IsNotNull(elementCategory);
            Assert.IsNotNull(elementCategoryId);

            Assert.AreEqual(projectInfo.Id, element.Id);
            Assert.AreEqual(projectInfo.Id, elementId);
            Assert.AreEqual(projectInfo.Id, elementCategory.Id);
            Assert.AreEqual(projectInfo.Id, elementCategoryId);
        }

        [Test]
        public void SelectElementFamily()
        {
            var familyCollector = document.Select<Family>();

            Assert.IsTrue(familyCollector.FirstElement().Id == familyCollector.FirstElementId());
        }

        [Test]
        public void SelectElementFamilySymbol()
        {
            var familySymbolCollector = document.Select<FamilySymbol>();

            Assert.IsTrue(familySymbolCollector.FirstElement().Id == familySymbolCollector.FirstElementId());
        }

        [Test]
        public void SelectElementFamilyInstance()
        {
            var familyInstanceCollector = document.Select<FamilyInstance>();

            Assert.IsTrue(familyInstanceCollector.FirstElement() is null);
            Assert.IsTrue(familyInstanceCollector.FirstElementId() == ElementId.InvalidElementId);
        }

        [Test]
        public void SelectElementT()
        {
            var elementCollector = document.Select<Element>();
            var selectElementCollector = document.SelectElements<Element>();

            Assert.IsTrue(elementCollector.FirstElementId() == selectElementCollector.FirstElementId());
            Assert.IsTrue(elementCollector.GetElementCount() == selectElementCollector.GetElementCount());

            var elementTypeCollector = document.Select<ElementType>();
            var selectElementTypeCollector = document.SelectElementTypes<ElementType>();

            Assert.IsTrue(elementTypeCollector.FirstElementId() == selectElementTypeCollector.FirstElementId());
            Assert.IsTrue(elementTypeCollector.GetElementCount() == selectElementTypeCollector.GetElementCount());
        }

        [Test]
        public void SelectElementFirst()
        {
            var elements = document.GetElements<Element>();
            var firstElement = document.GetFirstElement<Element>();
            var elementIds = document.GetElementIds<Element>();
            var firstElementId = document.GetFirstElementId<Element>();

            Assert.IsTrue(elements.Count() == elementIds.Count());
            Assert.IsTrue(elements.First().Id == firstElementId);
            Assert.IsTrue(elements.First().Id == elementIds.First());
            Assert.IsTrue(firstElement.Id == firstElementId);

            var elementTypes = document.GetElementTypes<ElementType>();
            var firstElementType = document.GetFirstElementType<ElementType>();
            var elementTypeIds = document.GetElementTypeIds<ElementType>();
            var firstElementTypeId = document.GetFirstElementTypeId<ElementType>();

            Assert.IsTrue(elementTypes.Count() == elementTypeIds.Count());
            Assert.IsTrue(elementTypes.First().Id == firstElementTypeId);
            Assert.IsTrue(elementTypes.First().Id == elementTypeIds.First());
            Assert.IsTrue(firstElementType.Id == firstElementTypeId);
        }

        [Test]
        public void SelectElementById()
        {
            var element = document.GetFirstElementType();

            var id = element.Id;
            var filterId = BuiltInParameter.ID_PARAM.Filter(id);
            var elementFilterId = document.GetFirstElementType(filterId);
            Console.WriteLine(id);

            Assert.IsTrue(element.Id == elementFilterId.Id);
        }

        [Test]
        public void SelectSymbolById()
        {
            var filterInverted = BuiltInParameter.SYMBOL_ID_PARAM.Rule(ElementId.InvalidElementId)
                .Filter(true);

            filterInverted = BuiltInParameter.SYMBOL_ID_PARAM.Filter(ElementId.InvalidElementId, true);

            var element = document.GetFirstElement(filterInverted);

            var typeId = element.GetTypeId();
            var filterTypeId = BuiltInParameter.SYMBOL_ID_PARAM.Filter(typeId);
            var elementFiltered = document.GetFirstElement(filterTypeId);
            Console.WriteLine(typeId);

            Assert.IsTrue(element.Id == elementFiltered.Id);
        }

        [Test]
        public void SelectTransaction_String_Comment()
        {
            var comments = "Comments";
            var builtInParameter = BuiltInParameter.ALL_MODEL_TYPE_COMMENTS;
            var elements = document.GetElementTypes();

            var dictionary = new Dictionary<ElementId, string>();
            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("Update Comments");
                foreach (var element in elements)
                {
                    if (element.get_Parameter(builtInParameter) is Parameter parameter)
                    {
                        if (parameter.IsReadOnly) continue;
                        var value = comments + element.UniqueId;
                        dictionary.Add(element.Id, value);
                        parameter.Set(value);
                    }
                }
                transaction.Commit();
            }

            Console.WriteLine($"Count: {dictionary.Count}");

            // Verify that the comments were set correctly
            foreach (var item in dictionary)
            {
                var id = item.Key;
                var value = item.Value;

                var elementType = document.GetFirstElementType(builtInParameter.Filter(value));
                var elementTypes = document.GetElementTypes(builtInParameter.Filter(value));
                var elementTypeIdLower = document.GetFirstElementTypeId(builtInParameter.Filter(value.ToLowerInvariant()));

                Assert.AreEqual(1, elementTypes.Count);
                Assert.IsTrue(elementType.Id == id);
                Assert.IsTrue(elementTypes.First().Id == id);
                Assert.IsTrue(elementTypeIdLower == id);
            }

            var beginWithComments = document.GetElementTypes(builtInParameter.Filter<FilterStringBeginsWith>(comments));
            Assert.AreEqual(dictionary.Count, beginWithComments.Count);

            var containsComments = document.GetElementTypes(builtInParameter.Filter<FilterStringContains>(comments));
            Assert.AreEqual(dictionary.Count, containsComments.Count);
        }

        [Test]
        public void SelectTransaction_Double_Cost()
        {
            var cost = 0.0;
            var builtInParameter = BuiltInParameter.ALL_MODEL_COST;
            var elements = document.GetElementTypes();

            var dictionary = new Dictionary<ElementId, double>();
            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("Update Cost");
                foreach (var element in elements)
                {
                    if (element.get_Parameter(builtInParameter) is Parameter parameter)
                    {
                        if (parameter.IsReadOnly) continue;
                        var value = cost;
                        cost += 1.23;
                        dictionary.Add(element.Id, value);
                        parameter.Set(value);
                    }
                }
                transaction.Commit();
            }

            Console.WriteLine($"Count: {dictionary.Count}");

            foreach (var item in dictionary)
            {
                var id = item.Key;
                var value = item.Value;

                var elementType = document.GetFirstElementType(builtInParameter.Filter(value));
                var elementTypes = document.GetElementTypes(builtInParameter.Filter(value));

                Assert.AreEqual(1, elementTypes.Count);
                Assert.IsTrue(elementType.Id == id);
                Assert.IsTrue(elementTypes.First().Id == id);
            }

            var greaterOrEqualToZero = document.GetElementTypes(builtInParameter.Filter<FilterNumericGreaterOrEqual>(0.0));
            Assert.AreEqual(dictionary.Count, greaterOrEqualToZero.Count);

            var lessOrEqualToZero = document.GetElementTypes(builtInParameter.Filter<FilterNumericLessOrEqual>(0.0));
            Assert.AreEqual(1, lessOrEqualToZero.Count);

            var lessOrEqualToCost = document.GetElementTypes(builtInParameter.Filter<FilterNumericLessOrEqual>(cost));
            Assert.AreEqual(dictionary.Count, lessOrEqualToCost.Count);
        }
    }
}
