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
        public void CreateMesh_Vertices_ShouldBe_CreateBox()
        {
            var shape = ShapeCreator.CreateBox(XYZ.Zero, 1);
            var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                shape.GetVertices().ToArray(),
                shape.GetIndexes().ToArray());
            var solids = tessellatedShape.OfType<Solid>();
            Assert.AreEqual(1, solids.Count());

            var solid = solids.FirstOrDefault();
            AssertUtils.Solid(solid, shape);
        }


        [Test]
        public void CreateMesh_TriangleVertices_ShouldBe_CreateBox()
        {
            var shape = ShapeCreator.CreateBox(XYZ.Zero, 1);
            var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                shape.GetTriangleVertices().ToArray());
            var solids = tessellatedShape.OfType<Solid>();
            Assert.AreEqual(1, solids.Count());

            var solid = solids.FirstOrDefault();
            AssertUtils.Solid(solid, shape);
        }


        [Test]
        public void CreateMesh_TriangleVertices_ShouldBe_CreateSphere()
        {
            var shape = ShapeCreator.CreateSphere(XYZ.Zero, 10);
            var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                shape.GetTriangleVertices().ToArray());
            var meshs = tessellatedShape.OfType<Mesh>();
            Assert.AreEqual(1, meshs.Count());

            var mesh = meshs.FirstOrDefault();
            System.Console.WriteLine(mesh.GetTriangleVertices().Count);
            var solid = TessellatedShapeCreator.CreateMesh(mesh.GetTriangleVertices().ToArray())
                .OfType<Solid>()
                .FirstOrDefault();
            System.Console.WriteLine(solid.GetTriangleVertices().Count);
        }
    }
}