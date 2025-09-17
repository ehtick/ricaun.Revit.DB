using Autodesk.Revit.DB;
using NUnit.Framework;
using System;

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

        [Test]
        public void ElementIdTryParse()
        {
            var elementId = ElementId.InvalidElementId;
            Assert.IsTrue(elementId.TryParse(elementId.ToString(), out var id));
            Assert.AreEqual(elementId, id);

            elementId = new ElementId(BuiltInCategory.OST_ProjectInformation);
            Assert.IsTrue(elementId.TryParse(elementId.ToString(), out id));
            Assert.AreEqual(elementId, id);

            elementId = new ElementId(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
            Assert.IsTrue(elementId.TryParse(elementId.ToString(), out id));
            Assert.AreEqual(elementId, id);

            Assert.IsTrue(elementId.TryParse("123456", out id));
            Assert.IsTrue(elementId.TryParse("012345", out id));
            Assert.IsTrue(elementId.TryParse("-12345", out id));

            Assert.IsFalse(elementId.TryParse("1234.5", out id));
            Assert.IsFalse(elementId.TryParse("1234a5", out id));
            Assert.IsFalse(elementId.TryParse("12345a", out id));
        }

        [Test]
        public void ElementIdParse()
        {
            var elementId = ElementId.InvalidElementId;
            Assert.AreEqual(elementId, elementId.Parse(elementId.ToString()));

            elementId = new ElementId(BuiltInCategory.OST_ProjectInformation);
            Assert.AreEqual(elementId, elementId.Parse(elementId.ToString()));

            elementId = new ElementId(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
            Assert.AreEqual(elementId, elementId.Parse(elementId.ToString()));

            Assert.IsNotNull(elementId.Parse("123456"));
            Assert.IsNotNull(elementId.Parse("012345"));
            Assert.IsNotNull(elementId.Parse("-12345"));

            Assert.Throws<InvalidOperationException>(() => elementId.Parse("1234.5"));
            Assert.Throws<InvalidOperationException>(() => elementId.Parse("1234a5"));
            Assert.Throws<InvalidOperationException>(() => elementId.Parse("12345a"));

        }
    }
}
