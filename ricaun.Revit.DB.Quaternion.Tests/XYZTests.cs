using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Quaternion;
using ricaun.Revit.DB.Quaternion.Extensions;
using System;

namespace RevitAddin.QuaternionTest.Tests
{
    public class XYZTests
    {
        /// <summary>
        /// Compare Transform.OfVector with Quaternion.Transform
        /// </summary>
        [Test]
        public void XYZ_Transform_OfVector_Tests()
        {
            TransformRotationUtils.CreateRotations((transform, normal, angle) =>
            {
                var xyz = XYZ.BasisX;
                Quaternion quaternion = Quaternion.CreateFromAxisAngle(normal, angle);

                var expected = transform.OfVector(xyz);
                var actual = quaternion.Transform(xyz);

                if (MathHelper.EqualRotation(quaternion, transform.GetQuaternion()) == false)
                {
                    System.Console.WriteLine(quaternion);
                    System.Console.WriteLine(transform.GetQuaternion());
                    System.Console.WriteLine(quaternion.ToMatrix().AsString());
                    System.Console.WriteLine(transform.ToMatrix().AsString());
                    Assert.Fail("quaternion is diferent from GetQuaternion");
                }

                Assert.True(MathHelper.Equal(expected, actual),
                    string.Format("Quaternion.Transform did not return the expected value. angle:{0} expected:{1} actual:{2} normal:{3}",
                    angle.ToString(), expected, actual, normal));
            });
        }

        /// <summary>
        /// Compare Transform.OfVector with *operator
        /// </summary>
        [Test]
        public void XYZ_Transform_OfVector_operator_Tests()
        {
            TransformRotationUtils.CreateRotations((transform, normal, angle) =>
            {
                var xyz = XYZ.BasisX;
                Quaternion quaternion = Quaternion.CreateFromAxisAngle(normal, angle);

                var expected = transform.OfVector(xyz);
                var actual = xyz * quaternion;

                if (MathHelper.EqualRotation(quaternion, transform.GetQuaternion()) == false)
                {
                    System.Console.WriteLine(quaternion);
                    System.Console.WriteLine(transform.GetQuaternion());
                    System.Console.WriteLine(quaternion.ToMatrix().AsString());
                    System.Console.WriteLine(transform.ToMatrix().AsString());
                    Assert.Fail("quaternion is diferent from GetQuaternion");
                }

                Assert.True(MathHelper.Equal(expected, actual),
                    string.Format("Quaternion.Transform did not return the expected value. angle:{0} expected:{1} actual:{2} normal:{3}",
                    angle.ToString(), expected, actual, normal));
            });
        }

        /// <summary>
        /// Compare Transform.OfVector with Quaternion.Transform
        /// </summary>
        [TestCase(0.5)]
        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.1)]
        public void XYZ_TransformScale_OfVector_Tests(double scale)
        {
            TransformRotationUtils.CreateRotations((transform, normal, angle) =>
            {
                var xyz = XYZ.BasisX;
                Quaternion quaternion = Quaternion.CreateFromAxisAngle(normal, angle);

                transform = transform.ScaleBasis(scale);
                quaternion *= Math.Sqrt(scale);

                var expected = transform.OfVector(xyz);
                var actual = quaternion.Transform(xyz);

                if (MathHelper.EqualRotation(quaternion, transform.GetQuaternion()) == false)
                {
                    Console.WriteLine($"Q: {quaternion} {-quaternion}");
                    Console.WriteLine($"T: {transform.GetQuaternion()}");

                    Console.WriteLine($"{Quaternion.Normalize(quaternion)} <> {Quaternion.Normalize(transform.GetQuaternion())}");

                    Console.WriteLine(quaternion.ToMatrix().AsString());
                    Console.WriteLine(transform.ToMatrix().AsString());
                    Assert.Fail($"Quaternion is diferent from GetQuaternion angle: {angle} {normal}");
                }

                Assert.True(MathHelper.Equal(expected, actual),
                    string.Format("Quaternion.Transform did not return the expected value. angle:{0} expected:{1} actual:{2} normal:{3}",
                    angle.ToString(), expected, actual, normal));
            });
        }

        /// <summary>
        /// Compare Transform.OfPoint with XYZ.Transform
        /// </summary>
        [Test]
        public void XYZ_Transform_OfPoint_Tests()
        {
            TransformRotationUtils.CreateRotations((transform, normal, angle) =>
            {
                var xyz = XYZ.BasisX;
                var origin = new XYZ(1, 1, 1);
                transform.Origin = origin;

                Quaternion quaternion = Quaternion.CreateFromAxisAngle(normal, angle);

                var expected = transform.OfPoint(xyz);
                var actual = xyz.Transform(quaternion) + origin;
                var actual2 = xyz.Transform(quaternion, origin);

                if (MathHelper.EqualRotation(quaternion, transform.GetQuaternion()) == false)
                {
                    System.Console.WriteLine(quaternion);
                    System.Console.WriteLine(transform.GetQuaternion());
                    System.Console.WriteLine(quaternion.ToMatrix().AsString());
                    System.Console.WriteLine(transform.ToMatrix().AsString());
                    Assert.Fail("quaternion is diferent from GetQuaternion");
                }

                Assert.True(MathHelper.Equal(expected, actual),
                    string.Format("Quaternion.Transform did not return the expected value. angle:{0} expected:{1} actual:{2} normal:{3}",
                    angle.ToString(), expected, actual, normal));

                Assert.IsTrue(MathHelper.Equal(actual, actual2), "Transform with origin is not equal");
            });
        }
    }
}
