using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Arrow_Tests
    {
        [Test]
        public void CreateArrow()
        {
            var solid = ShapeCreator.CreateArrow();

            var volume = 0.0000629;
            var surface = 0.0151090;
            AssertUtils.Solid(solid, 14, 8, volume, surface, 1e-6);
        }
    }
}