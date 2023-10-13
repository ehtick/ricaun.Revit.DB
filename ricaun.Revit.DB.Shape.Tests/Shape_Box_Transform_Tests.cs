using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using System;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Box_Transform_Tests
    {
        public double Scale { get; set; } = 1.0;
        public XYZ Center { get; set; } = XYZ.Zero;
        public Solid Solid { get; set; }
        [SetUp]
        public void Setup()
        {
            Solid = ShapeCreator.CreateBox(Center, Scale);
        }

        [Test]
        public void CreateBox_ShouldBe_Equals()
        {
            Solid other = ShapeCreator.CreateBox(Center, Scale);
            AssertBox(Solid, other);
        }

        [Test]
        public void CreateBox_ShouldBe_Equals_Transform()
        {
            Solid other = Solid.CreateTransformed(Transform.CreateRotation(XYZ.BasisZ, Math.PI));
            AssertBox(Solid, other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_Scale(double scale)
        {
            Solid other = ShapeCreator.CreateBox(Center, scale);
            AssertBox(Solid.Scale(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleCentroid(double scale)
        {
            var otherCenter = Center + XYZ.BasisX * scale;
            var transform = Transform.CreateTranslation(otherCenter);
            Solid other = ShapeCreator.CreateBox(otherCenter, scale);
            Solid solid = Solid.CreateTransformed(transform);
            AssertBox(solid.ScaleCentroid(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleLeft(double scale)
        {
            var otherCenter = Center + XYZ.BasisX * (scale - 1);
            Solid other = ShapeCreator.CreateBox(otherCenter, scale);
            AssertBox(Solid.ScaleLeft(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleRight(double scale)
        {
            var otherCenter = Center - XYZ.BasisX * (scale - 1);
            Solid other = ShapeCreator.CreateBox(otherCenter, scale);
            AssertBox(Solid.ScaleRight(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleFront(double scale)
        {
            var otherCenter = Center + XYZ.BasisY * (scale - 1);
            Solid other = ShapeCreator.CreateBox(otherCenter, scale);
            AssertBox(Solid.ScaleFront(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleBack(double scale)
        {
            var otherCenter = Center - XYZ.BasisY * (scale - 1);
            Solid other = ShapeCreator.CreateBox(otherCenter, scale);
            AssertBox(Solid.ScaleBack(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleBotton(double scale)
        {
            var otherCenter = Center + XYZ.BasisZ * (scale - 1);
            Solid other = ShapeCreator.CreateBox(otherCenter, scale);
            AssertBox(Solid.ScaleBotton(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleTop(double scale)
        {
            var otherCenter = Center - XYZ.BasisZ * (scale - 1);
            Solid other = ShapeCreator.CreateBox(otherCenter, scale);
            AssertBox(Solid.ScaleTop(scale), other);
        }

        [Test]
        public void CreateBox_ShouldBe_NotEquals_Scale()
        {
            var scaleOther = 2.0;
            Solid other = ShapeCreator.CreateBox(Center, scaleOther);
            Assert.IsFalse(Solid.AlmostEqual(other));
        }

        [Test]
        public void CreateBox_ShouldBe_NotEquals_Center()
        {
            var centerOther = XYZ.BasisX;
            Solid other = ShapeCreator.CreateBox(centerOther, Scale);
            Assert.IsFalse(Solid.AlmostEqual(other));
        }

        [Test]
        public void CreateBox_ShouldBe_NotEquals_Transform()
        {
            Solid other = Solid.CreateTransformed(Transform.CreateRotation(XYZ.BasisZ, 1));
            Assert.IsFalse(Solid.AlmostEqual(other));
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_Transformed(double scale)
        {
            Solid other = ShapeCreator.CreateBox(Center, scale);

            other = other.CreateTransformed(Transform.Identity.ScaleBasis(Scale / scale));

            AssertBox(Solid, other);
        }


        private void AssertBox(Solid solid, Solid other)
        {
            Assert.AreEqual(solid.Edges.Size, other.Edges.Size);
            Assert.AreEqual(solid.Faces.Size, other.Faces.Size);

            Assert.IsTrue(solid.Volume.AlmostEqual(other.Volume), $"Volume {solid.Volume} is not {other.Volume}");
            Assert.IsTrue(solid.SurfaceArea.AlmostEqual(other.SurfaceArea), $"SurfaceArea {solid.SurfaceArea} is not {other.SurfaceArea}");

            Assert.IsTrue(solid.GetBoundingBox().AlmostEqual(other.GetBoundingBox()), $"BoundingBox [{solid.GetBoundingBox().Min} {solid.GetBoundingBox().Max} {solid.GetBoundingBox()}] is not almost equal [{other.GetBoundingBox().Min} {other.GetBoundingBox().Max}]");

            Assert.IsTrue(solid.AlmostEqual(other), $"Solid {solid} is not almost equal {other}");
        }
    }
}