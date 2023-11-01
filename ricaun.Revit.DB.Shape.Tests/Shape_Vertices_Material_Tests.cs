using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using ricaun.Revit.DB.Shape.Tests.Utils;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Vertices_Material_Tests : OneTimeOpenDocumentTransactionTest
    {
        [Test]
        public void CreateBox_Material_Full()
        {
            var shape = ShapeCreator.CreateBox(XYZ.Zero, 1);

            var materialWhite = MaterialUtils.CreateMaterialWhite(document);

            var materialIds = new ElementId[] { materialWhite.Id };

            var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                    shape.GetTriangleVertices().ToArray(),
                    materialIds: materialIds);

            var solid = tessellatedShape.OfType<Solid>().FirstOrDefault();

            Assert.IsNotNull(solid);
            Assert.AreEqual(solid.GetMaterialId(), materialWhite.Id);
        }

        [Test]
        public void CreateBox_Material_IsEmpty()
        {
            var shape = ShapeCreator.CreateBox(XYZ.Zero, 1);

            var materialIds = new ElementId[] { };

            var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                    shape.GetTriangleVertices().ToArray(),
                    materialIds: materialIds);

            var solid = tessellatedShape.OfType<Solid>().FirstOrDefault();

            Assert.IsNotNull(solid);
            Assert.AreEqual(solid.GetMaterialId(), ElementId.InvalidElementId);
        }

        [Test]
        public void CreateBox_Material_Triangles()
        {
            var shape = ShapeCreator.CreateBox(XYZ.Zero, 1);

            var materialWhite = MaterialUtils.CreateMaterialWhite(document);
            var materialBlue = MaterialUtils.CreateMaterialBlue(document);

            var materialIds = new ElementId[] { materialWhite.Id, materialBlue.Id };

            var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                    shape.GetTriangleVertices().ToArray(),
                    materialIds: materialIds);

            var solid = tessellatedShape.OfType<Solid>().FirstOrDefault();

            Assert.IsNotNull(solid);
            Assert.AreEqual(solid.GetMaterialId(), materialWhite.Id);

            var trianglesMaterialIds = solid.GetTriangleMaterialIds();

            for (int i = 0; i < trianglesMaterialIds.Count(); i++)
            {
                Assert.AreEqual(materialIds[i % materialIds.Count()], trianglesMaterialIds[i]);
            }
        }

        [Test]
        public void CreateBox_Material_EachTriangles()
        {
            var shape = ShapeCreator.CreateBox(XYZ.Zero, 1);

            var materialRed = MaterialUtils.CreateMaterialRed(document);
            var materialGreen = MaterialUtils.CreateMaterialGreen(document);
            var materialBlue = MaterialUtils.CreateMaterialBlue(document);

            var materialIds = new ElementId[] {
                    materialRed.Id, materialRed.Id, materialRed.Id, materialRed.Id,
                    materialBlue.Id, materialBlue.Id, materialGreen.Id, materialGreen.Id,
                    materialBlue.Id, materialBlue.Id, materialGreen.Id, materialGreen.Id };

            var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                    shape.GetTriangleVertices().ToArray(),
                    materialIds: materialIds);

            var solid = tessellatedShape.OfType<Solid>().FirstOrDefault();

            Assert.IsNotNull(solid);

            var trianglesMaterialIds = solid.GetTriangleMaterialIds();

            Assert.AreEqual(materialIds.Count(), trianglesMaterialIds.Count());

            for (int i = 0; i < trianglesMaterialIds.Count(); i++)
            {
                Assert.AreEqual(materialIds[i], trianglesMaterialIds[i]);
            }
        }

        [TestCase(0.0)]
        [TestCase(0.3)]
        [TestCase(0.4)]
        [TestCase(0.5)]
        [TestCase(1.0)]
        public void CreateSphere_Material_Triangles(double levelOfDetail)
        {
            var shape = ShapeCreator.CreateSphere(XYZ.Zero, 1);

            var materialWhite = MaterialUtils.CreateMaterialWhite(document);
            var materialBlue = MaterialUtils.CreateMaterialBlue(document);

            var materialIds = new ElementId[] { materialWhite.Id };

            var tessellatedShape = TessellatedShapeCreator.CreateMesh(
                    shape.GetTriangleVertices(levelOfDetail).ToArray(),
                    materialIds: materialIds);

            var mesh = tessellatedShape.OfType<Mesh>().FirstOrDefault();

            Assert.IsNotNull(mesh);

            // Mesh only have one material
            var materialIndex = 0;
            var trianglesMaterialIds = mesh.GetTriangleMaterialIds();

            Assert.AreEqual(mesh.GetMaterialId(), materialIds[materialIndex]);
            for (int i = 0; i < trianglesMaterialIds.Count(); i++)
            {
                Assert.AreEqual(materialIds[materialIndex], trianglesMaterialIds[i]);
            }
        }
    }
}