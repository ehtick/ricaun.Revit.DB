using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using ricaun.Revit.DB.Shape.Tests.Utils;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Vertices_Tests
    {
        [Test]
        public void CreateBox_Vertices()
        {
            Solid solid = ShapeCreator.CreateBox(XYZ.Zero, 1);
            var vertices = solid.GetVertices();
            var indexes = solid.GetIndexes();
            Assert.AreEqual(24, vertices.Count);
            Assert.AreEqual(36, indexes.Count);

            var triangleVertices = solid.GetTriangleVertices();
            Assert.AreEqual(indexes.Count, triangleVertices.Count);
        }

        [Test]
        public void CreateMesh_Vertices()
        {
            var shape = ShapeCreator.CreateBox(XYZ.Zero, 1);
            var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                shape.GetVertices().ToArray(),
                shape.GetIndexes().ToArray());
            var solids = tessellatedShape.OfType<Solid>();
            Assert.AreEqual(1, solids.Count());

            var solid = solids.FirstOrDefault();
            //AssertUtils.Solid(solid, shape);
            Assert.IsTrue(solid.Volume.AlmostEqual(shape.Volume));
            Assert.IsTrue(solid.SurfaceArea.AlmostEqual(shape.SurfaceArea));
        }


        [Test]
        public void CreateMesh_TriangleVertices()
        {
            var shape = ShapeCreator.CreateBox(XYZ.Zero, 1);
            var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                shape.GetTriangleVertices().ToArray());
            var solids = tessellatedShape.OfType<Solid>();
            Assert.AreEqual(1, solids.Count());

            var solid = solids.FirstOrDefault();
            //AssertUtils.Solid(solid, shape);
            Assert.IsTrue(solid.Volume.AlmostEqual(shape.Volume));
            Assert.IsTrue(solid.SurfaceArea.AlmostEqual(shape.SurfaceArea));
        }
    }
}