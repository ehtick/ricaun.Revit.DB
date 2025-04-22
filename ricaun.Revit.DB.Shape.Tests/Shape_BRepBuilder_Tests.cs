using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using ricaun.Revit.DB.Shape.Tests.Utils;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_BRepBuilder_Tests
    {
        Solid SolidBox;
        Face FaceBox;

        [SetUp]
        public void Setup()
        {
            var scale = 1.0;
            var center = XYZ.Zero;

            SolidBox = ShapeCreator.CreateBox(center, scale);
            FaceBox = SolidBox.GetFaces().FirstOrDefault();
        }

        [Test]
        public void CreateSolid()
        {
            Solid solid = SolidBox.CreateSolid();

            Assert.AreEqual(ElementId.InvalidElementId, solid.GetMaterialId());

            AssertUtils.Solid(SolidBox, solid);
        }

        [Test]
        public void CreateSolid_MaterialId()
        {
            Solid solid = SolidBox.CreateSolid(ElementIdUtils.MaterialId);

            Assert.AreEqual(ElementIdUtils.MaterialId, solid.GetMaterialId());

            foreach (var face in solid.GetFaces())
            {
                Assert.AreEqual(ElementIdUtils.MaterialId, face.MaterialElementId);
            }
        }

        [Test]
        public void CreateSolid_Face()
        {
            Solid solid = FaceBox.CreateSolid();

            Assert.AreEqual(ElementId.InvalidElementId, solid.GetMaterialId());

            AssertUtils.Face(FaceBox, solid.GetFaces().FirstOrDefault());
        }

        [Test]
        public void CreateSolid_Face_MaterialId()
        {
            Solid solid = FaceBox.CreateSolid(ElementIdUtils.MaterialId);

            Assert.AreEqual(ElementIdUtils.MaterialId, solid.GetMaterialId());

            AssertUtils.Face(FaceBox, solid.GetFaces().FirstOrDefault());
        }

        [Test]
        public void CreateOpenShell()
        {
            Solid solid = SolidBox.CreateOpenShell();

            Assert.AreEqual(ElementId.InvalidElementId, solid.GetMaterialId());

            var faces = SolidBox.GetFaces().ToList();
            var facesOpenShell = solid.GetFaces().ToList();

            Assert.AreEqual(faces.Count, facesOpenShell.Count);
            for (int i = 0; i < faces.Count; i++)
            {
                AssertUtils.Face(faces[i], facesOpenShell[i]);
            }
        }

        [Test]
        public void CreateOpenShell_MaterialId()
        {
            Solid solid = SolidBox.CreateOpenShell(ElementIdUtils.MaterialId);

            Assert.AreEqual(ElementIdUtils.MaterialId, solid.GetMaterialId());

            var faces = SolidBox.GetFaces().ToList();
            var facesOpenShell = solid.GetFaces().ToList();

            Assert.AreEqual(faces.Count, facesOpenShell.Count);
            for (int i = 0; i < faces.Count; i++)
            {
                AssertUtils.Face(faces[i], facesOpenShell[i]);
            }
        }
    }
}