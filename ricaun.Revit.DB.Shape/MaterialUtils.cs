using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB.Shape
{
    /// <summary>
    /// MaterialUtils
    /// </summary>
    public static class MaterialUtils
    {
        /// <summary>
        /// MaterialColorName
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <returns>'Color RRGGBB' or 'Color AARRGGBB'</returns>
        public static string MaterialColorName(byte red, byte green, byte blue, byte alpha = byte.MaxValue)
        {
            return string.Format("Color {0}", Extensions.ColorExtension.ToHex(red, green, blue, alpha).Trim('#'));
        }

        /// <summary>
        /// MaterialColorName
        /// </summary>
        /// <param name="color"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static string MaterialColorName(Color color, byte alpha = byte.MaxValue)
        {
            return MaterialColorName(color.Red, color.Green, color.Blue, alpha);
        }

        /// <summary>
        /// MaterialColorName
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string MaterialColorName(ColorWithTransparency color)
        {
            return MaterialColorName((byte)color.GetRed(), (byte)color.GetGreen(), (byte)color.GetBlue(), (byte)color.GetTransparency());
        }

        /// <summary>
        /// CreateMaterial
        /// </summary>
        /// <param name="document"></param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static Material CreateMaterial(Document document, byte red, byte green, byte blue, byte alpha = byte.MaxValue)
        {
            var materialName = MaterialColorName(red, green, blue, alpha);
            var material = FindMaterial(document, materialName);
            if (material is null)
            {
                var elementId = Material.Create(document, materialName);
                material = document.GetElement(elementId) as Material;
            }
            material.Color = new Color(red, green, blue);
            material.Transparency = (int)((double)(255 - alpha) / 2.55);
            return material;
        }

        /// <summary>
        /// CreateMaterial
        /// </summary>
        /// <param name="document"></param>
        /// <param name="color"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static Material CreateMaterial(Document document, Color color, byte alpha = byte.MaxValue)
        {
            return CreateMaterial(document, color.Red, color.Green, color.Blue, alpha);
        }

        /// <summary>
        /// CreateMaterial
        /// </summary>
        /// <param name="document"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Material CreateMaterial(Document document, ColorWithTransparency color)
        {
            return CreateMaterial(document, (byte)color.GetRed(), (byte)color.GetGreen(), (byte)color.GetBlue(), (byte)color.GetTransparency());
        }

        #region Colors
        /// <summary>
        /// CreateMaterialWhite
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Material CreateMaterialWhite(Document document) => CreateMaterial(document, Colors.White);
        /// <summary>
        /// CreateMaterialRed
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Material CreateMaterialRed(Document document) => CreateMaterial(document, Colors.Red);
        /// <summary>
        /// CreateMaterialGreen
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Material CreateMaterialGreen(Document document) => CreateMaterial(document, Colors.Green);
        /// <summary>
        /// CreateMaterialBlue
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Material CreateMaterialBlue(Document document) => CreateMaterial(document, Colors.Blue);
        /// <summary>
        /// CreateMaterialYellow
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Material CreateMaterialYellow(Document document) => CreateMaterial(document, Colors.Yellow);
        /// <summary>
        /// CreateMaterialCyan
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Material CreateMaterialCyan(Document document) => CreateMaterial(document, Colors.Cyan);
        /// <summary>
        /// CreateMaterialMagenta
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Material CreateMaterialMagenta(Document document) => CreateMaterial(document, Colors.Magenta);
        /// <summary>
        /// CreateMaterialGray
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Material CreateMaterialGray(Document document) => CreateMaterial(document, Colors.Gray);
        /// <summary>
        /// CreateMaterialBlack
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Material CreateMaterialBlack(Document document) => CreateMaterial(document, Colors.Black);
        #endregion

        /// <summary>
        /// FindMaterial
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        internal static IEnumerable<Material> FindMaterial(Document document)
        {
            // Find materials
            var materials = new FilteredElementCollector(document)
                .OfClass(typeof(Material))
                .OfType<Material>();

            return materials;
        }

        /// <summary>
        /// FindMaterial
        /// </summary>
        /// <param name="document"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Material FindMaterial(Document document, string name)
        {
            return FindMaterial(document)
                .FirstOrDefault(m => m.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// FindMaterial
        /// </summary>
        /// <param name="document"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Material FindMaterial(Document document, Color color)
        {
            return FindMaterial(document, MaterialColorName(color));
        }

        /// <summary>
        /// FindMaterial
        /// </summary>
        /// <param name="document"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Material FindMaterial(Document document, ColorWithTransparency color)
        {
            return FindMaterial(document, MaterialColorName(color));
        }

        #region Colors
        /// <summary>
        /// GetColor
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public static Color GetColor(Material material)
        {
            return GetColor(material.Document, material.Id);
        }

        /// <summary>
        /// GetColorWithTransparency
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        public static ColorWithTransparency GetColorWithTransparency(Material material)
        {
            return GetColorWithTransparency(material.Document, material.Id);
        }

        /// <summary>
        /// GetColor
        /// </summary>
        /// <param name="document"></param>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public static Color GetColor(Document document, ElementId materialId)
        {
            var color = Colors.Gray;
            if (document.GetElement(materialId) is Material material)
            {
                color = material.Color;
            }
            return color;
        }

        /// <summary>
        /// GetColorWithTransparency
        /// </summary>
        /// <param name="document"></param>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public static ColorWithTransparency GetColorWithTransparency(Document document, ElementId materialId)
        {
            var colorWithTransparency = new ColorWithTransparency();
            colorWithTransparency.SetColor(Colors.Gray);
            if (document.GetElement(materialId) is Material material)
            {
                var transparency = 255 - 2.55 * material.Transparency;
                colorWithTransparency.SetColor(material.Color);
                colorWithTransparency.SetTransparency((uint)transparency);
            }
            return colorWithTransparency;
        }
        #endregion
    }
}
