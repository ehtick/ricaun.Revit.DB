using Autodesk.Revit.DB;
using NUnit.Framework;

namespace ricaun.Revit.DB.Shape.Tests.Utils
{
    public static class AssertUtils
    {
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

        public static void Solid(Solid solid, Solid other)
        {
            Assert.AreEqual(solid.Edges.Size, other.Edges.Size);
            Assert.AreEqual(solid.Faces.Size, other.Faces.Size);

            Assert.IsTrue(solid.Volume.AlmostEqual(other.Volume), $"Volume {solid.Volume} is not {other.Volume}");
            Assert.IsTrue(solid.SurfaceArea.AlmostEqual(other.SurfaceArea), $"SurfaceArea {solid.SurfaceArea} is not {other.SurfaceArea}");

            Assert.IsTrue(solid.GetBoundingBox().AlmostEqual(other.GetBoundingBox()), $"BoundingBox [{solid.GetBoundingBox().Min} {solid.GetBoundingBox().Max} {solid.GetBoundingBox().Transform.Origin}] is not almost equal [{other.GetBoundingBox().Min} {other.GetBoundingBox().Max} {other.GetBoundingBox().Transform.Origin}]");

            Assert.IsTrue(solid.AlmostEqual(other), $"Solid {solid} is not almost equal {other}");
        }

        public static void Solid(Solid solid, int edges, int faces, double volume, double area, double tolerance)
        {
            Assert.AreEqual(edges, solid.Edges.Size, $"Edges: {solid.Edges.Size}");
            Assert.AreEqual(faces, solid.Faces.Size, $"Faces: {solid.Faces.Size}");

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

        public static void Pointer(Solid solid, double radius, double height = 0)
        {
            if (height == 0)
                height = 2 * radius;

            var volume = System.Math.PI * System.Math.Pow(radius, 2) * height / 3;
            var area = System.Math.PI * radius * System.Math.Sqrt(System.Math.Pow(radius, 2) + System.Math.Pow(height, 2)) + System.Math.PI * System.Math.Pow(radius, 2);

            // Tolerance is bad with big radius
            var tolerance = 1e-0;

            AssertUtils.Solid(solid, 6, 4, volume, area, tolerance);
        }
    }
}