using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Extensions
{
    /// <summary>
    /// VerticesExtension
    /// </summary>
    public static class VerticesExtension
    {
        /// <summary>
        /// Get of Vertices in a list for each Triangles
        /// </summary>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static IList<XYZ> GetTriangleVertices(this Mesh mesh)
        {
            var vertices = mesh.GetVertices();
            var triangleVertices = mesh.GetIndexes()
                .Select(e => vertices[e])
                .ToList();

            return triangleVertices;
            //var triangleVertices = new List<XYZ>();
            //for (int i = 0; i < mesh.NumTriangles; i++)
            //{
            //    MeshTriangle triangle = mesh.get_Triangle(i);
            //    for (int j = 0; j < 3; j++)
            //    {
            //        var vertex = triangle.get_Vertex(j);
            //        triangleVertices.Add(vertex);
            //    }
            //}
            //return triangleVertices;
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
        public static IList<int> GetIndexes(this Mesh mesh)
        {
            var indexes = new List<int>();
            for (int i = 0; i < mesh.NumTriangles; i++)
            {
                MeshTriangle triangle = mesh.get_Triangle(i);
                for (int j = 0; j < 3; j++)
                {
                    var index = triangle.get_Index(j);
                    indexes.Add((int)index);
                }
            }
            return indexes;
        }
    }
}
