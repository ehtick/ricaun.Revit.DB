using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Tests.Utils;
using System.Linq;

namespace ricaun.Revit.DB.Tests
{
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
    }
}
