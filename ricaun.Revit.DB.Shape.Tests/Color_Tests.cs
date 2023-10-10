using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class Color_Tests
    {
        Color black = new Color(0, 0, 0);
        Color red = new Color(255, 0, 0);
        Color yellow = new Color(255, 255, 0);
        Color green = new Color(0, 255, 0);
        Color cyan = new Color(0, 255, 255);
        Color blue = new Color(0, 0, 255);
        Color magenta = new Color(255, 0, 255);
        Color white = new Color(255, 255, 255);
        Color darkgray = new Color(65, 65, 65);
        Color gray = new Color(128, 128, 128);

        [Test]
        public void Colors_Tests()
        {
            Assert.IsTrue(Colors.Black.ColorEquals(black));
            Assert.IsTrue(Colors.Red.ColorEquals(red));
            Assert.IsTrue(Colors.Yellow.ColorEquals(yellow));
            Assert.IsTrue(Colors.Green.ColorEquals(green));
            Assert.IsTrue(Colors.Cyan.ColorEquals(cyan));
            Assert.IsTrue(Colors.Blue.ColorEquals(blue));
            Assert.IsTrue(Colors.Magenta.ColorEquals(magenta));
            Assert.IsTrue(Colors.White.ColorEquals(white));
            Assert.IsTrue(Colors.DarkGray.ColorEquals(darkgray));
            Assert.IsTrue(Colors.Gray.ColorEquals(gray));
        }

        [Test]
        public void Colors_Index_Tests()
        {
            Assert.IsTrue(Colors.Index.Color_0.ColorEquals(black));
            Assert.IsTrue(Colors.Index.Color_1.ColorEquals(red));
            Assert.IsTrue(Colors.Index.Color_2.ColorEquals(yellow));
            Assert.IsTrue(Colors.Index.Color_3.ColorEquals(green));
            Assert.IsTrue(Colors.Index.Color_4.ColorEquals(cyan));
            Assert.IsTrue(Colors.Index.Color_5.ColorEquals(blue));
            Assert.IsTrue(Colors.Index.Color_6.ColorEquals(magenta));
            Assert.IsTrue(Colors.Index.Color_7.ColorEquals(white));
            Assert.IsTrue(Colors.Index.Color_8.ColorEquals(darkgray));
            Assert.IsTrue(Colors.Index.Color_9.ColorEquals(gray));
        }

        [Test]
        public void Colors_Index_Get_Tests()
        {
            Assert.IsTrue(Colors.Index.Get(0).ColorEquals(black));
            Assert.IsTrue(Colors.Index.Get(1).ColorEquals(red));
            Assert.IsTrue(Colors.Index.Get(2).ColorEquals(yellow));
            Assert.IsTrue(Colors.Index.Get(3).ColorEquals(green));
            Assert.IsTrue(Colors.Index.Get(4).ColorEquals(cyan));
            Assert.IsTrue(Colors.Index.Get(5).ColorEquals(blue));
            Assert.IsTrue(Colors.Index.Get(6).ColorEquals(magenta));
            Assert.IsTrue(Colors.Index.Get(7).ColorEquals(white));
            Assert.IsTrue(Colors.Index.Get(8).ColorEquals(darkgray));
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
    }


}