using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;
using ricaun.Revit.DB.Shape.Extensions;
using System;
using System.Collections.Generic;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class MaterialCreate_Tests : OneTimeOpenDocumentTransactionTest
    {
        [Test]
        public void CreateMaterial()
        {
            var material = MaterialUtils.CreateMaterial(document, 0, 1, 2);
            Assert.IsNotNull(material);
        }

        [Test]
        public void CreateMaterial_WithAlpha()
        {
            var material = MaterialUtils.CreateMaterial(document, 0, 1, 2, 3);
            Assert.IsNotNull(material);
        }

        [Test]
        public void CreateMaterial_Color()
        {
            var color = new Color(3, 4, 5);
            var material = MaterialUtils.CreateMaterial(document, color);
            Assert.IsNotNull(material);
            Assert.IsTrue(material.Color.ColorEquals(color));
        }

        [Test]
        public void CreateMaterial_GetColor()
        {
            var color = new Color(3, 4, 5);
            var material = MaterialUtils.CreateMaterial(document, color);
            Assert.IsNotNull(material);
            Assert.IsTrue(MaterialUtils.GetColor(material).ColorEquals(color));
        }

        [Test]
        public void CreateMaterial_ColorWithTransparency()
        {
            var color = new ColorWithTransparency(3, 4, 5, 6);
            var material = MaterialUtils.CreateMaterial(document, color);
            Assert.IsNotNull(material);
            Assert.IsTrue(material.Color.ColorEquals(color));
        }

        [TestCase(0)]
        [TestCase(51)]
        [TestCase(102)]
        [TestCase(153)]
        [TestCase(204)]
        [TestCase(255)]
        public void CreateMaterial_GetColorWithTransparency(int transparency)
        {
            var color = new ColorWithTransparency(3, 4, 5, (uint)transparency);
            // the material transparency is converted to a int with value 0 to 100.
            var material = MaterialUtils.CreateMaterial(document, color);
            var colorWithTransparency = MaterialUtils.GetColorWithTransparency(material);
            Assert.IsNotNull(material);
            Assert.IsTrue(colorWithTransparency.ColorEquals(color), $"Transparency:{material.Transparency} => {colorWithTransparency.GetTransparency()}");
        }

        [Test]
        public void CreateMaterialColors()
        {
            var colors = new Dictionary<Color, Material>() {
                { Colors.White, MaterialUtils.CreateMaterialWhite(document)},
                { Colors.Red, MaterialUtils.CreateMaterialRed(document)},
                { Colors.Green, MaterialUtils.CreateMaterialGreen(document)},
                { Colors.Blue, MaterialUtils.CreateMaterialBlue(document)},
                { Colors.Yellow, MaterialUtils.CreateMaterialYellow(document)},
                { Colors.Cyan, MaterialUtils.CreateMaterialCyan(document)},
                { Colors.Magenta, MaterialUtils.CreateMaterialMagenta(document)},
                { Colors.Black, MaterialUtils.CreateMaterialBlack(document)},
                { Colors.Gray, MaterialUtils.CreateMaterialGray(document)},
            };

            foreach (var color in colors)
            {
                Assert.IsNotNull(color.Value);
                Assert.IsTrue(color.Value.Color.ColorEquals(color.Key));
            }
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