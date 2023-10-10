using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class MaterialCreate_Tests : Utils.OneTimeOpenDocumentTest
    {
        #region Transaction
        Transaction transaction;
        [SetUp]
        public void Setup()
        {
            transaction?.Dispose();
            transaction = new Transaction(document);
            transaction.Start("MaterialCreate_Tests");
        }
        [TearDown]
        public void TearDown()
        {
            transaction.Commit();
            transaction.Dispose();
            transaction = null;
        }
        #endregion

        [Test]
        public void CreateMaterialWhite()
        {
            var material = MaterialUtils.CreateMaterialWhite(document);
            Assert.IsNotNull(material);
        }

        [Test]
        public void CreateMaterialRed()
        {
            var material = MaterialUtils.CreateMaterialRed(document);
            Assert.IsNotNull(material);
        }

        [Test]
        public void CreateMaterialGreen()
        {
            var material = MaterialUtils.CreateMaterialGreen(document);
            Assert.IsNotNull(material);
        }

        [Test]
        public void CreateMaterialBlue()
        {
            var material = MaterialUtils.CreateMaterialBlue(document);
            Assert.IsNotNull(material);
        }

        [Test]
        public void CreateMaterial_Index()
        {
            for (int i = 0; i < 256; i++)
            {
                var color = Colors.Index.Get((byte)i);
                var material = MaterialUtils.CreateMaterial(document, color);
                Assert.IsNotNull(material);

                var materialFindByName = MaterialUtils.CreateMaterial(document, color);
                Assert.AreEqual(material.Id, materialFindByName.Id);
            }
        }

        [Test]
        public void FindMaterial_ByName()
        {
            var color = new Color(1, 2, 3);
            MaterialUtils.CreateMaterial(document, color);
            var materialName = MaterialUtils.MaterialColorName(color);
            var material = MaterialUtils.FindMaterial(document, materialName);
            Assert.IsNotNull(material);
        }

        [Test]
        public void FindMaterial_ByColor()
        {
            var color = new Color(1, 2, 3);
            MaterialUtils.CreateMaterial(document, color);
            var material = MaterialUtils.FindMaterial(document, color);
            Assert.IsNotNull(material);
            Assert.AreEqual(material.Name, MaterialUtils.MaterialColorName(color));
        }

        [Test]
        public void FindMaterial_ByColorWithTransparency()
        {
            var colorWithTransparency = new ColorWithTransparency(1, 2, 3, 4);
            MaterialUtils.CreateMaterial(document, colorWithTransparency);
            var material = MaterialUtils.FindMaterial(document, colorWithTransparency);
            Assert.IsNotNull(material);
            Assert.AreEqual(material.Name, MaterialUtils.MaterialColorName(colorWithTransparency));
        }
    }
}