using Autodesk.Revit.DB;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Shape.Tests.Utils
{
    public static class AssertUtils
    {
        public static void Geometry<T>(Element element, int expected) where T : GeometryObject
        {
            var count = element.GetInstanceGeometry<T>().Count;
            Assert.AreEqual(expected, count, $"Geometry {typeof(T).Name} {count} is expected {expected}");
        }

        public static List<T> GetInstanceGeometry<T>(this Element element) where T : GeometryObject
        {
            var geometrys = new List<T>();

            var options = new Options() { DetailLevel = ViewDetailLevel.Fine };
            var geos = element.get_Geometry(options);
            if (geos is null)
            {
                // Force document to generate Geometry.
                element.Document.Regenerate();
                geos = element.get_Geometry(options);
                if (geos is null)
                {
                    return geometrys;
                }
            }

            var instances = geos
                .OfType<GeometryInstance>()
                .SelectMany(e => e.GetInstanceGeometry());

            geometrys.AddRange(instances.OfType<T>());
            geometrys.AddRange(geos.OfType<T>());

            return geometrys;
        }

        public static void Material(Solid solid, ElementId materialElementId, ElementId graphicsStyleId)
        {
            foreach (Face face in solid.Faces)
            {
                Assert.True(face.MaterialElementId == materialElementId, $"Face Material {face.MaterialElementId} is not equal {materialElementId}");
                Assert.True(face.GraphicsStyleId == graphicsStyleId, $"Face GraphicsStyle {face.GraphicsStyleId} is not equal {graphicsStyleId}");
            }
        }

        public static void Material(Solid[] solids, ElementId materialElementId, ElementId graphicsStyleId)
        {
            foreach (var solid in solids)
            {
                Material(solid, materialElementId, graphicsStyleId);
            }
        }

        public static void Material(Solid solid, ElementId[] materialElementIds, ElementId graphicsStyleId)
        {
            foreach (Face face in solid.Faces)
            {
                var materialElementId = ElementId.InvalidElementId;
                if (materialElementIds.Contains(face.MaterialElementId))
                    materialElementId = face.MaterialElementId;

                Assert.True(face.MaterialElementId == materialElementId, $"Face Material {face.MaterialElementId} is not equal {materialElementId}");
                Assert.True(face.GraphicsStyleId == graphicsStyleId, $"Face GraphicsStyle {face.GraphicsStyleId} is not equal {graphicsStyleId}");
            }
        }

        public static void Box(Solid solid, XYZ center, double scale = 1.0)
        {
            Assert.AreEqual(12, solid.Edges.Size);
            Assert.AreEqual(6, solid.Faces.Size);

            Assert.IsTrue(solid.ComputeCentroid().IsAlmostEqualTo(center), $"Centroid {solid.ComputeCentroid()} is not {center}");

            var volumeExpected = 2 * 2 * 2 * scale * scale * scale;
            var surfaceAreaExpected = 6 * 2 * 2 * scale * scale;
            Assert.IsTrue(solid.Volume.AlmostEqual(volumeExpected), $"Volume {solid.Volume} is not {volumeExpected}");
            Assert.IsTrue(solid.SurfaceArea.AlmostEqual(surfaceAreaExpected), $"SurfaceArea {solid.SurfaceArea} is not {surfaceAreaExpected}");
        }

        public static void Mesh(Mesh mesh, Mesh other)
        {
            Assert.AreEqual(mesh.Vertices.Count, other.Vertices.Count);
            Assert.AreEqual(mesh.NumTriangles, other.NumTriangles);
            var containsOtherOutline = GetOutline(mesh).ContainsOtherOutline(GetOutline(other), 1e-9);
            Assert.IsTrue(containsOtherOutline);
        }

        public static Outline GetOutline(Mesh mesh)
        {
            var vertices = mesh.Vertices;
            var first = vertices.First();
            Outline outline = new Outline(first, first);
            foreach (var vertice in mesh.Vertices)
            {
                outline.AddPoint(vertice);
            }
            return outline;
        }

        public static void Solid(Solid solid, Solid other)
        {
            Assert.AreEqual(solid.Edges.Size, other.Edges.Size);
            Assert.AreEqual(solid.Faces.Size, other.Faces.Size);

            Assert.IsTrue(solid.Volume.AlmostEqual(other.Volume), $"Volume {solid.Volume} is not {other.Volume}");
            Assert.IsTrue(solid.SurfaceArea.AlmostEqual(other.SurfaceArea), $"SurfaceArea {solid.SurfaceArea} is not {other.SurfaceArea}");

            Assert.IsTrue(solid.GetBoundingBox().AlmostEqual(other.GetBoundingBox()), $"BoundingBox [{solid.GetBoundingBox().Min} {solid.GetBoundingBox().Max} {solid.GetBoundingBox().Transform.Origin}] is not almost equal [{other.GetBoundingBox().Min} {other.GetBoundingBox().Max} {other.GetBoundingBox().Transform.Origin}]");

            Assert.IsTrue(solid.AlmostEqual(other), $"Solid {solid} is not almost equal {other}");
        }

        public static void Face(Face face, Face other)
        {
            Assert.AreEqual(face.EdgeLoops.Size, other.EdgeLoops.Size);

            Assert.IsTrue(face.Area.AlmostEqual(other.Area), $"Area {face.Area} is not {other.Area}");

            Assert.IsTrue(face.AlmostEqual(other), $"Face {face} is not almost equal {other}");
        }

        public static void Solid(Solid solid, int edges, int faces)
        {
            Assert.AreEqual(edges, solid.Edges.Size, $"Edges: {solid.Edges.Size}");
            Assert.AreEqual(faces, solid.Faces.Size, $"Faces: {solid.Faces.Size}");
        }

        public static void Solid(Solid solid, int edges, int faces, double volume, double area, double tolerance)
        {
            Solid(solid, edges, faces);

            Assert.True(volume.AlmostEqual(solid.Volume, tolerance), $"Solid Volume {solid.Volume} is not {volume}");
            Assert.True(area.AlmostEqual(solid.SurfaceArea, tolerance), $"Solid Area {solid.SurfaceArea} is not {area}");
        }

        public static void Sphere(Solid solid, double radius)
        {
            var volume = 4.0 / 3.0 * System.Math.PI * System.Math.Pow(radius, 3);
            var area = 4.0 * System.Math.PI * System.Math.Pow(radius, 2);

            AssertUtils.Solid(solid, 2, 2, volume, area, 1e-2);
        }

        public static void Cylinder(Solid solid, double radius, double height = 0)
        {
            if (height == 0)
                height = 2 * radius;

            var volume = System.Math.PI * System.Math.Pow(radius, 2) * height;
            var area = 2 * System.Math.PI * radius * height + 2 * System.Math.PI * System.Math.Pow(radius, 2);

            // Tolerance is bad with big radius
            var tolerance = 1e-0;

            AssertUtils.Solid(solid, 10, 6, volume, area, tolerance);
        }

        public static void Cone(Solid solid, double radius, double height = 0)
        {
            if (height == 0)
                height = 2 * radius;

            var volume = System.Math.PI * System.Math.Pow(radius, 2) * height / 3;
            var area = System.Math.PI * radius * System.Math.Sqrt(System.Math.Pow(radius, 2) + System.Math.Pow(height, 2)) + System.Math.PI * System.Math.Pow(radius, 2);

            // Tolerance is bad with big radius
            var tolerance = 1e-0;

            AssertUtils.Solid(solid, 6, 4, volume, area, tolerance);
        }

        public static void Pyramid(Solid solid, int sides, double radius, double height = 0)
        {
            if (height == 0)
                height = 2 * radius;

            var volume = System.Math.PI * System.Math.Pow(radius, 2) * height / 3;
            var area = System.Math.PI * radius * System.Math.Sqrt(System.Math.Pow(radius, 2) + System.Math.Pow(height, 2)) + System.Math.PI * System.Math.Pow(radius, 2);

            // Tolerance big to ignore area/volume
            var tolerance = 1e+4;

            var edges = sides * 2;
            var faces = sides + 1;

            AssertUtils.Solid(solid, edges, faces, volume, area, tolerance);
        }
        public static void Prism(Solid solid, int sides, double radius, double height = 0)
        {
            if (height == 0)
                height = 2 * radius;

            var volume = System.Math.PI * System.Math.Pow(radius, 2) * height;
            var area = 2 * System.Math.PI * radius * height + 2 * System.Math.PI * System.Math.Pow(radius, 2);

            // Tolerance big to ignore area/volume
            var tolerance = 1e+4;

            var edges = sides * 3;
            var faces = sides + 2;

            AssertUtils.Solid(solid, edges, faces, volume, area, tolerance);
        }
    }
}