using Autodesk.Revit.DB;

namespace ricaun.Revit.DB.Shape.Extensions
{
    /// <summary>
    /// PointExtension
    /// </summary>
    public static class PointExtension
    {
        /// <summary>
        /// Creates a new Point which is the transformation of the input Point.
        /// </summary>
        /// <param name="point">The point to be transformed.</param>
        /// <param name="transform">The transform (which must be conformal).</param>
        /// <returns></returns>
        public static Point CreateTransformed(this Point point, Transform transform)
        {
            var coord = transform.OfPoint(point.Coord);
            return Point.Create(coord);
        }
    }
}
