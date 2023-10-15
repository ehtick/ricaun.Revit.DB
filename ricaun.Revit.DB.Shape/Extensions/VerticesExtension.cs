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
        #region Solid
        internal static IEnumerable<Face> GetFaces(this Solid solid) => solid.Faces.OfType<Face>();
        /// <summary>
        /// GetVertices from Solid faces
        /// </summary>
        /// <param name="solid"></param>
        /// <returns></returns>
        public static IList<XYZ> GetVertices(this Solid solid)
        {
            return solid.GetFaces()
                .SelectMany(e => e.GetVertices())
                .ToList();
        }
        /// <summary>
        /// GetIndexes from Solid faces
        /// </summary>
        /// <param name="solid"></param>
        /// <returns></returns>
        public static IList<int> GetIndexes(this Solid solid)
        {
            var count = 0;
            var indexes = new List<int>();
            foreach (var face in solid.GetFaces())
            {
                var i = face.GetIndexes()
                    .Select(e => e + count);
                indexes.AddRange(i);
                count += face.GetVertices().Count;
            }
            return indexes;
        }
        /// <summary>
        /// GetTriangleVertices from Solid faces
        /// </summary>
        /// <param name="solid"></param>
        /// <returns></returns>
        public static IList<XYZ> GetTriangleVertices(this Solid solid)
        {
            var vertices = solid.GetVertices();
            var triangleVertices = solid.GetIndexes()
                .Select(e => vertices[e])
                .ToList();

            return triangleVertices;
        }
        #endregion
        #region Face
        /// <summary>
        /// GetVertices
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static IList<XYZ> GetVertices(this Face face)
        {
            return face.Triangulate().GetVertices();
        }

        /// <summary>
        /// GetIndexes
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static IList<int> GetIndexes(this Face face)
        {
            return face.Triangulate().GetIndexes();
        }

        /// <summary>
        /// GetTriangleVertices
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static IList<XYZ> GetTriangleVertices(this Face face)
        {
            return face.Triangulate().GetTriangleVertices();
        }
        #endregion

        #region Mesh
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
        #endregion
    }
}
