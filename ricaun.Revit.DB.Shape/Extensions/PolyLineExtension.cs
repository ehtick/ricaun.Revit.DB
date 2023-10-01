using Autodesk.Revit.DB;

namespace ricaun.Revit.DB.Shape.Extensions
{
    /// <summary>
    /// PolyLineExtension
    /// </summary>
    public static class PolyLineExtension
    {
        /// <summary>
        /// Creates a new PolyLine which is the transformation of the input PolyLine.
        /// </summary>
        /// <param name="polyLine">The polyLine to be transformed.</param>
        /// <param name="transform">The transform (which must be conformal).</param>
        /// <returns></returns>
        public static PolyLine CreateTransformed(this PolyLine polyLine, Transform transform)
        {
            return polyLine.GetTransformed(transform);
        }
    }
}
