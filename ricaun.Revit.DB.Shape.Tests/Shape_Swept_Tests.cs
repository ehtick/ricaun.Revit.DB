using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Swept_Tests
    {
        [Test]
        public void CreateSwept()
        {
            var radius = 1.0;
            var center = XYZ.Zero;
            var line = Line.CreateBound(center, 2 * radius * XYZ.BasisZ);
            var solid = ShapeCreator.CreateSwept(line, radius);

            Assert.IsNotNull(solid, "Solid should not be null");

            AssertUtils.Solid(solid, 6, 4);
        }

        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        public void CreateSweptSide(int sides)
        {
            var radius = 1.0;
            var center = XYZ.Zero;
            var line = Line.CreateBound(center, 2 * radius * XYZ.BasisZ);
            var loop = CurveLoopUtils.CreatePrismLoop(line, radius, sides);
            var solid = ShapeCreator.CreateSwept(line, loop);

            Assert.IsNotNull(solid, "Solid should not be null");

            AssertUtils.Solid(solid, 3 * sides, 2 + sides);
        }
    }
}