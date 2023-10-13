using Autodesk.Revit.DB;
using ricaun.Revit.DB.Shape.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Shape
{
    /// <summary>
    /// Provides static methods for creating various shapes.
    /// </summary>
    public static class ShapeCreator
    {
        #region Box
        /// <summary>
        /// Creates an array of lines representing the edges of a 3D box with the specified minimum and maximum points.
        /// </summary>
        /// <param name="center">The center point of the box.</param>
        /// <param name="scaleRadius">The scale size of the box.</param>
        /// <returns>An array of lines representing the edges of the 3D box.</returns>
        public static Line[] CreateBoxLines(XYZ center, double scaleRadius)
        {
            var scaleXYZ = new XYZ(scaleRadius, scaleRadius, scaleRadius);
            return CreateBoxLines(center - scaleXYZ, center + scaleXYZ);
        }

        /// <summary>
        /// Creates an array of lines representing the edges of a 3D box with the specified minimum and maximum points.
        /// </summary>
        /// <param name="min">The minimum point of the box. This point defines the lower corner of the box.</param>
        /// <param name="max">The maximum point of the box. This point defines the upper corner of the box.</param>
        /// <returns>An array of lines representing the edges of the 3D box.</returns>
        /// <remarks>Ignore Lines with distance too short.</remarks>
        public static Line[] CreateBoxLines(XYZ min, XYZ max)
        {
            // Create an array to store the lines
            Line[] lines = new Line[12];

            // Calculate the vertices of the cube
            XYZ[] vertices = {
                new XYZ(min.X, min.Y, min.Z),
                new XYZ(max.X, min.Y, min.Z),
                new XYZ(max.X, max.Y, min.Z),
                new XYZ(min.X, max.Y, min.Z),
                new XYZ(min.X, min.Y, max.Z),
                new XYZ(max.X, min.Y, max.Z),
                new XYZ(max.X, max.Y, max.Z),
                new XYZ(min.X, max.Y, max.Z)
            };

            // Create the lines for each edge of the cube using a for loop
            for (int i = 0; i < 4; i++)
            {
                lines[i] = CreateBound(vertices[i], vertices[(i + 1) % 4]);
                lines[i + 4] = CreateBound(vertices[i], vertices[i + 4]);
                lines[i + 8] = CreateBound(vertices[i + 4], vertices[(i + 1) % 4 + 4]);
            }

            return lines.OfType<Line>().ToArray();
        }
        private static Line CreateBound(XYZ point1, XYZ point2)
        {
            try
            {
                return Line.CreateBound(point1, point2);
            }
            catch { }
            return null;
        }
        /// <summary>
        /// Creates a 3D box with the specified center and size.
        /// </summary>
        /// <param name="center">The center point of the box.</param>
        /// <param name="scaleRadius">The scale size of the box.</param>
        /// <param name="materialId">The ID of the material to use for the box. If not specified, the box will use the default material.</param>
        /// <param name="graphicsStyleId">The ID of the graphics style to use for the box. If not specified, the box will use the default graphics style.</param>
        /// <returns>A solid representing the 3D box.</returns>
        public static Solid CreateBox(XYZ center, double scaleRadius,
            ElementId materialId = null,
            ElementId graphicsStyleId = null)
        {
            var scaleXYZ = new XYZ(scaleRadius, scaleRadius, scaleRadius);
            return CreateBox(center - scaleXYZ, center + scaleXYZ, materialId, graphicsStyleId);
        }
        /// <summary>
        /// Creates a 3D box with the specified minimum and maximum points.
        /// </summary>
        /// <param name="min">The minimum point of the box. This point defines the lower corner of the box.</param>
        /// <param name="max">The maximum point of the box. This point defines the upper corner of the box.</param>
        /// <param name="materialId">The ID of the material to use for the box. If not specified, the box will use the default material.</param>
        /// <param name="graphicsStyleId">The ID of the graphics style to use for the box. If not specified, the box will use the default graphics style.</param>
        /// <returns>A solid representing the 3D box.</returns>
        public static Solid CreateBox(XYZ min, XYZ max,
            ElementId materialId = null,
            ElementId graphicsStyleId = null)
        {
            // Create a list of CurveLoop objects to represent the profile of the box
            var profileLoops = new List<CurveLoop>();

            // Create the four lines connecting the minimum and maximum coordinates
            Line line1 = Line.CreateBound(min, new XYZ(max.X, min.Y, min.Z));
            Line line2 = Line.CreateBound(new XYZ(max.X, min.Y, min.Z), new XYZ(max.X, max.Y, min.Z));
            Line line3 = Line.CreateBound(new XYZ(max.X, max.Y, min.Z), new XYZ(min.X, max.Y, min.Z));
            Line line4 = Line.CreateBound(new XYZ(min.X, max.Y, min.Z), min);

            // Add the lines to a CurveLoop object
            CurveLoop curveLoop = new CurveLoop();
            curveLoop.Append(line1);
            curveLoop.Append(line2);
            curveLoop.Append(line3);
            curveLoop.Append(line4);

            // Add the CurveLoop object to the list of profile loops
            profileLoops.Add(curveLoop);

            // Set the extrusion direction and distance
            XYZ extrusionDir = XYZ.BasisZ;
            double extrusionDist = max.Z - min.Z;

            // Set material and graphicsStyle
            SolidOptions solidOptions = new SolidOptions(materialId ?? ElementId.InvalidElementId, graphicsStyleId ?? ElementId.InvalidElementId);

            // Create the solid box
            Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(profileLoops, extrusionDir, extrusionDist, solidOptions);

            return solid;
        }
        #endregion

        #region Sphere
        /// <summary>
        /// Creates a 3D sphere with the specified center and radius.
        /// </summary>
        /// <param name="center">The center point of the sphere.</param>
        /// <param name="radius">The radius of the sphere.</param>
        /// <param name="materialId">The ID of the material to use for the sphere. If not specified, the sphere will use the default material.</param>
        /// <param name="graphicsStyleId">The ID of the graphics style to use for sphere box. If not specified, the sphere will use the default graphics style.</param>
        /// <returns>A solid representing the 3D sphere.</returns>
        public static Solid CreateSphere(XYZ center, double radius,
            ElementId materialId = null,
            ElementId graphicsStyleId = null)
        {
            var profile = new List<Curve>();

            XYZ profilePlus = center + new XYZ(0, radius, 0);
            XYZ profileMinus = center - new XYZ(0, radius, 0);

            profile.Add(Line.CreateBound(profilePlus, profileMinus));
            profile.Add(Arc.Create(profileMinus, profilePlus, center + new XYZ(radius, 0, 0)));

            CurveLoop curveLoop = CurveLoop.Create(profile);
            SolidOptions solidOptions = CreateSolidOptions(materialId, graphicsStyleId);

            Frame frame = new Frame(center, XYZ.BasisX, -XYZ.BasisZ, XYZ.BasisY);
            Solid sphere = GeometryCreationUtilities.CreateRevolvedGeometry(frame, new CurveLoop[] { curveLoop }, 0, 2 * Math.PI, solidOptions);

            return sphere;
        }
        #endregion

        /// <summary>
        /// CreatePointer
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <param name="materialId"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        public static Solid CreatePointer(XYZ center, double radius, double height = 0,
            ElementId materialId = null,
            ElementId graphicsStyleId = null)
        {
            var profile = new List<Curve>();

            if (height <= 0) height = radius * 2;

            center -= new XYZ(0, 0, height / 2.0);

            XYZ profileCenter = center;
            XYZ profileHeight = center + new XYZ(0, 0, height);
            XYZ profileRadius = center + new XYZ(radius, 0, 0);

            profile.Add(Line.CreateBound(profileCenter, profileHeight));
            profile.Add(Line.CreateBound(profileHeight, profileRadius));
            profile.Add(Line.CreateBound(profileRadius, profileCenter));

            CurveLoop curveLoop = CurveLoop.Create(profile);
            SolidOptions solidOptions = CreateSolidOptions(materialId, graphicsStyleId);

            Frame frame = new Frame(center, XYZ.BasisX, XYZ.BasisY, XYZ.BasisZ);
            Solid sphere = GeometryCreationUtilities.CreateRevolvedGeometry(frame, new CurveLoop[] { curveLoop }, 0, 2 * Math.PI, solidOptions);

            return sphere;
        }

        /// <summary>
        /// CreateCylinder
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <param name="materialId"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        public static Solid CreateCylinder(XYZ center, double radius, double height = 0,
            ElementId materialId = null,
            ElementId graphicsStyleId = null)
        {
            var profile = new List<Curve>();

            if (height <= 0) height = radius * 2;

            center -= new XYZ(0, 0, height / 2.0);

            XYZ profileCenter = center;
            XYZ profileHeight = center + new XYZ(0, 0, height);
            XYZ profileRadius = center + new XYZ(radius, 0, 0);
            XYZ profileRadiusHeight = center + new XYZ(radius, 0, height);

            profile.Add(Line.CreateBound(profileCenter, profileHeight));
            profile.Add(Line.CreateBound(profileHeight, profileRadiusHeight));
            profile.Add(Line.CreateBound(profileRadiusHeight, profileRadius));
            profile.Add(Line.CreateBound(profileRadius, profileCenter));

            CurveLoop curveLoop = CurveLoop.Create(profile);
            SolidOptions solidOptions = CreateSolidOptions(materialId, graphicsStyleId);

            Frame frame = new Frame(center, XYZ.BasisX, XYZ.BasisY, XYZ.BasisZ);
            Solid sphere = GeometryCreationUtilities.CreateRevolvedGeometry(frame, new CurveLoop[] { curveLoop }, 0, 2 * Math.PI, solidOptions);

            return sphere;
        }

        private static SolidOptions CreateSolidOptions(
            ElementId materialId = null,
            ElementId graphicsStyleId = null)
        {
            return new SolidOptions(materialId ?? ElementId.InvalidElementId, graphicsStyleId ?? ElementId.InvalidElementId);
        }

        /// <summary>
        /// Create a Solid by union each of the input solids.
        /// </summary>
        /// <param name="solids"></param>
        /// <returns></returns>
        public static Solid CreateSolid(params Solid[] solids)
        {
            return solids.Aggregate((a, b) => a.Union(b));
        }


        /// <summary>
        /// Create Arrow pointing to axis
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="materialId"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        public static Solid CreateArrow(
            XYZ axis,
            ElementId materialId = null,
            ElementId graphicsStyleId = null)
        {
            return ShapeCreator.CreateArrow(materialId, graphicsStyleId)
                .CreateTransformed(TransformUtils.CreateRotation(axis));
        }

        /// <summary>
        /// CreateArrow
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        public static Solid CreateArrow(
        ElementId materialId = null,
        ElementId graphicsStyleId = null)
        {
            var cylinderHeight = 1.0 / 4.0;
            var cylinderRadius = 1.0 / 48.0 / 4.0;
            var pointerHeight = 1.0 / 12.0;
            var pointerRadius = 1.0 / 48.0;

            var cylinderCenter = XYZ.BasisZ * (cylinderHeight) / 2;
            var pointerCenter = cylinderCenter + XYZ.BasisZ * (cylinderHeight + pointerHeight) / 2;

            var cylinder = ShapeCreator.CreateCylinder(cylinderCenter, cylinderRadius, cylinderHeight, materialId, graphicsStyleId);
            var pointer = ShapeCreator.CreatePointer(pointerCenter, pointerRadius, pointerHeight, materialId, graphicsStyleId);

            var solid = ShapeCreator.CreateSolid(cylinder, pointer);
            return solid;
        }

        /// <summary>
        /// CreateGizmo with base material colors.
        /// </summary>
        /// <param name="document"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        /// <remarks>This method creates Material if not exist in the <paramref name="document"/></remarks>
        public static Solid CreateGizmo(
            Document document,
            ElementId graphicsStyleId = null)
        {
            var materialRed = MaterialUtils.CreateMaterialRed(document);
            var materialGreen = MaterialUtils.CreateMaterialGreen(document);
            var materialBlue = MaterialUtils.CreateMaterialBlue(document);
            return CreateGizmo(materialRed.Id, materialGreen.Id, materialBlue.Id, graphicsStyleId);
        }

        /// <summary>
        /// CreateGizmo
        /// </summary>
        /// <param name="materialIdX"></param>
        /// <param name="materialIdY"></param>
        /// <param name="materialIdZ"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        public static Solid CreateGizmo(
            ElementId materialIdX = null,
            ElementId materialIdY = null,
            ElementId materialIdZ = null,
            ElementId graphicsStyleId = null)
        {
            var solidRed = ShapeCreator.CreateArrow(XYZ.BasisX, materialIdX, graphicsStyleId);
            var solidGreen = ShapeCreator.CreateArrow(XYZ.BasisY, materialIdY, graphicsStyleId);
            var solidBlue = ShapeCreator.CreateArrow(XYZ.BasisZ, materialIdZ, graphicsStyleId);

            var gizmo = ShapeCreator.CreateSolid(solidRed, solidGreen, solidBlue);
            return gizmo;
        }
    }
}
