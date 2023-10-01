using Autodesk.Revit.DB;

namespace ricaun.Revit.DB.Shape
{
    /// <summary>
    /// Colors
    /// </summary>
    public sealed class Colors
    {
        #region Colors
        /// <summary>
        /// Represents the color black with the hex value #000000.
        /// </summary>
        public static Color Black { get; } = new Color(0, 0, 0);
        /// <summary>
        /// Represents the color red with the hex value #FF0000.
        /// </summary>
        public static Color Red { get; } = new Color(255, 0, 0);
        /// <summary>
        /// Represents the color yellow with the hex value #FFFF00.
        /// </summary>
        public static Color Yellow { get; } = new Color(255, 255, 0);
        /// <summary>
        /// Represents the color green with the hex value #00FF00.
        /// </summary>
        public static Color Green { get; } = new Color(0, 255, 0);
        /// <summary>
        /// Represents the color cyan with the hex value #00FFFF.
        /// </summary>
        public static Color Cyan { get; } = new Color(0, 255, 255);
        /// <summary>
        /// Represents the color blue with the hex value #0000FF.
        /// </summary>
        public static Color Blue { get; } = new Color(0, 0, 255);
        /// <summary>
        /// Represents the color magenta with the hex value #FF00FF.
        /// </summary>
        public static Color Magenta { get; } = new Color(255, 0, 255);
        /// <summary>
        /// Represents the color white with the hex value #FFFFFF.
        /// </summary>
        public static Color White { get; } = new Color(255, 255, 255);
        /// <summary>
        /// Represents the color dark gray with the hex value #414141.
        /// </summary>
        public static Color DarkGray { get; } = new Color(65, 65, 65);
        /// <summary>
        /// Represents the color gray with the hex value #808080.
        /// </summary>
        public static Color Gray { get; } = new Color(128, 128, 128);
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
            public static Color Color_0 { get; } = new Color(0, 0, 0);
            /// <summary>
            /// Represents the color red with the hex value #FF0000.
            /// </summary>
            public static Color Color_1 { get; } = new Color(255, 0, 0);
            /// <summary>
            /// Represents the color yellow with the hex value #FFFF00.
            /// </summary>
            public static Color Color_2 { get; } = new Color(255, 255, 0);
            /// <summary>
            /// Represents the color green with the hex value #00FF00.
            /// </summary>
            public static Color Color_3 { get; } = new Color(0, 255, 0);
            /// <summary>
            /// Represents the color cyan with the hex value #00FFFF.
            /// </summary>
            public static Color Color_4 { get; } = new Color(0, 255, 255);
            /// <summary>
            /// Represents the color blue with the hex value #0000FF.
            /// </summary>
            public static Color Color_5 { get; } = new Color(0, 0, 255);
            /// <summary>
            /// Represents the color magenta with the hex value #FF00FF.
            /// </summary>
            public static Color Color_6 { get; } = new Color(255, 0, 255);
            /// <summary>
            /// Represents the color white with the hex value #FFFFFF.
            /// </summary>
            public static Color Color_7 { get; } = new Color(255, 255, 255);
            /// <summary>
            /// Represents the color dark gray with the hex value #414141.
            /// </summary>
            public static Color Color_8 { get; } = new Color(65, 65, 65);
            /// <summary>
            /// Represents the color gray with the hex value #808080.
            /// </summary>
            public static Color Color_9 { get; } = new Color(128, 128, 128);
            /// <summary>
            /// Represents the color with the hex value #FF0000.
            /// </summary>
            public static Color Color_10 { get; } = new Color(255, 0, 0);
            /// <summary>
            /// Represents the color with the hex value #FFAAAA.
            /// </summary>
            public static Color Color_11 { get; } = new Color(255, 170, 170);
            /// <summary>
            /// Represents the color with the hex value #BD0000.
            /// </summary>
            public static Color Color_12 { get; } = new Color(189, 0, 0);
            /// <summary>
            /// Represents the color with the hex value #BD7E7E.
            /// </summary>
            public static Color Color_13 { get; } = new Color(189, 126, 126);
            /// <summary>
            /// Represents the color with the hex value #810000.
            /// </summary>
            public static Color Color_14 { get; } = new Color(129, 0, 0);
            /// <summary>
            /// Represents the color with the hex value #815656.
            /// </summary>
            public static Color Color_15 { get; } = new Color(129, 86, 86);
            /// <summary>
            /// Represents the color with the hex value #680000.
            /// </summary>
            public static Color Color_16 { get; } = new Color(104, 0, 0);
            /// <summary>
            /// Represents the color with the hex value #684545.
            /// </summary>
            public static Color Color_17 { get; } = new Color(104, 69, 69);
            /// <summary>
            /// Represents the color with the hex value #4F0000.
            /// </summary>
            public static Color Color_18 { get; } = new Color(79, 0, 0);
            /// <summary>
            /// Represents the color with the hex value #4F3535.
            /// </summary>
            public static Color Color_19 { get; } = new Color(79, 53, 53);
            /// <summary>
            /// Represents the color with the hex value #FF3F00.
            /// </summary>
            public static Color Color_20 { get; } = new Color(255, 63, 0);
            /// <summary>
            /// Represents the color with the hex value #FFBFAA.
            /// </summary>
            public static Color Color_21 { get; } = new Color(255, 191, 170);
            /// <summary>
            /// Represents the color with the hex value #BD2E00.
            /// </summary>
            public static Color Color_22 { get; } = new Color(189, 46, 0);
            /// <summary>
            /// Represents the color with the hex value #BD8D7E.
            /// </summary>
            public static Color Color_23 { get; } = new Color(189, 141, 126);
            /// <summary>
            /// Represents the color with the hex value #811F00.
            /// </summary>
            public static Color Color_24 { get; } = new Color(129, 31, 0);
            /// <summary>
            /// Represents the color with the hex value #816056.
            /// </summary>
            public static Color Color_25 { get; } = new Color(129, 96, 86);
            /// <summary>
            /// Represents the color with the hex value #681900.
            /// </summary>
            public static Color Color_26 { get; } = new Color(104, 25, 0);
            /// <summary>
            /// Represents the color with the hex value #684E45.
            /// </summary>
            public static Color Color_27 { get; } = new Color(104, 78, 69);
            /// <summary>
            /// Represents the color with the hex value #4F1300.
            /// </summary>
            public static Color Color_28 { get; } = new Color(79, 19, 0);
            /// <summary>
            /// Represents the color with the hex value #4F3B35.
            /// </summary>
            public static Color Color_29 { get; } = new Color(79, 59, 53);
            /// <summary>
            /// Represents the color with the hex value #FF7F00.
            /// </summary>
            public static Color Color_30 { get; } = new Color(255, 127, 0);
            /// <summary>
            /// Represents the color with the hex value #FFD4AA.
            /// </summary>
            public static Color Color_31 { get; } = new Color(255, 212, 170);
            /// <summary>
            /// Represents the color with the hex value #BD5E00.
            /// </summary>
            public static Color Color_32 { get; } = new Color(189, 94, 0);
            /// <summary>
            /// Represents the color with the hex value #BD9D7E.
            /// </summary>
            public static Color Color_33 { get; } = new Color(189, 157, 126);
            /// <summary>
            /// Represents the color with the hex value #814000.
            /// </summary>
            public static Color Color_34 { get; } = new Color(129, 64, 0);
            /// <summary>
            /// Represents the color with the hex value #816B56.
            /// </summary>
            public static Color Color_35 { get; } = new Color(129, 107, 86);
            /// <summary>
            /// Represents the color with the hex value #683400.
            /// </summary>
            public static Color Color_36 { get; } = new Color(104, 52, 0);
            /// <summary>
            /// Represents the color with the hex value #685645.
            /// </summary>
            public static Color Color_37 { get; } = new Color(104, 86, 69);
            /// <summary>
            /// Represents the color with the hex value #4F2700.
            /// </summary>
            public static Color Color_38 { get; } = new Color(79, 39, 0);
            /// <summary>
            /// Represents the color with the hex value #4F4235.
            /// </summary>
            public static Color Color_39 { get; } = new Color(79, 66, 53);
            /// <summary>
            /// Represents the color with the hex value #FFBF00.
            /// </summary>
            public static Color Color_40 { get; } = new Color(255, 191, 0);
            /// <summary>
            /// Represents the color with the hex value #FFEAAA.
            /// </summary>
            public static Color Color_41 { get; } = new Color(255, 234, 170);
            /// <summary>
            /// Represents the color with the hex value #BD8D00.
            /// </summary>
            public static Color Color_42 { get; } = new Color(189, 141, 0);
            /// <summary>
            /// Represents the color with the hex value #BDAD7E.
            /// </summary>
            public static Color Color_43 { get; } = new Color(189, 173, 126);
            /// <summary>
            /// Represents the color with the hex value #816000.
            /// </summary>
            public static Color Color_44 { get; } = new Color(129, 96, 0);
            /// <summary>
            /// Represents the color with the hex value #817656.
            /// </summary>
            public static Color Color_45 { get; } = new Color(129, 118, 86);
            /// <summary>
            /// Represents the color with the hex value #684E00.
            /// </summary>
            public static Color Color_46 { get; } = new Color(104, 78, 0);
            /// <summary>
            /// Represents the color with the hex value #685F45.
            /// </summary>
            public static Color Color_47 { get; } = new Color(104, 95, 69);
            /// <summary>
            /// Represents the color with the hex value #4F3B00.
            /// </summary>
            public static Color Color_48 { get; } = new Color(79, 59, 0);
            /// <summary>
            /// Represents the color with the hex value #4F4935.
            /// </summary>
            public static Color Color_49 { get; } = new Color(79, 73, 53);
            /// <summary>
            /// Represents the color with the hex value #FFFF00.
            /// </summary>
            public static Color Color_50 { get; } = new Color(255, 255, 0);
            /// <summary>
            /// Represents the color with the hex value #FFFFAA.
            /// </summary>
            public static Color Color_51 { get; } = new Color(255, 255, 170);
            /// <summary>
            /// Represents the color with the hex value #BDBD00.
            /// </summary>
            public static Color Color_52 { get; } = new Color(189, 189, 0);
            /// <summary>
            /// Represents the color with the hex value #BDBD7E.
            /// </summary>
            public static Color Color_53 { get; } = new Color(189, 189, 126);
            /// <summary>
            /// Represents the color with the hex value #818100.
            /// </summary>
            public static Color Color_54 { get; } = new Color(129, 129, 0);
            /// <summary>
            /// Represents the color with the hex value #818156.
            /// </summary>
            public static Color Color_55 { get; } = new Color(129, 129, 86);
            /// <summary>
            /// Represents the color with the hex value #686800.
            /// </summary>
            public static Color Color_56 { get; } = new Color(104, 104, 0);
            /// <summary>
            /// Represents the color with the hex value #686845.
            /// </summary>
            public static Color Color_57 { get; } = new Color(104, 104, 69);
            /// <summary>
            /// Represents the color with the hex value #4F4F00.
            /// </summary>
            public static Color Color_58 { get; } = new Color(79, 79, 0);
            /// <summary>
            /// Represents the color with the hex value #4F4F35.
            /// </summary>
            public static Color Color_59 { get; } = new Color(79, 79, 53);
            /// <summary>
            /// Represents the color with the hex value #BFFF00.
            /// </summary>
            public static Color Color_60 { get; } = new Color(191, 255, 0);
            /// <summary>
            /// Represents the color with the hex value #EAFFAA.
            /// </summary>
            public static Color Color_61 { get; } = new Color(234, 255, 170);
            /// <summary>
            /// Represents the color with the hex value #8DBD00.
            /// </summary>
            public static Color Color_62 { get; } = new Color(141, 189, 0);
            /// <summary>
            /// Represents the color with the hex value #ADBD7E.
            /// </summary>
            public static Color Color_63 { get; } = new Color(173, 189, 126);
            /// <summary>
            /// Represents the color with the hex value #608100.
            /// </summary>
            public static Color Color_64 { get; } = new Color(96, 129, 0);
            /// <summary>
            /// Represents the color with the hex value #768156.
            /// </summary>
            public static Color Color_65 { get; } = new Color(118, 129, 86);
            /// <summary>
            /// Represents the color with the hex value #4E6800.
            /// </summary>
            public static Color Color_66 { get; } = new Color(78, 104, 0);
            /// <summary>
            /// Represents the color with the hex value #5F6845.
            /// </summary>
            public static Color Color_67 { get; } = new Color(95, 104, 69);
            /// <summary>
            /// Represents the color with the hex value #3B4F00.
            /// </summary>
            public static Color Color_68 { get; } = new Color(59, 79, 0);
            /// <summary>
            /// Represents the color with the hex value #494F35.
            /// </summary>
            public static Color Color_69 { get; } = new Color(73, 79, 53);
            /// <summary>
            /// Represents the color with the hex value #7FFF00.
            /// </summary>
            public static Color Color_70 { get; } = new Color(127, 255, 0);
            /// <summary>
            /// Represents the color with the hex value #D4FFAA.
            /// </summary>
            public static Color Color_71 { get; } = new Color(212, 255, 170);
            /// <summary>
            /// Represents the color with the hex value #5EBD00.
            /// </summary>
            public static Color Color_72 { get; } = new Color(94, 189, 0);
            /// <summary>
            /// Represents the color with the hex value #9DBD7E.
            /// </summary>
            public static Color Color_73 { get; } = new Color(157, 189, 126);
            /// <summary>
            /// Represents the color with the hex value #408100.
            /// </summary>
            public static Color Color_74 { get; } = new Color(64, 129, 0);
            /// <summary>
            /// Represents the color with the hex value #6B8156.
            /// </summary>
            public static Color Color_75 { get; } = new Color(107, 129, 86);
            /// <summary>
            /// Represents the color with the hex value #346800.
            /// </summary>
            public static Color Color_76 { get; } = new Color(52, 104, 0);
            /// <summary>
            /// Represents the color with the hex value #566845.
            /// </summary>
            public static Color Color_77 { get; } = new Color(86, 104, 69);
            /// <summary>
            /// Represents the color with the hex value #274F00.
            /// </summary>
            public static Color Color_78 { get; } = new Color(39, 79, 0);
            /// <summary>
            /// Represents the color with the hex value #424F35.
            /// </summary>
            public static Color Color_79 { get; } = new Color(66, 79, 53);
            /// <summary>
            /// Represents the color with the hex value #3FFF00.
            /// </summary>
            public static Color Color_80 { get; } = new Color(63, 255, 0);
            /// <summary>
            /// Represents the color with the hex value #BFFFAA.
            /// </summary>
            public static Color Color_81 { get; } = new Color(191, 255, 170);
            /// <summary>
            /// Represents the color with the hex value #2EBD00.
            /// </summary>
            public static Color Color_82 { get; } = new Color(46, 189, 0);
            /// <summary>
            /// Represents the color with the hex value #8DBD7E.
            /// </summary>
            public static Color Color_83 { get; } = new Color(141, 189, 126);
            /// <summary>
            /// Represents the color with the hex value #1F8100.
            /// </summary>
            public static Color Color_84 { get; } = new Color(31, 129, 0);
            /// <summary>
            /// Represents the color with the hex value #608156.
            /// </summary>
            public static Color Color_85 { get; } = new Color(96, 129, 86);
            /// <summary>
            /// Represents the color with the hex value #196800.
            /// </summary>
            public static Color Color_86 { get; } = new Color(25, 104, 0);
            /// <summary>
            /// Represents the color with the hex value #4E6845.
            /// </summary>
            public static Color Color_87 { get; } = new Color(78, 104, 69);
            /// <summary>
            /// Represents the color with the hex value #134F00.
            /// </summary>
            public static Color Color_88 { get; } = new Color(19, 79, 0);
            /// <summary>
            /// Represents the color with the hex value #3B4F35.
            /// </summary>
            public static Color Color_89 { get; } = new Color(59, 79, 53);
            /// <summary>
            /// Represents the color with the hex value #00FF00.
            /// </summary>
            public static Color Color_90 { get; } = new Color(0, 255, 0);
            /// <summary>
            /// Represents the color with the hex value #AAFFAA.
            /// </summary>
            public static Color Color_91 { get; } = new Color(170, 255, 170);
            /// <summary>
            /// Represents the color with the hex value #00BD00.
            /// </summary>
            public static Color Color_92 { get; } = new Color(0, 189, 0);
            /// <summary>
            /// Represents the color with the hex value #7EBD7E.
            /// </summary>
            public static Color Color_93 { get; } = new Color(126, 189, 126);
            /// <summary>
            /// Represents the color with the hex value #008100.
            /// </summary>
            public static Color Color_94 { get; } = new Color(0, 129, 0);
            /// <summary>
            /// Represents the color with the hex value #568156.
            /// </summary>
            public static Color Color_95 { get; } = new Color(86, 129, 86);
            /// <summary>
            /// Represents the color with the hex value #006800.
            /// </summary>
            public static Color Color_96 { get; } = new Color(0, 104, 0);
            /// <summary>
            /// Represents the color with the hex value #456845.
            /// </summary>
            public static Color Color_97 { get; } = new Color(69, 104, 69);
            /// <summary>
            /// Represents the color with the hex value #004F00.
            /// </summary>
            public static Color Color_98 { get; } = new Color(0, 79, 0);
            /// <summary>
            /// Represents the color with the hex value #354F35.
            /// </summary>
            public static Color Color_99 { get; } = new Color(53, 79, 53);
            /// <summary>
            /// Represents the color with the hex value #00FF3F.
            /// </summary>
            public static Color Color_100 { get; } = new Color(0, 255, 63);
            /// <summary>
            /// Represents the color with the hex value #AAFFBF.
            /// </summary>
            public static Color Color_101 { get; } = new Color(170, 255, 191);
            /// <summary>
            /// Represents the color with the hex value #00BD2E.
            /// </summary>
            public static Color Color_102 { get; } = new Color(0, 189, 46);
            /// <summary>
            /// Represents the color with the hex value #7EBD8D.
            /// </summary>
            public static Color Color_103 { get; } = new Color(126, 189, 141);
            /// <summary>
            /// Represents the color with the hex value #00811F.
            /// </summary>
            public static Color Color_104 { get; } = new Color(0, 129, 31);
            /// <summary>
            /// Represents the color with the hex value #568160.
            /// </summary>
            public static Color Color_105 { get; } = new Color(86, 129, 96);
            /// <summary>
            /// Represents the color with the hex value #006819.
            /// </summary>
            public static Color Color_106 { get; } = new Color(0, 104, 25);
            /// <summary>
            /// Represents the color with the hex value #45684E.
            /// </summary>
            public static Color Color_107 { get; } = new Color(69, 104, 78);
            /// <summary>
            /// Represents the color with the hex value #004F13.
            /// </summary>
            public static Color Color_108 { get; } = new Color(0, 79, 19);
            /// <summary>
            /// Represents the color with the hex value #354F3B.
            /// </summary>
            public static Color Color_109 { get; } = new Color(53, 79, 59);
            /// <summary>
            /// Represents the color with the hex value #00FF7F.
            /// </summary>
            public static Color Color_110 { get; } = new Color(0, 255, 127);
            /// <summary>
            /// Represents the color with the hex value #AAFFD4.
            /// </summary>
            public static Color Color_111 { get; } = new Color(170, 255, 212);
            /// <summary>
            /// Represents the color with the hex value #00BD5E.
            /// </summary>
            public static Color Color_112 { get; } = new Color(0, 189, 94);
            /// <summary>
            /// Represents the color with the hex value #7EBD9D.
            /// </summary>
            public static Color Color_113 { get; } = new Color(126, 189, 157);
            /// <summary>
            /// Represents the color with the hex value #008140.
            /// </summary>
            public static Color Color_114 { get; } = new Color(0, 129, 64);
            /// <summary>
            /// Represents the color with the hex value #56816B.
            /// </summary>
            public static Color Color_115 { get; } = new Color(86, 129, 107);
            /// <summary>
            /// Represents the color with the hex value #006834.
            /// </summary>
            public static Color Color_116 { get; } = new Color(0, 104, 52);
            /// <summary>
            /// Represents the color with the hex value #456856.
            /// </summary>
            public static Color Color_117 { get; } = new Color(69, 104, 86);
            /// <summary>
            /// Represents the color with the hex value #004F27.
            /// </summary>
            public static Color Color_118 { get; } = new Color(0, 79, 39);
            /// <summary>
            /// Represents the color with the hex value #354F42.
            /// </summary>
            public static Color Color_119 { get; } = new Color(53, 79, 66);
            /// <summary>
            /// Represents the color with the hex value #00FFBF.
            /// </summary>
            public static Color Color_120 { get; } = new Color(0, 255, 191);
            /// <summary>
            /// Represents the color with the hex value #AAFFEA.
            /// </summary>
            public static Color Color_121 { get; } = new Color(170, 255, 234);
            /// <summary>
            /// Represents the color with the hex value #00BD8D.
            /// </summary>
            public static Color Color_122 { get; } = new Color(0, 189, 141);
            /// <summary>
            /// Represents the color with the hex value #7EBDAD.
            /// </summary>
            public static Color Color_123 { get; } = new Color(126, 189, 173);
            /// <summary>
            /// Represents the color with the hex value #008160.
            /// </summary>
            public static Color Color_124 { get; } = new Color(0, 129, 96);
            /// <summary>
            /// Represents the color with the hex value #568176.
            /// </summary>
            public static Color Color_125 { get; } = new Color(86, 129, 118);
            /// <summary>
            /// Represents the color with the hex value #00684E.
            /// </summary>
            public static Color Color_126 { get; } = new Color(0, 104, 78);
            /// <summary>
            /// Represents the color with the hex value #45685F.
            /// </summary>
            public static Color Color_127 { get; } = new Color(69, 104, 95);
            /// <summary>
            /// Represents the color with the hex value #004F3B.
            /// </summary>
            public static Color Color_128 { get; } = new Color(0, 79, 59);
            /// <summary>
            /// Represents the color with the hex value #354F49.
            /// </summary>
            public static Color Color_129 { get; } = new Color(53, 79, 73);
            /// <summary>
            /// Represents the color with the hex value #00FFFF.
            /// </summary>
            public static Color Color_130 { get; } = new Color(0, 255, 255);
            /// <summary>
            /// Represents the color with the hex value #AAFFFF.
            /// </summary>
            public static Color Color_131 { get; } = new Color(170, 255, 255);
            /// <summary>
            /// Represents the color with the hex value #00BDBD.
            /// </summary>
            public static Color Color_132 { get; } = new Color(0, 189, 189);
            /// <summary>
            /// Represents the color with the hex value #7EBDBD.
            /// </summary>
            public static Color Color_133 { get; } = new Color(126, 189, 189);
            /// <summary>
            /// Represents the color with the hex value #008181.
            /// </summary>
            public static Color Color_134 { get; } = new Color(0, 129, 129);
            /// <summary>
            /// Represents the color with the hex value #568181.
            /// </summary>
            public static Color Color_135 { get; } = new Color(86, 129, 129);
            /// <summary>
            /// Represents the color with the hex value #006868.
            /// </summary>
            public static Color Color_136 { get; } = new Color(0, 104, 104);
            /// <summary>
            /// Represents the color with the hex value #456868.
            /// </summary>
            public static Color Color_137 { get; } = new Color(69, 104, 104);
            /// <summary>
            /// Represents the color with the hex value #004F4F.
            /// </summary>
            public static Color Color_138 { get; } = new Color(0, 79, 79);
            /// <summary>
            /// Represents the color with the hex value #354F4F.
            /// </summary>
            public static Color Color_139 { get; } = new Color(53, 79, 79);
            /// <summary>
            /// Represents the color with the hex value #00BFFF.
            /// </summary>
            public static Color Color_140 { get; } = new Color(0, 191, 255);
            /// <summary>
            /// Represents the color with the hex value #AAEAFF.
            /// </summary>
            public static Color Color_141 { get; } = new Color(170, 234, 255);
            /// <summary>
            /// Represents the color with the hex value #008DBD.
            /// </summary>
            public static Color Color_142 { get; } = new Color(0, 141, 189);
            /// <summary>
            /// Represents the color with the hex value #7EADBD.
            /// </summary>
            public static Color Color_143 { get; } = new Color(126, 173, 189);
            /// <summary>
            /// Represents the color with the hex value #006081.
            /// </summary>
            public static Color Color_144 { get; } = new Color(0, 96, 129);
            /// <summary>
            /// Represents the color with the hex value #567681.
            /// </summary>
            public static Color Color_145 { get; } = new Color(86, 118, 129);
            /// <summary>
            /// Represents the color with the hex value #004E68.
            /// </summary>
            public static Color Color_146 { get; } = new Color(0, 78, 104);
            /// <summary>
            /// Represents the color with the hex value #455F68.
            /// </summary>
            public static Color Color_147 { get; } = new Color(69, 95, 104);
            /// <summary>
            /// Represents the color with the hex value #003B4F.
            /// </summary>
            public static Color Color_148 { get; } = new Color(0, 59, 79);
            /// <summary>
            /// Represents the color with the hex value #35494F.
            /// </summary>
            public static Color Color_149 { get; } = new Color(53, 73, 79);
            /// <summary>
            /// Represents the color with the hex value #007FFF.
            /// </summary>
            public static Color Color_150 { get; } = new Color(0, 127, 255);
            /// <summary>
            /// Represents the color with the hex value #AAD4FF.
            /// </summary>
            public static Color Color_151 { get; } = new Color(170, 212, 255);
            /// <summary>
            /// Represents the color with the hex value #005EBD.
            /// </summary>
            public static Color Color_152 { get; } = new Color(0, 94, 189);
            /// <summary>
            /// Represents the color with the hex value #7E9DBD.
            /// </summary>
            public static Color Color_153 { get; } = new Color(126, 157, 189);
            /// <summary>
            /// Represents the color with the hex value #004081.
            /// </summary>
            public static Color Color_154 { get; } = new Color(0, 64, 129);
            /// <summary>
            /// Represents the color with the hex value #566B81.
            /// </summary>
            public static Color Color_155 { get; } = new Color(86, 107, 129);
            /// <summary>
            /// Represents the color with the hex value #003468.
            /// </summary>
            public static Color Color_156 { get; } = new Color(0, 52, 104);
            /// <summary>
            /// Represents the color with the hex value #455668.
            /// </summary>
            public static Color Color_157 { get; } = new Color(69, 86, 104);
            /// <summary>
            /// Represents the color with the hex value #00274F.
            /// </summary>
            public static Color Color_158 { get; } = new Color(0, 39, 79);
            /// <summary>
            /// Represents the color with the hex value #35424F.
            /// </summary>
            public static Color Color_159 { get; } = new Color(53, 66, 79);
            /// <summary>
            /// Represents the color with the hex value #003FFF.
            /// </summary>
            public static Color Color_160 { get; } = new Color(0, 63, 255);
            /// <summary>
            /// Represents the color with the hex value #AABFFF.
            /// </summary>
            public static Color Color_161 { get; } = new Color(170, 191, 255);
            /// <summary>
            /// Represents the color with the hex value #002EBD.
            /// </summary>
            public static Color Color_162 { get; } = new Color(0, 46, 189);
            /// <summary>
            /// Represents the color with the hex value #7E8DBD.
            /// </summary>
            public static Color Color_163 { get; } = new Color(126, 141, 189);
            /// <summary>
            /// Represents the color with the hex value #001F81.
            /// </summary>
            public static Color Color_164 { get; } = new Color(0, 31, 129);
            /// <summary>
            /// Represents the color with the hex value #566081.
            /// </summary>
            public static Color Color_165 { get; } = new Color(86, 96, 129);
            /// <summary>
            /// Represents the color with the hex value #001968.
            /// </summary>
            public static Color Color_166 { get; } = new Color(0, 25, 104);
            /// <summary>
            /// Represents the color with the hex value #454E68.
            /// </summary>
            public static Color Color_167 { get; } = new Color(69, 78, 104);
            /// <summary>
            /// Represents the color with the hex value #00134F.
            /// </summary>
            public static Color Color_168 { get; } = new Color(0, 19, 79);
            /// <summary>
            /// Represents the color with the hex value #353B4F.
            /// </summary>
            public static Color Color_169 { get; } = new Color(53, 59, 79);
            /// <summary>
            /// Represents the color with the hex value #0000FF.
            /// </summary>
            public static Color Color_170 { get; } = new Color(0, 0, 255);
            /// <summary>
            /// Represents the color with the hex value #AAAAFF.
            /// </summary>
            public static Color Color_171 { get; } = new Color(170, 170, 255);
            /// <summary>
            /// Represents the color with the hex value #0000BD.
            /// </summary>
            public static Color Color_172 { get; } = new Color(0, 0, 189);
            /// <summary>
            /// Represents the color with the hex value #7E7EBD.
            /// </summary>
            public static Color Color_173 { get; } = new Color(126, 126, 189);
            /// <summary>
            /// Represents the color with the hex value #000081.
            /// </summary>
            public static Color Color_174 { get; } = new Color(0, 0, 129);
            /// <summary>
            /// Represents the color with the hex value #565681.
            /// </summary>
            public static Color Color_175 { get; } = new Color(86, 86, 129);
            /// <summary>
            /// Represents the color with the hex value #000068.
            /// </summary>
            public static Color Color_176 { get; } = new Color(0, 0, 104);
            /// <summary>
            /// Represents the color with the hex value #454568.
            /// </summary>
            public static Color Color_177 { get; } = new Color(69, 69, 104);
            /// <summary>
            /// Represents the color with the hex value #00004F.
            /// </summary>
            public static Color Color_178 { get; } = new Color(0, 0, 79);
            /// <summary>
            /// Represents the color with the hex value #35354F.
            /// </summary>
            public static Color Color_179 { get; } = new Color(53, 53, 79);
            /// <summary>
            /// Represents the color with the hex value #3F00FF.
            /// </summary>
            public static Color Color_180 { get; } = new Color(63, 0, 255);
            /// <summary>
            /// Represents the color with the hex value #BFAAFF.
            /// </summary>
            public static Color Color_181 { get; } = new Color(191, 170, 255);
            /// <summary>
            /// Represents the color with the hex value #2E00BD.
            /// </summary>
            public static Color Color_182 { get; } = new Color(46, 0, 189);
            /// <summary>
            /// Represents the color with the hex value #8D7EBD.
            /// </summary>
            public static Color Color_183 { get; } = new Color(141, 126, 189);
            /// <summary>
            /// Represents the color with the hex value #1F0081.
            /// </summary>
            public static Color Color_184 { get; } = new Color(31, 0, 129);
            /// <summary>
            /// Represents the color with the hex value #605681.
            /// </summary>
            public static Color Color_185 { get; } = new Color(96, 86, 129);
            /// <summary>
            /// Represents the color with the hex value #190068.
            /// </summary>
            public static Color Color_186 { get; } = new Color(25, 0, 104);
            /// <summary>
            /// Represents the color with the hex value #4E4568.
            /// </summary>
            public static Color Color_187 { get; } = new Color(78, 69, 104);
            /// <summary>
            /// Represents the color with the hex value #13004F.
            /// </summary>
            public static Color Color_188 { get; } = new Color(19, 0, 79);
            /// <summary>
            /// Represents the color with the hex value #3B354F.
            /// </summary>
            public static Color Color_189 { get; } = new Color(59, 53, 79);
            /// <summary>
            /// Represents the color with the hex value #7F00FF.
            /// </summary>
            public static Color Color_190 { get; } = new Color(127, 0, 255);
            /// <summary>
            /// Represents the color with the hex value #D4AAFF.
            /// </summary>
            public static Color Color_191 { get; } = new Color(212, 170, 255);
            /// <summary>
            /// Represents the color with the hex value #5E00BD.
            /// </summary>
            public static Color Color_192 { get; } = new Color(94, 0, 189);
            /// <summary>
            /// Represents the color with the hex value #9D7EBD.
            /// </summary>
            public static Color Color_193 { get; } = new Color(157, 126, 189);
            /// <summary>
            /// Represents the color with the hex value #400081.
            /// </summary>
            public static Color Color_194 { get; } = new Color(64, 0, 129);
            /// <summary>
            /// Represents the color with the hex value #6B5681.
            /// </summary>
            public static Color Color_195 { get; } = new Color(107, 86, 129);
            /// <summary>
            /// Represents the color with the hex value #340068.
            /// </summary>
            public static Color Color_196 { get; } = new Color(52, 0, 104);
            /// <summary>
            /// Represents the color with the hex value #564568.
            /// </summary>
            public static Color Color_197 { get; } = new Color(86, 69, 104);
            /// <summary>
            /// Represents the color with the hex value #27004F.
            /// </summary>
            public static Color Color_198 { get; } = new Color(39, 0, 79);
            /// <summary>
            /// Represents the color with the hex value #42354F.
            /// </summary>
            public static Color Color_199 { get; } = new Color(66, 53, 79);
            /// <summary>
            /// Represents the color with the hex value #BF00FF.
            /// </summary>
            public static Color Color_200 { get; } = new Color(191, 0, 255);
            /// <summary>
            /// Represents the color with the hex value #EAAAFF.
            /// </summary>
            public static Color Color_201 { get; } = new Color(234, 170, 255);
            /// <summary>
            /// Represents the color with the hex value #8D00BD.
            /// </summary>
            public static Color Color_202 { get; } = new Color(141, 0, 189);
            /// <summary>
            /// Represents the color with the hex value #AD7EBD.
            /// </summary>
            public static Color Color_203 { get; } = new Color(173, 126, 189);
            /// <summary>
            /// Represents the color with the hex value #600081.
            /// </summary>
            public static Color Color_204 { get; } = new Color(96, 0, 129);
            /// <summary>
            /// Represents the color with the hex value #765681.
            /// </summary>
            public static Color Color_205 { get; } = new Color(118, 86, 129);
            /// <summary>
            /// Represents the color with the hex value #4E0068.
            /// </summary>
            public static Color Color_206 { get; } = new Color(78, 0, 104);
            /// <summary>
            /// Represents the color with the hex value #5F4568.
            /// </summary>
            public static Color Color_207 { get; } = new Color(95, 69, 104);
            /// <summary>
            /// Represents the color with the hex value #3B004F.
            /// </summary>
            public static Color Color_208 { get; } = new Color(59, 0, 79);
            /// <summary>
            /// Represents the color with the hex value #49354F.
            /// </summary>
            public static Color Color_209 { get; } = new Color(73, 53, 79);
            /// <summary>
            /// Represents the color with the hex value #FF00FF.
            /// </summary>
            public static Color Color_210 { get; } = new Color(255, 0, 255);
            /// <summary>
            /// Represents the color with the hex value #FFAAFF.
            /// </summary>
            public static Color Color_211 { get; } = new Color(255, 170, 255);
            /// <summary>
            /// Represents the color with the hex value #BD00BD.
            /// </summary>
            public static Color Color_212 { get; } = new Color(189, 0, 189);
            /// <summary>
            /// Represents the color with the hex value #BD7EBD.
            /// </summary>
            public static Color Color_213 { get; } = new Color(189, 126, 189);
            /// <summary>
            /// Represents the color with the hex value #810081.
            /// </summary>
            public static Color Color_214 { get; } = new Color(129, 0, 129);
            /// <summary>
            /// Represents the color with the hex value #815681.
            /// </summary>
            public static Color Color_215 { get; } = new Color(129, 86, 129);
            /// <summary>
            /// Represents the color with the hex value #680068.
            /// </summary>
            public static Color Color_216 { get; } = new Color(104, 0, 104);
            /// <summary>
            /// Represents the color with the hex value #684568.
            /// </summary>
            public static Color Color_217 { get; } = new Color(104, 69, 104);
            /// <summary>
            /// Represents the color with the hex value #4F004F.
            /// </summary>
            public static Color Color_218 { get; } = new Color(79, 0, 79);
            /// <summary>
            /// Represents the color with the hex value #4F354F.
            /// </summary>
            public static Color Color_219 { get; } = new Color(79, 53, 79);
            /// <summary>
            /// Represents the color with the hex value #FF00BF.
            /// </summary>
            public static Color Color_220 { get; } = new Color(255, 0, 191);
            /// <summary>
            /// Represents the color with the hex value #FFAAEA.
            /// </summary>
            public static Color Color_221 { get; } = new Color(255, 170, 234);
            /// <summary>
            /// Represents the color with the hex value #BD008D.
            /// </summary>
            public static Color Color_222 { get; } = new Color(189, 0, 141);
            /// <summary>
            /// Represents the color with the hex value #BD7EAD.
            /// </summary>
            public static Color Color_223 { get; } = new Color(189, 126, 173);
            /// <summary>
            /// Represents the color with the hex value #810060.
            /// </summary>
            public static Color Color_224 { get; } = new Color(129, 0, 96);
            /// <summary>
            /// Represents the color with the hex value #815676.
            /// </summary>
            public static Color Color_225 { get; } = new Color(129, 86, 118);
            /// <summary>
            /// Represents the color with the hex value #68004E.
            /// </summary>
            public static Color Color_226 { get; } = new Color(104, 0, 78);
            /// <summary>
            /// Represents the color with the hex value #68455F.
            /// </summary>
            public static Color Color_227 { get; } = new Color(104, 69, 95);
            /// <summary>
            /// Represents the color with the hex value #4F003B.
            /// </summary>
            public static Color Color_228 { get; } = new Color(79, 0, 59);
            /// <summary>
            /// Represents the color with the hex value #4F3549.
            /// </summary>
            public static Color Color_229 { get; } = new Color(79, 53, 73);
            /// <summary>
            /// Represents the color with the hex value #FF007F.
            /// </summary>
            public static Color Color_230 { get; } = new Color(255, 0, 127);
            /// <summary>
            /// Represents the color with the hex value #FFAAD4.
            /// </summary>
            public static Color Color_231 { get; } = new Color(255, 170, 212);
            /// <summary>
            /// Represents the color with the hex value #BD005E.
            /// </summary>
            public static Color Color_232 { get; } = new Color(189, 0, 94);
            /// <summary>
            /// Represents the color with the hex value #BD7E9D.
            /// </summary>
            public static Color Color_233 { get; } = new Color(189, 126, 157);
            /// <summary>
            /// Represents the color with the hex value #810040.
            /// </summary>
            public static Color Color_234 { get; } = new Color(129, 0, 64);
            /// <summary>
            /// Represents the color with the hex value #81566B.
            /// </summary>
            public static Color Color_235 { get; } = new Color(129, 86, 107);
            /// <summary>
            /// Represents the color with the hex value #680034.
            /// </summary>
            public static Color Color_236 { get; } = new Color(104, 0, 52);
            /// <summary>
            /// Represents the color with the hex value #684556.
            /// </summary>
            public static Color Color_237 { get; } = new Color(104, 69, 86);
            /// <summary>
            /// Represents the color with the hex value #4F0027.
            /// </summary>
            public static Color Color_238 { get; } = new Color(79, 0, 39);
            /// <summary>
            /// Represents the color with the hex value #4F3542.
            /// </summary>
            public static Color Color_239 { get; } = new Color(79, 53, 66);
            /// <summary>
            /// Represents the color with the hex value #FF003F.
            /// </summary>
            public static Color Color_240 { get; } = new Color(255, 0, 63);
            /// <summary>
            /// Represents the color with the hex value #FFAABF.
            /// </summary>
            public static Color Color_241 { get; } = new Color(255, 170, 191);
            /// <summary>
            /// Represents the color with the hex value #BD002E.
            /// </summary>
            public static Color Color_242 { get; } = new Color(189, 0, 46);
            /// <summary>
            /// Represents the color with the hex value #BD7E8D.
            /// </summary>
            public static Color Color_243 { get; } = new Color(189, 126, 141);
            /// <summary>
            /// Represents the color with the hex value #81001F.
            /// </summary>
            public static Color Color_244 { get; } = new Color(129, 0, 31);
            /// <summary>
            /// Represents the color with the hex value #815660.
            /// </summary>
            public static Color Color_245 { get; } = new Color(129, 86, 96);
            /// <summary>
            /// Represents the color with the hex value #680019.
            /// </summary>
            public static Color Color_246 { get; } = new Color(104, 0, 25);
            /// <summary>
            /// Represents the color with the hex value #68454E.
            /// </summary>
            public static Color Color_247 { get; } = new Color(104, 69, 78);
            /// <summary>
            /// Represents the color with the hex value #4F0013.
            /// </summary>
            public static Color Color_248 { get; } = new Color(79, 0, 19);
            /// <summary>
            /// Represents the color with the hex value #4F353B.
            /// </summary>
            public static Color Color_249 { get; } = new Color(79, 53, 59);
            /// <summary>
            /// Represents the color with the hex value #333333.
            /// </summary>
            public static Color Color_250 { get; } = new Color(51, 51, 51);
            /// <summary>
            /// Represents the color with the hex value #505050.
            /// </summary>
            public static Color Color_251 { get; } = new Color(80, 80, 80);
            /// <summary>
            /// Represents the color with the hex value #696969.
            /// </summary>
            public static Color Color_252 { get; } = new Color(105, 105, 105);
            /// <summary>
            /// Represents the color with the hex value #828282.
            /// </summary>
            public static Color Color_253 { get; } = new Color(130, 130, 130);
            /// <summary>
            /// Represents the color with the hex value #BEBEBE.
            /// </summary>
            public static Color Color_254 { get; } = new Color(190, 190, 190);
            /// <summary>
            /// Represents the color with the hex value #FFFFFF.
            /// </summary>
            public static Color Color_255 { get; } = new Color(255, 255, 255);
        }
        #endregion
    }
}
