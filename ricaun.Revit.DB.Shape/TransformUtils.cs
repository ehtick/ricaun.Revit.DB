using Autodesk.Revit.DB;
using System;

namespace ricaun.Revit.DB.Shape
{
    /// <summary>
    /// TransformUtils
    /// </summary>
    public static class TransformUtils
    {
        const double Tolerance = 1e-9;
        private const double SCALE = 1.0;

        /// <summary>
        /// Create Transform to point to <paramref name="axisZ"/> in <see cref="Autodesk.Revit.DB.Transform.BasisZ"/> direction.
        /// </summary>
        /// <param name="axisZ"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Transform CreateRotation(XYZ axisZ, double scale = SCALE)
        {
            if (axisZ.IsZeroLength()) axisZ = XYZ.BasisZ;
            axisZ = axisZ.Normalize();

            var transform = Transform.Identity;
            var normal = transform.BasisZ;
            var rotate = transform.BasisX;
            var angle = axisZ.AngleTo(normal);

            if (Math.Sin(angle) > Tolerance)
                rotate = normal.CrossProduct(axisZ);

            transform = Transform.CreateRotation(rotate, angle)
                .ScaleBasis(scale);

            return transform;
        }

        /// <summary>
        /// Create Transform to point to <paramref name="axisZ"/> in <see cref="Autodesk.Revit.DB.Transform.BasisZ"/> direction and <paramref name="axisX"/> in <see cref="Autodesk.Revit.DB.Transform.BasisX"/>. 
        /// </summary>
        /// <param name="axisZ"></param>
        /// <param name="axisX"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Transform CreateRotationX(XYZ axisZ, XYZ axisX, double scale = SCALE)
        {
            if (axisX.IsZeroLength()) axisX = XYZ.BasisX;
            if (axisZ.IsZeroLength()) axisZ = XYZ.BasisZ;
            axisX = axisX.Normalize();
            axisZ = axisZ.Normalize();

            var transform = CreateRotation(axisZ, scale);

            var normal = transform.BasisX;
            var angle = axisX.AngleTo(normal);

            var transformX = Transform.CreateRotation(axisZ, angle);

            var result = transformX * transform;

            var isBasisEqual = (result.BasisX - axisX * scale).IsZeroLength();
            if (isBasisEqual)
                return result;

            var transformXNegative = Transform.CreateRotation(axisZ, -angle);
            result = transformXNegative * transform;
            return result;
        }

        /// <summary>
        /// Create Transform to point to <paramref name="axisZ"/> in <see cref="Autodesk.Revit.DB.Transform.BasisZ"/> direction and <paramref name="axisY"/> in <see cref="Autodesk.Revit.DB.Transform.BasisY"/>. 
        /// </summary>
        /// <param name="axisZ"></param>
        /// <param name="axisY"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Transform CreateRotationY(XYZ axisZ, XYZ axisY, double scale = SCALE)
        {
            if (axisY.IsZeroLength()) axisY = XYZ.BasisY;
            if (axisZ.IsZeroLength()) axisZ = XYZ.BasisZ;
            axisY = axisY.Normalize();
            axisZ = axisZ.Normalize();

            var transform = CreateRotation(axisZ, scale);

            var normal = transform.BasisY;
            var angle = axisY.AngleTo(normal);
            var transformY = Transform.CreateRotation(axisZ, angle);

            var result = transformY * transform;

            var isBasisEqual = (result.BasisY - axisY * scale).IsZeroLength();
            if (isBasisEqual)
                return result;

            var transformNegative = Transform.CreateRotation(axisZ, -angle);
            result = transformNegative * transform;

            return result;
        }
    }
}
