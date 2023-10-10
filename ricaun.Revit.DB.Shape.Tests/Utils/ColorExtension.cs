using Autodesk.Revit.DB;

namespace ricaun.Revit.DB.Shape.Tests.Utils
{
    public static class ColorExtension
    {
        public static bool ColorEquals(this Color colorA, Color colorB)
        {
            return colorA.Red == colorB.Red && colorA.Green == colorB.Green && colorA.Blue == colorB.Blue;
        }
    }
}