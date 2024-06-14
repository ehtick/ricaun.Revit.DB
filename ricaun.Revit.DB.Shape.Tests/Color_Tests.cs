using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;
using ricaun.Revit.DB.Shape.Extensions;
using System.Collections.Generic;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Color_Tests
    {
        Color black = new Color(0, 0, 0);
        Color red = new Color(255, 0, 0);
        Color yellow = new Color(255, 255, 0);
        Color lime = new Color(0, 255, 0);
        Color cyan = new Color(0, 255, 255);
        Color blue = new Color(0, 0, 255);
        Color magenta = new Color(255, 0, 255);
        Color white = new Color(255, 255, 255);
        Color blackgray = new Color(65, 65, 65);
        Color gray = new Color(128, 128, 128);

        private static Dictionary<string, System.Windows.Media.Color> GetMediaColors()
        {
            var result = new Dictionary<string, System.Windows.Media.Color>();
            foreach (var property in typeof(System.Windows.Media.Colors).GetProperties())
            {
                if (property.Name == "Transparent") continue;
                if (property.GetValue(null) is System.Windows.Media.Color color)
                    result.Add(property.Name, color);
            }
            return result;
        }

        [Test]
        public void Colors_Tests()
        {
            var colorsType = typeof(Colors);
            var count = colorsType.GetProperties().Length;
            var mediaColors = GetMediaColors();

            System.Console.WriteLine($"Colors: {count} \tMedia.Colors: {mediaColors.Count}");

            foreach (var color in mediaColors)
            {
                var name = color.Key;
                var expectedColor = new Color(color.Value.R, color.Value.G, color.Value.B);
                if (colorsType.GetProperty(name)?.GetValue(null) is Color colorTest)
                {
                    Assert.IsTrue(colorTest.ColorEquals(expectedColor),
                        $"{name} Color ({colorTest.Red},{colorTest.Green},{colorTest.Blue}) is not equal to ({expectedColor.Red},{expectedColor.Green},{expectedColor.Blue})");
                }
                else
                {
                    Assert.Fail($"Colors.{name} not found.");
                }
            }
        }

        [Test]
        public void Colors_Index_Tests()
        {
            Assert.IsTrue(Colors.Index.Color_0.ColorEquals(black));
            Assert.IsTrue(Colors.Index.Color_1.ColorEquals(red));
            Assert.IsTrue(Colors.Index.Color_2.ColorEquals(yellow));
            Assert.IsTrue(Colors.Index.Color_3.ColorEquals(lime));
            Assert.IsTrue(Colors.Index.Color_4.ColorEquals(cyan));
            Assert.IsTrue(Colors.Index.Color_5.ColorEquals(blue));
            Assert.IsTrue(Colors.Index.Color_6.ColorEquals(magenta));
            Assert.IsTrue(Colors.Index.Color_7.ColorEquals(white));
            Assert.IsTrue(Colors.Index.Color_8.ColorEquals(blackgray));
            Assert.IsTrue(Colors.Index.Color_9.ColorEquals(gray));
        }

        [Test]
        public void Colors_Index_Get_Tests()
        {
            Assert.IsTrue(Colors.Index.Get(0).ColorEquals(black));
            Assert.IsTrue(Colors.Index.Get(1).ColorEquals(red));
            Assert.IsTrue(Colors.Index.Get(2).ColorEquals(yellow));
            Assert.IsTrue(Colors.Index.Get(3).ColorEquals(lime));
            Assert.IsTrue(Colors.Index.Get(4).ColorEquals(cyan));
            Assert.IsTrue(Colors.Index.Get(5).ColorEquals(blue));
            Assert.IsTrue(Colors.Index.Get(6).ColorEquals(magenta));
            Assert.IsTrue(Colors.Index.Get(7).ColorEquals(white));
            Assert.IsTrue(Colors.Index.Get(8).ColorEquals(blackgray));
            Assert.IsTrue(Colors.Index.Get(9).ColorEquals(gray));
        }

        [Test]
        public void Colors_Index_Get_All_Tests()
        {
            for (int i = 0; i < 256; i++)
            {
                Assert.IsNotNull(Colors.Index.Get((byte)i));
            }
        }

        [Test]
        public void ColorExtension_ColorEquals_Tests()
        {
            for (int i = 0; i < 256; i++)
            {
                var color = Colors.Index.Get((byte)i);
                Assert.IsTrue(color.ColorEquals(color));

                var colorT = color.ToColorWithTransparency();
                Assert.IsTrue(colorT.ColorEquals(colorT));
                Assert.IsTrue(colorT.ColorEquals(color));
                Assert.IsTrue(color.ColorEquals(colorT));

                var colorT100 = color.ToColorWithTransparency(100);
                Assert.IsFalse(colorT.ColorEquals(colorT100));
                Assert.IsFalse(colorT100.ColorEquals(colorT));

                var _color = colorT.ToColor();
                Assert.IsTrue(color.ColorEquals(_color));
            }
        }

        [Test]
        public void ColorExtension_Lerp_Tests()
        {
            var color = Colors.Black.Lerp(Colors.Gray, 0.5);
            var colorExpected = new Color(64, 64, 64);
            Assert.IsTrue(color.ColorEquals(colorExpected));
        }

        [Test]
        public void ColorExtension_ToHex_Tests()
        {
            var tests = new Dictionary<string, Color>()
            {
                { "#000000", Colors.Black },
                { "#FF0000", Colors.Red },
                { "#008000", Colors.Green },
                { "#00FF00", Colors.Lime },
                { "#0000FF", Colors.Blue },
                { "#FFFF00", Colors.Yellow },
                { "#00FFFF", Colors.Cyan },
                { "#FF00FF", Colors.Magenta },
                { "#808080", Colors.Gray },
                { "#FFFFFF", Colors.White },
            };

            foreach (var test in tests)
            {
                Assert.AreEqual(test.Key, test.Value.ToHex());
            }

            foreach (var test in tests)
            {
                Assert.AreEqual(test.Key, test.Value.ToColorWithTransparency().ToHex());
            }
        }
    }

}