using Autodesk.Revit.DB;
using System;

namespace RevitAddin.QuaternionTest.Tests
{
    public class TransformRotationUtils
    {
        public static void CreateRotations(Action<Transform> eachTransform)
        {
            CreateRotations((transform, normal, angle) => { eachTransform.Invoke(transform); });
        }

        public static void CreateRotations(Action<Transform, XYZ, double> eachTransformNormalAngle)
        {
            var normals = new[] { XYZ.BasisX, XYZ.BasisY, XYZ.BasisZ, new XYZ(1, 1, 0), new XYZ(1, 1, 1) };

            for (double i = 0; i <= 4.0 * Math.PI; i += Math.PI / 24)
            {
                foreach (var normal in normals)
                {
                    var transform = Transform.CreateRotation(normal, i);
                    eachTransformNormalAngle.Invoke(transform, normal, i);
                }
            }
        }
    }
}