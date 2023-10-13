using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using ricaun.Revit.DB.Shape.Tests.Utils;
using System;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Box_Transform_Tests
    {
        public double Scale => 1.0;
        public XYZ Center => XYZ.Zero;
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
            AssertUtils.Solid(Solid, other);
        }

        [Test]
        public void CreateBox_ShouldBe_Equals_Transform()
        {
            Solid other = Solid.CreateTransformed(Transform.CreateRotation(XYZ.BasisZ, Math.PI));
            AssertUtils.Solid(Solid, other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_Scale(double scale)
        {
            Solid other = ShapeCreator.CreateBox(Center, scale);
            AssertUtils.Solid(Solid.Scale(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleOrigin(double scale)
        {
            Solid other = ShapeCreator.CreateBox(Center, scale);
            AssertUtils.Solid(Solid.Scale(scale, Center), other);
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
            AssertUtils.Solid(solid.ScaleCentroid(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleLeft(double scale)
        {
            var otherCenter = Center + XYZ.BasisX * (scale - 1);
            Solid other = ShapeCreator.CreateBox(otherCenter, scale);
            AssertUtils.Solid(Solid.ScaleLeft(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleRight(double scale)
        {
            var otherCenter = Center - XYZ.BasisX * (scale - 1);
            Solid other = ShapeCreator.CreateBox(otherCenter, scale);
            AssertUtils.Solid(Solid.ScaleRight(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleFront(double scale)
        {
            var otherCenter = Center + XYZ.BasisY * (scale - 1);
            Solid other = ShapeCreator.CreateBox(otherCenter, scale);
            AssertUtils.Solid(Solid.ScaleFront(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleBack(double scale)
        {
            var otherCenter = Center - XYZ.BasisY * (scale - 1);
            Solid other = ShapeCreator.CreateBox(otherCenter, scale);
            AssertUtils.Solid(Solid.ScaleBack(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleBotton(double scale)
        {
            var otherCenter = Center + XYZ.BasisZ * (scale - 1);
            Solid other = ShapeCreator.CreateBox(otherCenter, scale);
            AssertUtils.Solid(Solid.ScaleBotton(scale), other);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        public void CreateBox_ShouldBe_Equals_ScaleTop(double scale)
        {
            var otherCenter = Center - XYZ.BasisZ * (scale - 1);
            Solid other = ShapeCreator.CreateBox(otherCenter, scale);
            AssertUtils.Solid(Solid.ScaleTop(scale), other);
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

            AssertUtils.Solid(Solid, other);
        }
    }
}