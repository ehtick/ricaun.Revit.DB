using Autodesk.Revit.DB;
using System.Linq;

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
        /// Creates a new Solid which is the transformation of the input Solid.
        /// </summary>
        /// <param name="solids">The solids to be transformed.</param>
        /// <param name="transform">The transform (which must be conformal).</param>
        /// <returns></returns>
        public static Solid[] CreateTransformed(this Solid[] solids, Transform transform)
        {
            return solids.Select(solid => solid.CreateTransformed(transform)).ToArray();
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
            var origin = solid.GetOrigin();
            return solid.Scale(scale, origin);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid. (Origin.X, Origin.Y, Min.Z)
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid ScaleBotton(this Solid solid, double scale)
        {
            var origin = solid.GetOrigin();
            var box = solid.GetBoundingBox();
            origin = new XYZ(origin.X, origin.Y, box.Min.Z);
            return solid.Scale(scale, origin);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid. (Origin.X, Origin.Y, Max.Z)
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid ScaleTop(this Solid solid, double scale)
        {
            var origin = solid.GetOrigin();
            var box = solid.GetBoundingBox();
            origin = new XYZ(origin.X, origin.Y, box.Max.Z);
            return solid.Scale(scale, origin);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid. (Min.X, Origin.Y, Origin.Z)
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid ScaleLeft(this Solid solid, double scale)
        {
            var origin = solid.GetOrigin();
            var box = solid.GetBoundingBox();
            origin = new XYZ(box.Min.X, origin.Y, origin.Z);
            return solid.Scale(scale, origin);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid. (Max.X, Origin.Y, Origin.Z)
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid ScaleRight(this Solid solid, double scale)
        {
            var origin = solid.GetOrigin();
            var box = solid.GetBoundingBox();
            origin = new XYZ(box.Max.X, origin.Y, origin.Z);
            return solid.Scale(scale, origin);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid. (Origin.X, Min.Y, Origin.Z)
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid ScaleFront(this Solid solid, double scale)
        {
            var origin = solid.GetOrigin();
            var box = solid.GetBoundingBox();
            origin = new XYZ(origin.X, box.Min.Y, origin.Z);
            return solid.Scale(scale, origin);
        }

        /// <summary>
        /// Creates a new Solid which is the scaled of the input Solid. (Origin.X, Max.Y, Origin.Z)
        /// </summary>
        /// <param name="solid">The solid to be scaled.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns></returns>
        public static Solid ScaleBack(this Solid solid, double scale)
        {
            var origin = solid.GetOrigin();
            var box = solid.GetBoundingBox();
            origin = new XYZ(origin.X, box.Max.Y, origin.Z);
            return solid.Scale(scale, origin);
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

        /// <summary>
        /// GetOrigin using bounding box transform origin
        /// </summary>
        /// <param name="solid"></param>
        /// <returns></returns>
        public static XYZ GetOrigin(this Solid solid)
        {
            return solid.GetBoundingBox().Transform.Origin;
        }
    }
}
