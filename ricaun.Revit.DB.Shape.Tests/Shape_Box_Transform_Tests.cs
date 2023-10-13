using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using System;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Box_Transform_Tests
    {
        [Test]
        public void CreateBox_ShouldBe_Equals()
        {
            var scale = 1.0;
            var center = XYZ.Zero;
            Solid solid = ShapeCreator.CreateBox(center, scale);
            Solid other = ShapeCreator.CreateBox(center, scale);
            AssertBox(solid, other);
        }

        [Test]
        public void CreateBox_ShouldBe_Equals_Transform()
        {
            var scale = 1.0;
            var center = XYZ.Zero;
            Solid solid = ShapeCreator.CreateBox(center, scale);
            Solid other = solid.CreateTransformed(Transform.CreateRotation(XYZ.BasisZ, Math.PI));
            AssertBox(solid, other);
        }

        [Test]
        public void CreateBox_ShouldBe_NotEquals_Scale()
        {
            var scale = 1.0;
            var scaleOther = 2.0;
            var center = XYZ.Zero;
            Solid solid = ShapeCreator.CreateBox(center, scale);
            Solid other = ShapeCreator.CreateBox(center, scaleOther);
            Assert.IsFalse(solid.AlmostEqual(other));
        }

        [Test]
        public void CreateBox_ShouldBe_NotEquals_Center()
        {
            var scale = 1.0;
            var center = XYZ.Zero;
            var centerOther = XYZ.BasisX;
            Solid solid = ShapeCreator.CreateBox(center, scale);
            Solid other = ShapeCreator.CreateBox(centerOther, scale);
            Assert.IsFalse(solid.AlmostEqual(other));
        }

        [Test]
        public void CreateBox_ShouldBe_NotEquals_Transform()
        {
            var scale = 1.0;
            var center = XYZ.Zero;
            Solid solid = ShapeCreator.CreateBox(center, scale);
            Solid other = solid.CreateTransformed(Transform.CreateRotation(XYZ.BasisZ, 1));
            Assert.IsFalse(solid.AlmostEqual(other));
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_Transformed(double scale)
        {
            var scaleOther = 1.0;
            var center = XYZ.Zero;
            Solid solid = ShapeCreator.CreateBox(center, scale);
            Solid other = ShapeCreator.CreateBox(center, scaleOther);

            other = other.CreateTransformed(Transform.Identity.ScaleBasis(scale / scaleOther));

            AssertBox(solid, other);
        }


        private void AssertBox(Solid solid, Solid other)
        {
            Assert.AreEqual(solid.Edges.Size, other.Edges.Size);
            Assert.AreEqual(solid.Faces.Size, other.Faces.Size);

            Assert.IsTrue(solid.Volume.AlmostEqual(other.Volume), $"Volume {solid.Volume} is not {other.Volume}");
            Assert.IsTrue(solid.SurfaceArea.AlmostEqual(other.SurfaceArea), $"SurfaceArea {solid.SurfaceArea} is not {other.SurfaceArea}");

            Assert.IsTrue(solid.GetBoundingBox().AlmostEqual(other.GetBoundingBox()), $"BoundingBox {solid.GetBoundingBox()} is not almost equal {other.GetBoundingBox()}");

            Assert.IsTrue(solid.AlmostEqual(other), $"Solid {solid} is not almost equal {other}");
        }
    }
}