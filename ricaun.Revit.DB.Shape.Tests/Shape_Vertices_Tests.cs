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
            var indices = solid.GetIndices();
            Assert.AreEqual(24, vertices.Count);
            Assert.AreEqual(36, indices.Count);

            var triangleVertices = solid.GetTriangleVertices();
            Assert.AreEqual(indices.Count, triangleVertices.Count);
        }

        [Test]
        public void CreateMesh_Vertices_ShouldBe_CreateBox()
        {
            var shape = ShapeCreator.CreateBox(XYZ.Zero, 1);
            var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                shape.GetVertices().ToArray(),
                shape.GetIndices().ToArray());
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
        public void CreateMesh_TriangleVertices_ShouldBe_Two_CreateBox()
        {
            var shape1 = ShapeCreator.CreateBox(XYZ.Zero, 1);
            var shape2 = ShapeCreator.CreateBox(XYZ.Zero, 1)
                .CreateTransformed(Transform.CreateTranslation(10 * XYZ.BasisX));

            var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                shape1.GetTriangleVertices().Concat(shape2.GetTriangleVertices()).ToArray());
            var solids = tessellatedShape.OfType<Solid>();
            Assert.AreEqual(1, solids.Count());

            var solid = solids.FirstOrDefault();
            Assert.AreEqual(shape1.Faces.Size + shape2.Faces.Size, solid.Faces.Size);
            Assert.AreEqual(shape1.Edges.Size + shape2.Edges.Size, solid.Edges.Size);
            Assert.IsTrue(solid.Volume.AlmostEqual(shape1.Volume + shape2.Volume));
            Assert.IsTrue(solid.SurfaceArea.AlmostEqual(shape1.SurfaceArea + shape2.SurfaceArea));

            var splitVolumes = SolidUtils.SplitVolumes(solid);
            Assert.AreEqual(2, splitVolumes.Count());
            var solid1 = splitVolumes.FirstOrDefault();
            var solid2 = splitVolumes.LastOrDefault();

            AssertUtils.Solid(solid1, shape1);
            AssertUtils.Solid(solid2, shape2);
        }


        [Test]
        public void CreateMesh_TriangleVertices_ShouldBe_CreateSphere()
        {
            var shape = ShapeCreator.CreateSphere(XYZ.Zero, 1);

            var mesh1 = TessellatedShapeCreator.CreateMesh(shape.GetTriangleVertices().ToArray())
                .OfType<Mesh>().FirstOrDefault();
            var mesh2 = TessellatedShapeCreator.CreateMesh(shape.GetVertices().ToArray(), shape.GetIndices().ToArray())
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
            var solid2 = TessellatedShapeCreator.CreateMesh(shape.GetVertices().ToArray(), shape.GetIndices().ToArray())
                .OfType<Solid>().FirstOrDefault();

            Assert.IsNotNull(solid1);
            Assert.IsNotNull(solid2);

            AssertUtils.Solid(solid1, solid2);
        }

        [TestCase(0.0)]
        [TestCase(0.3)]
        [TestCase(0.4)]
        [TestCase(0.5)]
        [TestCase(1.0)]
        public void CreateMesh_TriangleVerticesWithDetail_ShouldBe_CreateSphere(double levelOfDetail)
        {
            var shape = ShapeCreator.CreateSphere(XYZ.Zero, 1);

            var triangleVertices = shape.GetTriangleVertices(levelOfDetail).ToArray();

            System.Console.WriteLine($"TriangleVertices: {triangleVertices.Length}");

            var mesh1 = TessellatedShapeCreator.CreateMesh(triangleVertices)
                .OfType<Mesh>().FirstOrDefault();
            var mesh2 = TessellatedShapeCreator.CreateMesh(shape.GetVertices(levelOfDetail).ToArray(), shape.GetIndices(levelOfDetail).ToArray())
                .OfType<Mesh>().FirstOrDefault();

            Assert.IsNotNull(mesh1);
            Assert.IsNotNull(mesh2);

            AssertUtils.Mesh(mesh1, mesh2);
        }
    }
}