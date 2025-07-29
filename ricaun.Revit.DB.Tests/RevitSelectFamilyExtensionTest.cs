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
}
