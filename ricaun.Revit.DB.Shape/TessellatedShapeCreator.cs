using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Shape
{
    /// <summary>
    /// TessellatedShapeCreator
    /// </summary>
    public static class TessellatedShapeCreator
    {
        /// <summary>
        /// Create <see cref="Autodesk.Revit.DB.TessellatedShapeBuilder"/> using <paramref name="actionBuilder"/>.
        /// </summary>
        /// <param name="actionBuilder"></param>
        /// <returns>The result of the TessellatedShapeBuilder</returns>
        /// <remarks>The Target equal to <see cref="Autodesk.Revit.DB.TessellatedShapeBuilderTarget.AnyGeometry"/> and Fallback equals to  <see cref="Autodesk.Revit.DB.TessellatedShapeBuilderFallback.Mesh"/></remarks>
        public static TessellatedShapeBuilderResult Create(Action<TessellatedShapeBuilder> actionBuilder)
        {
            TessellatedShapeBuilder builder = new TessellatedShapeBuilder();
            builder.Target = TessellatedShapeBuilderTarget.AnyGeometry;
            builder.Fallback = TessellatedShapeBuilderFallback.Mesh;
            builder.OpenConnectedFaceSet(false);
            actionBuilder?.Invoke(builder);
            builder.CloseConnectedFaceSet();
            builder.Build();
            TessellatedShapeBuilderResult result = builder.GetBuildResult();
            return result;
        }

        /// <summary>
        /// Create Mesh or Solid from vertices and indexes.
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="indexes"></param>
        /// <param name="materialIds"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        public static TessellatedShapeBuilderResult CreateMesh(
            XYZ[] vertices,
            int[] indexes = null,
            ElementId[] materialIds = null,
            ElementId graphicsStyleId = null)
        {
            var result = TessellatedShapeCreator.Create(builder =>
            {
                if (graphicsStyleId is ElementId) builder.GraphicsStyleId = graphicsStyleId;
                if (indexes is null) indexes = Enumerable.Range(0, vertices.Length).ToArray();

                var loopVertices = new List<XYZ>();

                for (int i = 0; i < indexes.Length; i += 3)
                {
                    var p1 = vertices[indexes[i + 0]];
                    var p2 = vertices[indexes[i + 1]];
                    var p3 = vertices[indexes[i + 2]];

                    var materialId = ElementId.InvalidElementId;
                    if (materialIds is ElementId[])
                    {
                        materialId = materialIds[(i / 3) % materialIds.Length];
                    }

                    loopVertices.Add(p1);
                    loopVertices.Add(p2);
                    loopVertices.Add(p3);

                    TessellatedFace face = new TessellatedFace(loopVertices, materialId);
                    if (builder.DoesFaceHaveEnoughLoopsAndVertices(face))
                    {
                        builder.AddFace(face);
                    }
                    loopVertices.Clear();
                }
            });
            return result;
        }

        /// <summary>
        /// Get Geometrical Objects of the TessellatedShapeBuilderResult
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> OfType<TResult>(this TessellatedShapeBuilderResult result)
        {
            if (result.AreObjectsAvailable)
            {
                return result.GetGeometricalObjects().OfType<TResult>();
            }
            return Enumerable.Empty<TResult>();
        }
    }
}
