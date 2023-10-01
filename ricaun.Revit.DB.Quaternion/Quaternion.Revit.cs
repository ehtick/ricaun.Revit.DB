using Autodesk.Revit.DB;
using System;
using System.Runtime.CompilerServices;

namespace ricaun.Revit.DB.Quaternion
{
    public partial class Quaternion
    {
        /// <summary>
        /// Constructs a Quaternion from the given vector and rotation parts.
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="scale"></param>
        public Quaternion(XYZ vector, double scale)
        {
            this.X = vector.X;
            this.Y = vector.Y;
            this.Z = vector.Z;
            this.W = scale;
        }

        /// <summary>
        /// Creates a quaternion from the given axis and angle.
        /// </summary>
        /// <param name="axis">The axis.</param>
        /// <param name="angle">The angle in radians.</param>
        /// <returns>A new quaternion created from the given axis and angle.</returns>
        public static Quaternion CreateFromAxisAngle(XYZ axis, double angle)
        {
            axis = axis.Normalize();
            return CreateFromAxisAngle(axis.X, axis.Y, axis.Z, angle);
        }

        /// <summary>
        /// Transforms a vector by the given Quaternion rotation value.
        /// </summary>
        /// <param name="value">The source vector to be rotated.</param>
        /// <param name="quaternion">The rotation to apply.</param>
        /// <returns>The transformed vector.</returns>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XYZ Transform(XYZ value, Quaternion quaternion)
        {
            var scale = quaternion.LengthSquared();
            quaternion = Quaternion.Normalize(quaternion);

            double x2 = quaternion.X + quaternion.X;
            double y2 = quaternion.Y + quaternion.Y;
            double z2 = quaternion.Z + quaternion.Z;

            double wx2 = quaternion.W * x2;
            double wy2 = quaternion.W * y2;
            double wz2 = quaternion.W * z2;
            double xx2 = quaternion.X * x2;
            double xy2 = quaternion.X * y2;
            double xz2 = quaternion.X * z2;
            double yy2 = quaternion.Y * y2;
            double yz2 = quaternion.Y * z2;
            double zz2 = quaternion.Z * z2;

            return scale * new XYZ(
                value.X * (1.0 - yy2 - zz2) + value.Y * (xy2 - wz2) + value.Z * (xz2 + wy2),
                value.X * (xy2 + wz2) + value.Y * (1.0 - xx2 - zz2) + value.Z * (yz2 - wx2),
                value.X * (xz2 - wy2) + value.Y * (yz2 + wx2) + value.Z * (1.0 - xx2 - yy2));
        }

        /// <summary>
        /// Transforms a vector by the given Quaternion rotation value.
        /// </summary>
        /// <param name="value">The source vector to be rotated.</param>
        /// <returns>The transformed vector.</returns>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XYZ Transform(XYZ value)
        {
            return Transform(value, this);
        }

        /// <summary>
        /// Transforms a vector by the given Quaternion rotation value.
        /// </summary>
        /// <param name="value">The source vector to be rotated.</param>
        /// <param name="quaternion">The rotation to apply.</param>
        /// <returns>The transformed vector.</returns>
        public static XYZ operator *(XYZ value, Quaternion quaternion)
        {
            return quaternion.Transform(value);
        }
    }

}
