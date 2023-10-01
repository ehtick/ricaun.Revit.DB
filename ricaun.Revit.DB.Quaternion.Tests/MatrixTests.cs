using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Quaternion;
using ricaun.Revit.DB.Quaternion.Extensions;
using System;

namespace RevitAddin.QuaternionTest.Tests
{
    public class MatrixTests
    {
        [TestCase(0.5)]
        [TestCase(2.0)]
        [TestCase(3.1)]
        public void CreateFromMatrix_NotEquals_GetQuaternion_WithScale(double scale)
        {
            TransformRotationUtils.CreateRotations((t, n, a) =>
            {
                t = t.ScaleBasis(scale);
                var expected = Quaternion.CreateFromMatrix(t.ToMatrix());
                var actual = t.GetQuaternion();
                if (actual.IsAlmostEqualTo(expected) == true)
                {
                    Console.WriteLine($"actual {actual} {actual.LengthSquared()}");
                    Console.WriteLine($"expected {expected} {expected.LengthSquared()}");
                    Console.WriteLine($"normal {n} angle {a}");
                    Assert.Fail($"AlmostEqual: actual:{actual} expected:{expected}");
                }
            });
        }

        [TestCase(0.25)]
        [TestCase(0.5)]
        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.1)]
        [TestCase(4.0)]
        public void ToMatrix_Equals_GetQuaternion_Test(double scale)
        {
            TransformRotationUtils.CreateRotations((t, n, a) =>
            {
                t = t.ScaleBasis(scale);
                var expected = t.ToMatrix();
                var q = t.GetQuaternion();
                var actual = q.ToMatrix();

                if (MathHelper.Similar(actual, expected) == false)
                {
                    Console.WriteLine($"a: {q} {q.LengthSquared()} {q.Length()}");
                    Console.WriteLine($"actual {actual.AsString()}");
                    Console.WriteLine($"expected {expected.AsString()}");
                    Console.WriteLine($"normal {n} angle {a}");
                    Assert.Fail($"AlmostEqual: actual:{actual} expected:{expected}");
                }
            });
        }

        [Test]
        public void ToMatrixNormalize_Equals_ToMatrix_Test()
        {
            TransformRotationUtils.CreateRotations((t, n, a) =>
            {
                var expected = t.GetQuaternion().ToMatrixNormalize();
                var actual = t.GetQuaternion().ToMatrix();
                if (MathHelper.Similar(actual, expected) == false)
                {
                    Console.WriteLine($"actual {actual.AsString()}");
                    Console.WriteLine($"expected {expected.AsString()}");
                    Console.WriteLine($"normal {n} angle {a}");
                    Assert.Fail($"AlmostEqual: actual:{actual} expected:{expected}");
                }
            });
        }

        [Test]
        public void CreateMatrix_Equals_ToMatrix_Test()
        {
            TransformRotationUtils.CreateRotations((t, n, a) =>
            {
                var matrix = t.GetQuaternion().ToMatrix();
                var expected = t;
                var actual = Transform.Identity.CreateMatrix(matrix);
                if (MathHelper.EqualRotation(expected, actual) == false)
                {
                    Console.WriteLine($"actual {actual.AsString()}");
                    Console.WriteLine($"expected {expected.AsString()}");
                    Console.WriteLine($"normal {n} angle {a}");
                    Assert.Fail($"EqualRotation: actual:{actual} expected:{expected}");
                }
            });
        }

        [Test]
        public void Determinant_Equals_Determinant3x3_Test()
        {
            TransformRotationUtils.CreateRotations((t, n, a) =>
            {
                var matrix = t.GetQuaternion().ToMatrix();
                var expected = t.Determinant;
                var actual = matrix.Determinant3x3();
                if (MathHelper.Equal(expected, actual) == false)
                {
                    Console.WriteLine($"actual {actual}");
                    Console.WriteLine($"expected {expected}");
                    Console.WriteLine($"normal {n} angle {a}");
                    Assert.Fail($"EqualRotation: actual:{actual} expected:{expected}");
                }
            });
        }

        [TestCase(0.5)]
        [TestCase(2.0)]
        [TestCase(3.1)]
        public void CreateFromMatrix_NotEquals_ToMatrix_WithScale(double scale)
        {
            TransformRotationUtils.CreateRotations((t, n, a) =>
            {
                t = t.ScaleBasis(scale);
                var expected = Quaternion.CreateFromMatrix(t.ToMatrix());
                var actual = Quaternion.CreateFromMatrix(expected.ToMatrix());
                if (MathHelper.Equal(actual, expected) == true)
                {
                    Console.WriteLine($"actual {actual} {actual.LengthSquared()} {actual.Length()}");
                    Console.WriteLine($"expected {expected} {expected.LengthSquared()} {expected.Length()}");
                    Console.WriteLine($"actual ToMatrix {actual.ToMatrix().AsString()}");
                    Console.WriteLine($"expected ToMatrix {expected.ToMatrix().AsString()}");

                    Console.WriteLine($"normal {n} angle {a}");
                    Assert.Fail($"AlmostEqual: actual:{actual} expected:{expected}");
                }
            });
        }
    }
}