using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;
using System;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Transform_Tests
    {
        [Test]
        public void CreateRotation_ShouldBe_Identity()
        {
            var transform = TransformUtils.CreateRotation(XYZ.BasisZ);
            System.Console.WriteLine(transform.BasisZ);
            Assert.IsTrue(Transform.Identity.AlmostEqual(transform));
        }

        [Test]
        public void CreateRotation_Zero_ShouldBe_Identity()
        {
            var transform = TransformUtils.CreateRotation(XYZ.Zero);
            System.Console.WriteLine(transform.BasisZ);
            Assert.IsTrue(Transform.Identity.AlmostEqual(transform));
        }

        [TestCase(0.5)]
        [TestCase(1.0)]
        [TestCase(2.0)]
        public void CreateRotation_ShouldBe_Identity_Scale(double scale)
        {
            var transform = TransformUtils.CreateRotation(XYZ.BasisZ, scale);
            System.Console.WriteLine(transform.BasisZ);
            Assert.IsTrue(Transform.Identity.ScaleBasis(scale).AlmostEqual(transform));
        }

        [Test]
        public void CreateRotationX_ShouldBe_Identity()
        {
            var transform = TransformUtils.CreateRotationX(XYZ.BasisZ, XYZ.BasisX);
            Assert.IsTrue(Transform.Identity.AlmostEqual(transform));
        }

        [Test]
        public void CreateRotationX_Zero_ShouldBe_Identity()
        {
            var transform = TransformUtils.CreateRotationX(XYZ.Zero, XYZ.Zero);
            Assert.IsTrue(Transform.Identity.AlmostEqual(transform));
        }

        [TestCase(0.5)]
        [TestCase(1.0)]
        [TestCase(2.0)]
        public void CreateRotationX_ShouldBe_Identity_Scale(double scale)
        {
            var transform = TransformUtils.CreateRotationX(XYZ.BasisZ, XYZ.BasisX, scale);
            Assert.IsTrue(Transform.Identity.ScaleBasis(scale).AlmostEqual(transform));
        }

        [Test]
        public void CreateRotationY_ShouldBe_Identity()
        {
            var transform = TransformUtils.CreateRotationY(XYZ.BasisZ, XYZ.BasisY);
            Assert.IsTrue(Transform.Identity.AlmostEqual(transform));
        }

        [Test]
        public void CreateRotationY_Zero_ShouldBe_Identity()
        {
            var transform = TransformUtils.CreateRotationY(XYZ.Zero, XYZ.Zero);
            Assert.IsTrue(Transform.Identity.AlmostEqual(transform));
        }

        [TestCase(0.5)]
        [TestCase(1.0)]
        [TestCase(2.0)]
        public void CreateRotationY_ShouldBe_Identity_Scale(double scale)
        {
            var transform = TransformUtils.CreateRotationY(XYZ.BasisZ, XYZ.BasisY, scale);
            Assert.IsTrue(Transform.Identity.ScaleBasis(scale).AlmostEqual(transform));
        }


        [Test]
        public void CreateRotation_EachPoint()
        {
            LoopAroundSphereUtils.EachPoint(point =>
            {
                var transform = TransformUtils.CreateRotation(point);
                Assert.IsTrue(point.IsAlmostEqualTo(transform.BasisZ));
            });
        }

        [TestCase(0.5)]
        [TestCase(1.0)]
        [TestCase(2.0)]
        public void CreateRotation_EachPoint_Scale(double scale)
        {
            LoopAroundSphereUtils.EachPoint(point =>
            {
                var transform = TransformUtils.CreateRotation(point, scale);
                Assert.IsTrue(point.IsAlmostEqualTo(transform.BasisZ), $"{point} is not almost equal to {transform.BasisZ}");
            }, radius: scale);
        }


        [Test]
        public void CreateRotationX_EachPointOrthogonal()
        {
            LoopAroundSphereUtils.EachPointOrthogonal((pointZ, pointX) =>
            {
                var transform = TransformUtils.CreateRotationX(pointZ, pointX);
                Assert.IsTrue(pointZ.IsAlmostEqualTo(transform.BasisZ), $"{pointZ} is not almost equal to {transform.BasisZ}");
                Assert.IsTrue(pointX.IsAlmostEqualTo(transform.BasisX), $"{pointX} is not almost equal to {transform.BasisX}");
            });
        }

        [Test]
        public void CreateRotationY_EachPointOrthogonal()
        {
            LoopAroundSphereUtils.EachPointOrthogonal((pointZ, pointY) =>
            {
                var transform = TransformUtils.CreateRotationY(pointZ, pointY);
                Assert.IsTrue(pointZ.IsAlmostEqualTo(transform.BasisZ));
                Assert.IsTrue(pointY.IsAlmostEqualTo(transform.BasisY));
            });
        }

        [TestCase(0.5)]
        [TestCase(1.0)]
        [TestCase(2.0)]
        public void CreateRotationX_EachPointOrthogonal_Scale(double scale)
        {
            LoopAroundSphereUtils.EachPointOrthogonal((pointZ, pointX) =>
            {
                var transform = TransformUtils.CreateRotationX(pointZ, pointX, scale);
                Assert.IsTrue(pointZ.IsAlmostEqualTo(transform.BasisZ), $"{pointZ} is not almost equal to {transform.BasisZ}");
                Assert.IsTrue(pointX.IsAlmostEqualTo(transform.BasisX), $"{pointX} is not almost equal to {transform.BasisX}");
            }, radius: scale);
        }

        [TestCase(0.5)]
        [TestCase(1.0)]
        [TestCase(2.0)]
        public void CreateRotationY_EachPointOrthogonal_Scale(double scale)
        {
            LoopAroundSphereUtils.EachPointOrthogonal((pointZ, pointY) =>
            {
                var transform = TransformUtils.CreateRotationY(pointZ, pointY, scale);
                Assert.IsTrue(pointZ.IsAlmostEqualTo(transform.BasisZ), $"{pointZ} is not almost equal to {transform.BasisZ}");
                Assert.IsTrue(pointY.IsAlmostEqualTo(transform.BasisY), $"{pointY} is not almost equal to {transform.BasisY}");
            }, radius: scale);
        }

    }
}