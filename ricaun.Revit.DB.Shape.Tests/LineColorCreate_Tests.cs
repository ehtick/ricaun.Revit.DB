using NUnit.Framework;
using ricaun.Revit.DB.Shape.Tests.Utils;

namespace ricaun.Revit.DB.Shape.Tests
{
    public class LineColorCreate_Tests : OneTimeOpenDocumentTransactionTest
    {
        [Test]
        public void CreateLineColorWhite()
        {
            var graphicsStyle = GraphicsStyleUtils.CreateLineColorWhite(document);
            Assert.IsNotNull(graphicsStyle);
        }

        [Test]
        public void CreateLineColorRed()
        {
            var graphicsStyle = GraphicsStyleUtils.CreateLineColorRed(document);
            Assert.IsNotNull(graphicsStyle);
        }

        [Test]
        public void CreateLineColorGreen()
        {
            var graphicsStyle = GraphicsStyleUtils.CreateLineColorGreen(document);
            Assert.IsNotNull(graphicsStyle);
        }

        [Test]
        public void CreateLineColorBlue()
        {
            var graphicsStyle = GraphicsStyleUtils.CreateLineColorBlue(document);
            Assert.IsNotNull(graphicsStyle);
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