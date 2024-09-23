using Autodesk.Revit.DB;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Extensions
{
    /// <summary>
    /// Face extension
    /// </summary>
    public static class FaceExtension
    {
#if NET47_OR_GREATER || NET8_0_OR_GREATER
        /// <summary>
        /// Converts a Revit face to a solid.
        /// </summary>
        /// <param name="face">The face to convert.</param>
        /// <param name="materialId">The material ID to assign to the solid.</param>
        /// <returns>The converted solid.</returns>
        public static Solid ToSolid(this Face face, ElementId materialId = null)
        {
            BRepBuilder brepBuilder = new BRepBuilder(BRepType.OpenShell);

            var surface = face.GetSurface();
            var faceIsReversed = !face.OrientationMatchesSurfaceOrientation;
            BRepBuilderGeometryId faceId = brepBuilder.AddFace(BRepBuilderSurfaceGeometry.Create(surface, null), faceIsReversed);

            var curveLoops = face.GetEdgesAsCurveLoops();
            foreach (var curveLoop in curveLoops)
            {
                BRepBuilderGeometryId loopId = brepBuilder.AddLoop(faceId);
                var curves = curveLoop.OfType<Curve>();

                var edgeIds = curves.Select(curve =>
                {
                    BRepBuilderEdgeGeometry edgeId = BRepBuilderEdgeGeometry.Create(curve);
                    BRepBuilderGeometryId geoEdgeId = brepBuilder.AddEdge(edgeId);
                    return geoEdgeId;
                }).ToList();

                foreach (var edgeId in edgeIds)
                {
                    brepBuilder.AddCoEdge(loopId, edgeId, false);
                }

                brepBuilder.FinishLoop(loopId);
            }

            brepBuilder.SetFaceMaterialId(faceId, face.MaterialElementId);

            if (materialId != null)
                brepBuilder.SetFaceMaterialId(faceId, materialId);

            brepBuilder.FinishFace(faceId);

            var outcome = brepBuilder.Finish();

            return brepBuilder.GetResult();
        }
#endif
    }
}
