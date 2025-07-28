using Autodesk.Revit.DB;
using NUnit.Framework;

namespace ricaun.Revit.DB.Tests
{
    public class RevitFilterCategoryExtension
    {
        [Test]
        public void FilterBuiltInCategory()
        {
            var value = BuiltInCategory.OST_ProjectInformation;
            var filter = value.Filter();
            var filterInverted = value.Filter(true);

            Assert.IsNotNull(filter);
            Assert.IsNotNull(filterInverted);

            Assert.IsInstanceOf<ElementCategoryFilter>(filter);
            Assert.IsInstanceOf<ElementCategoryFilter>(filterInverted);

            Assert.False(filter.Inverted);
            Assert.True(filterInverted.Inverted);
        }

        [Test]
        public void FilterBuiltInCategories()
        {
            var values = new[] {
                BuiltInCategory.OST_Floors,
                BuiltInCategory.OST_Walls
            };

            var filter = values.Filter();
            var filterInverted = values.Filter(true);

            Assert.IsNotNull(filter);
            Assert.IsNotNull(filterInverted);

            Assert.IsInstanceOf<ElementMulticategoryFilter>(filter);
            Assert.IsInstanceOf<ElementMulticategoryFilter>(filterInverted);

            Assert.False(filter.Inverted);
            Assert.True(filterInverted.Inverted);
        }

    }
}
