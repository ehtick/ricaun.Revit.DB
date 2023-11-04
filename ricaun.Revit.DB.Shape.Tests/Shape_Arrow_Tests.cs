using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using ricaun.Revit.DB.Shape.Tests.Utils;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Arrow_Tests
    {
        [Test]
        public void CreateArrow()
        {
            var solid = ShapeCreator.CreateArrow();

            AssertArrow(solid);
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        [TestCase(9.8)]
        public void CreateArrow_Scale(double scale)
        {
            var solid = ShapeCreator.CreateArrow();

            solid = solid.CreateTransformed(Transform.Identity.ScaleBasis(scale));

            AssertArrow(solid, scale);
        }

        [Test]
        public void CreateArrow_Sides()
        {
            for (int sides = 3; sides <= 10; sides++)
            {
                var solid = ShapeCreator.CreateArrow(sides);

                var edges = sides * 3; // Prism
                edges += sides * 2; // Pyramid

                var faces = sides + 2; // Prism
                faces += sides + 1; // Pyramid
                faces -= 1; // Intersection

                AssertUtils.Solid(solid, edges, faces);
            }
        }

        internal static void AssertArrow(Solid solid, double scale = 1.0)
        {
            const double Tolerance = 1e-2;
            const double VolumeArrow = 0.0000629;
            const double SurfaceArrow = 0.0151090;

            var volume = VolumeArrow * scale * scale * scale;
            var surface = SurfaceArrow * scale * scale;
            AssertUtils.Solid(solid, 14, 8, volume, surface, Tolerance);
        }
    }
}