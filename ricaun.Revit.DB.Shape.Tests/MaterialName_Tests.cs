using NUnit.Framework;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class MaterialName_Tests
    {
        [TestCase(0, 0, 0, ExpectedResult = "Color 000000")]
        [TestCase(255, 0, 0, ExpectedResult = "Color FF0000")]
        [TestCase(0, 255, 0, ExpectedResult = "Color 00FF00")]
        [TestCase(0, 0, 255, ExpectedResult = "Color 0000FF")]
        [TestCase(255, 128, 0, ExpectedResult = "Color FF8000")]
        [TestCase(0, 255, 128, ExpectedResult = "Color 00FF80")]
        [TestCase(128, 0, 255, ExpectedResult = "Color 8000FF")]
        [TestCase(254, 254, 254, ExpectedResult = "Color FEFEFE")]
        public string MaterialColorName(int red, int green, int blue)
        {
            var materialName = MaterialUtils.MaterialColorName((byte)red, (byte)green, (byte)blue);
            return materialName;
        }

        [TestCase(255, 255, 255, 0, ExpectedResult = "Color 00FFFFFF")]
        [TestCase(255, 255, 255, 32, ExpectedResult = "Color 20FFFFFF")]
        [TestCase(255, 255, 255, 64, ExpectedResult = "Color 40FFFFFF")]
        [TestCase(255, 255, 255, 128, ExpectedResult = "Color 80FFFFFF")]
        [TestCase(255, 255, 255, 255, ExpectedResult = "Color FFFFFF")]
        public string MaterialColorName_WithAlpha(int red, int green, int blue, int alpha)
        {
            var materialName = MaterialUtils.MaterialColorName((byte)red, (byte)green, (byte)blue, (byte)alpha);
            return materialName;
        }
    }


}