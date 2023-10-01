using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Quaternion;
using System;
using System.Globalization;

namespace RevitAddin.QuaternionTest.Tests
{
    public class QuaternionTests
    {
        // A test for Dot (Quaternion, Quaternion)
        [Test]
        public void QuaternionDotTest()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);
            Quaternion b = new Quaternion(5.0, 6.0, 7.0, 8.0);

            double expected = 70.0;
            double actual;

            actual = Quaternion.Dot(a, b);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Dot did not return the expected value.");
        }


        // A test for Length ()
        [Test]
        public void QuaternionLengthTest()
        {
            XYZ v = new XYZ(1.0, 2.0, 3.0);

            double w = 4.0;

            Quaternion target = new Quaternion(v, w);

            double expected = 5.477226;
            double actual;

            actual = target.Length();

            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Length did not return the expected value.");
        }

        // A test for LengthSquared ()
        [Test]
        public void QuaternionLengthSquaredTest()
        {
            XYZ v = new XYZ(1.0, 2.0, 3.0);
            double w = 4.0;

            Quaternion target = new Quaternion(v, w);

            double expected = 30.0;
            double actual;

            actual = target.LengthSquared();

            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.LengthSquared did not return the expected value.");
        }

        // A test for Lerp (Quaternion, Quaternion, double)
        [Test]
        public void QuaternionLerpTest()
        {
            XYZ axis = new XYZ(1.0, 2.0, 3.0).Normalize();
            Quaternion a = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(10.0));
            Quaternion b = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(30.0));

            double t = 0.5;

            Quaternion expected = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(20.0));
            Quaternion actual;

            actual = Quaternion.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Lerp did not return the expected value.");

            // Case a and b are same.
            expected = a;
            actual = Quaternion.Lerp(a, a, t);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Lerp did not return the expected value.");
        }

        // A test for Lerp (Quaternion, Quaternion, double)
        // Lerp test when t = 0
        [Test]
        public void QuaternionLerpTest1()
        {
            XYZ axis = new XYZ(1.0, 2.0, 3.0).Normalize();
            Quaternion a = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(10.0));
            Quaternion b = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(30.0));

            double t = 0.0;

            Quaternion expected = new Quaternion(a.X, a.Y, a.Z, a.W);
            Quaternion actual = Quaternion.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Lerp did not return the expected value.");
        }

        // A test for Lerp (Quaternion, Quaternion, double)
        // Lerp test when t = 1
        [Test]
        public void QuaternionLerpTest2()
        {
            XYZ axis = new XYZ(1.0, 2.0, 3.0).Normalize();
            Quaternion a = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(10.0));
            Quaternion b = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(30.0));

            double t = 1.0;

            Quaternion expected = new Quaternion(b.X, b.Y, b.Z, b.W);
            Quaternion actual = Quaternion.Lerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Lerp did not return the expected value.");
        }

        // A test for Lerp (Quaternion, Quaternion, double)
        // Lerp test when the two quaternions are more than 90 degree (dot product <0)
        [Test]
        public void QuaternionLerpTest3()
        {
            XYZ axis = new XYZ(1.0, 2.0, 3.0).Normalize();
            Quaternion a = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(10.0));
            Quaternion b = Quaternion.Negate(a);

            double t = 1.0;

            Quaternion actual = Quaternion.Lerp(a, b, t);
            // Note that in quaternion world, Q == -Q. In the case of quaternions dot product is zero, 
            // one of the quaternion will be flipped to compute the shortest distance. When t = 1, we
            // expect the result to be the same as quaternion b but flipped.
            Assert.True(actual == a, "Quaternion.Lerp did not return the expected value.");
        }

        // A test for Conjugate(Quaternion)
        [Test]
        public void QuaternionConjugateTest1()
        {
            Quaternion a = new Quaternion(1, 2, 3, 4);

            Quaternion expected = new Quaternion(-1, -2, -3, 4);
            Quaternion actual;

            actual = Quaternion.Conjugate(a);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Conjugate did not return the expected value.");
        }

        // A test for Normalize (Quaternion)
        [Test]
        public void QuaternionNormalizeTest()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);

            Quaternion expected = new Quaternion(0.182574185835055, 0.365148371670111, 0.547722557505166, 0.730296743340221);
            Quaternion actual;

            actual = a.Normalize();
            Console.WriteLine(actual);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Normalize did not return the expected value.");
        }

        // A test for Normalize (Quaternion)
        // Normalize zero length quaternion
        [Test]
        public void QuaternionNormalizeTest1()
        {
            Quaternion a = new Quaternion(0.0, 0.0, -0.0, 0.0);

            Quaternion actual = a.Normalize();
            Assert.True(double.IsNaN(actual.X) && double.IsNaN(actual.Y) && double.IsNaN(actual.Z) && double.IsNaN(actual.W)
                , "Quaternion.Normalize did not return the expected value.");
        }

        // A test for Concatenate(Quaternion, Quaternion)
        [Test]
        public void QuaternionConcatenateTest1()
        {
            Quaternion b = new Quaternion(1.0, 2.0, 3.0, 4.0);
            Quaternion a = new Quaternion(5.0, 6.0, 7.0, 8.0);

            Quaternion expected = new Quaternion(24.0, 48.0, 48.0, -6.0);
            Quaternion actual;

            actual = Quaternion.Concatenate(a, b);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Concatenate did not return the expected value.");
        }

        // A test for operator - (Quaternion, Quaternion)
        [Test]
        public void QuaternionSubtractionTest()
        {
            Quaternion a = new Quaternion(1.0, 6.0, 7.0, 4.0);
            Quaternion b = new Quaternion(5.0, 2.0, 3.0, 8.0);

            Quaternion expected = new Quaternion(-4.0, 4.0, 4.0, -4.0);
            Quaternion actual;

            actual = a - b;

            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.operator - did not return the expected value.");
        }

        // A test for operator * (Quaternion, double)
        [Test]
        public void QuaternionMultiplyTest()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);
            double factor = 0.5;

            Quaternion expected = new Quaternion(0.5, 1.0, 1.5, 2.0);
            Quaternion actual;

            actual = a * factor;

            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.operator * did not return the expected value.");
        }

        // A test for operator * (Quaternion, Quaternion)
        [Test]
        public void QuaternionMultiplyTest1()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);
            Quaternion b = new Quaternion(5.0, 6.0, 7.0, 8.0);

            Quaternion expected = new Quaternion(24.0, 48.0, 48.0, -6.0);
            Quaternion actual;

            actual = a * b;

            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.operator * did not return the expected value.");
        }

        // A test for operator / (Quaternion, Quaternion)
        [Test]
        public void QuaternionDivisionTest1()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);
            Quaternion b = new Quaternion(5.0, 6.0, 7.0, 8.0);

            Quaternion expected = new Quaternion(-0.0459770114942529, -0.0919540229885057, 0, 0.402298850574713);
            Quaternion actual;

            actual = a / b;

            Console.WriteLine(actual);

            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.operator / did not return the expected value.");
        }

        // A test for operator + (Quaternion, Quaternion)
        [Test]
        public void QuaternionAdditionTest()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);
            Quaternion b = new Quaternion(5.0, 6.0, 7.0, 8.0);

            Quaternion expected = new Quaternion(6.0, 8.0, 10.0, 12.0);
            Quaternion actual;

            actual = a + b;

            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.operator + did not return the expected value.");
        }

        // A test for Quaternion (double, double, double, double)
        [Test]
        public void QuaternionConstructorTest()
        {
            double x = 1.0;
            double y = 2.0;
            double z = 3.0;
            double w = 4.0;

            Quaternion target = new Quaternion(x, y, z, w);

            Assert.True(MathHelper.Equal(target.X, x) && MathHelper.Equal(target.Y, y) && MathHelper.Equal(target.Z, z) && MathHelper.Equal(target.W, w),
                "Quaternion.constructor (x,y,z,w) did not return the expected value.");
        }

        // A test for Quaternion (XYZ, double)
        [Test]
        public void QuaternionConstructorTest1()
        {
            XYZ v = new XYZ(1.0, 2.0, 3.0);
            double w = 4.0;

            Quaternion target = new Quaternion(v, w);
            Assert.True(MathHelper.Equal(target.X, v.X) && MathHelper.Equal(target.Y, v.Y) && MathHelper.Equal(target.Z, v.Z) && MathHelper.Equal(target.W, w),
                "Quaternion.constructor (XYZ,w) did not return the expected value.");
        }

        // A test for CreateFromAxisAngle (XYZ, double)
        [Test]
        public void QuaternionCreateFromAxisAngleTest()
        {
            XYZ axis = new XYZ(1.0, 2.0, 3.0).Normalize();
            double angle = MathHelper.ToRadians(30.0);

            Quaternion expected = new Quaternion(0.0691722994246875, 0.138344598849375, 0.207516898274062, 0.965925826289068);
            Quaternion actual;

            actual = Quaternion.CreateFromAxisAngle(axis, angle);
            //Console.WriteLine(actual);

            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.CreateFromAxisAngle did not return the expected value.");
        }

        // A test for CreateFromAxisAngle (XYZ, double)
        // CreateFromAxisAngle of zero vector
        [Test]
        public void QuaternionCreateFromAxisAngleTest1()
        {
            XYZ axis = new XYZ();
            double angle = MathHelper.ToRadians(-30.0);

            double cos = (double)Math.Cos(angle / 2.0);
            Quaternion actual = Quaternion.CreateFromAxisAngle(axis, angle);

            //Console.WriteLine(actual);

            Assert.True(actual.X == 0.0 && actual.Y == 0.0 && actual.Z == 0.0 && MathHelper.Equal(cos, actual.W)
                , "Quaternion.CreateFromAxisAngle did not return the expected value.");
        }

        // A test for CreateFromAxisAngle (XYZ, double)
        // CreateFromAxisAngle of angle = 30 && 750
        [Test]
        public void QuaternionCreateFromAxisAngleTest2()
        {
            XYZ axis = new XYZ(1, 0, 0);
            double angle1 = MathHelper.ToRadians(30.0);
            double angle2 = MathHelper.ToRadians(750.0);

            Quaternion actual1 = Quaternion.CreateFromAxisAngle(axis, angle1);
            Quaternion actual2 = Quaternion.CreateFromAxisAngle(axis, angle2);
            Assert.True(MathHelper.Equal(actual1, actual2), "Quaternion.CreateFromAxisAngle did not return the expected value.");
        }

        // A test for CreateFromAxisAngle (XYZ, double)
        // CreateFromAxisAngle of angle = 30 && 390
        [Test]
        public void QuaternionCreateFromAxisAngleTest3()
        {
            XYZ axis = new XYZ(1, 0, 0);
            double angle1 = MathHelper.ToRadians(30.0);
            double angle2 = MathHelper.ToRadians(390.0);

            Quaternion actual1 = Quaternion.CreateFromAxisAngle(axis, angle1);
            Quaternion actual2 = Quaternion.CreateFromAxisAngle(axis, angle2);
            actual1.X = -actual1.X;
            actual1.W = -actual1.W;

            Assert.True(MathHelper.Equal(actual1, actual2), "Quaternion.CreateFromAxisAngle did not return the expected value.");
        }

        [Test]
        public void QuaternionCreateFromYawPitchRollTest1()
        {
            double yawAngle = MathHelper.ToRadians(30.0);
            double pitchAngle = MathHelper.ToRadians(40.0);
            double rollAngle = MathHelper.ToRadians(50.0);

            Quaternion yaw = Quaternion.CreateFromAxisAngle(XYZ.BasisY, yawAngle);
            Quaternion pitch = Quaternion.CreateFromAxisAngle(XYZ.BasisX, pitchAngle);
            Quaternion roll = Quaternion.CreateFromAxisAngle(XYZ.BasisZ, rollAngle);

            Quaternion expected = yaw * pitch * roll;
            Quaternion actual = Quaternion.CreateFromYawPitchRoll(yawAngle, pitchAngle, rollAngle);
            Assert.True(MathHelper.Equal(expected, actual));
        }

        // Covers more numeric rigions
        [Test]
        public void QuaternionCreateFromYawPitchRollTest2()
        {
            const double step = 35.0;

            for (double yawAngle = -720.0; yawAngle <= 720.0; yawAngle += step)
            {
                for (double pitchAngle = -720.0; pitchAngle <= 720.0; pitchAngle += step)
                {
                    for (double rollAngle = -720.0; rollAngle <= 720.0; rollAngle += step)
                    {
                        double yawRad = MathHelper.ToRadians(yawAngle);
                        double pitchRad = MathHelper.ToRadians(pitchAngle);
                        double rollRad = MathHelper.ToRadians(rollAngle);

                        Quaternion yaw = Quaternion.CreateFromAxisAngle(XYZ.BasisY, yawRad);
                        Quaternion pitch = Quaternion.CreateFromAxisAngle(XYZ.BasisX, pitchRad);
                        Quaternion roll = Quaternion.CreateFromAxisAngle(XYZ.BasisZ, rollRad);

                        Quaternion expected = yaw * pitch * roll;
                        Quaternion actual = Quaternion.CreateFromYawPitchRoll(yawRad, pitchRad, rollRad);
                        Assert.True(MathHelper.Equal(expected, actual), String.Format("Yaw:{0} Pitch:{1} Roll:{2}", yawAngle, pitchAngle, rollAngle));
                    }
                }
            }
        }

        // A test for Slerp (Quaternion, Quaternion, double)
        [Test]
        public void QuaternionSlerpTest()
        {
            XYZ axis = new XYZ(1.0, 2.0, 3.0).Normalize();
            Quaternion a = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(10.0));
            Quaternion b = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(30.0));

            double t = 0.5;

            Quaternion expected = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(20.0));
            Quaternion actual;

            actual = Quaternion.Slerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Slerp did not return the expected value.");

            // Case a and b are same.
            expected = a;
            actual = Quaternion.Slerp(a, a, t);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Slerp did not return the expected value.");
        }

        // A test for Slerp (Quaternion, Quaternion, double)
        // Slerp test where t = 0
        [Test]
        public void QuaternionSlerpTest1()
        {
            XYZ axis = new XYZ(1.0, 2.0, 3.0).Normalize();
            Quaternion a = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(10.0));
            Quaternion b = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(30.0));

            double t = 0.0;

            Quaternion expected = new Quaternion(a.X, a.Y, a.Z, a.W);
            Quaternion actual = Quaternion.Slerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Slerp did not return the expected value.");
        }

        // A test for Slerp (Quaternion, Quaternion, double)
        // Slerp test where t = 1
        [Test]
        public void QuaternionSlerpTest2()
        {
            XYZ axis = new XYZ(1.0, 2.0, 3.0).Normalize();
            Quaternion a = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(10.0));
            Quaternion b = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(30.0));

            double t = 1.0;

            Quaternion expected = new Quaternion(b.X, b.Y, b.Z, b.W);
            Quaternion actual = Quaternion.Slerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Slerp did not return the expected value.");
        }

        // A test for Slerp (Quaternion, Quaternion, double)
        // Slerp test where dot product is < 0
        [Test]
        public void QuaternionSlerpTest3()
        {
            XYZ axis = new XYZ(1.0, 2.0, 3.0).Normalize();
            Quaternion a = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(10.0));
            Quaternion b = -a;

            double t = 1.0;

            Quaternion expected = a;
            Quaternion actual = Quaternion.Slerp(a, b, t);
            // Note that in quaternion world, Q == -Q. In the case of quaternions dot product is zero, 
            // one of the quaternion will be flipped to compute the shortest distance. When t = 1, we
            // expect the result to be the same as quaternion b but flipped.
            Assert.True(actual == expected, "Quaternion.Slerp did not return the expected value.");
        }

        // A test for Slerp (Quaternion, Quaternion, double)
        // Slerp test where the quaternion is flipped
        [Test]
        public void QuaternionSlerpTest4()
        {
            XYZ axis = new XYZ(1.0, 2.0, 3.0).Normalize();
            Quaternion a = Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(10.0));
            Quaternion b = -Quaternion.CreateFromAxisAngle(axis, MathHelper.ToRadians(30.0));

            double t = 0.0;

            Quaternion expected = new Quaternion(a.X, a.Y, a.Z, a.W);
            Quaternion actual = Quaternion.Slerp(a, b, t);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Slerp did not return the expected value.");
        }

        // A test for operator - (Quaternion)
        [Test]
        public void QuaternionUnaryNegationTest()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);

            Quaternion expected = new Quaternion(-1.0, -2.0, -3.0, -4.0);
            Quaternion actual;

            actual = -a;

            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.operator - did not return the expected value.");
        }

        // A test for Inverse (Quaternion)
        [Test]
        public void QuaternionInverseTest()
        {
            Quaternion a = new Quaternion(5.0, 6.0, 7.0, 8.0);


            Quaternion expected = new Quaternion(-0.028735632183908046, -0.034482758620689655, -0.040229885057471264, 0.045977011494252873);
            Quaternion actual;

            actual = Quaternion.Inverse(a);

            Console.WriteLine(actual);
            Assert.True(MathHelper.Equal(expected, actual));
        }

        // A test for Inverse (Quaternion)
        // Invert zero length quaternion
        [Test]
        public void QuaternionInverseTest1()
        {
            Quaternion a = new Quaternion();
            Quaternion actual = Quaternion.Inverse(a);

            Console.WriteLine(actual);

            Assert.True(double.IsNaN(actual.X) && double.IsNaN(actual.Y) && double.IsNaN(actual.Z) && double.IsNaN(actual.W));
        }

        // A test for ToString ()
        [Test]
        public void QuaternionToStringTest()
        {
            Quaternion target = new Quaternion(-1.0, 2.2, 3.3, -4.4);

            string expected = string.Format(CultureInfo.InvariantCulture
                , "({0}, {1}, {2}, {3})"
                , -1.0, 2.2, 3.3, -4.4);

            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        // A test for Add (Quaternion, Quaternion)
        [Test]
        public void QuaternionAddTest()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);
            Quaternion b = new Quaternion(5.0, 6.0, 7.0, 8.0);

            Quaternion expected = new Quaternion(6.0, 8.0, 10.0, 12.0);
            Quaternion actual;

            actual = Quaternion.Add(a, b);
            Assert.AreEqual(expected, actual);
        }

        // A test for Divide (Quaternion, Quaternion)
        [Test]
        public void QuaternionDivideTest()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);
            Quaternion b = new Quaternion(5.0, 6.0, 7.0, 8.0);

            Quaternion expected = new Quaternion(-0.0459770114942529, -0.0919540229885057, 0, 0.402298850574713);
            Quaternion actual;

            actual = Quaternion.Divide(a, b);
            Console.WriteLine(actual);

            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Divide did not return the expected value.");
        }

        // A test for Equals (object)
        [Test]
        public void QuaternionEqualsTest()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);
            Quaternion b = new Quaternion(1.0, 2.0, 3.0, 4.0);

            // case 1: compare between same values
            object obj = b;

            bool expected = true;
            bool actual = a.Equals(obj);
            Assert.AreEqual(expected, actual);

            // case 2: compare between different values
            b.X = 10.0;
            obj = b;
            expected = false;
            actual = a.Equals(obj);
            Assert.AreEqual(expected, actual);

            // case 3: compare between different types.
            obj = new XYZ();
            expected = false;
            actual = a.Equals(obj);
            Assert.AreEqual(expected, actual);

            // case 3: compare against null.
            obj = null;
            expected = false;
            actual = a.Equals(obj);
            Assert.AreEqual(expected, actual);
        }

        // A test for GetHashCode ()
        [Test]
        public void QuaternionGetHashCodeTest()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);

            int expected = a.X.GetHashCode() + a.Y.GetHashCode() + a.Z.GetHashCode() + a.W.GetHashCode();
            int actual = a.GetHashCode();
            Assert.AreEqual(expected, actual);
        }

        // A test for Multiply (Quaternion, double)
        [Test]
        public void QuaternionMultiplyTest2()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);
            double factor = 0.5;

            Quaternion expected = new Quaternion(0.5, 1.0, 1.5, 2.0);
            Quaternion actual;

            actual = Quaternion.Multiply(a, factor);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Multiply did not return the expected value.");
        }

        // A test for Multiply (Quaternion, Quaternion)
        [Test]
        public void QuaternionMultiplyTest3()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);
            Quaternion b = new Quaternion(5.0, 6.0, 7.0, 8.0);

            Quaternion expected = new Quaternion(24.0, 48.0, 48.0, -6.0);
            Quaternion actual;

            actual = Quaternion.Multiply(a, b);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.Multiply did not return the expected value.");
        }

        // A test for Negate (Quaternion)
        [Test]
        public void QuaternionNegateTest()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);

            Quaternion expected = new Quaternion(-1.0, -2.0, -3.0, -4.0);
            Quaternion actual;

            actual = Quaternion.Negate(a);
            Assert.AreEqual(expected, actual);
        }

        // A test for Subtract (Quaternion, Quaternion)
        [Test]
        public void QuaternionSubtractTest()
        {
            Quaternion a = new Quaternion(1.0, 6.0, 7.0, 4.0);
            Quaternion b = new Quaternion(5.0, 2.0, 3.0, 8.0);

            Quaternion expected = new Quaternion(-4.0, 4.0, 4.0, -4.0);
            Quaternion actual;

            actual = Quaternion.Subtract(a, b);
            Assert.AreEqual(expected, actual);
        }

        // A test for operator != (Quaternion, Quaternion)
        [Test]
        public void QuaternionInequalityTest()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);
            Quaternion b = new Quaternion(1.0, 2.0, 3.0, 4.0);

            // case 1: compare between same values
            bool expected = false;
            bool actual = a != b;
            Assert.AreEqual(expected, actual);

            // case 2: compare between different values
            b.X = 10.0;
            expected = true;
            actual = a != b;
            Assert.AreEqual(expected, actual);
        }

        // A test for operator == (Quaternion, Quaternion)
        [Test]
        public void QuaternionEqualityTest()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);
            Quaternion b = new Quaternion(1.0, 2.0, 3.0, 4.0);

            // case 1: compare between same values
            bool expected = true;
            bool actual = a == b;
            Assert.AreEqual(expected, actual);

            // case 2: compare between different values
            b.X = 10.0;
            expected = false;
            actual = a == b;
            Assert.AreEqual(expected, actual);
        }


        /*

        // A test for CreateFromRotationMatrix (Matrix4x4)
        // Convert Identity matrix test
        [Test]
        public void QuaternionFromRotationMatrixTest1()
        {
            Matrix4x4 matrix = Matrix4x4.Identity;

            Quaternion expected = new Quaternion(0.0, 0.0, 0.0, 1.0);
            Quaternion actual = Quaternion.CreateFromRotationMatrix(matrix);
            Assert.True(MathHelper.Equal(expected, actual), "Quaternion.CreateFromRotationMatrix did not return the expected value.");

            // make sure convert back to matrix is same as we passed matrix.
            Matrix4x4 m2 = Matrix4x4.CreateFromQuaternion(actual);
            Assert.True(MathHelper.Equal(matrix, m2), "Quaternion.CreateFromRotationMatrix did not return the expected value.");
        }

        // A test for CreateFromRotationMatrix (Matrix4x4)
        // Convert X axis rotation matrix
        [Test]
        public void QuaternionFromRotationMatrixTest2()
        {
            for (double angle = 0.0; angle < 720.0; angle += 10.0)
            {
                Matrix4x4 matrix = Matrix4x4.CreateRotationX(angle);

                Quaternion expected = Quaternion.CreateFromAxisAngle(XYZ.UnitX, angle);
                Quaternion actual = Quaternion.CreateFromRotationMatrix(matrix);
                Assert.True(MathHelper.EqualRotation(expected, actual),
                    string.Format("Quaternion.CreateFromRotationMatrix did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), expected.ToString(), actual.ToString()));

                // make sure convert back to matrix is same as we passed matrix.
                Matrix4x4 m2 = Matrix4x4.CreateFromQuaternion(actual);
                Assert.True(MathHelper.Equal(matrix, m2),
                    string.Format("Quaternion.CreateFromRotationMatrix did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), matrix.ToString(), m2.ToString()));
            }
        }

        // A test for CreateFromRotationMatrix (Matrix4x4)
        // Convert Y axis rotation matrix
        [Test]
        public void QuaternionFromRotationMatrixTest3()
        {
            for (double angle = 0.0; angle < 720.0; angle += 10.0)
            {
                Matrix4x4 matrix = Matrix4x4.CreateRotationY(angle);

                Quaternion expected = Quaternion.CreateFromAxisAngle(XYZ.UnitY, angle);
                Quaternion actual = Quaternion.CreateFromRotationMatrix(matrix);
                Assert.True(MathHelper.EqualRotation(expected, actual),
                    string.Format("Quaternion.CreateFromRotationMatrix did not return the expected value. angle:{0}",
                    angle.ToString()));

                // make sure convert back to matrix is same as we passed matrix.
                Matrix4x4 m2 = Matrix4x4.CreateFromQuaternion(actual);
                Assert.True(MathHelper.Equal(matrix, m2),
                    string.Format("Quaternion.CreateFromRotationMatrix did not return the expected value. angle:{0}",
                    angle.ToString()));
            }
        }

        // A test for CreateFromRotationMatrix (Matrix4x4)
        // Convert Z axis rotation matrix
        [Test]
        public void QuaternionFromRotationMatrixTest4()
        {
            for (double angle = 0.0; angle < 720.0; angle += 10.0)
            {
                Matrix4x4 matrix = Matrix4x4.CreateRotationZ(angle);

                Quaternion expected = Quaternion.CreateFromAxisAngle(XYZ.UnitZ, angle);
                Quaternion actual = Quaternion.CreateFromRotationMatrix(matrix);
                Assert.True(MathHelper.EqualRotation(expected, actual),
                    string.Format("Quaternion.CreateFromRotationMatrix did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), expected.ToString(), actual.ToString()));

                // make sure convert back to matrix is same as we passed matrix.
                Matrix4x4 m2 = Matrix4x4.CreateFromQuaternion(actual);
                Assert.True(MathHelper.Equal(matrix, m2),
                    string.Format("Quaternion.CreateFromRotationMatrix did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), matrix.ToString(), m2.ToString()));
            }
        }

        // A test for CreateFromRotationMatrix (Matrix4x4)
        // Convert XYZ axis rotation matrix
        [Test]
        public void QuaternionFromRotationMatrixTest5()
        {
            for (double angle = 0.0; angle < 720.0; angle += 10.0)
            {
                Matrix4x4 matrix = Matrix4x4.CreateRotationX(angle) * Matrix4x4.CreateRotationY(angle) * Matrix4x4.CreateRotationZ(angle);

                Quaternion expected =
                    Quaternion.CreateFromAxisAngle(XYZ.UnitZ, angle) *
                    Quaternion.CreateFromAxisAngle(XYZ.UnitY, angle) *
                    Quaternion.CreateFromAxisAngle(XYZ.UnitX, angle);

                Quaternion actual = Quaternion.CreateFromRotationMatrix(matrix);
                Assert.True(MathHelper.EqualRotation(expected, actual),
                    string.Format("Quaternion.CreateFromRotationMatrix did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), expected.ToString(), actual.ToString()));

                // make sure convert back to matrix is same as we passed matrix.
                Matrix4x4 m2 = Matrix4x4.CreateFromQuaternion(actual);
                Assert.True(MathHelper.Equal(matrix, m2),
                    string.Format("Quaternion.CreateFromRotationMatrix did not return the expected value. angle:{0} expected:{1} actual:{2}",
                    angle.ToString(), matrix.ToString(), m2.ToString()));
            }
        }

        // A test for CreateFromRotationMatrix (Matrix4x4)
        // X axis is most large axis case
        [Test]
        public void QuaternionFromRotationMatrixWithScaledMatrixTest1()
        {
            double angle = MathHelper.ToRadians(180.0);
            Matrix4x4 matrix = Matrix4x4.CreateRotationY(angle) * Matrix4x4.CreateRotationZ(angle);

            Quaternion expected = Quaternion.CreateFromAxisAngle(XYZ.UnitZ, angle) * Quaternion.CreateFromAxisAngle(XYZ.UnitY, angle);
            Quaternion actual = Quaternion.CreateFromRotationMatrix(matrix);
            Assert.True(MathHelper.EqualRotation(expected, actual), "Quaternion.CreateFromRotationMatrix did not return the expected value.");

            // make sure convert back to matrix is same as we passed matrix.
            Matrix4x4 m2 = Matrix4x4.CreateFromQuaternion(actual);
            Assert.True(MathHelper.Equal(matrix, m2), "Quaternion.CreateFromRotationMatrix did not return the expected value.");
        }

        // A test for CreateFromRotationMatrix (Matrix4x4)
        // Y axis is most large axis case
        [Test]
        public void QuaternionFromRotationMatrixWithScaledMatrixTest2()
        {
            double angle = MathHelper.ToRadians(180.0);
            Matrix4x4 matrix = Matrix4x4.CreateRotationX(angle) * Matrix4x4.CreateRotationZ(angle);

            Quaternion expected = Quaternion.CreateFromAxisAngle(XYZ.UnitZ, angle) * Quaternion.CreateFromAxisAngle(XYZ.UnitX, angle);
            Quaternion actual = Quaternion.CreateFromRotationMatrix(matrix);
            Assert.True(MathHelper.EqualRotation(expected, actual), "Quaternion.CreateFromRotationMatrix did not return the expected value.");

            // make sure convert back to matrix is same as we passed matrix.
            Matrix4x4 m2 = Matrix4x4.CreateFromQuaternion(actual);
            Assert.True(MathHelper.Equal(matrix, m2), "Quaternion.CreateFromRotationMatrix did not return the expected value.");
        }

        // A test for CreateFromRotationMatrix (Matrix4x4)
        // Z axis is most large axis case
        [Test]
        public void QuaternionFromRotationMatrixWithScaledMatrixTest3()
        {
            double angle = MathHelper.ToRadians(180.0);
            Matrix4x4 matrix = Matrix4x4.CreateRotationX(angle) * Matrix4x4.CreateRotationY(angle);

            Quaternion expected = Quaternion.CreateFromAxisAngle(XYZ.UnitY, angle) * Quaternion.CreateFromAxisAngle(XYZ.UnitX, angle);
            Quaternion actual = Quaternion.CreateFromRotationMatrix(matrix);
            Assert.True(MathHelper.EqualRotation(expected, actual), "Quaternion.CreateFromRotationMatrix did not return the expected value.");

            // make sure convert back to matrix is same as we passed matrix.
            Matrix4x4 m2 = Matrix4x4.CreateFromQuaternion(actual);
            Assert.True(MathHelper.Equal(matrix, m2), "Quaternion.CreateFromRotationMatrix did not return the expected value.");
        }

        */

        // A test for Equals (Quaternion)
        [Test]
        public void QuaternionEqualsTest1()
        {
            Quaternion a = new Quaternion(1.0, 2.0, 3.0, 4.0);
            Quaternion b = new Quaternion(1.0, 2.0, 3.0, 4.0);

            // case 1: compare between same values
            bool expected = true;
            bool actual = a.Equals(b);
            Assert.AreEqual(expected, actual);

            // case 2: compare between different values
            b.X = 10.0;
            expected = false;
            actual = a.Equals(b);
            Assert.AreEqual(expected, actual);
        }

        // A test for empty
        [Test]
        public void QuaternionEmptyTest()
        {
            Quaternion val = new Quaternion();
            Assert.AreEqual(val.X, 0.0);
            Assert.AreEqual(val.Y, 0.0);
            Assert.AreEqual(val.Z, 0.0);
            Assert.AreEqual(val.W, 0.0);
        }

        // A test for Identity
        [Test]
        public void QuaternionIdentityTest()
        {
            Quaternion val = new Quaternion(0, 0, 0, 1);
            Assert.AreEqual(val, Quaternion.Identity);
        }

        // A test for IsIdentity
        [Test]
        public void QuaternionIsIdentityTest()
        {
            Assert.True(Quaternion.Identity.IsIdentity);
            Assert.True(new Quaternion(0, 0, 0, 1).IsIdentity);
            Assert.False(new Quaternion(1, 0, 0, 1).IsIdentity);
            Assert.False(new Quaternion(0, 1, 0, 1).IsIdentity);
            Assert.False(new Quaternion(0, 0, 1, 1).IsIdentity);
            Assert.False(new Quaternion(0, 0, 0, 0).IsIdentity);
        }

    }
}