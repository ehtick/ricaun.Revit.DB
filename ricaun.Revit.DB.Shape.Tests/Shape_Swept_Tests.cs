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
            var solid = ShapeCreator.CreateSwept(Line.CreateBound(center, 2 * radius * XYZ.BasisZ), radius);

            Assert.IsNotNull(solid, "Solid should not be null");

            Assert.Ignore("This test is ignored, missing implementation.");
        }
    }
}