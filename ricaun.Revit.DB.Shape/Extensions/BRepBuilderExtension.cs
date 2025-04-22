#if NET47_OR_GREATER || NET8_0_OR_GREATER
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Extensions
{
    /// <summary>
    /// BRepBuilder extension
    /// </summary>
    public static class BRepBuilderExtension
    {
        /// <summary>
        /// Create and copy the face to a new solid instance.
        /// </summary>
        /// <param name="face">The face to convert.</param>
        /// <param name="materialId">The material ID to assign to the solid.</param>
        /// <returns>The converted solid.</returns>
        /// <exception cref="System.InvalidOperationException">Failed to create the solid.</exception>
        /// <remarks>This method uses <see cref="Autodesk.Revit.DB.BRepBuilder"/> to create the solid.</remarks>
        public static Solid CreateSolid(this Face face, ElementId materialId = null)
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

            if (outcome == BRepBuilderOutcome.Failure)
                throw new InvalidOperationException("Failed to create the solid.");

            return brepBuilder.GetResult();
        }

        /// <summary>
        /// Create and copy the solid to a new solid instance.
        /// </summary>
        /// <param name="solid">The solid to convert.</param>
        /// <param name="materialId">The material ID to assign to the solid.</param>
        /// <returns>The converted solid.</returns>
        /// <exception cref="System.InvalidOperationException">Failed to create the solid.</exception>
        /// <remarks>This method uses <see cref="Autodesk.Revit.DB.BRepBuilder"/> to create the solid.</remarks>
        public static Solid CreateSolid(this Solid solid, ElementId materialId = null)
        {
            BRepBuilder brepBuilder = new BRepBuilder(BRepType.Solid);

            var bRepBuilderGeometryId = new Dictionary<Curve, BRepBuilderGeometryId>();
            var solidEdges = solid.Edges.OfType<Edge>();

            foreach (var edge in solidEdges)
            {
                var curve = edge.AsCurve();
                BRepBuilderEdgeGeometry edgeId = BRepBuilderEdgeGeometry.Create(curve);
                BRepBuilderGeometryId geoEdgeId = brepBuilder.AddEdge(edgeId);
                bRepBuilderGeometryId.Add(curve, geoEdgeId);
            }

            foreach (Face face in solid.Faces.OfType<Face>())
            {
                var surface = face.GetSurface();

                if (BRepBuilder.IsPermittedSurfaceType(surface) == false)
                    continue;

                var faceIsReversed = !face.OrientationMatchesSurfaceOrientation;
                BRepBuilderGeometryId faceId = brepBuilder.AddFace(BRepBuilderSurfaceGeometry.Create(surface, null), faceIsReversed);

                var curveLoops = face.GetEdgesAsCurveLoops();
                foreach (var curveLoop in curveLoops)
                {
                    BRepBuilderGeometryId loopId = brepBuilder.AddLoop(faceId);
                    foreach (var curveFace in curveLoop.OfType<Curve>())
                    {
                        var edgeCurve = bRepBuilderGeometryId.Keys.FirstOrDefault(e => IsAlmostEqualTo(e, curveFace));
                        var edgeId = bRepBuilderGeometryId[edgeCurve];

                        var edgeIsReversed = IsAlmostEqualTo(edgeCurve, curveFace, false);

                        brepBuilder.AddCoEdge(loopId, edgeId, !edgeIsReversed);
                    }
                    brepBuilder.FinishLoop(loopId);
                }

                brepBuilder.SetFaceMaterialId(faceId, face.MaterialElementId);

                if (materialId != null)
                    brepBuilder.SetFaceMaterialId(faceId, materialId);

                brepBuilder.FinishFace(faceId);
            }

            var outcome = brepBuilder.Finish();

            if (outcome == BRepBuilderOutcome.Failure)
                throw new InvalidOperationException("Failed to create the solid.");

            return brepBuilder.GetResult();
        }

        /// <summary>
        /// Create and copy the solid to a new solid instance.
        /// </summary>
        /// <param name="solid">The solid to convert.</param>
        /// <param name="materialId">The material ID to assign to the solid.</param>
        /// <returns>The converted solid.</returns>
        /// <exception cref="System.InvalidOperationException">Failed to create the solid.</exception>
        /// <remarks>This method uses <see cref="Autodesk.Revit.DB.BRepBuilder"/> to create the solid.</remarks>
        public static Solid CreateOpenShell(this Solid solid, ElementId materialId = null)
        {
            BRepBuilder brepBuilder = new BRepBuilder(BRepType.OpenShell);

            foreach (Face face in solid.Faces.OfType<Face>())
            {
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
            }

            var outcome = brepBuilder.Finish();

            if (outcome == BRepBuilderOutcome.Failure)
                throw new InvalidOperationException("Failed to create the solid.");

            return brepBuilder.GetResult();
        }

        internal static bool IsAlmostEqualTo(Curve curve1, Curve curve2, bool similarReversed = true)
        {
            if (curve1.GetType() != curve2.GetType())
                return false;

            if (curve1.ApproximateLength.IsAlmostEqualTo(curve2.ApproximateLength) == false)
                return false;

            var t1 = curve1.Tessellate();
            var t2 = curve2.Tessellate();

            if (t1.Count != t2.Count)
                return false;

            var t1First = t1[0];
            var t1Last = t1[t1.Count - 1];
            var t2First = t2[0];
            var t2Last = t2[t2.Count - 1];

            var equalPointFirst = (t1First - t2First).IsZeroLength();
            var equalPointLast = (t1First - t2Last).IsZeroLength();

            var equalsPoints = t1First.IsAlmostEqualTo(t2First, Tolerance) && t1Last.IsAlmostEqualTo(t2Last, Tolerance);

            if (similarReversed == false)
                return equalsPoints;

            var equalsPointsInverted = t1First.IsAlmostEqualTo(t2Last, Tolerance) && t1Last.IsAlmostEqualTo(t2First, Tolerance);

            return equalsPoints || equalsPointsInverted;
        }

        /// <summary>
        /// Tolerance of the Almost
        /// </summary>
        private const double Tolerance = 1.0E-9;

        /// <summary>
        /// <paramref name="a"/> is almost Zero by <paramref name="tolerance"/>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        internal static bool IsAlmostZero(this double a, double tolerance = Tolerance)
        {
            return tolerance > Math.Abs(a);
        }

        /// <summary>
        /// <paramref name="a"/> is almost Equal to <paramref name="b"/> by <paramref name="tolerance"/>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        internal static bool IsAlmostEqualTo(this double a, double b, double tolerance = Tolerance)
        {
            return IsAlmostZero(b - a, tolerance);
        }
    }
}
#endif