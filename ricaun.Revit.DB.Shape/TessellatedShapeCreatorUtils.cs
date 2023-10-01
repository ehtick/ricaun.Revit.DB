using Autodesk.Revit.DB;
using System;

namespace ricaun.Revit.DB.Shape
{
    /// <summary>
    /// TessellatedShapeCreatorUtils
    /// </summary>
    public static class TessellatedShapeCreatorUtils
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
    }
}
