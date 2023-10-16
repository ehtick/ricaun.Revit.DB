using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using ricaun.Revit.DB.Shape.Tests.Utils;
using System.Collections.Generic;
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
            var shape = ShapeCreator.CreateSphere(XYZ.Zero, 1);

            var mesh1 = TessellatedShapeCreator.CreateMesh(shape.GetTriangleVertices().ToArray())
                .OfType<Mesh>().FirstOrDefault();
            var mesh2 = TessellatedShapeCreator.CreateMesh(shape.GetVertices().ToArray(), shape.GetIndexes().ToArray())
                .OfType<Mesh>().FirstOrDefault();

            Assert.IsNotNull(mesh1);
            Assert.IsNotNull(mesh2);

            AssertUtils.Mesh(mesh1, mesh2);
        }

        [Test]
        public void CreateMesh_TriangleVertices_ShouldBe_CreateCylinder()
        {
            var shape = ShapeCreator.CreateCylinder(XYZ.Zero, 1);

            var solid1 = TessellatedShapeCreator.CreateMesh(shape.GetTriangleVertices().ToArray())
                .OfType<Solid>().FirstOrDefault();
            var solid2 = TessellatedShapeCreator.CreateMesh(shape.GetVertices().ToArray(), shape.GetIndexes().ToArray())
                .OfType<Solid>().FirstOrDefault();

            Assert.IsNotNull(solid1);
            Assert.IsNotNull(solid2);

            AssertUtils.Solid(solid1, solid2);
        }
    }
}