using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Tests.Utils;
using System.Linq;

namespace ricaun.Revit.DB.Tests
{
    public class RevitSelectFamilyExtensionTest : OneTimeOpenDocumentTest
    {
        [Test]
        public void SelectFamily()
        {
            // There is not parameter for Family to find by name :(
            // Is possible to have multiple families with the same name if the category is different.
            // The 'SYMBOL_FAMILY_NAME_PARAM' or 'ALL_MODEL_FAMILY_NAME' is used to find all FamilySymbol elements with the family name.
            // There is some possibility to exist a Family without any FamilySymbol element in the document.

            var idParameter = BuiltInParameter.ID_PARAM; 
            var symbolFamilyNameParameter = BuiltInParameter.SYMBOL_FAMILY_NAME_PARAM;
            var modelFamilyNameParameter = BuiltInParameter.ALL_MODEL_FAMILY_NAME;
            var elements = document.GetElements<Family>();

            foreach (var element in elements)
            {
                var id = element.Id;
                var filterElements = document.GetElements<Family>(idParameter.Filter(id));
                Assert.AreEqual(1, filterElements.Count(), $"There should be exactly one Family element with id {id}.");

                var familyName = element.Name;
                var filterSymbolByFamilyNameElements = document.GetElementTypes<FamilySymbol>(symbolFamilyNameParameter.Filter(familyName));
                Assert.AreEqual(1, filterSymbolByFamilyNameElements.Count(), $"There should be exactly one Family element with family name {familyName}.");

                var filterModelByFamilyNameElements = document.GetElementTypes(modelFamilyNameParameter.Filter(familyName));
                Assert.AreEqual(1, filterModelByFamilyNameElements.Count(), $"There should be exactly one Family element with family name {familyName}.");
            }
        }

        [Test]
        public void SelectFamilySymbol()
        {
            var symbolFamilyNameParameter = BuiltInParameter.SYMBOL_FAMILY_NAME_PARAM;
            var symbolNameParameter = BuiltInParameter.SYMBOL_NAME_PARAM;
            var elements = document.GetElementTypes<FamilySymbol>();

            foreach (var element in elements)
            {
                var name = element.Name;
                var filterElements = document.GetElementTypes<FamilySymbol>(symbolNameParameter.Filter(name));
                Assert.AreEqual(1, filterElements.Count(), $"There should be exactly one FamilySymbol element with name {name}.");

                var familyName = element.FamilyName;
                var filterByFamilyNameElements = document.GetElementTypes<FamilySymbol>(symbolFamilyNameParameter.Filter(familyName));
                Assert.AreEqual(1, filterByFamilyNameElements.Count(), $"There should be exactly one Family element with family name {familyName}.");
            }
        }
    }

    public class RevitSelectLevelExtensionTest : OneTimeOpenDocumentTest
    {
        [Test]
        public void SelectLevelType()
        {
            var first = document.GetFirstElementType<LevelType>();
            Assert.IsNotNull(first, "First LevelType should not be null.");

            var firstId = document.GetFirstElementTypeId<LevelType>();
            Assert.AreEqual(first.Id, firstId, "First LevelType ID should match the first element type ID.");

            var count = document.SelectElementTypes<LevelType>().GetElementCount();
            Assert.AreEqual(1, count, "There should be exactly one LevelType element in the document.");

            var elements = document.GetElementTypes<LevelType>();
            Assert.AreEqual(1, elements.Count(), "There should be exactly one LevelType element in the document.");

            var firstCategory = document.GetFirstElementType(BuiltInCategory.OST_Levels);
            Assert.IsNotNull(firstCategory, "First LevelType category should not be null.");

            var countCategory = document.SelectElementTypes(BuiltInCategory.OST_Levels).GetElementCount();
            Assert.AreEqual(1, countCategory, "There should be exactly one LevelType element in the OST_Levels category.");

            var elementsCategory = document.GetElementTypes(BuiltInCategory.OST_Levels);
            Assert.AreEqual(1, elementsCategory.Count(), "There should be exactly one LevelType element in the OST_Levels category.");
        }

        [Test]
        public void SelectLevelType_Filter()
        {
            var first = document.GetFirstElementType<LevelType>();
            Assert.IsNotNull(first, "First LevelType should not be null.");

            // 'Type Name' - SYMBOL_NAME_PARAM is only available for ElementType
            var firstByName = document.GetFirstElementType(BuiltInParameter.SYMBOL_NAME_PARAM.Filter(first.Name));
            Assert.AreEqual(first.Id, firstByName.Id, "First LevelType by name should match the first element type ID.");

            var firstByNameLower = document.GetFirstElementType(BuiltInParameter.SYMBOL_NAME_PARAM.Filter(first.Name.ToLower()));
            Assert.AreEqual(first.Id, firstByNameLower.Id, "First LevelType by name should match the first element type ID.");

            var firstByNameUpper = document.GetFirstElementType(BuiltInParameter.SYMBOL_NAME_PARAM.Filter(first.Name.ToUpper()));
            Assert.AreEqual(first.Id, firstByNameUpper.Id, "First LevelType by name should match the first element type ID.");
        }

        [Test]
        public void SelectLevel()
        {
            var first = document.GetFirstElement<Level>();
            Assert.IsNotNull(first, "First Level should not be null.");

            var firstId = document.GetFirstElementId<Level>();
            Assert.AreEqual(first.Id, firstId, "First Level ID should match the first element ID.");

            var count = document.SelectElements<Level>().GetElementCount();
            Assert.AreEqual(1, count, "There should be exactly one Level element in the document.");

            var elements = document.GetElements<Level>();
            Assert.AreEqual(1, elements.Count(), "There should be exactly one Level element in the document.");

            var firstCategory = document.GetFirstElement(BuiltInCategory.OST_Levels);
            Assert.IsNotNull(firstCategory, "First Level category should not be null.");

            var countCategory = document.SelectElements(BuiltInCategory.OST_Levels).GetElementCount();
            Assert.AreEqual(1, countCategory, "There should be exactly one Level element in the OST_Levels category.");

            var elementsCategory = document.GetElements(BuiltInCategory.OST_Levels);
            Assert.AreEqual(1, elementsCategory.Count(), "There should be exactly one Level element in the OST_Levels category.");
        }

        [Test]
        public void SelectLevel_Filter()
        {
            var first = document.GetFirstElement<Level>();
            Assert.IsNotNull(first, "First Level should not be null.");

            // 'Name' - DATUM_TEXT is only available for Level
            var firstByName = document.GetFirstElement(BuiltInParameter.DATUM_TEXT.Filter(first.Name));
            Assert.AreEqual(first.Id, firstByName.Id, "First Level by name should match the first element ID.");

            var firstByNameLower = document.GetFirstElement(BuiltInParameter.DATUM_TEXT.Filter(first.Name.ToLower()));
            Assert.AreEqual(first.Id, firstByNameLower.Id, "First Level by name should match the first element ID.");

            var firstByNameUpper = document.GetFirstElement(BuiltInParameter.DATUM_TEXT.Filter(first.Name.ToUpper()));
            Assert.AreEqual(first.Id, firstByNameUpper.Id, "First Level by name should match the first element ID.");
        }
    }
}
