using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Shape
{
    /// <summary>
    /// XYZUtils
    /// </summary>
    public static class XYZUtils
    {
        private const double Tolerance = 1e-9;
        /// <summary>
        /// IsAlmostParallelTo
        /// </summary>
        /// <param name="value"></param>
        /// <param name="source"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool IsAlmostParallelTo(XYZ value, XYZ source, double tolerance = Tolerance)
        {
            return Math.Abs(value.DotProduct(source)) >= 1.0 - tolerance;
        }

        /// <summary>
        /// ComputeNormal
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        public static XYZ ComputeNormal(XYZ p1, XYZ p2, XYZ p3)
        {
            // Calculate the vectors that define the triangle
            var v1 = p2 - p1;
            var v2 = p3 - p1;

            // Compute the cross product of the two vectors to get the normal
            var normal = v1.CrossProduct(v2);

            // Normalize the normal vector
            normal = normal.Normalize();

            return normal;
        }

        internal static XYZ[] CreateCircleLoopSides(XYZ origin, XYZ normal, double radius, int sides = 3)
        {
            origin ??= XYZ.Zero;
            normal ??= XYZ.BasisZ;

            if (sides < 3) 
                sides = 3;

            var points = new List<XYZ>();
            var circle = Arc.Create(Plane.CreateByNormalAndOrigin(normal, origin), radius, 0, 2.0 * Math.PI);

            for (int i = 0; i < sides; i++)
            {
                var angle = 2.0 * Math.PI * (double)i / sides;
                var point = circle.Evaluate(angle, false);
                points.Add(point);
            }

            return points.ToArray();
        }

        internal static XYZ[] CreateCircleLoopSides(XYZ origin, double radius, int sides = 3)
        {
            return CreateCircleLoopSides(origin, XYZ.BasisZ, radius, sides);
        }

        internal static bool UpdateLoopWithTriangle(List<XYZ> loop, params XYZ[] values)
        {
            XYZAlmostEqualComparer comparer = new XYZAlmostEqualComparer();
            var valuesCopy = values.ToList();
            foreach (var value in values)
            {
                if (loop.Contains(value, comparer))
                {
                    valuesCopy.Remove(value);
                }
            }

            if (valuesCopy.Count == 1)
            {
                var value = valuesCopy[0];
                var count = loop.Count;
                for (int i = 0; i < count + 1; i++)
                {
                    var p1 = loop[(i + 0) % count];
                    var p2 = loop[(i + 1) % count];
                    if (values.Contains(p1, comparer))
                    {
                        if (values.Contains(p2, comparer))
                        {
                            var index = (i + 1) % count;
                            loop.Insert(index, value);
                            break;
                        }
                    }
                }
            }
            return valuesCopy.Count == 1;
        }

        /// <summary>
        /// XYZAlmostEqualComparer
        /// </summary>
        public class XYZAlmostEqualComparer : IEqualityComparer<XYZ>, IComparer<XYZ>
        {
            private const double Tolerance = 1e-9;
            private double tolerance;
            /// <summary>
            /// XYZAlmostEqualComparer
            /// </summary>
            /// <param name="tolerance"></param>
            public XYZAlmostEqualComparer(double tolerance = Tolerance)
            {
                this.tolerance = tolerance;
            }
            /// <summary>
            /// Compare
            /// </summary>
            /// <param name="point1"></param>
            /// <param name="point2"></param>
            /// <returns></returns>
            public int Compare(XYZ point1, XYZ point2)
            {
                if (point1.IsAlmostEqualTo(point2, tolerance))
                    return 0;
                return 1;
            }
            /// <summary>
            /// Equals
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public bool Equals(XYZ x, XYZ y)
            {
                return x.IsAlmostEqualTo(y, tolerance);
            }
            /// <summary>
            /// GetHashCode
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public int GetHashCode(XYZ obj)
            {
                return obj.X.GetHashCode() ^ obj.Y.GetHashCode() ^ obj.Z.GetHashCode();
            }
        }
    }
}
