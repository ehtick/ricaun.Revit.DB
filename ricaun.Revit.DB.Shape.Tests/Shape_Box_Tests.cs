using Autodesk.Revit.DB;
using NUnit.Framework;

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

            AssertBox(solid, center, scale);
        }

        [Test]
        public void CreateBox_MinMax()
        {
            var scale = 1.0;
            var min = new XYZ(-1, -1, -1) * scale;
            var max = new XYZ(1, 1, 1) * scale;
            var center = (max + min) / 2;

            Solid solid = ShapeCreator.CreateBox(min, max);

            AssertBox(solid, center, scale);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_Scale(double scale)
        {
            var center = XYZ.Zero;
            Solid solid = ShapeCreator.CreateBox(center, scale);

            AssertBox(solid, center, scale);
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

            AssertBox(solid, center, scale);
        }

        private void AssertBox(Solid solid, XYZ center, double scale = 1.0)
        {
            Assert.AreEqual(12, solid.Edges.Size);
            Assert.AreEqual(6, solid.Faces.Size);

            Assert.IsTrue(solid.ComputeCentroid().IsAlmostEqualTo(center), $"Centroid {solid.ComputeCentroid()} is not {center}");

            var volumeExpected = 2 * 2 * 2 * scale * scale * scale;
            var surfaceAreaExpected = 6 * 2 * 2 * scale * scale;
            Assert.IsTrue(solid.Volume.AlmostEqual(volumeExpected), $"Volume {solid.Volume} is not {volumeExpected}");
            Assert.IsTrue(solid.SurfaceArea.AlmostEqual(surfaceAreaExpected), $"SurfaceArea {solid.SurfaceArea} is not {surfaceAreaExpected}");
        }
    }
}