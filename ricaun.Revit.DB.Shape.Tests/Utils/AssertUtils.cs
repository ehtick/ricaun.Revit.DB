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
    }
}