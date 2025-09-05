using Autodesk.Revit.DB;
using NUnit.Framework;

namespace ricaun.Revit.DB.Tests
{
    public class RevitElementIdExtensionTest
    {
        static ElementId elementId = ElementId.InvalidElementId;
        const long elementIdValue = -1;

        [Test]
        public void ElementIdIsNotNull()
        {
            Assert.IsNotNull(elementId);
            Assert.IsInstanceOf<ElementId>(elementId);
            Assert.AreEqual(ElementId.InvalidElementId, elementId);
        }

        [Test]
        public void ElementIdValue()
        {
            var value = elementId.GetValue();
            Assert.IsInstanceOf<long>(value);
            Assert.AreEqual(elementIdValue, value);
        }

        [Test]
        public void ElementIdIsValid()
        {
            Assert.False(((ElementId)null).IsValid());
            Assert.False(elementId.IsValid());
            Assert.True(new ElementId(BuiltInCategory.OST_ProjectInformation).IsValid());
            Assert.True(new ElementId(BuiltInParameter.ID_PARAM).IsValid());
        }

        [Test]
        public void ElementIdIsLessThanInvalid()
        {
            Assert.False(((ElementId)null).IsLessThanInvalid());
            Assert.False(elementId.IsLessThanInvalid());
            Assert.True(new ElementId(BuiltInCategory.OST_ProjectInformation).IsLessThanInvalid());
            Assert.True(new ElementId(BuiltInParameter.ID_PARAM).IsLessThanInvalid());
        }

        [Test]
        public void ElementIdIsGreaterThanInvalid()
        {
            Assert.False(((ElementId)null).IsGreaterThanInvalid());
            Assert.False(elementId.IsGreaterThanInvalid());
            Assert.False(new ElementId(BuiltInCategory.OST_ProjectInformation).IsGreaterThanInvalid());
            Assert.False(new ElementId(BuiltInParameter.ID_PARAM).IsGreaterThanInvalid());
        }

        [Test]
        public void ElementIdBuiltInCategory()
        {
            var builtInCategory = elementId.GetBuiltInCategory();
            Assert.IsTrue(elementId.AreEquals(builtInCategory));
            Assert.AreEqual(BuiltInCategory.INVALID, builtInCategory);

            builtInCategory = BuiltInCategory.OST_ProjectInformation;
            var builtInCategoryId = new ElementId(builtInCategory);
            Assert.IsTrue(builtInCategoryId.AreEquals(builtInCategory));
        }

        [Test]
        public void ElementIdBuiltInParameter()
        {
            var builtInParameter = elementId.GetBuiltInParameter();
            Assert.IsTrue(elementId.AreEquals(builtInParameter));
            Assert.AreEqual(BuiltInParameter.INVALID, builtInParameter);

            builtInParameter = BuiltInParameter.ID_PARAM;
            var builtInParameterId = new ElementId(builtInParameter);
            Assert.IsTrue(builtInParameterId.AreEquals(builtInParameter));
        }
    }
}
