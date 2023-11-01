using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using ricaun.Revit.DB.Shape.Tests.Utils;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Gizmo_Tests
    {
        [Test]
        public void CreateGizmo()
        {
            var gizmo = ShapeCreator.CreateGizmo();

            AssertGizmo(gizmo);
        }

        [Test]
        public void CreateGizmo_Sides()
        {
            for (int sides = 3; sides <= 10; sides++)
            {
                var gizmo = ShapeCreator.CreateGizmo(sides);

                var edges = sides * 3; // Prism
                edges += sides * 2; // Pyramid

                var faces = sides + 2; // Prism
                faces += sides + 1; // Pyramid
                faces -= 1; // Intersection

                foreach (var solid in gizmo)
                {
                    AssertUtils.Solid(solid, edges, faces);
                }
            }
        }

        [TestCase(1.0)]
        [TestCase(2.0)]
        [TestCase(3.0)]
        [TestCase(4.2)]
        [TestCase(9.8)]
        public void CreateGizmo_Scale(double scale)
        {
            var solid = ShapeCreator.CreateGizmo();

            solid = solid.CreateTransformed(Transform.Identity.ScaleBasis(scale));

            AssertGizmo(solid, scale);
        }

        private void AssertGizmo(Solid solid, double scale = 1.0)
        {
            const double Tolerance = 1e-1;
            const double VolumeArrow = 0.00018834888144212;
            const double SurfaceArrow = 0.0448952160891422;

            var volume = VolumeArrow * scale * scale * scale;
            var surface = SurfaceArrow * scale * scale;
            AssertUtils.Solid(solid, 41, 21, volume, surface, Tolerance);
        }

        private void AssertGizmo(Solid[] solids, double scale = 1.0)
        {
            foreach (var solid in solids)
            {
                Shape_Arrow_Tests.AssertArrow(solid, scale);
            }
        }
    }
}