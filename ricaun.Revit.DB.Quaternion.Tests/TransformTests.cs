using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Quaternion;
using ricaun.Revit.DB.Quaternion.Extensions;

namespace RevitAddin.QuaternionTest.Tests
{
    public class TransformTests
    {
        // A test for Transform.GetQuaternion (Transform)
        // Convert Identity Transform test
        [Test]
        public void TransformGetSetQuaternionTest1()
        {
            Transform transform = Transform.Identity;

            Quaternion expected = new Quaternion(0.0, 0.0, 0.0, 1.0);
            Quaternion actual = transform.GetQuaternion();
            Assert.True(MathHelper.Equal(expected, actual), "Transform.GetQuaternion did not return the expected value.");

            // make sure convert back to Transform is same as we passed Transform.
            Transform m2 = Transform.Identity.SetQuaternion(actual);
            Assert.True(MathHelper.Equal(transform, m2), "Transform.SetQuaternion did not return the expected value.");
        }

        // A test for Transform.CreateRotation (Transform)
        // Convert X axis rotation transform
        [Test]
        public void TransformGetSetQuaternionTest_X()
        {
            for (double a = 0.0; a < 720.0; a += 10.0)
            {
                var angle = MathHelper.ToRadians(a);
                Transform transform = Transform.CreateRotation(XYZ.BasisX, angle);

                Quaternion expected = Quaternion.CreateFromAxisAngle(XYZ.BasisX, angle);
                Quaternion actual = transform.GetQuaternion();
                Assert.True(MathHelper.EqualRotation(expected, actual),
                    string.Format("Transform.GetQuaternion did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), expected.ToString(), actual.ToString()));

                // make sure convert back to matrix is same as we passed matrix.
                Transform m2 = Transform.Identity.SetQuaternion(actual);
                Assert.True(MathHelper.Equal(transform, m2),
                    string.Format("Transform.SetQuaternion did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), transform.AsString(), m2.AsString()));
            }
        }

        // A test for Transform.CreateRotation (Transform)
        // Convert Y axis rotation matrix
        [Test]
        public void TransformGetSetQuaternionTest_Y()
        {
            for (double a = 0.0; a < 720.0; a += 10.0)
            {
                var angle = MathHelper.ToRadians(a);
                Transform transform = Transform.CreateRotation(XYZ.BasisY, angle);

                Quaternion expected = Quaternion.CreateFromAxisAngle(XYZ.BasisY, angle);
                Quaternion actual = transform.GetQuaternion();
                Assert.True(MathHelper.EqualRotation(expected, actual),
                    string.Format("Transform.GetQuaternion did not return the expected value. angle:{0}",
                    angle.ToString()));

                // make sure convert back to matrix is same as we passed matrix.
                Transform m2 = Transform.Identity.SetQuaternion(actual);
                Assert.True(MathHelper.Equal(transform, m2),
                    string.Format("Transform.GetQuaternion did not return the expected value. angle:{0}",
                    angle.ToString()));
            }
        }

        // A test for Transform.CreateRotation (Transform)
        // Convert Z axis rotation matrix
        [Test]
        public void TransformGetSetQuaternionTest_Z()
        {
            for (double a = 0.0; a < 720.0; a += 10.0)
            {
                var angle = MathHelper.ToRadians(a);
                Transform transform = Transform.CreateRotation(XYZ.BasisZ, angle);

                Quaternion expected = Quaternion.CreateFromAxisAngle(XYZ.BasisZ, angle);
                Quaternion actual = transform.GetQuaternion();
                Assert.True(MathHelper.EqualRotation(expected, actual),
                    string.Format("Transform.GetQuaternion did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), expected.ToString(), actual.ToString()));

                // make sure convert back to matrix is same as we passed matrix.
                Transform m2 = Transform.Identity.SetQuaternion(actual);
                Assert.True(MathHelper.Equal(transform, m2),
                    string.Format("Transform.SetQuaternion did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), transform.ToString(), m2.ToString()));
            }
        }

        // A test for Transform.CreateRotation (Transform)
        // Convert XYZ axis rotation matrix
        [Test]
        public void TransformGetSetQuaternionTest_XYZ()
        {
            for (double a = 0.0; a < 720.0; a += 10.0)
            {
                var angle = MathHelper.ToRadians(a);
                Transform transform =
                    Transform.CreateRotation(XYZ.BasisX, angle) *
                    Transform.CreateRotation(XYZ.BasisY, angle) *
                    Transform.CreateRotation(XYZ.BasisZ, angle);

                Quaternion expected =
                    Quaternion.CreateFromAxisAngle(XYZ.BasisX, angle) *
                    Quaternion.CreateFromAxisAngle(XYZ.BasisY, angle) *
                    Quaternion.CreateFromAxisAngle(XYZ.BasisZ, angle);

                Quaternion actual = transform.GetQuaternion();
                Assert.True(MathHelper.EqualRotation(expected, actual),
                    string.Format("Transform.GetQuaternion did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), expected.ToString(), actual.ToString()));

                // make sure convert back to transform is same as we passed transform.
                Transform m2 = Transform.Identity.SetQuaternion(actual);
                Assert.True(MathHelper.Equal(transform, m2),
                    string.Format("Transform.SetQuaternion did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), transform.ToString(), m2.ToString()));
            }
        }

        // A test for Transform.CreateRotation (Transform)
        // X axis is most large axis case
        [Test]
        public void QuaternionFromCreateRotationLargeTest1()
        {
            double angle = MathHelper.ToRadians(180.0);
            Transform transform =
                Transform.CreateRotation(XYZ.BasisY, angle) *
                Transform.CreateRotation(XYZ.BasisZ, angle);

            Quaternion expected =
                Quaternion.CreateFromAxisAngle(XYZ.BasisZ, angle) *
                Quaternion.CreateFromAxisAngle(XYZ.BasisY, angle);

            Quaternion actual = transform.GetQuaternion();
            Assert.True(MathHelper.EqualRotation(expected, actual), "Transform.GetQuaternion did not return the expected value.");

            // make sure convert back to transform is same as we passed transform.
            Transform m2 = Transform.Identity.SetQuaternion(actual);
            Assert.True(MathHelper.Equal(transform, m2), "Transform.SetQuaternion did not return the expected value.");
        }

        // A test for Transform.CreateRotation (Transform)
        // Y axis is most large axis case
        [Test]
        public void QuaternionFromCreateRotationLargeTest2()
        {
            double angle = MathHelper.ToRadians(180.0);
            Transform transform =
                Transform.CreateRotation(XYZ.BasisX, angle) *
                Transform.CreateRotation(XYZ.BasisZ, angle);

            Quaternion expected =
                Quaternion.CreateFromAxisAngle(XYZ.BasisZ, angle) *
                Quaternion.CreateFromAxisAngle(XYZ.BasisX, angle);

            Quaternion actual = transform.GetQuaternion();
            Assert.True(MathHelper.EqualRotation(expected, actual), "Transform.GetQuaternion did not return the expected value.");

            // make sure convert back to transform is same as we passed transform.
            Transform m2 = Transform.Identity.SetQuaternion(actual);
            Assert.True(MathHelper.Equal(transform, m2), "Transform.SetQuaternion did not return the expected value.");
        }

        // A test for Transform.CreateRotation (Transform)
        // Z axis is most large axis case
        [Test]
        public void QuaternionFromCreateRotationLargeTest3()
        {
            double angle = MathHelper.ToRadians(180.0);
            Transform transform =
                Transform.CreateRotation(XYZ.BasisX, angle) *
                Transform.CreateRotation(XYZ.BasisY, angle);

            Quaternion expected =
                Quaternion.CreateFromAxisAngle(XYZ.BasisY, angle) *
                Quaternion.CreateFromAxisAngle(XYZ.BasisX, angle);

            Quaternion actual = transform.GetQuaternion();
            Assert.True(MathHelper.EqualRotation(expected, actual), "Transform.GetQuaternion did not return the expected value.");

            // make sure convert back to transform is same as we passed transform.
            Transform m2 = Transform.Identity.SetQuaternion(actual);
            Assert.True(MathHelper.Equal(transform, m2), "Transform.SetQuaternion did not return the expected value.");
        }

        [Test]
        public void Transform_Decompose_Test1()
        {
            for (double a = 0.0; a < 720.0; a += 10.0)
            {
                var angle = MathHelper.ToRadians(a);
                var actual = XYZ.BasisX;
                Transform transform = Transform.CreateRotation(XYZ.BasisZ, angle);
                transform.Origin = actual;

                transform.Decompose(out Quaternion quaternion, out XYZ expected);

                Assert.True(MathHelper.Equal(expected, actual),
                    string.Format("Transform.Decompose did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), expected, actual));
            }
        }

        [Test]
        public void Transform_Scale_Test1()
        {
            for (double a = 0.0; a < 720.0; a += 10.0)
            {
                var angle = MathHelper.ToRadians(a);
                var axis = XYZ.BasisZ;
                var scale = 2.0;
                Transform transform = Transform.CreateRotation(axis, angle).ScaleBasis(scale);

                Quaternion expected = Quaternion.CreateFromAxisAngle(axis, angle).Scale(scale);
                Quaternion actual = transform.GetQuaternion();

                if (MathHelper.EqualRotation(actual, expected) == false)
                {
                    System.Console.WriteLine($"transform: {transform} - {transform.ToMatrix().AsString()}");
                    System.Console.WriteLine($"expected: {expected} - {expected.ToMatrix().AsString()}");
                    System.Console.WriteLine($"actual: {actual} - {actual.ToMatrix().AsString()}");
                }

                Assert.True(MathHelper.EqualRotation(expected, actual),
                    string.Format("Transform.GetQuaternion did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), expected, actual));
            }
        }

    }
}