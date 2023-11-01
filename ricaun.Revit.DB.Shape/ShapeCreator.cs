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
        private const int Sides = 6;
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
            SolidOptions solidOptions = CreateSolidOptions(materialId, graphicsStyleId);

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

        #region Cone / Cylinder

        /// <summary>
        /// CreateCone
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <param name="materialId"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        public static Solid CreateCone(XYZ center, double radius, double height = 0,
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
            Solid solid = GeometryCreationUtilities.CreateRevolvedGeometry(frame, new CurveLoop[] { curveLoop }, 0, 2 * Math.PI, solidOptions);

            return solid;
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
            Solid solid = GeometryCreationUtilities.CreateRevolvedGeometry(frame, new CurveLoop[] { curveLoop }, 0, 2 * Math.PI, solidOptions);

            return solid;
        }
        #endregion

        #region Prism / Pyramid
        /// <summary>
        /// CreatePrism
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <param name="materialId"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        public static Solid CreatePrism(XYZ center, double radius, double height = 0,
            ElementId materialId = null,
            ElementId graphicsStyleId = null)
        {
            return CreatePrism(Sides, center, radius, height, materialId, graphicsStyleId);
        }

        /// <summary>
        /// CreatePrism
        /// </summary>
        /// <param name="sides"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <param name="materialId"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        public static Solid CreatePrism(int sides, XYZ center, double radius, double height = 0,
            ElementId materialId = null,
            ElementId graphicsStyleId = null)
        {
            if (sides < 3) sides = 3;
            if (height <= 0) height = radius * 2;

            var heightHalfZ = height * XYZ.BasisZ / 2.0;
            center -= heightHalfZ;

            var profileLoops = new List<CurveLoop>();
            var curveLoop = new CurveLoop();
            var points = XYZUtils.CreateCircleLoopVertices(center, radius, sides);

            for (int i = 0; i < points.Length; i++)
            {
                var p1 = points[(i + 0) % points.Length];
                var p2 = points[(i + 1) % points.Length];
                curveLoop.Append(Line.CreateBound(p1, p2));
            }

            profileLoops.Add(curveLoop);
            XYZ extrusionDir = XYZ.BasisZ;
            double extrusionDist = height;
            SolidOptions solidOptions = CreateSolidOptions(materialId, graphicsStyleId);
            Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(profileLoops, extrusionDir, extrusionDist, solidOptions);

            return solid;
        }

        /// <summary>
        /// CreatePyramid
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <param name="materialId"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        /// <remarks>This method uses <see cref="TessellatedShapeCreator"/> and return null if fails.</remarks>
        public static Solid CreatePyramid(XYZ center, double radius, double height = 0,
           ElementId materialId = null,
           ElementId graphicsStyleId = null)
        {
            return CreatePyramid(Sides, center, radius, height, materialId, graphicsStyleId);
        }

        /// <summary>
        /// CreatePyramid
        /// </summary>
        /// <param name="sides"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        /// <param name="materialId"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        /// <remarks>This method uses <see cref="TessellatedShapeCreator"/> and return null if fails.</remarks>
        public static Solid CreatePyramid(int sides, XYZ center, double radius, double height = 0,
            ElementId materialId = null,
            ElementId graphicsStyleId = null)
        {
            if (sides < 3) sides = 3;
            if (height <= 0) height = radius * 2;

            var heightHalfZ = height * XYZ.BasisZ / 2.0;
            var pyramidPoint = center + heightHalfZ;
            center -= heightHalfZ;

            var points = XYZUtils.CreateCircleLoopVertices(center, radius, sides);

            var solid = TessellatedShapeCreator.Create((builder) =>
            {
                if (materialId is null) materialId = ElementId.InvalidElementId;
                if (graphicsStyleId is not null) builder.GraphicsStyleId = graphicsStyleId;

                for (int i = 0; i < points.Length; i++)
                {
                    var p1 = points[(i + 0) % points.Length];
                    var p2 = points[(i + 1) % points.Length];
                    builder.AddFace(new List<XYZ> { p1, p2, pyramidPoint }, materialId);
                }

                builder.AddFace(points.ToList(), materialId);

            }).OfType<Solid>().FirstOrDefault();

            return solid;
        }

        #endregion

        #region Utils
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
        internal static Solid CreateSolid(params Solid[] solids)
        {
            return solids.Aggregate((a, b) => a.Union(b));
        }
        #endregion

        #region Arrow / Gizmo
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
            var coneHeight = 1.0 / 12.0;
            var coneRadius = 1.0 / 48.0;

            var cylinderCenter = XYZ.BasisZ * (cylinderHeight) / 2;
            var coneCenter = cylinderCenter + XYZ.BasisZ * (cylinderHeight + coneHeight) / 2;

            var cylinder = ShapeCreator.CreateCylinder(cylinderCenter, cylinderRadius, cylinderHeight, materialId, graphicsStyleId);
            var cone = ShapeCreator.CreateCone(coneCenter, coneRadius, coneHeight, materialId, graphicsStyleId);

            var solid = ShapeCreator.CreateSolid(cylinder, cone);
            return solid;
        }

        /// <summary>
        /// CreateArrow
        /// </summary>
        /// <param name="sides"></param>
        /// <param name="axis"></param>
        /// <param name="materialId"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        /// <remarks>Sides limit equal to 10.</remarks>
        internal static Solid CreateArrow(
            int sides,
            XYZ axis,
            ElementId materialId = null,
            ElementId graphicsStyleId = null)
        {
            return ShapeCreator.CreateArrow(sides, materialId, graphicsStyleId)
                .CreateTransformed(TransformUtils.CreateRotation(axis));
        }

        /// <summary>
        /// CreateArrow
        /// </summary>
        /// <param name="sides"></param>
        /// <param name="materialId"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        /// <remarks>Sides limit equal to 10.</remarks>
        internal static Solid CreateArrow(
            int sides,
            ElementId materialId = null,
            ElementId graphicsStyleId = null)
        {
            if (sides > 10) sides = 10;

            var cylinderHeight = 1.0 / 4.0;
            var cylinderRadius = 1.0 / 48.0 / 4.0;
            var coneHeight = 1.0 / 12.0;
            var coneRadius = 1.0 / 48.0;

            var cylinderCenter = XYZ.BasisZ * (cylinderHeight) / 2;
            var coneCenter = cylinderCenter + XYZ.BasisZ * (cylinderHeight + coneHeight) / 2;

            var cylinder = ShapeCreator.CreatePrism(sides, cylinderCenter, cylinderRadius, cylinderHeight, materialId, graphicsStyleId);
            var cone = ShapeCreator.CreatePyramid(sides, coneCenter, coneRadius, coneHeight, materialId, graphicsStyleId);

            var solid = ShapeCreator.CreateSolid(cylinder, cone);
            return solid;
        }

        /// <summary>
        /// CreateGizmo with base material colors.
        /// </summary>
        /// <param name="document"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        /// <remarks>This method creates Material if not exist in the <paramref name="document"/></remarks>
        public static Solid[] CreateGizmo(
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
        public static Solid[] CreateGizmo(
            ElementId materialIdX = null,
            ElementId materialIdY = null,
            ElementId materialIdZ = null,
            ElementId graphicsStyleId = null)
        {
            var solidRed = ShapeCreator.CreateArrow(XYZ.BasisX, materialIdX, graphicsStyleId);
            var solidGreen = ShapeCreator.CreateArrow(XYZ.BasisY, materialIdY, graphicsStyleId);
            var solidBlue = ShapeCreator.CreateArrow(XYZ.BasisZ, materialIdZ, graphicsStyleId);

            return new[] { solidRed, solidGreen, solidBlue };
        }

        /// <summary>
        /// CreateGizmo with base material colors.
        /// </summary>
        /// <param name="document"></param>
        /// <param name="sides"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        /// <remarks>This method creates Material if not exist in the <paramref name="document"/></remarks>
        internal static Solid[] CreateGizmo(
            Document document,
            int sides,
            ElementId graphicsStyleId = null)
        {
            var materialRed = MaterialUtils.CreateMaterialRed(document);
            var materialGreen = MaterialUtils.CreateMaterialGreen(document);
            var materialBlue = MaterialUtils.CreateMaterialBlue(document);
            return CreateGizmo(sides, materialRed.Id, materialGreen.Id, materialBlue.Id, graphicsStyleId);
        }

        /// <summary>
        /// CreateGizmo
        /// </summary>
        /// <param name="sides"></param>
        /// <param name="materialIdX"></param>
        /// <param name="materialIdY"></param>
        /// <param name="materialIdZ"></param>
        /// <param name="graphicsStyleId"></param>
        /// <returns></returns>
        internal static Solid[] CreateGizmo(
            int sides,
            ElementId materialIdX = null,
            ElementId materialIdY = null,
            ElementId materialIdZ = null,
            ElementId graphicsStyleId = null)
        {
            var solidRed = ShapeCreator.CreateArrow(sides, XYZ.BasisX, materialIdX, graphicsStyleId);
            var solidGreen = ShapeCreator.CreateArrow(sides, XYZ.BasisY, materialIdY, graphicsStyleId);
            var solidBlue = ShapeCreator.CreateArrow(sides, XYZ.BasisZ, materialIdZ, graphicsStyleId);

            return new[] { solidRed, solidGreen, solidBlue };
        }
        #endregion
    }
}
