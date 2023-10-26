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
        /// GetIndices from Solid faces
        /// </summary>
        /// <param name="solid"></param>
        /// <returns></returns>
        public static IList<int> GetIndices(this Solid solid)
        {
            var count = 0;
            var indices = new List<int>();
            foreach (var face in solid.GetFaces())
            {
                var i = face.GetIndices().Select(e => e + count);
                indices.AddRange(i);
                count += face.GetVertices().Count;
            }
            return indices;
        }
        /// <summary>
        /// GetTriangleVertices from Solid faces
        /// </summary>
        /// <param name="solid"></param>
        /// <returns></returns>
        public static IList<XYZ> GetTriangleVertices(this Solid solid)
        {
            var vertices = solid.GetVertices();
            var triangleVertices = solid.GetIndices()
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
        /// GetIndices
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static IList<int> GetIndices(this Face face)
        {
            return face.Triangulate().GetIndices();
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
        #region LevelOfDetail
        /// <summary>
        /// GetVertices from Solid faces
        /// </summary>
        /// <param name="solid"></param>
        /// <param name="levelOfDetail"></param>
        /// <returns></returns>
        public static IList<XYZ> GetVertices(this Solid solid, double levelOfDetail)
        {
            return solid.GetFaces()
                .SelectMany(e => e.GetVertices(levelOfDetail))
                .ToList();
        }
        /// <summary>
        /// GetIndices from Solid faces
        /// </summary>
        /// <param name="solid"></param>
        /// <param name="levelOfDetail"></param>
        /// <returns></returns>
        public static IList<int> GetIndices(this Solid solid, double levelOfDetail)
        {
            var count = 0;
            var indices = new List<int>();
            foreach (var face in solid.GetFaces())
            {
                var i = face.GetIndices(levelOfDetail).Select(e => e + count);
                indices.AddRange(i);
                count += face.GetVertices(levelOfDetail).Count;
            }
            return indices;
        }
        /// <summary>
        /// GetTriangleVertices from Solid faces
        /// </summary>
        /// <param name="solid"></param>
        /// <param name="levelOfDetail"></param>
        /// <returns></returns>
        public static IList<XYZ> GetTriangleVertices(this Solid solid, double levelOfDetail)
        {
            var vertices = solid.GetVertices(levelOfDetail);
            var triangleVertices = solid.GetIndices(levelOfDetail)
                .Select(e => vertices[e])
                .ToList();

            return triangleVertices;
        }
        /// <summary>
        /// GetVertices
        /// </summary>
        /// <param name="face"></param>
        /// <param name="levelOfDetail"></param>
        /// <returns></returns>
        public static IList<XYZ> GetVertices(this Face face, double levelOfDetail)
        {
            return face.Triangulate(levelOfDetail).GetVertices();
        }

        /// <summary>
        /// GetIndices
        /// </summary>
        /// <param name="face"></param>
        /// <param name="levelOfDetail"></param>
        /// <returns></returns>
        public static IList<int> GetIndices(this Face face, double levelOfDetail)
        {
            return face.Triangulate(levelOfDetail).GetIndices();
        }

        /// <summary>
        /// GetTriangleVertices
        /// </summary>
        /// <param name="face"></param>
        /// <param name="levelOfDetail"></param>
        /// <returns></returns>
        public static IList<XYZ> GetTriangleVertices(this Face face, double levelOfDetail)
        {
            return face.Triangulate(levelOfDetail).GetTriangleVertices();
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
            var triangleVertices = mesh.GetIndices()
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
        /// Get indices for the <see cref="Mesh.Vertices"/>
        /// </summary>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static IList<int> GetIndices(this Mesh mesh)
        {
            var indices = new List<int>();
            for (int i = 0; i < mesh.NumTriangles; i++)
            {
                MeshTriangle triangle = mesh.get_Triangle(i);
                for (int j = 0; j < 3; j++)
                {
                    var index = triangle.get_Index(j);
                    indices.Add((int)index);
                }
            }
            return indices;
        }
        #endregion
    }
}
