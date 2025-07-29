using Autodesk.Revit.DB;
using System;

namespace ricaun.Revit.DB.Shape
{
    /// <summary>
    /// Provides utility methods for creating <see cref="Autodesk.Revit.DB.CurveLoop"/> objects representing geometric shapes.
    /// </summary>
    public static class CurveLoopUtils
    {
        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.CurveLoop"/> representing a circle at the specified origin, normal, and radius.
        /// </summary>
        /// <param name="origin">
        /// The <see cref="Autodesk.Revit.DB.XYZ"/> point representing the center of the circle.
        /// </param>
        /// <param name="normal">
        /// The <see cref="Autodesk.Revit.DB.XYZ"/> vector representing the normal direction of the circle's plane.
        /// </param>
        /// <param name="radius">
        /// Optional. The radius of the circle. Default is 1.0.
        /// </param>
        /// <returns>
        /// A <see cref="Autodesk.Revit.DB.CurveLoop"/> containing two <see cref="Autodesk.Revit.DB.Arc"/> segments that together form a complete circle.
        /// </returns>
        public static CurveLoop CreateCircleLoop(XYZ origin, XYZ normal, double radius = 1.0)
        {
            CurveLoop loop = new CurveLoop();
            var arc1 = Arc.Create(Plane.CreateByNormalAndOrigin(normal, origin), radius, -Math.PI, 0);
            var arc2 = Arc.Create(Plane.CreateByNormalAndOrigin(normal, origin), radius, 0, Math.PI);
            loop.Append(arc1);
            loop.Append(arc2);
            return loop;
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.CurveLoop"/> representing a circle at the origin and normal derived from the specified <see cref="Autodesk.Revit.DB.Curve"/>.
        /// </summary>
        /// <param name="curve">
        /// The <see cref="Autodesk.Revit.DB.Curve"/> whose start point and tangent are used as the origin and normal for the circle's plane.
        /// </param>
        /// <param name="radius">
        /// Optional. The radius of the circle. Default is 1.0.
        /// </param>
        /// <returns>
        /// A <see cref="Autodesk.Revit.DB.CurveLoop"/> containing two <see cref="Autodesk.Revit.DB.Arc"/> segments that together form a complete circle.
        /// </returns>
        public static CurveLoop CreateCircleLoop(Curve curve, double radius = 1.0)
        {
            var origin = curve.Evaluate(0, true);
            var normal = curve.ComputeDerivatives(0, true).BasisX;
            return CreateCircleLoop(origin, normal, radius);
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.CurveLoop"/> representing a prism shape with the specified origin, normal, radius, and number of sides.
        /// </summary>
        /// <param name="origin">The <see cref="Autodesk.Revit.DB.XYZ"/> point representing the center of the prism's base.</param>
        /// <param name="normal">The <see cref="Autodesk.Revit.DB.XYZ"/> vector representing the normal direction of the prism's base plane.</param>
        /// <param name="radius">Optional. The radius of the prism's base. Default is 1.0.</param>
        /// <param name="sides">Optional. The number of sides for the prism's base. Default is 3.</param>
        /// <returns>
        /// A <see cref="Autodesk.Revit.DB.CurveLoop"/> containing <see cref="Line"/> segments that form a closed polygonal loop representing the prism's base.
        /// </returns>
        public static CurveLoop CreatePrismLoop(XYZ origin, XYZ normal, double radius = 1.0, int sides = 3)
        {
            CurveLoop loop = new CurveLoop();
            var points = XYZUtils.CreateCircleLoopSides(origin, normal, radius, sides);
            var lines = ShapeCreator.CreateLines(points, true);
            return CurveLoop.Create(lines);
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.CurveLoop"/> representing a prism shape with the specified curve, radius, and number of sides.
        /// </summary>
        /// <param name="curve">
        /// The <see cref="Autodesk.Revit.DB.Curve"/> whose start point and tangent are used as the origin and normal for the prism's base.
        /// </param>
        /// <param name="radius">
        /// Optional. The radius of the prism's base. Default is 1.0.
        /// </param>
        /// <param name="sides">
        /// Optional. The number of sides for the prism's base. Default is 3.
        /// </param>
        /// <returns>
        /// A <see cref="Autodesk.Revit.DB.CurveLoop"/> containing <see cref="Line"/> segments that form a closed polygonal loop representing the prism's base.
        /// </returns>
        public static CurveLoop CreatePrismLoop(Curve curve, double radius = 1.0, int sides = 3)
        {
            var origin = curve.Evaluate(0, true);
            var normal = curve.ComputeDerivatives(0, true).BasisX;
            return CreatePrismLoop(origin, normal, radius, sides);
        }
    }
}
