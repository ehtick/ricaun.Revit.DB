using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Box_Tests
    {
        [Test]
        public void CreateBox()
        {
            var scale = 1.0;
            var center = XYZ.Zero;

            Solid solid = ShapeCreator.CreateBox(center, scale);

            AssertUtils.Box(solid, center, scale);
        }

        [Test]
        public void CreateBox_MinMax()
        {
            var scale = 1.0;
            var min = new XYZ(-1, -1, -1) * scale;
            var max = new XYZ(1, 1, 1) * scale;
            var center = (max + min) / 2;

            Solid solid = ShapeCreator.CreateBox(min, max);

            AssertUtils.Box(solid, center, scale);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_Scale(double scale)
        {
            var center = XYZ.Zero;
            Solid solid = ShapeCreator.CreateBox(center, scale);

            AssertUtils.Box(solid, center, scale);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_MinMax_Scale(double scale)
        {
            var min = new XYZ(-1, -1, -1) * scale;
            var max = new XYZ(1, 1, 1) * scale;
            var center = (max + min) / 2;

            Solid solid = ShapeCreator.CreateBox(min, max);

            AssertUtils.Box(solid, center, scale);
        }
    }
}