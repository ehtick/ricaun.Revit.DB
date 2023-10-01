using Autodesk.Revit.DB;
using ricaun.Revit.DB.Quaternion;

namespace RevitAddin.QuaternionTest.Tests
{
    static partial class MathHelper
    {
        public static bool Equal(Quaternion a, Quaternion b)
        {
            return a.IsAlmostEqualTo(b);
            //return Equal(a.X, b.X) && Equal(a.Y, b.Y) && Equal(a.Z, b.Z) && Equal(a.W, b.W);
        }

        public static bool EqualRotation(Quaternion a, Quaternion b)
        {
            return a.IsAlmostEqualTo(b) || a.IsAlmostEqualTo(-b);
        }

        public static bool Equal(Transform a, Transform b)
        {
            return a.AlmostEqual(b);
        }

        public static bool EqualRotation(Transform a, Transform b)
        {
            return a.AlmostEqual(b) || a.AlmostEqual(b.Inverse);
        }

        public static bool Equal(XYZ a, XYZ b)
        {
            return a.IsAlmostEqualTo(b);
        }
    }

}