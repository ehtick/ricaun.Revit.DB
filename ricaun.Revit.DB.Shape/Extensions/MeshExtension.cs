using Autodesk.Revit.DB;

namespace ricaun.Revit.DB.Shape.Extensions
{
    /// <summary>
    /// MeshExtension
    /// </summary>
    public static class MeshExtension
    {
        /// <summary>
        /// Creates a new Mesh which is the transformation of the input Mesh.
        /// </summary>
        /// <param name="mesh">The mesh to be transformed.</param>
        /// <param name="transform">The transform (which must be conformal).</param>
        /// <returns></returns>
        public static Mesh CreateTransformed(this Mesh mesh, Transform transform)
        {
            return mesh.get_Transformed(transform);
        }
    }
}
