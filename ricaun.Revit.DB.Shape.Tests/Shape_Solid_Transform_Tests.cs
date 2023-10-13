using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using ricaun.Revit.DB.Shape.Tests.Utils;
using System;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Solid_Transform_Tests
    {
        public Solid Solid1 { get; set; }
        public Solid Solid2 { get; set; }
        public Solid Solid12 { get; set; }
        [SetUp]
        public void Setup()
        {
            Solid1 = ShapeCreator.CreateBox(-XYZ.BasisX, 1);
            Solid2 = ShapeCreator.CreateBox(XYZ.BasisX, 1);
            var min = new XYZ(-2, -1, -1);
            var max = new XYZ(2, 1, 1);
            Solid12 = ShapeCreator.CreateBox(min, max);
        }

        [Test]
        public void Solid_Union()
        {
            var expected = Solid12;
            var union = Solid1.Union(Solid2);
            AssertUtils.Solid(union, expected);
        }

        [Test]
        public void Solid_Intersect()
        {
            var expected = Solid1;
            var intersect = Solid1.Intersect(Solid12);
            AssertUtils.Solid(intersect, expected);
        }

        [Test]
        public void Solid_Difference()
        {
            var expected = Solid2;
            var difference = Solid12.Difference(Solid1);
            AssertUtils.Solid(difference, expected);
        }

        [Test]
        public void Solid_Difference_ShouldBe_Zero()
        {
            var difference = Solid1.Difference(Solid1);
            Assert.Zero(difference.Edges.Size);
            Assert.Zero(difference.Faces.Size);
            Assert.Zero(difference.Volume);
            Assert.Zero(difference.SurfaceArea);
        }
    }
}