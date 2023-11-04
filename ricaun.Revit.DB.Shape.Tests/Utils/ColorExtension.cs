using Autodesk.Revit.DB;

namespace ricaun.Revit.DB.Shape.Tests.Utils
{
    public static class ColorExtension
    {
        public static bool ColorEquals(this Color colorA, Color colorB)
        {
            return colorA.Red == colorB.Red && colorA.Green == colorB.Green && colorA.Blue == colorB.Blue;
        }

        public static bool ColorEquals(this Color colorA, ColorWithTransparency colorB)
        {
            return colorA.Red == colorB.GetRed() && colorA.Green == colorB.GetGreen() && colorA.Blue == colorB.GetBlue();
        }

        public static bool ColorEquals(this ColorWithTransparency colorA, Color colorB)
        {
            return colorB.ColorEquals(colorA);
        }

        public static bool ColorEquals(this ColorWithTransparency colorA, ColorWithTransparency colorB)
        {
            return colorA.GetRed() == colorB.GetRed() &&
                colorA.GetGreen() == colorB.GetGreen() &&
                colorA.GetBlue() == colorB.GetBlue() &&
                colorA.GetTransparency() == colorB.GetTransparency();
        }
    }
}