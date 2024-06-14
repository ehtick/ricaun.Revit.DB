using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_BoxLine_Tests
    {
        [Test]
        public void CreateBoxLines()
        {
            var scale = 1.0;
            var center = XYZ.Zero;

            var lines = ShapeCreator.CreateBoxLines(center, scale);
            Assert.AreEqual(12, lines.Length);
        }

        [Test]
        public void CreateBoxLines_GraphicsStyleId()
        {
            var scale = 1.0;
            var center = XYZ.Zero;

            var lines = ShapeCreator.CreateBoxLines(center, scale, ElementIdUtils.GraphicsStyleId);

            foreach (var line in lines)
            {
                Assert.AreEqual(ElementIdUtils.GraphicsStyleId, line.GraphicsStyleId);
            }
        }

        [Test]
        public void CreateBoxLines_MinMax()
        {
            var min = new XYZ(-1, -1, -1);
            var max = new XYZ(1, 1, 1);

            var lines = ShapeCreator.CreateBoxLines(min, max);
            Assert.AreEqual(12, lines.Length);
        }

        [Test]
        public void CreateBoxLines_MinMax_ShouldBe_Eight()
        {
            var min = new XYZ(-1, -1, 0);
            var max = new XYZ(1, 1, 0);

            var lines = ShapeCreator.CreateBoxLines(min, max);
            Assert.AreEqual(8, lines.Length);
        }

        [Test]
        public void CreateBoxLines_MinMax_ShouldBe_Four()
        {
            var min = new XYZ(-1, 0, 0);
            var max = new XYZ(1, 0, 0);

            var lines = ShapeCreator.CreateBoxLines(min, max);
            Assert.AreEqual(4, lines.Length);
        }

        [Test]
        public void CreateBoxLines_MinMax_ShouldBe_Zero()
        {
            var min = new XYZ(0, 0, 0);
            var max = new XYZ(0, 0, 0);

            var lines = ShapeCreator.CreateBoxLines(min, max);
            Assert.AreEqual(0, lines.Length);
        }
    }
}