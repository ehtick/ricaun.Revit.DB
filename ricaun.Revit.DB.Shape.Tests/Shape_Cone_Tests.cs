using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Cone_Tests
    {
        [Test]
        public void CreateCone()
        {
            var radius = 1.0;
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreateCone(center, radius);

            AssertUtils.Cone(solid, radius);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        [TestCase(9.8)]
        public void CreateCone_Radius(double radius)
        {
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreateCone(center, radius);

            AssertUtils.Cone(solid, radius);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        [TestCase(9.8)]
        public void CreateCone_Height(double height)
        {
            var radius = 1.0;
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreateCone(center, radius, height);

            AssertUtils.Cone(solid, radius, height);
        }

        [TestCase(1.0, 1.0)]
        [TestCase(2.0, 1.0)]
        [TestCase(3.0, 1.0)]
        [TestCase(4.2, 1.0)]
        [TestCase(9.8, 1.0)]
        public void CreateCone_RadiusHeight(double radius, double height)
        {
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreateCone(center, radius, height);

            AssertUtils.Cone(solid, radius, height);
        }
    }
}