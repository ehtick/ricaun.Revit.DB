using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Prism_Tests
    {
        public int Sides { get; set; } = ShapeCreator.Sides;
        [Test]
        public void CreatePrism()
        {
            var radius = 1.0;
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreatePrism(center, radius);

            AssertUtils.Prism(solid, Sides, radius);
        }

        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(8)]
        [TestCase(12)]
        [TestCase(24)]
        [TestCase(32)]
        [TestCase(64)]
        public void CreatePrism_Sides(int sides)
        {
            var radius = 1.0;
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreatePrism(sides, center, radius);

            AssertUtils.Prism(solid, sides, radius);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        [TestCase(9.8)]
        public void CreatePrism_Radius(double radius)
        {
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreatePrism(center, radius);

            AssertUtils.Prism(solid, Sides, radius);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        [TestCase(9.8)]
        public void CreatePrism_Height(double height)
        {
            var radius = 1.0;
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreatePrism(center, radius, height);

            AssertUtils.Prism(solid, Sides, radius, height);
        }

        [TestCase(1.0, 1.0)]
        [TestCase(2.0, 1.0)]
        [TestCase(3.0, 1.0)]
        [TestCase(4.2, 1.0)]
        [TestCase(9.8, 1.0)]
        public void CreatePrism_RadiusHeight(double radius, double height)
        {
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreatePrism(center, radius, height);

            AssertUtils.Prism(solid, Sides, radius, height);
        }
    }
}