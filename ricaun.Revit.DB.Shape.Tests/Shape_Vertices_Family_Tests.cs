using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using ricaun.Revit.DB.Shape.Tests.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Vertices_Family_Tests : OneTimeOpenDocumentLoadFamilyTest
    {
        protected override string FamilyName => @"Family\Box2021.rfa";

        [Test]
        public void Shape_Family()
        {
            Assert.IsNotNull(FamilyInstance);
            System.Console.WriteLine(FamilyInstance?.Name);
        }

        [TestCase(32, 60)]
        public void Shape_Vertices_Family(int verticesCount, int indicesCount)
        {
            var solid = FamilyInstanceSolid();

            var vertices = solid.GetVertices();
            var indices = solid.GetIndices();

            Assert.AreEqual(verticesCount, vertices.Count());
            Assert.AreEqual(indicesCount, indices.Count());
        }

        [TestCase(6)]
        public void Shape_Face_Family(int faceCount)
        {
            var solid = FamilyInstanceSolid();

            var faces = solid.GetFaces(); // Box 6 faces

            Assert.AreEqual(faceCount, faces.Count());
        }

        [TestCase(7)]
        public void Shape_FacesRegions_Family(int faceCount)
        {
            var solid = FamilyInstanceSolid();

            var faces = solid.GetFacesRegions(); // Box 6 faces + 1 region

            Assert.AreEqual(faceCount, faces.Count());
        }
    }
}