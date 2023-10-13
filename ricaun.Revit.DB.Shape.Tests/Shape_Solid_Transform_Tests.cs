using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Extensions;
using System;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Shape_Solid_Transform_Tests
    {
        [Test]
        public void CreateBox_ShouldBe_CreateTranslation()
        {
            for (double i = 1; i < 10; i += 0.1)
            {
                var translation = XYZ.BasisX * i;
                var transform = Transform.CreateTranslation(translation);
                Solid solid = ShapeCreator.CreateBox(XYZ.Zero, 1).CreateTransformed(transform);

                if (solid.ComputeCentroid().IsAlmostEqualTo(solid.GetOrigin())) continue;
                Console.WriteLine($"Centroid: {solid.ComputeCentroid()}");
                Console.WriteLine($"Origin: {(solid.GetOrigin())}");
            }
        }
    }
}