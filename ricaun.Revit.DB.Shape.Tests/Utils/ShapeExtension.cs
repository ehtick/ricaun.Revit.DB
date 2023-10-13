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
            if (box.Transform.AlmostEqual(other.Transform) == false)
            {
                //Console.WriteLine(box.Transform.BasisX);
                //Console.WriteLine(box.Transform.BasisY);
                //Console.WriteLine(box.Transform.BasisZ);
                //Console.WriteLine(box.Transform.Origin);
                //Console.WriteLine(box.Transform.Scale);

                //Console.WriteLine(other.Transform.BasisX);
                //Console.WriteLine(other.Transform.BasisY);
                //Console.WriteLine(other.Transform.BasisZ);
                //Console.WriteLine(other.Transform.Origin);
                //Console.WriteLine(other.Transform.Scale);

                //Console.WriteLine(box.Transform.BasisX.IsAlmostEqualTo(other.Transform.BasisX));
                //Console.WriteLine(box.Transform.BasisY.IsAlmostEqualTo(other.Transform.BasisY));
                //Console.WriteLine(box.Transform.BasisZ.IsAlmostEqualTo(other.Transform.BasisZ));
                //Console.WriteLine(box.Transform.Origin.IsAlmostEqualTo(other.Transform.Origin));
                //Console.WriteLine(box.Transform.Scale.AlmostEqual(other.Transform.Scale));

                return false;
            }
            return true;
        }

        public static bool AlmostEqual(this double value, double other)
        {
            return Math.Abs(value - other) < Tolerance;
        }
    }
}