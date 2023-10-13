using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Sphere_Tests
    {
        [Test]
        public void CreateSphere()
        {
            var radius = 1.0;
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreateSphere(center, radius);

            AssertUtils.Sphere(solid, radius);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        [TestCase(9.8)]
        public void CreateSphere_Radius(double radius)
        {
            var center = XYZ.Zero;
            var solid = ShapeCreator.CreateSphere(center, radius);

            AssertUtils.Sphere(solid, radius);
        }
    }
}