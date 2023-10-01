using System;

namespace ricaun.Revit.DB.Quaternion
{
    /// <summary>
    /// Represents a Quaternion, a type of mathematical object used in 3D graphics and physics simulations to represent rotations.
    /// </summary>
    public partial class Quaternion
    {
        private const double Tolerance = 1e-9;

        /// <summary>
        /// The x-coordinate of the quaternion.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// The y-coordinate of the quaternion.
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// The z-coordinate of the quaternion.
        /// </summary>
        public double Z { get; set; }
        /// <summary>
        /// The w-coordinate of the quaternion.
        /// </summary>
        public double W { get; set; }// = 1.0;

        /// <summary>
        /// IReturns a Quaternion representing no rotation. 
        /// </summary>
        public static Quaternion Identity
        {
            get { return new Quaternion(0, 0, 0, 1); }
        }

        /// <summary>
        /// Returns whether the Quaternion is the identity Quaternion.
        /// </summary>
        public bool IsIdentity
        {
            get { return X == 0 && Y == 0 && Z == 0 && W == 1; }
        }

        /// <summary>
        /// Initializes a new instance of the Quaternion class.
        /// </summary>
        public Quaternion() { }

        /// <summary>
        /// Initializes a new instance of the Quaternion class with the specified values.
        /// </summary>
        /// <param name="x">The x-coordinate of the quaternion.</param>
        /// <param name="y">The y-coordinate of the quaternion.</param>
        /// <param name="z">The z-coordinate of the quaternion.</param>
        /// <param name="w">The w-coordinate of the quaternion.</param>
        public Quaternion(double x, double y, double z, double w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        /// <summary>
        /// Calculates the length of the Quaternion.
        /// </summary>
        /// <returns>The computed length of the Quaternion.</returns>
        public double Length()
        {
            return Math.Sqrt(LengthSquared());
        }

        /// <summary>
        /// Calculates the length squared of the Quaternion. This operation is cheaper than Length().
        /// </summary>
        /// <returns>The length squared of the Quaternion.</returns>
        public double LengthSquared()
        {
            return X * X + Y * Y + Z * Z + W * W;
        }

        /// <summary>
        /// Multiply the Quaternion with Math.Sqrt(<paramref name="scale"/>)
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public Quaternion Scale(double scale)
        {
            return this * Math.Sqrt(scale);
        }

        /// <summary>
        /// Divides each component of the Quaternion by the length of the Quaternion.
        /// </summary>
        /// <returns>The normalized Quaternion.</returns>
        public Quaternion Normalize()
        {
            double length = Length();

            X /= length;
            Y /= length;
            Z /= length;
            W /= length;

            // Normalize Direction
            if (W <= -0.50 || ((X <= -0.50 || Y <= -0.50 || Z <= -0.50) && W < 0.50))
            {
                X *= -1;
                Y *= -1;
                Z *= -1;
                W *= -1;
            }

            return this;
        }

        /// <summary>
        /// Divides each component of the Quaternion by the length of the Quaternion.
        /// </summary>
        /// <param name="value">The source Quaternion.</param>
        /// <returns>The normalized Quaternion.</returns>
        public static Quaternion Normalize(Quaternion value)
        {
            Quaternion ans = new Quaternion(value.X, value.Y, value.Z, value.W);
            return ans.Normalize();
        }

        /// <summary>
        /// Calculates the dot product of two Quaternions.
        /// </summary>
        /// <param name="quaternion1">The first source Quaternion.</param>
        /// <param name="quaternion2">The second source Quaternion.</param>
        /// <returns>The dot product of the Quaternions.</returns>
        public static double Dot(Quaternion quaternion1, Quaternion quaternion2)
        {
            return quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y + quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W;
        }

        /// <summary>
        /// Interpolates between two quaternions, using spherical linear interpolation.
        /// </summary>
        /// <param name="quaternion1">The first source Quaternion.</param>
        /// <param name="quaternion2">The second source Quaternion.</param>
        /// <param name="amount">The relative weight of the second source Quaternion in the interpolation.</param>
        /// <returns>The interpolated Quaternion.</returns>
        public static Quaternion Slerp(Quaternion quaternion1, Quaternion quaternion2, double amount)
        {
            const double epsilon = Tolerance;

            double t = amount;

            double cosOmega = quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y +
                             quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W;

            bool flip = false;

            if (cosOmega < 0.0)
            {
                flip = true;
                cosOmega = -cosOmega;
            }

            double s1, s2;

            if (cosOmega > 1.0 - epsilon)
            {
                // Too close, do straight linear interpolation.
                s1 = 1.0 - t;
                s2 = flip ? -t : t;
            }
            else
            {
                double omega = (double)Math.Acos(cosOmega);
                double invSinOmega = (double)(1 / Math.Sin(omega));

                s1 = (double)Math.Sin((1.0 - t) * omega) * invSinOmega;
                s2 = flip
                    ? (double)-Math.Sin(t * omega) * invSinOmega
                    : (double)Math.Sin(t * omega) * invSinOmega;
            }

            Quaternion ans = new Quaternion();

            ans.X = s1 * quaternion1.X + s2 * quaternion2.X;
            ans.Y = s1 * quaternion1.Y + s2 * quaternion2.Y;
            ans.Z = s1 * quaternion1.Z + s2 * quaternion2.Z;
            ans.W = s1 * quaternion1.W + s2 * quaternion2.W;

            return ans;
        }

        /// <summary>
        ///  Linearly interpolates between two quaternions.
        /// </summary>
        /// <param name="quaternion1">The first source Quaternion.</param>
        /// <param name="quaternion2">The second source Quaternion.</param>
        /// <param name="amount">The relative weight of the second source Quaternion in the interpolation.</param>
        /// <returns>The interpolated Quaternion.</returns>
        public static Quaternion Lerp(Quaternion quaternion1, Quaternion quaternion2, double amount)
        {
            double t = amount;
            double t1 = 1.0 - t;

            Quaternion r = new Quaternion();

            double dot = quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y +
                        quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W;

            if (dot >= 0.0)
            {
                r.X = t1 * quaternion1.X + t * quaternion2.X;
                r.Y = t1 * quaternion1.Y + t * quaternion2.Y;
                r.Z = t1 * quaternion1.Z + t * quaternion2.Z;
                r.W = t1 * quaternion1.W + t * quaternion2.W;
            }
            else
            {
                r.X = t1 * quaternion1.X - t * quaternion2.X;
                r.Y = t1 * quaternion1.Y - t * quaternion2.Y;
                r.Z = t1 * quaternion1.Z - t * quaternion2.Z;
                r.W = t1 * quaternion1.W - t * quaternion2.W;
            }

            // Normalize it.
            double ls = r.X * r.X + r.Y * r.Y + r.Z * r.Z + r.W * r.W;
            double invNorm = 1.0 / (double)Math.Sqrt((double)ls);

            r.X *= invNorm;
            r.Y *= invNorm;
            r.Z *= invNorm;
            r.W *= invNorm;

            return r;
        }

        /// <summary>
        /// Creates the conjugate of a specified Quaternion.
        /// </summary>
        /// <param name="value">The Quaternion of which to return the conjugate.</param>
        /// <returns>A new Quaternion that is the conjugate of the specified one.</returns>
        public static Quaternion Conjugate(Quaternion value)
        {
            return new Quaternion(-value.X, -value.Y, -value.Z, value.W);
        }

        /// <summary>
        /// Returns the inverse of a Quaternion.
        /// </summary>
        /// <param name="value">The source Quaternion.</param>
        /// <returns>The inverted Quaternion.</returns>
        public static Quaternion Inverse(Quaternion value)
        {
            //  -1   (       a              -v       )
            // q   = ( -------------   ------------- )
            //       (  a^2 + |v|^2  ,  a^2 + |v|^2  )

            Quaternion ans = new Quaternion();

            double ls = value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W;
            double invNorm = 1.0 / ls;

            ans.X = -value.X * invNorm;
            ans.Y = -value.Y * invNorm;
            ans.Z = -value.Z * invNorm;
            ans.W = value.W * invNorm;

            return ans;
        }

        /// <summary>
        /// Creates a quaternion from the given axis and angle.
        /// </summary>
        /// <param name="axisX">The x-coordinate of the axis.</param>
        /// <param name="axisY">The y-coordinate of the axis.</param>
        /// <param name="axisZ">The z-coordinate of the axis.</param>
        /// <param name="angle">The angle in radians.</param>
        /// <returns>A new quaternion created from the given axis and angle.</returns>
        public static Quaternion CreateFromAxisAngle(double axisX, double axisY, double axisZ, double angle)
        {
            double halfAngle = angle * 0.5;
            double s = Math.Sin(halfAngle);
            double w = Math.Cos(halfAngle);

            Quaternion result = new Quaternion();

            result.X = axisX * s;
            result.Y = axisY * s;
            result.Z = axisZ * s;
            result.W = w;

            return result;
        }

        /// <summary>
        /// Creates a quaternion from the given yaw, pitch and roll angles in radians.
        /// </summary>
        /// <param name="yaw">The yaw angle in radians.</param>
        /// <param name="pitch">The pitch angle in radians.</param>
        /// <param name="roll">The roll angle in radians.</param>
        /// <returns>A new quaternion created from the given angles.</returns>
        public static Quaternion CreateFromYawPitchRoll(double yaw, double pitch, double roll)
        {
            double cy = Math.Cos(yaw * 0.5);
            double sy = Math.Sin(yaw * 0.5);
            double cp = Math.Cos(pitch * 0.5);
            double sp = Math.Sin(pitch * 0.5);
            double cr = Math.Cos(roll * 0.5);
            double sr = Math.Sin(roll * 0.5);

            Quaternion result = new Quaternion();
            result.X = cy * sp * cr + sy * cp * sr;
            result.Y = sy * cp * cr - cy * sp * sr;
            result.Z = cy * cp * sr - sy * sp * cr;
            result.W = cy * cp * cr + sy * sp * sr;
            return result;
        }

        /// <summary>
        /// Concatenates two Quaternions; the result represents the value1 rotation followed by the value2 rotation.
        /// </summary>
        /// <param name="value1">The first Quaternion rotation in the series.</param>
        /// <param name="value2">The second Quaternion rotation in the series.</param>
        /// <returns>A new Quaternion representing the concatenation of the value1 rotation followed by the value2 rotation.</returns>
        public static Quaternion Concatenate(Quaternion value1, Quaternion value2)
        {
            Quaternion ans = new Quaternion();

            // Concatenate rotation is actually q2 * q1 instead of q1 * q2.
            // So that's why value2 goes q1 and value1 goes q2.
            double q1x = value2.X;
            double q1y = value2.Y;
            double q1z = value2.Z;
            double q1w = value2.W;

            double q2x = value1.X;
            double q2y = value1.Y;
            double q2z = value1.Z;
            double q2w = value1.W;

            // cross(av, bv)
            double cx = q1y * q2z - q1z * q2y;
            double cy = q1z * q2x - q1x * q2z;
            double cz = q1x * q2y - q1y * q2x;

            double dot = q1x * q2x + q1y * q2y + q1z * q2z;

            ans.X = q1x * q2w + q2x * q1w + cx;
            ans.Y = q1y * q2w + q2y * q1w + cy;
            ans.Z = q1z * q2w + q2z * q1w + cz;
            ans.W = q1w * q2w - dot;

            return ans;
        }


        /// <summary>
        /// Flips the sign of each component of the quaternion.
        /// </summary>
        /// <param name="value">The source Quaternion.</param>
        /// <returns>The negated Quaternion.</returns>
        public static Quaternion Negate(Quaternion value)
        {
            Quaternion ans = new Quaternion();

            ans.X = -value.X;
            ans.Y = -value.Y;
            ans.Z = -value.Z;
            ans.W = -value.W;

            return ans;
        }

        /// <summary>
        /// Adds two Quaternions element-by-element.
        /// </summary>
        /// <param name="value1">The first source Quaternion.</param>
        /// <param name="value2">The second source Quaternion.</param>
        /// <returns>The result of adding the Quaternions.</returns>
        public static Quaternion Add(Quaternion value1, Quaternion value2)
        {
            Quaternion ans = new Quaternion();

            ans.X = value1.X + value2.X;
            ans.Y = value1.Y + value2.Y;
            ans.Z = value1.Z + value2.Z;
            ans.W = value1.W + value2.W;

            return ans;
        }

        /// <summary>
        /// Subtracts one Quaternion from another.
        /// </summary>
        /// <param name="value1">The first source Quaternion.</param>
        /// <param name="value2">The second Quaternion, to be subtracted from the first.</param>
        /// <returns>The result of the subtraction.</returns>
        public static Quaternion Subtract(Quaternion value1, Quaternion value2)
        {
            Quaternion ans = new Quaternion();

            ans.X = value1.X - value2.X;
            ans.Y = value1.Y - value2.Y;
            ans.Z = value1.Z - value2.Z;
            ans.W = value1.W - value2.W;

            return ans;
        }

        /// <summary>
        /// Multiplies two Quaternions together.
        /// </summary>
        /// <param name="value1">The Quaternion on the left side of the multiplication.</param>
        /// <param name="value2">The Quaternion on the right side of the multiplication.</param>
        /// <returns>The result of the multiplication.</returns>
        public static Quaternion Multiply(Quaternion value1, Quaternion value2)
        {
            Quaternion ans = new Quaternion();

            double q1x = value1.X;
            double q1y = value1.Y;
            double q1z = value1.Z;
            double q1w = value1.W;

            double q2x = value2.X;
            double q2y = value2.Y;
            double q2z = value2.Z;
            double q2w = value2.W;

            // cross(av, bv)
            double cx = q1y * q2z - q1z * q2y;
            double cy = q1z * q2x - q1x * q2z;
            double cz = q1x * q2y - q1y * q2x;

            double dot = q1x * q2x + q1y * q2y + q1z * q2z;

            ans.X = q1x * q2w + q2x * q1w + cx;
            ans.Y = q1y * q2w + q2y * q1w + cy;
            ans.Z = q1z * q2w + q2z * q1w + cz;
            ans.W = q1w * q2w - dot;

            return ans;
        }

        /// <summary>
        /// Multiplies a Quaternion by a scalar value.
        /// </summary>
        /// <param name="value1">The source Quaternion.</param>
        /// <param name="value2">The scalar value.</param>
        /// <returns>The result of the multiplication.</returns>
        public static Quaternion Multiply(Quaternion value1, double value2)
        {
            Quaternion ans = new Quaternion();

            ans.X = value1.X * value2;
            ans.Y = value1.Y * value2;
            ans.Z = value1.Z * value2;
            ans.W = value1.W * value2;

            return ans;
        }

        /// <summary>
        /// Divides a Quaternion by another Quaternion.
        /// </summary>
        /// <param name="value1">The source Quaternion.</param>
        /// <param name="value2">The divisor.</param>
        /// <returns>The result of the division.</returns>
        public static Quaternion Divide(Quaternion value1, Quaternion value2)
        {
            Quaternion ans = new Quaternion();

            double q1x = value1.X;
            double q1y = value1.Y;
            double q1z = value1.Z;
            double q1w = value1.W;

            //-------------------------------------
            // Inverse part.
            double ls = value2.X * value2.X + value2.Y * value2.Y +
                       value2.Z * value2.Z + value2.W * value2.W;
            double invNorm = 1.0 / ls;

            double q2x = -value2.X * invNorm;
            double q2y = -value2.Y * invNorm;
            double q2z = -value2.Z * invNorm;
            double q2w = value2.W * invNorm;

            //-------------------------------------
            // Multiply part.

            // cross(av, bv)
            double cx = q1y * q2z - q1z * q2y;
            double cy = q1z * q2x - q1x * q2z;
            double cz = q1x * q2y - q1y * q2x;

            double dot = q1x * q2x + q1y * q2y + q1z * q2z;

            ans.X = q1x * q2w + q2x * q1w + cx;
            ans.Y = q1y * q2w + q2y * q1w + cy;
            ans.Z = q1z * q2w + q2z * q1w + cz;
            ans.W = q1w * q2w - dot;

            return ans;
        }

        /// <summary>
        /// Flips the sign of each component of the quaternion.
        /// </summary>
        /// <param name="value">The source Quaternion.</param>
        /// <returns>The negated Quaternion.</returns>
        public static Quaternion operator -(Quaternion value)
        {
            return Negate(value);
        }

        /// <summary>
        /// Adds two Quaternions element-by-element.
        /// </summary>
        /// <param name="value1">The first source Quaternion.</param>
        /// <param name="value2">The second source Quaternion.</param>
        /// <returns>The result of adding the Quaternions.</returns>
        public static Quaternion operator +(Quaternion value1, Quaternion value2)
        {
            return Add(value1, value2);
        }
        /// <summary>
        /// Subtracts one Quaternion from another.
        /// </summary>
        /// <param name="value1">The first source Quaternion.</param>
        /// <param name="value2">The second Quaternion, to be subtracted from the first.</param>
        /// <returns>The result of the subtraction.</returns>
        public static Quaternion operator -(Quaternion value1, Quaternion value2)
        {
            return Subtract(value1, value2);
        }

        /// <summary>
        /// Multiplies two Quaternions together.
        /// </summary>
        /// <param name="value1">The Quaternion on the left side of the multiplication.</param>
        /// <param name="value2">The Quaternion on the right side of the multiplication.</param>
        /// <returns>The result of the multiplication.</returns>
        public static Quaternion operator *(Quaternion value1, Quaternion value2)
        {
            return Multiply(value1, value2);
        }
        /// <summary>
        /// Multiplies a Quaternion by a scalar value.
        /// </summary>
        /// <param name="value1">The source Quaternion.</param>
        /// <param name="value2">The scalar value.</param>
        /// <returns>The result of the multiplication.</returns>
        public static Quaternion operator *(Quaternion value1, double value2)
        {
            return Multiply(value1, value2);
        }

        /// <summary>
        /// Divides a Quaternion by another Quaternion.
        /// </summary>
        /// <param name="value1">The source Quaternion.</param>
        /// <param name="value2">The divisor.</param>
        /// <returns>The result of the division.</returns>
        public static Quaternion operator /(Quaternion value1, Quaternion value2)
        {
            return Divide(value1, value2);
        }

        /// <summary>
        /// Returns a boolean indicating whether the two given Quaternions are equal.
        /// </summary>
        /// <param name="value1">The first Quaternion to compare.</param>
        /// <param name="value2">The second Quaternion to compare.</param>
        /// <returns>True if the Quaternions are equal; False otherwise.</returns>
        public static bool operator ==(Quaternion value1, Quaternion value2)
        {
            return value1.Equals(value2);
        }

        /// <summary>
        /// Returns a boolean indicating whether the two given Quaternions are not equal.
        /// </summary>
        /// <param name="value1">The first Quaternion to compare.</param>
        /// <param name="value2">The second Quaternion to compare.</param>
        /// <returns>True if the Quaternions are not equal; False if they are equal.</returns>
        public static bool operator !=(Quaternion value1, Quaternion value2)
        {
            return !value1.Equals(value2);
        }

        /// <summary>
        /// Returns a String representing this Quaternion instance.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            var ci = System.Globalization.CultureInfo.InvariantCulture;
            return string.Format(ci, "({0}, {1}, {2}, {3})", X.ToString(ci), Y.ToString(ci), Z.ToString(ci), W.ToString(ci));
        }

        /// <summary>
        /// IsAlmostEqualTo
        /// </summary>
        /// <param name="other"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public bool IsAlmostEqualTo(Quaternion other, double tolerance = Tolerance)
        {
            if (Math.Abs(this.X - other.X) < tolerance)
            {
                if (Math.Abs(this.Y - other.Y) < tolerance)
                {
                    if (Math.Abs(this.Z - other.Z) < tolerance)
                    {
                        if (Math.Abs(this.W - other.W) < tolerance)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Returns a boolean indicating whether the given Object is equal to this Quaternion instance.
        /// </summary>
        /// <param name="obj">The Object to compare against.</param>
        /// <returns>True if the Object is equal to this Quaternion; False otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Quaternion other)
            {
                return other.X == X && other.Y == Y && other.Z == Z && other.W == W;
            }
            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code.</returns>
        /// <remarks>( X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode() + W.GetHashCode() )</remarks>
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode() + W.GetHashCode();
        }
    }
}


