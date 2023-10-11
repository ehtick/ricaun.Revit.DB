using Autodesk.Revit.DB;
using System;

namespace ricaun.Revit.DB.Shape.Tests.Utils
{
    public static class LoopAroundSphereUtils
    {
        public static void EachPoint(Action<XYZ> eachPoint, double angle = Math.PI / 8.0, double radius = 1.0)
        {
            XYZ lastPoint = XYZ.Zero;
            for (double phi = 0; phi <= Math.PI; phi += angle)
            {
                for (double theta = 0; theta < 2 * Math.PI; theta += angle)
                {
                    var point = CalculatePoint(radius, phi, theta);

                    if (point.IsAlmostEqualTo(lastPoint) == false)
                        eachPoint?.Invoke(point);

                    lastPoint = point;
                }
            }
        }

        public static void EachPointOrthogonal(Action<XYZ, XYZ> eachPoint, double angle = Math.PI / 8.0, double radius = 1.0)
        {
            XYZ lastPoint = XYZ.Zero;
            for (double phi = 0; phi <= Math.PI; phi += angle)
            {
                for (double theta = 0; theta < 2 * Math.PI; theta += angle)
                {
                    var point = CalculatePoint(radius, phi, theta);

                    if (point.IsAlmostEqualTo(lastPoint) == false)
                    {
                        var orthogonalPoint = CalculatePoint(radius, phi + Math.PI / 2.0, theta);

                        eachPoint?.Invoke(point, orthogonalPoint);
                    }

                    lastPoint = point;
                }
            }
        }

        internal static XYZ CalculatePoint(double radius, double phi, double theta)
        {
            double x = radius * Math.Sin(phi) * Math.Cos(theta);
            double y = radius * Math.Sin(phi) * Math.Sin(theta);
            double z = radius * Math.Cos(phi);
            return new XYZ(x, y, z);
        }
    }
}