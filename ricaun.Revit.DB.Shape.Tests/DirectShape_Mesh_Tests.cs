using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using ricaun.Revit.DB.Shape.Tests.Utils;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class TessellatedShapeCreator_Tests : OneTimeOpenDocumentTransactionTest
    {
        private void SolidBuilder(TessellatedShapeBuilder builder)
        {
            var vertices = new List<XYZ>();
            vertices.Add(new XYZ(0, 0, 0));
            vertices.Add(new XYZ(1, 0, 0));
            vertices.Add(new XYZ(0, 1, 0));
            builder.AddFace(new TessellatedFace(vertices, ElementId.InvalidElementId));
        }

        [Test]
        public void CreateTessellated_Solid()
        {
            var tessellatedShape = TessellatedShapeCreator.Create(SolidBuilder);
            var solids = tessellatedShape.OfType<Solid>();
            Assert.AreEqual(1, solids.Count());
        }

        private void MeshBuilder(TessellatedShapeBuilder builder)
        {
            var vertices = new List<XYZ>();
            vertices.Add(new XYZ(0, 0, 0));
            vertices.Add(new XYZ(1, 0, 0));
            vertices.Add(new XYZ(0, 1, 0));
            builder.AddFace(new TessellatedFace(vertices, ElementId.InvalidElementId));
            builder.AddFace(new TessellatedFace(vertices, ElementId.InvalidElementId));
        }

        [Test]
        public void CreateTessellated_Mesh()
        {
            var tessellatedShape = TessellatedShapeCreator.Create(MeshBuilder);
            var meshs = tessellatedShape.OfType<Mesh>();
            Assert.AreEqual(1, meshs.Count());
        }

        [Test]
        public void CreateTessellated_Mesh_Tranformed()
        {
            var tessellatedShape = TessellatedShapeCreator.Create(MeshBuilder);
            var mesh = tessellatedShape.OfType<Mesh>().FirstOrDefault();
            Assert.IsNotNull(mesh);
            mesh = mesh.CreateTransformed(Transform.CreateTranslation(new XYZ(1, 1, 1)));
            Assert.IsNotNull(mesh);
        }

        [Test]
        public void CreateTessellated_Should_Fail()
        {
            Assert.Throws<Autodesk.Revit.Exceptions.InvalidOperationException>(() =>
                TessellatedShapeCreator.Create((builder) => { })
                );
        }

        XYZ[] verticesCube = new[] { new XYZ(0.25, -0.25, 0.25), new XYZ(0.25, 0.25, 0.25), new XYZ(-0.25, 0.25, 0.25), new XYZ(-0.25, -0.25, 0.25), new XYZ(-0.25, 0.25, -0.25), new XYZ(0.25, 0.25, -0.25), new XYZ(0.25, -0.25, -0.25), new XYZ(-0.25, -0.25, -0.25), new XYZ(-0.25, -0.25, 0.25), new XYZ(-0.25, -0.25, -0.25), new XYZ(0.25, -0.25, -0.25), new XYZ(0.25, -0.25, 0.25), new XYZ(0.25, -0.25, 0.25), new XYZ(0.25, -0.25, -0.25), new XYZ(0.25, 0.25, -0.25), new XYZ(0.25, 0.25, 0.25), new XYZ(0.25, 0.25, 0.25), new XYZ(0.25, 0.25, -0.25), new XYZ(-0.25, 0.25, -0.25), new XYZ(-0.25, 0.25, 0.25), new XYZ(-0.25, 0.25, 0.25), new XYZ(-0.25, 0.25, -0.25), new XYZ(-0.25, -0.25, -0.25), new XYZ(-0.25, -0.25, 0.25) };
        int[] indexesCube = new[] { 0, 1, 2, 2, 3, 0, 4, 5, 6, 6, 7, 4, 8, 9, 10, 10, 11, 8, 12, 13, 14, 14, 15, 12, 16, 17, 18, 18, 19, 16, 20, 21, 22, 22, 23, 20 };

        [Test]
        public void CreateMesh_Cube()
        {
            var tessellatedShape = TessellatedShapeCreator.CreateMesh(verticesCube, indexesCube);
            var solids = tessellatedShape.OfType<Solid>();
            Assert.AreEqual(1, solids.Count());
        }

        [Test]
        public void CreateMesh_Cube_Material()
        {
            var material = MaterialUtils.CreateMaterialWhite(document);
            var materialIds = new[] { material.Id };
            var tessellatedShape = TessellatedShapeCreator.CreateMesh(verticesCube, indexesCube, materialIds);
            var solid = tessellatedShape.OfType<Solid>().FirstOrDefault();
            Assert.IsNotNull(solid);
            AssertUtils.Material(solid, materialIds, ElementId.InvalidElementId);
        }

        [Test]
        public void CreateMesh_Cube_Material_GraphicsStyle()
        {
            var graphicsStyle = GraphicsStyleUtils.CreateLineColorWhite(document);
            var material = MaterialUtils.CreateMaterialWhite(document);
            var materialIds = new[] { material.Id };
            var tessellatedShape = TessellatedShapeCreator.CreateMesh(verticesCube, indexesCube, materialIds, graphicsStyle.Id);
            var solid = tessellatedShape.OfType<Solid>().FirstOrDefault();
            Assert.IsNotNull(solid);
            AssertUtils.Material(solid, materialIds, graphicsStyle.Id);
        }

        [Test]
        public void CreateMesh_Cube_CreateDirectShape()
        {
            var tessellatedShape = TessellatedShapeCreator.CreateMesh(verticesCube, indexesCube);
            var solids = tessellatedShape.OfType<Solid>();
            var directShape = document.CreateDirectShape(solids);
            AssertUtils.Geometry<Solid>(directShape, 1);
        }
    }
}