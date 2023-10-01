using Autodesk.Revit.DB;

namespace ricaun.Revit.DB.Shape.Extensions
{
    /// <summary>
    /// SolidExtension
    /// </summary>
    public static class SolidExtension
    {
        /// <summary>
        /// Union between two solids.
        /// </summary>
        /// <param name="solid"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static Solid Union(this Solid solid, Solid other)
        {
            return BooleanOperationsUtils.ExecuteBooleanOperation(solid, other, BooleanOperationsType.Union);
        }

        /// <summary>
        /// Intersect between two solids.
        /// </summary>
        /// <param name="solid"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static Solid Intersect(this Solid solid, Solid other)
        {
            return BooleanOperationsUtils.ExecuteBooleanOperation(solid, other, BooleanOperationsType.Intersect);
        }

        /// <summary>
        /// Difference between two solids.
        /// </summary>
        /// <param name="solid"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static Solid Difference(this Solid solid, Solid other)
        {
            return BooleanOperationsUtils.ExecuteBooleanOperation(solid, other, BooleanOperationsType.Difference);
        }

        /// <summary>
        /// Creates a new Solid which is the transformation of the input Solid.
        /// </summary>
        /// <param name="solid">The solid to be transformed.</param>
        /// <param name="transform">The transform (which must be conformal).</param>
        /// <returns></returns>
        public static Solid CreateTransformed(this Solid solid, Transform transform)
        {
            return SolidUtils.CreateTransformed(solid, transform);
        }

        /// <summary>
        /// Creates a new Solid which is a copy of the input Solid.
        /// </summary>
        /// <param name="solid">The solid to be cloned.</param>
        /// <returns></returns>
        public static Solid Clone(this Solid solid)
        {
            return SolidUtils.Clone(solid);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid.
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid ScaleCentroid(this Solid solid, double scale)
        {
            var center = solid.ComputeCentroid();
            return solid.Scale(scale, center);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid.
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid ScaleBotton(this Solid solid, double scale)
        {
            var center = solid.ComputeCentroid();
            var box = solid.GetBoundingBox();
            center = new XYZ(center.X, center.Y, box.Min.Z);
            return solid.Scale(scale, center);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid.
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid ScaleTop(this Solid solid, double scale)
        {
            var center = solid.ComputeCentroid();
            var box = solid.GetBoundingBox();
            center = new XYZ(center.X, center.Y, box.Max.Z);
            return solid.Scale(scale, center);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid.
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid ScaleLeft(this Solid solid, double scale)
        {
            var center = solid.ComputeCentroid();
            var box = solid.GetBoundingBox();
            center = new XYZ(box.Min.X, center.Y, center.Z);
            return solid.Scale(scale, center);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid.
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid ScaleRight(this Solid solid, double scale)
        {
            var center = solid.ComputeCentroid();
            var box = solid.GetBoundingBox();
            center = new XYZ(box.Max.X, center.Y, center.Z);
            return solid.Scale(scale, center);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid.
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid ScaleFront(this Solid solid, double scale)
        {
            var center = solid.ComputeCentroid();
            var box = solid.GetBoundingBox();
            center = new XYZ(center.X, box.Min.Y, center.Z);
            return solid.Scale(scale, center);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid.
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid ScaleBack(this Solid solid, double scale)
        {
            var center = solid.ComputeCentroid();
            var box = solid.GetBoundingBox();
            center = new XYZ(center.X, box.Max.Y, center.Z);
            return solid.Scale(scale, center);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid.
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <param name="origin">The origin of the scale.</param>
        /// <returns></returns>
        public static Solid Scale(this Solid solid, double scale, XYZ origin)
        {
            var transform = Transform.CreateTranslation(-origin);
            solid = solid.CreateTransformed(transform.ScaleBasisAndOrigin(scale));
            return solid.CreateTransformed(Transform.CreateTranslation(origin));
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid.
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid Scale(this Solid solid, double scale)
        {
            var transform = Transform.Identity.ScaleBasis(scale);
            return solid.CreateTransformed(transform);
        }
    }
}
