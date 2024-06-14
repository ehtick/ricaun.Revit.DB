using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Lines_Tests
    {
        private static readonly XYZ[] _points = new[]
        {
            new XYZ(0, 0, 0),
            new XYZ(1, 0, 0),
            new XYZ(1, 1, 0),
            new XYZ(0, 1, 0),
            new XYZ(0, 0, 1),
            new XYZ(1, 0, 1),
            new XYZ(1, 1, 1),
            new XYZ(0, 1, 1),
        };

        [Test]
        public void CreateLines()
        {
            var lines = ShapeCreator.CreateLines(_points);
            Assert.AreEqual(_points.Length - 1, lines.Length);
        }

        [Test]
        public void CreateLines_Closed()
        {
            var lines = ShapeCreator.CreateLines(_points, true);
            Assert.AreEqual(_points.Length, lines.Length);
        }

        [Test]
        public void CreateLines_GraphicsStyleId()
        {
            var lines = ShapeCreator.CreateLines(_points, ElementIdUtils.GraphicsStyleId);

            foreach (var line in lines)
            {
                Assert.AreEqual(ElementIdUtils.GraphicsStyleId, line.GraphicsStyleId);
            }
        }
    }
}