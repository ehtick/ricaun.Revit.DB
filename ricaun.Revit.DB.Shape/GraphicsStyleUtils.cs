using Autodesk.Revit.DB;
using System.Linq;

namespace ricaun.Revit.DB.Shape
{
    /// <summary>
    /// GraphicsStyleUtils
    /// </summary>
    public static class GraphicsStyleUtils
    {
        /// <summary>
        /// Create Category Lines
        /// </summary>
        /// <param name="document"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Category CreateCategoryLines(Document document, string name)
        {
            var categories = document.Settings.Categories;

            var categoryLines = categories.get_Item(BuiltInCategory.OST_Lines);
            var subCategories = categoryLines.SubCategories.OfType<Category>();

            var subCategory = subCategories.FirstOrDefault(e => e.Name == name);

            if (subCategory is null)
                subCategory = categories.NewSubcategory(categoryLines, name);

            return subCategory;
        }
        /// <summary>
        /// Create LineColor Category and return GraphicsStyleType.Projection.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static GraphicsStyle CreateLineColorWhite(Document document)
        {
            return CreateLineColor(document, Colors.White);
        }
        /// <summary>
        /// Create LineColor Category and return GraphicsStyleType.Projection.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static GraphicsStyle CreateLineColorGreen(Document document)
        {
            return CreateLineColor(document, Colors.Green);
        }
        /// <summary>
        /// Create LineColor Category and return GraphicsStyleType.Projection.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static GraphicsStyle CreateLineColorRed(Document document)
        {
            return CreateLineColor(document, Colors.Red);
        }
        /// <summary>
        /// Create LineColor Category and return GraphicsStyleType.Projection.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static GraphicsStyle CreateLineColorBlue(Document document)
        {
            return CreateLineColor(document, Colors.Blue);
        }
        /// <summary>
        /// Create LineColor Category and return GraphicsStyleType.Projection.
        /// </summary>
        /// <param name="document"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static GraphicsStyle CreateLineColor(Document document, Color color)
        {
            var name = MaterialUtils.MaterialColorName(color);
            var subCategory = CreateCategoryLines(document, name);
            subCategory.LineColor = color;
            return subCategory.GetGraphicsStyle(GraphicsStyleType.Projection);
        }
    }
}
