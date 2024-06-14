using Autodesk.Revit.DB;

namespace ricaun.Revit.DB.Shape
{
    /// <summary>
    /// Colors
    /// </summary>
    public sealed class Colors
    {
        #region Colors
        ///// <summary>
        ///// Represents the color black with the hex value #000000.
        ///// </summary>
        //public static Color Black => new Color(0, 0, 0);
        ///// <summary>
        ///// Represents the color red with the hex value #FF0000.
        ///// </summary>
        //public static Color Red => new Color(255, 0, 0);
        ///// <summary>
        ///// Represents the color yellow with the hex value #FFFF00.
        ///// </summary>
        //public static Color Yellow => new Color(255, 255, 0);
        ///// <summary>
        ///// Represents the color green with the hex value #00FF00.
        ///// </summary>
        //public static Color Green => new Color(0, 255, 0);
        ///// <summary>
        ///// Represents the color cyan with the hex value #00FFFF.
        ///// </summary>
        //public static Color Cyan => new Color(0, 255, 255);
        ///// <summary>
        ///// Represents the color blue with the hex value #0000FF.
        ///// </summary>
        //public static Color Blue => new Color(0, 0, 255);
        ///// <summary>
        ///// Represents the color magenta with the hex value #FF00FF.
        ///// </summary>
        //public static Color Magenta => new Color(255, 0, 255);
        ///// <summary>
        ///// Represents the color white with the hex value #FFFFFF.
        ///// </summary>
        //public static Color White => new Color(255, 255, 255);
        ///// <summary>
        ///// Represents the color dark gray with the hex value #414141.
        ///// </summary>
        //public static Color DarkGray => new Color(65, 65, 65);
        ///// <summary>
        ///// Represents the color gray with the hex value #808080.
        ///// </summary>
        //public static Color Gray => new Color(128, 128, 128);
        #endregion
        #region Media Colors
        /// <summary>
        /// Represents the color with the hex value #F0F8FF.
        /// </summary>
        public static Color AliceBlue => new Color(240, 248, 255);
        /// <summary>
        /// Represents the color with the hex value #FAEBD7.
        /// </summary>
        public static Color AntiqueWhite => new Color(250, 235, 215);
        /// <summary>
        /// Represents the color with the hex value #00FFFF.
        /// </summary>
        public static Color Aqua => new Color(0, 255, 255);
        /// <summary>
        /// Represents the color with the hex value #7FFFD4.
        /// </summary>
        public static Color Aquamarine => new Color(127, 255, 212);
        /// <summary>
        /// Represents the color with the hex value #F0FFFF.
        /// </summary>
        public static Color Azure => new Color(240, 255, 255);
        /// <summary>
        /// Represents the color with the hex value #F5F5DC.
        /// </summary>
        public static Color Beige => new Color(245, 245, 220);
        /// <summary>
        /// Represents the color with the hex value #FFE4C4.
        /// </summary>
        public static Color Bisque => new Color(255, 228, 196);
        /// <summary>
        /// Represents the color with the hex value #000000.
        /// </summary>
        public static Color Black => new Color(0, 0, 0);
        /// <summary>
        /// Represents the color with the hex value #FFEBCD.
        /// </summary>
        public static Color BlanchedAlmond => new Color(255, 235, 205);
        /// <summary>
        /// Represents the color with the hex value #0000FF.
        /// </summary>
        public static Color Blue => new Color(0, 0, 255);
        /// <summary>
        /// Represents the color with the hex value #8A2BE2.
        /// </summary>
        public static Color BlueViolet => new Color(138, 43, 226);
        /// <summary>
        /// Represents the color with the hex value #A52A2A.
        /// </summary>
        public static Color Brown => new Color(165, 42, 42);
        /// <summary>
        /// Represents the color with the hex value #DEB887.
        /// </summary>
        public static Color BurlyWood => new Color(222, 184, 135);
        /// <summary>
        /// Represents the color with the hex value #5F9EA0.
        /// </summary>
        public static Color CadetBlue => new Color(95, 158, 160);
        /// <summary>
        /// Represents the color with the hex value #7FFF00.
        /// </summary>
        public static Color Chartreuse => new Color(127, 255, 0);
        /// <summary>
        /// Represents the color with the hex value #D2691E.
        /// </summary>
        public static Color Chocolate => new Color(210, 105, 30);
        /// <summary>
        /// Represents the color with the hex value #FF7F50.
        /// </summary>
        public static Color Coral => new Color(255, 127, 80);
        /// <summary>
        /// Represents the color with the hex value #6495ED.
        /// </summary>
        public static Color CornflowerBlue => new Color(100, 149, 237);
        /// <summary>
        /// Represents the color with the hex value #FFF8DC.
        /// </summary>
        public static Color Cornsilk => new Color(255, 248, 220);
        /// <summary>
        /// Represents the color with the hex value #DC143C.
        /// </summary>
        public static Color Crimson => new Color(220, 20, 60);
        /// <summary>
        /// Represents the color with the hex value #00FFFF.
        /// </summary>
        public static Color Cyan => new Color(0, 255, 255);
        /// <summary>
        /// Represents the color with the hex value #00008B.
        /// </summary>
        public static Color DarkBlue => new Color(0, 0, 139);
        /// <summary>
        /// Represents the color with the hex value #008B8B.
        /// </summary>
        public static Color DarkCyan => new Color(0, 139, 139);
        /// <summary>
        /// Represents the color with the hex value #B8860B.
        /// </summary>
        public static Color DarkGoldenrod => new Color(184, 134, 11);
        /// <summary>
        /// Represents the color with the hex value #A9A9A9.
        /// </summary>
        public static Color DarkGray => new Color(169, 169, 169);
        /// <summary>
        /// Represents the color with the hex value #006400.
        /// </summary>
        public static Color DarkGreen => new Color(0, 100, 0);
        /// <summary>
        /// Represents the color with the hex value #BDB76B.
        /// </summary>
        public static Color DarkKhaki => new Color(189, 183, 107);
        /// <summary>
        /// Represents the color with the hex value #8B008B.
        /// </summary>
        public static Color DarkMagenta => new Color(139, 0, 139);
        /// <summary>
        /// Represents the color with the hex value #556B2F.
        /// </summary>
        public static Color DarkOliveGreen => new Color(85, 107, 47);
        /// <summary>
        /// Represents the color with the hex value #FF8C00.
        /// </summary>
        public static Color DarkOrange => new Color(255, 140, 0);
        /// <summary>
        /// Represents the color with the hex value #9932CC.
        /// </summary>
        public static Color DarkOrchid => new Color(153, 50, 204);
        /// <summary>
        /// Represents the color with the hex value #8B0000.
        /// </summary>
        public static Color DarkRed => new Color(139, 0, 0);
        /// <summary>
        /// Represents the color with the hex value #E9967A.
        /// </summary>
        public static Color DarkSalmon => new Color(233, 150, 122);
        /// <summary>
        /// Represents the color with the hex value #8FBC8F.
        /// </summary>
        public static Color DarkSeaGreen => new Color(143, 188, 143);
        /// <summary>
        /// Represents the color with the hex value #483D8B.
        /// </summary>
        public static Color DarkSlateBlue => new Color(72, 61, 139);
        /// <summary>
        /// Represents the color with the hex value #2F4F4F.
        /// </summary>
        public static Color DarkSlateGray => new Color(47, 79, 79);
        /// <summary>
        /// Represents the color with the hex value #00CED1.
        /// </summary>
        public static Color DarkTurquoise => new Color(0, 206, 209);
        /// <summary>
        /// Represents the color with the hex value #9400D3.
        /// </summary>
        public static Color DarkViolet => new Color(148, 0, 211);
        /// <summary>
        /// Represents the color with the hex value #FF1493.
        /// </summary>
        public static Color DeepPink => new Color(255, 20, 147);
        /// <summary>
        /// Represents the color with the hex value #00BFFF.
        /// </summary>
        public static Color DeepSkyBlue => new Color(0, 191, 255);
        /// <summary>
        /// Represents the color with the hex value #696969.
        /// </summary>
        public static Color DimGray => new Color(105, 105, 105);
        /// <summary>
        /// Represents the color with the hex value #1E90FF.
        /// </summary>
        public static Color DodgerBlue => new Color(30, 144, 255);
        /// <summary>
        /// Represents the color with the hex value #B22222.
        /// </summary>
        public static Color Firebrick => new Color(178, 34, 34);
        /// <summary>
        /// Represents the color with the hex value #FFFAF0.
        /// </summary>
        public static Color FloralWhite => new Color(255, 250, 240);
        /// <summary>
        /// Represents the color with the hex value #228B22.
        /// </summary>
        public static Color ForestGreen => new Color(34, 139, 34);
        /// <summary>
        /// Represents the color with the hex value #FF00FF.
        /// </summary>
        public static Color Fuchsia => new Color(255, 0, 255);
        /// <summary>
        /// Represents the color with the hex value #DCDCDC.
        /// </summary>
        public static Color Gainsboro => new Color(220, 220, 220);
        /// <summary>
        /// Represents the color with the hex value #F8F8FF.
        /// </summary>
        public static Color GhostWhite => new Color(248, 248, 255);
        /// <summary>
        /// Represents the color with the hex value #FFD700.
        /// </summary>
        public static Color Gold => new Color(255, 215, 0);
        /// <summary>
        /// Represents the color with the hex value #DAA520.
        /// </summary>
        public static Color Goldenrod => new Color(218, 165, 32);
        /// <summary>
        /// Represents the color with the hex value #808080.
        /// </summary>
        public static Color Gray => new Color(128, 128, 128);
        /// <summary>
        /// Represents the color with the hex value #008000.
        /// </summary>
        public static Color Green => new Color(0, 128, 0);
        /// <summary>
        /// Represents the color with the hex value #ADFF2F.
        /// </summary>
        public static Color GreenYellow => new Color(173, 255, 47);
        /// <summary>
        /// Represents the color with the hex value #F0FFF0.
        /// </summary>
        public static Color Honeydew => new Color(240, 255, 240);
        /// <summary>
        /// Represents the color with the hex value #FF69B4.
        /// </summary>
        public static Color HotPink => new Color(255, 105, 180);
        /// <summary>
        /// Represents the color with the hex value #CD5C5C.
        /// </summary>
        public static Color IndianRed => new Color(205, 92, 92);
        /// <summary>
        /// Represents the color with the hex value #4B0082.
        /// </summary>
        public static Color Indigo => new Color(75, 0, 130);
        /// <summary>
        /// Represents the color with the hex value #FFFFF0.
        /// </summary>
        public static Color Ivory => new Color(255, 255, 240);
        /// <summary>
        /// Represents the color with the hex value #F0E68C.
        /// </summary>
        public static Color Khaki => new Color(240, 230, 140);
        /// <summary>
        /// Represents the color with the hex value #E6E6FA.
        /// </summary>
        public static Color Lavender => new Color(230, 230, 250);
        /// <summary>
        /// Represents the color with the hex value #FFF0F5.
        /// </summary>
        public static Color LavenderBlush => new Color(255, 240, 245);
        /// <summary>
        /// Represents the color with the hex value #7CFC00.
        /// </summary>
        public static Color LawnGreen => new Color(124, 252, 0);
        /// <summary>
        /// Represents the color with the hex value #FFFACD.
        /// </summary>
        public static Color LemonChiffon => new Color(255, 250, 205);
        /// <summary>
        /// Represents the color with the hex value #ADD8E6.
        /// </summary>
        public static Color LightBlue => new Color(173, 216, 230);
        /// <summary>
        /// Represents the color with the hex value #F08080.
        /// </summary>
        public static Color LightCoral => new Color(240, 128, 128);
        /// <summary>
        /// Represents the color with the hex value #E0FFFF.
        /// </summary>
        public static Color LightCyan => new Color(224, 255, 255);
        /// <summary>
        /// Represents the color with the hex value #FAFAD2.
        /// </summary>
        public static Color LightGoldenrodYellow => new Color(250, 250, 210);
        /// <summary>
        /// Represents the color with the hex value #D3D3D3.
        /// </summary>
        public static Color LightGray => new Color(211, 211, 211);
        /// <summary>
        /// Represents the color with the hex value #90EE90.
        /// </summary>
        public static Color LightGreen => new Color(144, 238, 144);
        /// <summary>
        /// Represents the color with the hex value #FFB6C1.
        /// </summary>
        public static Color LightPink => new Color(255, 182, 193);
        /// <summary>
        /// Represents the color with the hex value #FFA07A.
        /// </summary>
        public static Color LightSalmon => new Color(255, 160, 122);
        /// <summary>
        /// Represents the color with the hex value #20B2AA.
        /// </summary>
        public static Color LightSeaGreen => new Color(32, 178, 170);
        /// <summary>
        /// Represents the color with the hex value #87CEFA.
        /// </summary>
        public static Color LightSkyBlue => new Color(135, 206, 250);
        /// <summary>
        /// Represents the color with the hex value #778899.
        /// </summary>
        public static Color LightSlateGray => new Color(119, 136, 153);
        /// <summary>
        /// Represents the color with the hex value #B0C4DE.
        /// </summary>
        public static Color LightSteelBlue => new Color(176, 196, 222);
        /// <summary>
        /// Represents the color with the hex value #FFFFE0.
        /// </summary>
        public static Color LightYellow => new Color(255, 255, 224);
        /// <summary>
        /// Represents the color with the hex value #00FF00.
        /// </summary>
        public static Color Lime => new Color(0, 255, 0);
        /// <summary>
        /// Represents the color with the hex value #32CD32.
        /// </summary>
        public static Color LimeGreen => new Color(50, 205, 50);
        /// <summary>
        /// Represents the color with the hex value #FAF0E6.
        /// </summary>
        public static Color Linen => new Color(250, 240, 230);
        /// <summary>
        /// Represents the color with the hex value #FF00FF.
        /// </summary>
        public static Color Magenta => new Color(255, 0, 255);
        /// <summary>
        /// Represents the color with the hex value #800000.
        /// </summary>
        public static Color Maroon => new Color(128, 0, 0);
        /// <summary>
        /// Represents the color with the hex value #66CDAA.
        /// </summary>
        public static Color MediumAquamarine => new Color(102, 205, 170);
        /// <summary>
        /// Represents the color with the hex value #0000CD.
        /// </summary>
        public static Color MediumBlue => new Color(0, 0, 205);
        /// <summary>
        /// Represents the color with the hex value #BA55D3.
        /// </summary>
        public static Color MediumOrchid => new Color(186, 85, 211);
        /// <summary>
        /// Represents the color with the hex value #9370DB.
        /// </summary>
        public static Color MediumPurple => new Color(147, 112, 219);
        /// <summary>
        /// Represents the color with the hex value #3CB371.
        /// </summary>
        public static Color MediumSeaGreen => new Color(60, 179, 113);
        /// <summary>
        /// Represents the color with the hex value #7B68EE.
        /// </summary>
        public static Color MediumSlateBlue => new Color(123, 104, 238);
        /// <summary>
        /// Represents the color with the hex value #00FA9A.
        /// </summary>
        public static Color MediumSpringGreen => new Color(0, 250, 154);
        /// <summary>
        /// Represents the color with the hex value #48D1CC.
        /// </summary>
        public static Color MediumTurquoise => new Color(72, 209, 204);
        /// <summary>
        /// Represents the color with the hex value #C71585.
        /// </summary>
        public static Color MediumVioletRed => new Color(199, 21, 133);
        /// <summary>
        /// Represents the color with the hex value #191970.
        /// </summary>
        public static Color MidnightBlue => new Color(25, 25, 112);
        /// <summary>
        /// Represents the color with the hex value #F5FFFA.
        /// </summary>
        public static Color MintCream => new Color(245, 255, 250);
        /// <summary>
        /// Represents the color with the hex value #FFE4E1.
        /// </summary>
        public static Color MistyRose => new Color(255, 228, 225);
        /// <summary>
        /// Represents the color with the hex value #FFE4B5.
        /// </summary>
        public static Color Moccasin => new Color(255, 228, 181);
        /// <summary>
        /// Represents the color with the hex value #FFDEAD.
        /// </summary>
        public static Color NavajoWhite => new Color(255, 222, 173);
        /// <summary>
        /// Represents the color with the hex value #000080.
        /// </summary>
        public static Color Navy => new Color(0, 0, 128);
        /// <summary>
        /// Represents the color with the hex value #FDF5E6.
        /// </summary>
        public static Color OldLace => new Color(253, 245, 230);
        /// <summary>
        /// Represents the color with the hex value #808000.
        /// </summary>
        public static Color Olive => new Color(128, 128, 0);
        /// <summary>
        /// Represents the color with the hex value #6B8E23.
        /// </summary>
        public static Color OliveDrab => new Color(107, 142, 35);
        /// <summary>
        /// Represents the color with the hex value #FFA500.
        /// </summary>
        public static Color Orange => new Color(255, 165, 0);
        /// <summary>
        /// Represents the color with the hex value #FF4500.
        /// </summary>
        public static Color OrangeRed => new Color(255, 69, 0);
        /// <summary>
        /// Represents the color with the hex value #DA70D6.
        /// </summary>
        public static Color Orchid => new Color(218, 112, 214);
        /// <summary>
        /// Represents the color with the hex value #EEE8AA.
        /// </summary>
        public static Color PaleGoldenrod => new Color(238, 232, 170);
        /// <summary>
        /// Represents the color with the hex value #98FB98.
        /// </summary>
        public static Color PaleGreen => new Color(152, 251, 152);
        /// <summary>
        /// Represents the color with the hex value #AFEEEE.
        /// </summary>
        public static Color PaleTurquoise => new Color(175, 238, 238);
        /// <summary>
        /// Represents the color with the hex value #DB7093.
        /// </summary>
        public static Color PaleVioletRed => new Color(219, 112, 147);
        /// <summary>
        /// Represents the color with the hex value #FFEFD5.
        /// </summary>
        public static Color PapayaWhip => new Color(255, 239, 213);
        /// <summary>
        /// Represents the color with the hex value #FFDAB9.
        /// </summary>
        public static Color PeachPuff => new Color(255, 218, 185);
        /// <summary>
        /// Represents the color with the hex value #CD853F.
        /// </summary>
        public static Color Peru => new Color(205, 133, 63);
        /// <summary>
        /// Represents the color with the hex value #FFC0CB.
        /// </summary>
        public static Color Pink => new Color(255, 192, 203);
        /// <summary>
        /// Represents the color with the hex value #DDA0DD.
        /// </summary>
        public static Color Plum => new Color(221, 160, 221);
        /// <summary>
        /// Represents the color with the hex value #B0E0E6.
        /// </summary>
        public static Color PowderBlue => new Color(176, 224, 230);
        /// <summary>
        /// Represents the color with the hex value #800080.
        /// </summary>
        public static Color Purple => new Color(128, 0, 128);
        /// <summary>
        /// Represents the color with the hex value #FF0000.
        /// </summary>
        public static Color Red => new Color(255, 0, 0);
        /// <summary>
        /// Represents the color with the hex value #BC8F8F.
        /// </summary>
        public static Color RosyBrown => new Color(188, 143, 143);
        /// <summary>
        /// Represents the color with the hex value #4169E1.
        /// </summary>
        public static Color RoyalBlue => new Color(65, 105, 225);
        /// <summary>
        /// Represents the color with the hex value #8B4513.
        /// </summary>
        public static Color SaddleBrown => new Color(139, 69, 19);
        /// <summary>
        /// Represents the color with the hex value #FA8072.
        /// </summary>
        public static Color Salmon => new Color(250, 128, 114);
        /// <summary>
        /// Represents the color with the hex value #F4A460.
        /// </summary>
        public static Color SandyBrown => new Color(244, 164, 96);
        /// <summary>
        /// Represents the color with the hex value #2E8B57.
        /// </summary>
        public static Color SeaGreen => new Color(46, 139, 87);
        /// <summary>
        /// Represents the color with the hex value #FFF5EE.
        /// </summary>
        public static Color SeaShell => new Color(255, 245, 238);
        /// <summary>
        /// Represents the color with the hex value #A0522D.
        /// </summary>
        public static Color Sienna => new Color(160, 82, 45);
        /// <summary>
        /// Represents the color with the hex value #C0C0C0.
        /// </summary>
        public static Color Silver => new Color(192, 192, 192);
        /// <summary>
        /// Represents the color with the hex value #87CEEB.
        /// </summary>
        public static Color SkyBlue => new Color(135, 206, 235);
        /// <summary>
        /// Represents the color with the hex value #6A5ACD.
        /// </summary>
        public static Color SlateBlue => new Color(106, 90, 205);
        /// <summary>
        /// Represents the color with the hex value #708090.
        /// </summary>
        public static Color SlateGray => new Color(112, 128, 144);
        /// <summary>
        /// Represents the color with the hex value #FFFAFA.
        /// </summary>
        public static Color Snow => new Color(255, 250, 250);
        /// <summary>
        /// Represents the color with the hex value #00FF7F.
        /// </summary>
        public static Color SpringGreen => new Color(0, 255, 127);
        /// <summary>
        /// Represents the color with the hex value #4682B4.
        /// </summary>
        public static Color SteelBlue => new Color(70, 130, 180);
        /// <summary>
        /// Represents the color with the hex value #D2B48C.
        /// </summary>
        public static Color Tan => new Color(210, 180, 140);
        /// <summary>
        /// Represents the color with the hex value #008080.
        /// </summary>
        public static Color Teal => new Color(0, 128, 128);
        /// <summary>
        /// Represents the color with the hex value #D8BFD8.
        /// </summary>
        public static Color Thistle => new Color(216, 191, 216);
        /// <summary>
        /// Represents the color with the hex value #FF6347.
        /// </summary>
        public static Color Tomato => new Color(255, 99, 71);
        /// <summary>
        /// Represents the color with the hex value #40E0D0.
        /// </summary>
        public static Color Turquoise => new Color(64, 224, 208);
        /// <summary>
        /// Represents the color with the hex value #EE82EE.
        /// </summary>
        public static Color Violet => new Color(238, 130, 238);
        /// <summary>
        /// Represents the color with the hex value #F5DEB3.
        /// </summary>
        public static Color Wheat => new Color(245, 222, 179);
        /// <summary>
        /// Represents the color with the hex value #FFFFFF.
        /// </summary>
        public static Color White => new Color(255, 255, 255);
        /// <summary>
        /// Represents the color with the hex value #F5F5F5.
        /// </summary>
        public static Color WhiteSmoke => new Color(245, 245, 245);
        /// <summary>
        /// Represents the color with the hex value #FFFF00.
        /// </summary>
        public static Color Yellow => new Color(255, 255, 0);
        /// <summary>
        /// Represents the color with the hex value #9ACD32.
        /// </summary>
        public static Color YellowGreen => new Color(154, 205, 50);
        #endregion
        #region AutoCAD Colors
        /// <summary>
        /// Color Index
        /// </summary>
        public class Index
        {
            /// <summary>
            /// Get Color by the <paramref name="index"/>
            /// </summary>
            /// <param name="index">0 to 255</param>
            /// <returns></returns>
            public static Color Get(byte index)
            {
                return typeof(Index).GetProperty("Color_" + index).GetValue(null) as Color;
            }
            /// <summary>
            /// Represents the color black with the hex value #000000.
            /// </summary>
            public static Color Color_0 => new Color(0, 0, 0);
            /// <summary>
            /// Represents the color red with the hex value #FF0000.
            /// </summary>
            public static Color Color_1 => new Color(255, 0, 0);
            /// <summary>
            /// Represents the color yellow with the hex value #FFFF00.
            /// </summary>
            public static Color Color_2 => new Color(255, 255, 0);
            /// <summary>
            /// Represents the color green with the hex value #00FF00.
            /// </summary>
            public static Color Color_3 => new Color(0, 255, 0);
            /// <summary>
            /// Represents the color cyan with the hex value #00FFFF.
            /// </summary>
            public static Color Color_4 => new Color(0, 255, 255);
            /// <summary>
            /// Represents the color blue with the hex value #0000FF.
            /// </summary>
            public static Color Color_5 => new Color(0, 0, 255);
            /// <summary>
            /// Represents the color magenta with the hex value #FF00FF.
            /// </summary>
            public static Color Color_6 => new Color(255, 0, 255);
            /// <summary>
            /// Represents the color white with the hex value #FFFFFF.
            /// </summary>
            public static Color Color_7 => new Color(255, 255, 255);
            /// <summary>
            /// Represents the color black gray with the hex value #414141.
            /// </summary>
            public static Color Color_8 => new Color(65, 65, 65);
            /// <summary>
            /// Represents the color gray with the hex value #808080.
            /// </summary>
            public static Color Color_9 => new Color(128, 128, 128);
            /// <summary>
            /// Represents the color with the hex value #FF0000.
            /// </summary>
            public static Color Color_10 => new Color(255, 0, 0);
            /// <summary>
            /// Represents the color with the hex value #FFAAAA.
            /// </summary>
            public static Color Color_11 => new Color(255, 170, 170);
            /// <summary>
            /// Represents the color with the hex value #BD0000.
            /// </summary>
            public static Color Color_12 => new Color(189, 0, 0);
            /// <summary>
            /// Represents the color with the hex value #BD7E7E.
            /// </summary>
            public static Color Color_13 => new Color(189, 126, 126);
            /// <summary>
            /// Represents the color with the hex value #810000.
            /// </summary>
            public static Color Color_14 => new Color(129, 0, 0);
            /// <summary>
            /// Represents the color with the hex value #815656.
            /// </summary>
            public static Color Color_15 => new Color(129, 86, 86);
            /// <summary>
            /// Represents the color with the hex value #680000.
            /// </summary>
            public static Color Color_16 => new Color(104, 0, 0);
            /// <summary>
            /// Represents the color with the hex value #684545.
            /// </summary>
            public static Color Color_17 => new Color(104, 69, 69);
            /// <summary>
            /// Represents the color with the hex value #4F0000.
            /// </summary>
            public static Color Color_18 => new Color(79, 0, 0);
            /// <summary>
            /// Represents the color with the hex value #4F3535.
            /// </summary>
            public static Color Color_19 => new Color(79, 53, 53);
            /// <summary>
            /// Represents the color with the hex value #FF3F00.
            /// </summary>
            public static Color Color_20 => new Color(255, 63, 0);
            /// <summary>
            /// Represents the color with the hex value #FFBFAA.
            /// </summary>
            public static Color Color_21 => new Color(255, 191, 170);
            /// <summary>
            /// Represents the color with the hex value #BD2E00.
            /// </summary>
            public static Color Color_22 => new Color(189, 46, 0);
            /// <summary>
            /// Represents the color with the hex value #BD8D7E.
            /// </summary>
            public static Color Color_23 => new Color(189, 141, 126);
            /// <summary>
            /// Represents the color with the hex value #811F00.
            /// </summary>
            public static Color Color_24 => new Color(129, 31, 0);
            /// <summary>
            /// Represents the color with the hex value #816056.
            /// </summary>
            public static Color Color_25 => new Color(129, 96, 86);
            /// <summary>
            /// Represents the color with the hex value #681900.
            /// </summary>
            public static Color Color_26 => new Color(104, 25, 0);
            /// <summary>
            /// Represents the color with the hex value #684E45.
            /// </summary>
            public static Color Color_27 => new Color(104, 78, 69);
            /// <summary>
            /// Represents the color with the hex value #4F1300.
            /// </summary>
            public static Color Color_28 => new Color(79, 19, 0);
            /// <summary>
            /// Represents the color with the hex value #4F3B35.
            /// </summary>
            public static Color Color_29 => new Color(79, 59, 53);
            /// <summary>
            /// Represents the color with the hex value #FF7F00.
            /// </summary>
            public static Color Color_30 => new Color(255, 127, 0);
            /// <summary>
            /// Represents the color with the hex value #FFD4AA.
            /// </summary>
            public static Color Color_31 => new Color(255, 212, 170);
            /// <summary>
            /// Represents the color with the hex value #BD5E00.
            /// </summary>
            public static Color Color_32 => new Color(189, 94, 0);
            /// <summary>
            /// Represents the color with the hex value #BD9D7E.
            /// </summary>
            public static Color Color_33 => new Color(189, 157, 126);
            /// <summary>
            /// Represents the color with the hex value #814000.
            /// </summary>
            public static Color Color_34 => new Color(129, 64, 0);
            /// <summary>
            /// Represents the color with the hex value #816B56.
            /// </summary>
            public static Color Color_35 => new Color(129, 107, 86);
            /// <summary>
            /// Represents the color with the hex value #683400.
            /// </summary>
            public static Color Color_36 => new Color(104, 52, 0);
            /// <summary>
            /// Represents the color with the hex value #685645.
            /// </summary>
            public static Color Color_37 => new Color(104, 86, 69);
            /// <summary>
            /// Represents the color with the hex value #4F2700.
            /// </summary>
            public static Color Color_38 => new Color(79, 39, 0);
            /// <summary>
            /// Represents the color with the hex value #4F4235.
            /// </summary>
            public static Color Color_39 => new Color(79, 66, 53);
            /// <summary>
            /// Represents the color with the hex value #FFBF00.
            /// </summary>
            public static Color Color_40 => new Color(255, 191, 0);
            /// <summary>
            /// Represents the color with the hex value #FFEAAA.
            /// </summary>
            public static Color Color_41 => new Color(255, 234, 170);
            /// <summary>
            /// Represents the color with the hex value #BD8D00.
            /// </summary>
            public static Color Color_42 => new Color(189, 141, 0);
            /// <summary>
            /// Represents the color with the hex value #BDAD7E.
            /// </summary>
            public static Color Color_43 => new Color(189, 173, 126);
            /// <summary>
            /// Represents the color with the hex value #816000.
            /// </summary>
            public static Color Color_44 => new Color(129, 96, 0);
            /// <summary>
            /// Represents the color with the hex value #817656.
            /// </summary>
            public static Color Color_45 => new Color(129, 118, 86);
            /// <summary>
            /// Represents the color with the hex value #684E00.
            /// </summary>
            public static Color Color_46 => new Color(104, 78, 0);
            /// <summary>
            /// Represents the color with the hex value #685F45.
            /// </summary>
            public static Color Color_47 => new Color(104, 95, 69);
            /// <summary>
            /// Represents the color with the hex value #4F3B00.
            /// </summary>
            public static Color Color_48 => new Color(79, 59, 0);
            /// <summary>
            /// Represents the color with the hex value #4F4935.
            /// </summary>
            public static Color Color_49 => new Color(79, 73, 53);
            /// <summary>
            /// Represents the color with the hex value #FFFF00.
            /// </summary>
            public static Color Color_50 => new Color(255, 255, 0);
            /// <summary>
            /// Represents the color with the hex value #FFFFAA.
            /// </summary>
            public static Color Color_51 => new Color(255, 255, 170);
            /// <summary>
            /// Represents the color with the hex value #BDBD00.
            /// </summary>
            public static Color Color_52 => new Color(189, 189, 0);
            /// <summary>
            /// Represents the color with the hex value #BDBD7E.
            /// </summary>
            public static Color Color_53 => new Color(189, 189, 126);
            /// <summary>
            /// Represents the color with the hex value #818100.
            /// </summary>
            public static Color Color_54 => new Color(129, 129, 0);
            /// <summary>
            /// Represents the color with the hex value #818156.
            /// </summary>
            public static Color Color_55 => new Color(129, 129, 86);
            /// <summary>
            /// Represents the color with the hex value #686800.
            /// </summary>
            public static Color Color_56 => new Color(104, 104, 0);
            /// <summary>
            /// Represents the color with the hex value #686845.
            /// </summary>
            public static Color Color_57 => new Color(104, 104, 69);
            /// <summary>
            /// Represents the color with the hex value #4F4F00.
            /// </summary>
            public static Color Color_58 => new Color(79, 79, 0);
            /// <summary>
            /// Represents the color with the hex value #4F4F35.
            /// </summary>
            public static Color Color_59 => new Color(79, 79, 53);
            /// <summary>
            /// Represents the color with the hex value #BFFF00.
            /// </summary>
            public static Color Color_60 => new Color(191, 255, 0);
            /// <summary>
            /// Represents the color with the hex value #EAFFAA.
            /// </summary>
            public static Color Color_61 => new Color(234, 255, 170);
            /// <summary>
            /// Represents the color with the hex value #8DBD00.
            /// </summary>
            public static Color Color_62 => new Color(141, 189, 0);
            /// <summary>
            /// Represents the color with the hex value #ADBD7E.
            /// </summary>
            public static Color Color_63 => new Color(173, 189, 126);
            /// <summary>
            /// Represents the color with the hex value #608100.
            /// </summary>
            public static Color Color_64 => new Color(96, 129, 0);
            /// <summary>
            /// Represents the color with the hex value #768156.
            /// </summary>
            public static Color Color_65 => new Color(118, 129, 86);
            /// <summary>
            /// Represents the color with the hex value #4E6800.
            /// </summary>
            public static Color Color_66 => new Color(78, 104, 0);
            /// <summary>
            /// Represents the color with the hex value #5F6845.
            /// </summary>
            public static Color Color_67 => new Color(95, 104, 69);
            /// <summary>
            /// Represents the color with the hex value #3B4F00.
            /// </summary>
            public static Color Color_68 => new Color(59, 79, 0);
            /// <summary>
            /// Represents the color with the hex value #494F35.
            /// </summary>
            public static Color Color_69 => new Color(73, 79, 53);
            /// <summary>
            /// Represents the color with the hex value #7FFF00.
            /// </summary>
            public static Color Color_70 => new Color(127, 255, 0);
            /// <summary>
            /// Represents the color with the hex value #D4FFAA.
            /// </summary>
            public static Color Color_71 => new Color(212, 255, 170);
            /// <summary>
            /// Represents the color with the hex value #5EBD00.
            /// </summary>
            public static Color Color_72 => new Color(94, 189, 0);
            /// <summary>
            /// Represents the color with the hex value #9DBD7E.
            /// </summary>
            public static Color Color_73 => new Color(157, 189, 126);
            /// <summary>
            /// Represents the color with the hex value #408100.
            /// </summary>
            public static Color Color_74 => new Color(64, 129, 0);
            /// <summary>
            /// Represents the color with the hex value #6B8156.
            /// </summary>
            public static Color Color_75 => new Color(107, 129, 86);
            /// <summary>
            /// Represents the color with the hex value #346800.
            /// </summary>
            public static Color Color_76 => new Color(52, 104, 0);
            /// <summary>
            /// Represents the color with the hex value #566845.
            /// </summary>
            public static Color Color_77 => new Color(86, 104, 69);
            /// <summary>
            /// Represents the color with the hex value #274F00.
            /// </summary>
            public static Color Color_78 => new Color(39, 79, 0);
            /// <summary>
            /// Represents the color with the hex value #424F35.
            /// </summary>
            public static Color Color_79 => new Color(66, 79, 53);
            /// <summary>
            /// Represents the color with the hex value #3FFF00.
            /// </summary>
            public static Color Color_80 => new Color(63, 255, 0);
            /// <summary>
            /// Represents the color with the hex value #BFFFAA.
            /// </summary>
            public static Color Color_81 => new Color(191, 255, 170);
            /// <summary>
            /// Represents the color with the hex value #2EBD00.
            /// </summary>
            public static Color Color_82 => new Color(46, 189, 0);
            /// <summary>
            /// Represents the color with the hex value #8DBD7E.
            /// </summary>
            public static Color Color_83 => new Color(141, 189, 126);
            /// <summary>
            /// Represents the color with the hex value #1F8100.
            /// </summary>
            public static Color Color_84 => new Color(31, 129, 0);
            /// <summary>
            /// Represents the color with the hex value #608156.
            /// </summary>
            public static Color Color_85 => new Color(96, 129, 86);
            /// <summary>
            /// Represents the color with the hex value #196800.
            /// </summary>
            public static Color Color_86 => new Color(25, 104, 0);
            /// <summary>
            /// Represents the color with the hex value #4E6845.
            /// </summary>
            public static Color Color_87 => new Color(78, 104, 69);
            /// <summary>
            /// Represents the color with the hex value #134F00.
            /// </summary>
            public static Color Color_88 => new Color(19, 79, 0);
            /// <summary>
            /// Represents the color with the hex value #3B4F35.
            /// </summary>
            public static Color Color_89 => new Color(59, 79, 53);
            /// <summary>
            /// Represents the color with the hex value #00FF00.
            /// </summary>
            public static Color Color_90 => new Color(0, 255, 0);
            /// <summary>
            /// Represents the color with the hex value #AAFFAA.
            /// </summary>
            public static Color Color_91 => new Color(170, 255, 170);
            /// <summary>
            /// Represents the color with the hex value #00BD00.
            /// </summary>
            public static Color Color_92 => new Color(0, 189, 0);
            /// <summary>
            /// Represents the color with the hex value #7EBD7E.
            /// </summary>
            public static Color Color_93 => new Color(126, 189, 126);
            /// <summary>
            /// Represents the color with the hex value #008100.
            /// </summary>
            public static Color Color_94 => new Color(0, 129, 0);
            /// <summary>
            /// Represents the color with the hex value #568156.
            /// </summary>
            public static Color Color_95 => new Color(86, 129, 86);
            /// <summary>
            /// Represents the color with the hex value #006800.
            /// </summary>
            public static Color Color_96 => new Color(0, 104, 0);
            /// <summary>
            /// Represents the color with the hex value #456845.
            /// </summary>
            public static Color Color_97 => new Color(69, 104, 69);
            /// <summary>
            /// Represents the color with the hex value #004F00.
            /// </summary>
            public static Color Color_98 => new Color(0, 79, 0);
            /// <summary>
            /// Represents the color with the hex value #354F35.
            /// </summary>
            public static Color Color_99 => new Color(53, 79, 53);
            /// <summary>
            /// Represents the color with the hex value #00FF3F.
            /// </summary>
            public static Color Color_100 => new Color(0, 255, 63);
            /// <summary>
            /// Represents the color with the hex value #AAFFBF.
            /// </summary>
            public static Color Color_101 => new Color(170, 255, 191);
            /// <summary>
            /// Represents the color with the hex value #00BD2E.
            /// </summary>
            public static Color Color_102 => new Color(0, 189, 46);
            /// <summary>
            /// Represents the color with the hex value #7EBD8D.
            /// </summary>
            public static Color Color_103 => new Color(126, 189, 141);
            /// <summary>
            /// Represents the color with the hex value #00811F.
            /// </summary>
            public static Color Color_104 => new Color(0, 129, 31);
            /// <summary>
            /// Represents the color with the hex value #568160.
            /// </summary>
            public static Color Color_105 => new Color(86, 129, 96);
            /// <summary>
            /// Represents the color with the hex value #006819.
            /// </summary>
            public static Color Color_106 => new Color(0, 104, 25);
            /// <summary>
            /// Represents the color with the hex value #45684E.
            /// </summary>
            public static Color Color_107 => new Color(69, 104, 78);
            /// <summary>
            /// Represents the color with the hex value #004F13.
            /// </summary>
            public static Color Color_108 => new Color(0, 79, 19);
            /// <summary>
            /// Represents the color with the hex value #354F3B.
            /// </summary>
            public static Color Color_109 => new Color(53, 79, 59);
            /// <summary>
            /// Represents the color with the hex value #00FF7F.
            /// </summary>
            public static Color Color_110 => new Color(0, 255, 127);
            /// <summary>
            /// Represents the color with the hex value #AAFFD4.
            /// </summary>
            public static Color Color_111 => new Color(170, 255, 212);
            /// <summary>
            /// Represents the color with the hex value #00BD5E.
            /// </summary>
            public static Color Color_112 => new Color(0, 189, 94);
            /// <summary>
            /// Represents the color with the hex value #7EBD9D.
            /// </summary>
            public static Color Color_113 => new Color(126, 189, 157);
            /// <summary>
            /// Represents the color with the hex value #008140.
            /// </summary>
            public static Color Color_114 => new Color(0, 129, 64);
            /// <summary>
            /// Represents the color with the hex value #56816B.
            /// </summary>
            public static Color Color_115 => new Color(86, 129, 107);
            /// <summary>
            /// Represents the color with the hex value #006834.
            /// </summary>
            public static Color Color_116 => new Color(0, 104, 52);
            /// <summary>
            /// Represents the color with the hex value #456856.
            /// </summary>
            public static Color Color_117 => new Color(69, 104, 86);
            /// <summary>
            /// Represents the color with the hex value #004F27.
            /// </summary>
            public static Color Color_118 => new Color(0, 79, 39);
            /// <summary>
            /// Represents the color with the hex value #354F42.
            /// </summary>
            public static Color Color_119 => new Color(53, 79, 66);
            /// <summary>
            /// Represents the color with the hex value #00FFBF.
            /// </summary>
            public static Color Color_120 => new Color(0, 255, 191);
            /// <summary>
            /// Represents the color with the hex value #AAFFEA.
            /// </summary>
            public static Color Color_121 => new Color(170, 255, 234);
            /// <summary>
            /// Represents the color with the hex value #00BD8D.
            /// </summary>
            public static Color Color_122 => new Color(0, 189, 141);
            /// <summary>
            /// Represents the color with the hex value #7EBDAD.
            /// </summary>
            public static Color Color_123 => new Color(126, 189, 173);
            /// <summary>
            /// Represents the color with the hex value #008160.
            /// </summary>
            public static Color Color_124 => new Color(0, 129, 96);
            /// <summary>
            /// Represents the color with the hex value #568176.
            /// </summary>
            public static Color Color_125 => new Color(86, 129, 118);
            /// <summary>
            /// Represents the color with the hex value #00684E.
            /// </summary>
            public static Color Color_126 => new Color(0, 104, 78);
            /// <summary>
            /// Represents the color with the hex value #45685F.
            /// </summary>
            public static Color Color_127 => new Color(69, 104, 95);
            /// <summary>
            /// Represents the color with the hex value #004F3B.
            /// </summary>
            public static Color Color_128 => new Color(0, 79, 59);
            /// <summary>
            /// Represents the color with the hex value #354F49.
            /// </summary>
            public static Color Color_129 => new Color(53, 79, 73);
            /// <summary>
            /// Represents the color with the hex value #00FFFF.
            /// </summary>
            public static Color Color_130 => new Color(0, 255, 255);
            /// <summary>
            /// Represents the color with the hex value #AAFFFF.
            /// </summary>
            public static Color Color_131 => new Color(170, 255, 255);
            /// <summary>
            /// Represents the color with the hex value #00BDBD.
            /// </summary>
            public static Color Color_132 => new Color(0, 189, 189);
            /// <summary>
            /// Represents the color with the hex value #7EBDBD.
            /// </summary>
            public static Color Color_133 => new Color(126, 189, 189);
            /// <summary>
            /// Represents the color with the hex value #008181.
            /// </summary>
            public static Color Color_134 => new Color(0, 129, 129);
            /// <summary>
            /// Represents the color with the hex value #568181.
            /// </summary>
            public static Color Color_135 => new Color(86, 129, 129);
            /// <summary>
            /// Represents the color with the hex value #006868.
            /// </summary>
            public static Color Color_136 => new Color(0, 104, 104);
            /// <summary>
            /// Represents the color with the hex value #456868.
            /// </summary>
            public static Color Color_137 => new Color(69, 104, 104);
            /// <summary>
            /// Represents the color with the hex value #004F4F.
            /// </summary>
            public static Color Color_138 => new Color(0, 79, 79);
            /// <summary>
            /// Represents the color with the hex value #354F4F.
            /// </summary>
            public static Color Color_139 => new Color(53, 79, 79);
            /// <summary>
            /// Represents the color with the hex value #00BFFF.
            /// </summary>
            public static Color Color_140 => new Color(0, 191, 255);
            /// <summary>
            /// Represents the color with the hex value #AAEAFF.
            /// </summary>
            public static Color Color_141 => new Color(170, 234, 255);
            /// <summary>
            /// Represents the color with the hex value #008DBD.
            /// </summary>
            public static Color Color_142 => new Color(0, 141, 189);
            /// <summary>
            /// Represents the color with the hex value #7EADBD.
            /// </summary>
            public static Color Color_143 => new Color(126, 173, 189);
            /// <summary>
            /// Represents the color with the hex value #006081.
            /// </summary>
            public static Color Color_144 => new Color(0, 96, 129);
            /// <summary>
            /// Represents the color with the hex value #567681.
            /// </summary>
            public static Color Color_145 => new Color(86, 118, 129);
            /// <summary>
            /// Represents the color with the hex value #004E68.
            /// </summary>
            public static Color Color_146 => new Color(0, 78, 104);
            /// <summary>
            /// Represents the color with the hex value #455F68.
            /// </summary>
            public static Color Color_147 => new Color(69, 95, 104);
            /// <summary>
            /// Represents the color with the hex value #003B4F.
            /// </summary>
            public static Color Color_148 => new Color(0, 59, 79);
            /// <summary>
            /// Represents the color with the hex value #35494F.
            /// </summary>
            public static Color Color_149 => new Color(53, 73, 79);
            /// <summary>
            /// Represents the color with the hex value #007FFF.
            /// </summary>
            public static Color Color_150 => new Color(0, 127, 255);
            /// <summary>
            /// Represents the color with the hex value #AAD4FF.
            /// </summary>
            public static Color Color_151 => new Color(170, 212, 255);
            /// <summary>
            /// Represents the color with the hex value #005EBD.
            /// </summary>
            public static Color Color_152 => new Color(0, 94, 189);
            /// <summary>
            /// Represents the color with the hex value #7E9DBD.
            /// </summary>
            public static Color Color_153 => new Color(126, 157, 189);
            /// <summary>
            /// Represents the color with the hex value #004081.
            /// </summary>
            public static Color Color_154 => new Color(0, 64, 129);
            /// <summary>
            /// Represents the color with the hex value #566B81.
            /// </summary>
            public static Color Color_155 => new Color(86, 107, 129);
            /// <summary>
            /// Represents the color with the hex value #003468.
            /// </summary>
            public static Color Color_156 => new Color(0, 52, 104);
            /// <summary>
            /// Represents the color with the hex value #455668.
            /// </summary>
            public static Color Color_157 => new Color(69, 86, 104);
            /// <summary>
            /// Represents the color with the hex value #00274F.
            /// </summary>
            public static Color Color_158 => new Color(0, 39, 79);
            /// <summary>
            /// Represents the color with the hex value #35424F.
            /// </summary>
            public static Color Color_159 => new Color(53, 66, 79);
            /// <summary>
            /// Represents the color with the hex value #003FFF.
            /// </summary>
            public static Color Color_160 => new Color(0, 63, 255);
            /// <summary>
            /// Represents the color with the hex value #AABFFF.
            /// </summary>
            public static Color Color_161 => new Color(170, 191, 255);
            /// <summary>
            /// Represents the color with the hex value #002EBD.
            /// </summary>
            public static Color Color_162 => new Color(0, 46, 189);
            /// <summary>
            /// Represents the color with the hex value #7E8DBD.
            /// </summary>
            public static Color Color_163 => new Color(126, 141, 189);
            /// <summary>
            /// Represents the color with the hex value #001F81.
            /// </summary>
            public static Color Color_164 => new Color(0, 31, 129);
            /// <summary>
            /// Represents the color with the hex value #566081.
            /// </summary>
            public static Color Color_165 => new Color(86, 96, 129);
            /// <summary>
            /// Represents the color with the hex value #001968.
            /// </summary>
            public static Color Color_166 => new Color(0, 25, 104);
            /// <summary>
            /// Represents the color with the hex value #454E68.
            /// </summary>
            public static Color Color_167 => new Color(69, 78, 104);
            /// <summary>
            /// Represents the color with the hex value #00134F.
            /// </summary>
            public static Color Color_168 => new Color(0, 19, 79);
            /// <summary>
            /// Represents the color with the hex value #353B4F.
            /// </summary>
            public static Color Color_169 => new Color(53, 59, 79);
            /// <summary>
            /// Represents the color with the hex value #0000FF.
            /// </summary>
            public static Color Color_170 => new Color(0, 0, 255);
            /// <summary>
            /// Represents the color with the hex value #AAAAFF.
            /// </summary>
            public static Color Color_171 => new Color(170, 170, 255);
            /// <summary>
            /// Represents the color with the hex value #0000BD.
            /// </summary>
            public static Color Color_172 => new Color(0, 0, 189);
            /// <summary>
            /// Represents the color with the hex value #7E7EBD.
            /// </summary>
            public static Color Color_173 => new Color(126, 126, 189);
            /// <summary>
            /// Represents the color with the hex value #000081.
            /// </summary>
            public static Color Color_174 => new Color(0, 0, 129);
            /// <summary>
            /// Represents the color with the hex value #565681.
            /// </summary>
            public static Color Color_175 => new Color(86, 86, 129);
            /// <summary>
            /// Represents the color with the hex value #000068.
            /// </summary>
            public static Color Color_176 => new Color(0, 0, 104);
            /// <summary>
            /// Represents the color with the hex value #454568.
            /// </summary>
            public static Color Color_177 => new Color(69, 69, 104);
            /// <summary>
            /// Represents the color with the hex value #00004F.
            /// </summary>
            public static Color Color_178 => new Color(0, 0, 79);
            /// <summary>
            /// Represents the color with the hex value #35354F.
            /// </summary>
            public static Color Color_179 => new Color(53, 53, 79);
            /// <summary>
            /// Represents the color with the hex value #3F00FF.
            /// </summary>
            public static Color Color_180 => new Color(63, 0, 255);
            /// <summary>
            /// Represents the color with the hex value #BFAAFF.
            /// </summary>
            public static Color Color_181 => new Color(191, 170, 255);
            /// <summary>
            /// Represents the color with the hex value #2E00BD.
            /// </summary>
            public static Color Color_182 => new Color(46, 0, 189);
            /// <summary>
            /// Represents the color with the hex value #8D7EBD.
            /// </summary>
            public static Color Color_183 => new Color(141, 126, 189);
            /// <summary>
            /// Represents the color with the hex value #1F0081.
            /// </summary>
            public static Color Color_184 => new Color(31, 0, 129);
            /// <summary>
            /// Represents the color with the hex value #605681.
            /// </summary>
            public static Color Color_185 => new Color(96, 86, 129);
            /// <summary>
            /// Represents the color with the hex value #190068.
            /// </summary>
            public static Color Color_186 => new Color(25, 0, 104);
            /// <summary>
            /// Represents the color with the hex value #4E4568.
            /// </summary>
            public static Color Color_187 => new Color(78, 69, 104);
            /// <summary>
            /// Represents the color with the hex value #13004F.
            /// </summary>
            public static Color Color_188 => new Color(19, 0, 79);
            /// <summary>
            /// Represents the color with the hex value #3B354F.
            /// </summary>
            public static Color Color_189 => new Color(59, 53, 79);
            /// <summary>
            /// Represents the color with the hex value #7F00FF.
            /// </summary>
            public static Color Color_190 => new Color(127, 0, 255);
            /// <summary>
            /// Represents the color with the hex value #D4AAFF.
            /// </summary>
            public static Color Color_191 => new Color(212, 170, 255);
            /// <summary>
            /// Represents the color with the hex value #5E00BD.
            /// </summary>
            public static Color Color_192 => new Color(94, 0, 189);
            /// <summary>
            /// Represents the color with the hex value #9D7EBD.
            /// </summary>
            public static Color Color_193 => new Color(157, 126, 189);
            /// <summary>
            /// Represents the color with the hex value #400081.
            /// </summary>
            public static Color Color_194 => new Color(64, 0, 129);
            /// <summary>
            /// Represents the color with the hex value #6B5681.
            /// </summary>
            public static Color Color_195 => new Color(107, 86, 129);
            /// <summary>
            /// Represents the color with the hex value #340068.
            /// </summary>
            public static Color Color_196 => new Color(52, 0, 104);
            /// <summary>
            /// Represents the color with the hex value #564568.
            /// </summary>
            public static Color Color_197 => new Color(86, 69, 104);
            /// <summary>
            /// Represents the color with the hex value #27004F.
            /// </summary>
            public static Color Color_198 => new Color(39, 0, 79);
            /// <summary>
            /// Represents the color with the hex value #42354F.
            /// </summary>
            public static Color Color_199 => new Color(66, 53, 79);
            /// <summary>
            /// Represents the color with the hex value #BF00FF.
            /// </summary>
            public static Color Color_200 => new Color(191, 0, 255);
            /// <summary>
            /// Represents the color with the hex value #EAAAFF.
            /// </summary>
            public static Color Color_201 => new Color(234, 170, 255);
            /// <summary>
            /// Represents the color with the hex value #8D00BD.
            /// </summary>
            public static Color Color_202 => new Color(141, 0, 189);
            /// <summary>
            /// Represents the color with the hex value #AD7EBD.
            /// </summary>
            public static Color Color_203 => new Color(173, 126, 189);
            /// <summary>
            /// Represents the color with the hex value #600081.
            /// </summary>
            public static Color Color_204 => new Color(96, 0, 129);
            /// <summary>
            /// Represents the color with the hex value #765681.
            /// </summary>
            public static Color Color_205 => new Color(118, 86, 129);
            /// <summary>
            /// Represents the color with the hex value #4E0068.
            /// </summary>
            public static Color Color_206 => new Color(78, 0, 104);
            /// <summary>
            /// Represents the color with the hex value #5F4568.
            /// </summary>
            public static Color Color_207 => new Color(95, 69, 104);
            /// <summary>
            /// Represents the color with the hex value #3B004F.
            /// </summary>
            public static Color Color_208 => new Color(59, 0, 79);
            /// <summary>
            /// Represents the color with the hex value #49354F.
            /// </summary>
            public static Color Color_209 => new Color(73, 53, 79);
            /// <summary>
            /// Represents the color with the hex value #FF00FF.
            /// </summary>
            public static Color Color_210 => new Color(255, 0, 255);
            /// <summary>
            /// Represents the color with the hex value #FFAAFF.
            /// </summary>
            public static Color Color_211 => new Color(255, 170, 255);
            /// <summary>
            /// Represents the color with the hex value #BD00BD.
            /// </summary>
            public static Color Color_212 => new Color(189, 0, 189);
            /// <summary>
            /// Represents the color with the hex value #BD7EBD.
            /// </summary>
            public static Color Color_213 => new Color(189, 126, 189);
            /// <summary>
            /// Represents the color with the hex value #810081.
            /// </summary>
            public static Color Color_214 => new Color(129, 0, 129);
            /// <summary>
            /// Represents the color with the hex value #815681.
            /// </summary>
            public static Color Color_215 => new Color(129, 86, 129);
            /// <summary>
            /// Represents the color with the hex value #680068.
            /// </summary>
            public static Color Color_216 => new Color(104, 0, 104);
            /// <summary>
            /// Represents the color with the hex value #684568.
            /// </summary>
            public static Color Color_217 => new Color(104, 69, 104);
            /// <summary>
            /// Represents the color with the hex value #4F004F.
            /// </summary>
            public static Color Color_218 => new Color(79, 0, 79);
            /// <summary>
            /// Represents the color with the hex value #4F354F.
            /// </summary>
            public static Color Color_219 => new Color(79, 53, 79);
            /// <summary>
            /// Represents the color with the hex value #FF00BF.
            /// </summary>
            public static Color Color_220 => new Color(255, 0, 191);
            /// <summary>
            /// Represents the color with the hex value #FFAAEA.
            /// </summary>
            public static Color Color_221 => new Color(255, 170, 234);
            /// <summary>
            /// Represents the color with the hex value #BD008D.
            /// </summary>
            public static Color Color_222 => new Color(189, 0, 141);
            /// <summary>
            /// Represents the color with the hex value #BD7EAD.
            /// </summary>
            public static Color Color_223 => new Color(189, 126, 173);
            /// <summary>
            /// Represents the color with the hex value #810060.
            /// </summary>
            public static Color Color_224 => new Color(129, 0, 96);
            /// <summary>
            /// Represents the color with the hex value #815676.
            /// </summary>
            public static Color Color_225 => new Color(129, 86, 118);
            /// <summary>
            /// Represents the color with the hex value #68004E.
            /// </summary>
            public static Color Color_226 => new Color(104, 0, 78);
            /// <summary>
            /// Represents the color with the hex value #68455F.
            /// </summary>
            public static Color Color_227 => new Color(104, 69, 95);
            /// <summary>
            /// Represents the color with the hex value #4F003B.
            /// </summary>
            public static Color Color_228 => new Color(79, 0, 59);
            /// <summary>
            /// Represents the color with the hex value #4F3549.
            /// </summary>
            public static Color Color_229 => new Color(79, 53, 73);
            /// <summary>
            /// Represents the color with the hex value #FF007F.
            /// </summary>
            public static Color Color_230 => new Color(255, 0, 127);
            /// <summary>
            /// Represents the color with the hex value #FFAAD4.
            /// </summary>
            public static Color Color_231 => new Color(255, 170, 212);
            /// <summary>
            /// Represents the color with the hex value #BD005E.
            /// </summary>
            public static Color Color_232 => new Color(189, 0, 94);
            /// <summary>
            /// Represents the color with the hex value #BD7E9D.
            /// </summary>
            public static Color Color_233 => new Color(189, 126, 157);
            /// <summary>
            /// Represents the color with the hex value #810040.
            /// </summary>
            public static Color Color_234 => new Color(129, 0, 64);
            /// <summary>
            /// Represents the color with the hex value #81566B.
            /// </summary>
            public static Color Color_235 => new Color(129, 86, 107);
            /// <summary>
            /// Represents the color with the hex value #680034.
            /// </summary>
            public static Color Color_236 => new Color(104, 0, 52);
            /// <summary>
            /// Represents the color with the hex value #684556.
            /// </summary>
            public static Color Color_237 => new Color(104, 69, 86);
            /// <summary>
            /// Represents the color with the hex value #4F0027.
            /// </summary>
            public static Color Color_238 => new Color(79, 0, 39);
            /// <summary>
            /// Represents the color with the hex value #4F3542.
            /// </summary>
            public static Color Color_239 => new Color(79, 53, 66);
            /// <summary>
            /// Represents the color with the hex value #FF003F.
            /// </summary>
            public static Color Color_240 => new Color(255, 0, 63);
            /// <summary>
            /// Represents the color with the hex value #FFAABF.
            /// </summary>
            public static Color Color_241 => new Color(255, 170, 191);
            /// <summary>
            /// Represents the color with the hex value #BD002E.
            /// </summary>
            public static Color Color_242 => new Color(189, 0, 46);
            /// <summary>
            /// Represents the color with the hex value #BD7E8D.
            /// </summary>
            public static Color Color_243 => new Color(189, 126, 141);
            /// <summary>
            /// Represents the color with the hex value #81001F.
            /// </summary>
            public static Color Color_244 => new Color(129, 0, 31);
            /// <summary>
            /// Represents the color with the hex value #815660.
            /// </summary>
            public static Color Color_245 => new Color(129, 86, 96);
            /// <summary>
            /// Represents the color with the hex value #680019.
            /// </summary>
            public static Color Color_246 => new Color(104, 0, 25);
            /// <summary>
            /// Represents the color with the hex value #68454E.
            /// </summary>
            public static Color Color_247 => new Color(104, 69, 78);
            /// <summary>
            /// Represents the color with the hex value #4F0013.
            /// </summary>
            public static Color Color_248 => new Color(79, 0, 19);
            /// <summary>
            /// Represents the color with the hex value #4F353B.
            /// </summary>
            public static Color Color_249 => new Color(79, 53, 59);
            /// <summary>
            /// Represents the color with the hex value #333333.
            /// </summary>
            public static Color Color_250 => new Color(51, 51, 51);
            /// <summary>
            /// Represents the color with the hex value #505050.
            /// </summary>
            public static Color Color_251 => new Color(80, 80, 80);
            /// <summary>
            /// Represents the color with the hex value #696969.
            /// </summary>
            public static Color Color_252 => new Color(105, 105, 105);
            /// <summary>
            /// Represents the color with the hex value #828282.
            /// </summary>
            public static Color Color_253 => new Color(130, 130, 130);
            /// <summary>
            /// Represents the color with the hex value #BEBEBE.
            /// </summary>
            public static Color Color_254 => new Color(190, 190, 190);
            /// <summary>
            /// Represents the color with the hex value #FFFFFF.
            /// </summary>
            public static Color Color_255 => new Color(255, 255, 255);
        }
        #endregion
    }
}
