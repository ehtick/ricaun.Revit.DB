using Autodesk.Revit.DB;
using System;

namespace ricaun.Revit.DB.Shape.Tests
{
    public static class ShapeExtension
    {
        const double Tolerance = 1e-9;
        public static bool AlmostEqual(this Solid solid, Solid other)
        {
            if (solid.Edges.Size != other.Edges.Size) return false;
            if (solid.Faces.Size != other.Faces.Size) return false;

            if (solid.Volume.AlmostEqual(other.Volume) == false) return false;
            if (solid.SurfaceArea.AlmostEqual(other.SurfaceArea) == false) return false;

            return solid.GetBoundingBox().AlmostEqual(other.GetBoundingBox());
        }

        public static bool AlmostEqual(this BoundingBoxXYZ box, BoundingBoxXYZ other)
        {
            if (box.Min.IsAlmostEqualTo(other.Min) == false) return false;
            if (box.Max.IsAlmostEqualTo(other.Max) == false) return false;

            return box.Transform.AlmostEqual(other.Transform);
        }

        public static bool AlmostEqual(this double value, double other)
        {
            return Math.Abs(value - other) < Tolerance;
        }
    }
}