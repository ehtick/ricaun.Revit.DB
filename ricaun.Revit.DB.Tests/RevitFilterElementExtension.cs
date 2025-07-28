using Autodesk.Revit.DB;
using NUnit.Framework;

namespace ricaun.Revit.DB.Tests
{
    public class RevitFilterElementExtension
    {
        ElementCategoryFilter ElementCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_ProjectInformation);
        ElementClassFilter ElementClassFilter = new ElementClassFilter(typeof(ProjectInfo));

        [Test]
        public void And()
        {
            var filter = ElementCategoryFilter.And(ElementClassFilter);
            Assert.IsNotNull(filter);

            Assert.IsInstanceOf<LogicalAndFilter>(filter);
        }

        [Test]
        public void And_AddFilter()
        {
            var filter = new LogicalAndFilter(ElementCategoryFilter, ElementClassFilter);
            Assert.IsNotNull(filter);

            filter.AddFilter(ElementClassFilter);

            Assert.IsInstanceOf<LogicalAndFilter>(filter);
        }

        [Test]
        public void Or()
        {
            var filter = ElementCategoryFilter.Or(ElementClassFilter);
            Assert.IsNotNull(filter);

            Assert.IsInstanceOf<LogicalOrFilter>(filter);
        }

        [Test]
        public void Or_AddFilter()
        {
            var filter = new LogicalOrFilter(ElementCategoryFilter, ElementClassFilter);
            Assert.IsNotNull(filter);

            filter.AddFilter(ElementClassFilter);

            Assert.IsInstanceOf<LogicalOrFilter>(filter);
        }
    }
}
