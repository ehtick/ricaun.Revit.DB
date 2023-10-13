using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Cylinder_Tests
    {
        [Test]
        public void CreateCylinder()
        {
            var radius = 1.0;
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreateCylinder(center, radius);

            AssertUtils.Cylinder(solid, radius);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        [TestCase(9.8)]
        public void CreateCylinder_Radius(double radius)
        {
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreateCylinder(center, radius);

            AssertUtils.Cylinder(solid, radius);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        [TestCase(9.8)]
        public void CreateCylinder_Height(double height)
        {
            var radius = 1.0;
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreateCylinder(center, radius, height);

            AssertUtils.Cylinder(solid, radius, height);
        }

        [TestCase(1.0, 1.0)]
        [TestCase(2.0, 1.0)]
        [TestCase(3.0, 1.0)]
        [TestCase(4.2, 1.0)]
        [TestCase(9.8, 1.0)]
        public void CreateCylinder_RadiusHeight(double radius, double height)
        {
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreateCylinder(center, radius, height);

            AssertUtils.Cylinder(solid, radius, height);
        }
    }
}