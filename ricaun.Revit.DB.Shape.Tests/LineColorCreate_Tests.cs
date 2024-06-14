using Autodesk.Revit.DB;
using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;
using System.Collections.Generic;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class LineColorCreate_Tests : OneTimeOpenDocumentTransactionTest
    {
        [Test]
        public void CreateLineColors()
        {
            var colors = new Dictionary<Color, GraphicsStyle>() {
                { Colors.White, GraphicsStyleUtils.CreateLineColorWhite(document)},
                { Colors.Red, GraphicsStyleUtils.CreateLineColorRed(document)},
                { Colors.Green, GraphicsStyleUtils.CreateLineColorGreen(document)},
                { Colors.Blue, GraphicsStyleUtils.CreateLineColorBlue(document)},
                { Colors.Yellow, GraphicsStyleUtils.CreateLineColorYellow(document)},
                { Colors.Cyan, GraphicsStyleUtils.CreateLineColorCyan(document)},
                { Colors.Magenta, GraphicsStyleUtils.CreateLineColorMagenta(document)},
                { Colors.Black, GraphicsStyleUtils.CreateLineColorBlack(document)},
                { Colors.Gray, GraphicsStyleUtils.CreateLineColorGray(document)},
            };

            foreach (var color in colors)
            {
                Assert.IsNotNull(color.Value);
                Assert.IsTrue(color.Value.GraphicsStyleCategory.LineColor.ColorEquals(color.Key));
            }
        }

        [Test]
        public void CreateLineColor_Index()
        {
            for (int i = 0; i < 256; i++)
            {
                var color = Colors.Index.Get((byte)i);
                var graphicsStyle = GraphicsStyleUtils.CreateLineColor(document, color);
                Assert.IsNotNull(graphicsStyle);

                var graphicsStyleFindName = GraphicsStyleUtils.CreateLineColor(document, color);
                Assert.AreEqual(graphicsStyle.Id, graphicsStyleFindName.Id);
            }
        }
    }
}