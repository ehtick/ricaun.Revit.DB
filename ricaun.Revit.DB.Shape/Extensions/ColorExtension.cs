using Autodesk.Revit.DB;

namespace ricaun.Revit.DB.Shape.Extensions
{
    /// <summary>
    /// ColorExtension
    /// </summary>
    public static class ColorExtension
    {
        /// <summary>
        /// Linearly interpolates between colors a and b by t.
        /// </summary>
        /// <param name="colorA"></param>
        /// <param name="colorB"></param>
        /// <param name="t"></param>
        public static Color Lerp(this Color colorA, Color colorB, double t)
        {
            byte r = (byte)(colorA.Red + (colorB.Red - colorA.Red) * t);
            byte g = (byte)(colorA.Green + (colorB.Green - colorA.Green) * t);
            byte b = (byte)(colorA.Blue + (colorB.Blue - colorA.Blue) * t);
            return new Color(r, g, b);
        }

        /// <summary>
        /// ToColorWithTransparency
        /// </summary>
        /// <param name="color"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static ColorWithTransparency ToColorWithTransparency(this Color color, byte alpha = byte.MaxValue)
        {
            if (color is null) return null;
            var colorWithTransparency = new ColorWithTransparency(color.Red, color.Green, color.Blue, alpha);
            return colorWithTransparency;
        }

        /// <summary>
        /// ToColor
        /// </summary>
        /// <param name="colorWithTransparency"></param>
        /// <returns></returns>
        public static Color ToColor(this ColorWithTransparency colorWithTransparency)
        {
            if (colorWithTransparency is null) return null;
            var color = new Color(
                (byte)colorWithTransparency.GetRed(),
                (byte)colorWithTransparency.GetGreen(),
                (byte)colorWithTransparency.GetBlue());
            return color;
        }

        #region Equals
        /// <summary>
        /// ColorEquals RGB
        /// </summary>
        /// <param name="colorA"></param>
        /// <param name="colorB"></param>
        public static bool ColorEquals(this Color colorA, Color colorB)
        {
            return colorA.Red == colorB.Red && colorA.Green == colorB.Green && colorA.Blue == colorB.Blue;
        }
        /// <summary>
        /// ColorEquals RGB only the transparency is not compared.
        /// </summary>
        /// <param name="colorA"></param>
        /// <param name="colorB"></param>
        public static bool ColorEquals(this Color colorA, ColorWithTransparency colorB)
        {
            return colorA.Red == colorB.GetRed() && colorA.Green == colorB.GetGreen() && colorA.Blue == colorB.GetBlue();
        }
        /// <summary>
        /// ColorEquals RGB only the transparency is not compared.
        /// </summary>
        /// <param name="colorA"></param>
        /// <param name="colorB"></param>
        public static bool ColorEquals(this ColorWithTransparency colorA, Color colorB)
        {
            return colorB.ColorEquals(colorA);
        }
        /// <summary>
        /// ColorEquals RGB and Transparency
        /// </summary>
        /// <param name="colorA"></param>
        /// <param name="colorB"></param>
        public static bool ColorEquals(this ColorWithTransparency colorA, ColorWithTransparency colorB)
        {
            return colorA.GetRed() == colorB.GetRed() &&
                colorA.GetGreen() == colorB.GetGreen() &&
                colorA.GetBlue() == colorB.GetBlue() &&
                colorA.GetTransparency() == colorB.GetTransparency();
        }
        #endregion

        /// <summary>
        /// Convert to #RRGGBB in hex format
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ToHex(this Color color)
        {
            return ToHex(color.Red, color.Green, color.Blue);
        }

        /// <summary>
        /// Convert to #RRGGBB or #AARRGGBB in hex format
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ToHex(this ColorWithTransparency color)
        {
            return ToHex((byte)color.GetRed(), (byte)color.GetGreen(), (byte)color.GetBlue(), (byte)color.GetTransparency());
        }

        /// <summary>
        /// Convert to #RRGGBB or #AARRGGBB
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static string ToHex(byte red, byte green, byte blue, byte alpha = byte.MaxValue)
        {
            if (alpha == byte.MaxValue)
                return string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);

            return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", alpha, red, green, blue);
        }
    }
}
