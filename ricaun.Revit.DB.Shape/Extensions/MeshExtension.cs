using Autodesk.Revit.DB;
using System.Collections.Generic;

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

        /// <summary>
        /// Get of Vertices in a list for each Triangles
        /// </summary>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static IList<XYZ> GetTriangleVertices(this Mesh mesh)
        {
            var triangleVertices = new List<XYZ>();
            for (int i = 0; i < mesh.NumTriangles; i++)
            {
                MeshTriangle triangle = mesh.get_Triangle(i);
                for (int j = 0; j < 3; j++)
                {
                    var vertex = triangle.get_Vertex(j);
                    triangleVertices.Add(vertex);
                }
            }
            return triangleVertices;
        }

        /// <summary>
        /// Get vertices using <see cref="Mesh.Vertices"/>
        /// </summary>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static IList<XYZ> GetVertices(this Mesh mesh)
        {
            return mesh.Vertices;
        }

        /// <summary>
        /// Get indexes for the <see cref="Mesh.Vertices"/>
        /// </summary>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static IList<uint> GetIndexes(this Mesh mesh)
        {
            var indexes = new List<uint>();
            for (int i = 0; i < mesh.NumTriangles; i++)
            {
                MeshTriangle triangle = mesh.get_Triangle(i);
                for (int j = 0; j < 3; j++)
                {
                    var index = triangle.get_Index(j);
                    indexes.Add(index);
                }
            }
            return indexes;
        }
    }
}
