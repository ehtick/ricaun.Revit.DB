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
        /// <returns>Color {alpha}{red}{blue}{green} in hexa</returns>
        public static string MaterialColorName(byte red, byte green, byte blue, byte alpha = byte.MaxValue)
        {
            if (alpha == byte.MaxValue)
                return string.Format("Color {0:X2}{1:X2}{2:X2}", red, green, blue);

            return string.Format("Color {0:X2}{1:X2}{2:X2}{3:X2}", alpha, red, green, blue);
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
            material.Transparency = (int)((255 - alpha) / 2.55);
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

        /// <summary>
        /// CreateMaterialWhite
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Material CreateMaterialWhite(Document document)
        {
            return CreateMaterial(document, Colors.White);
        }

        /// <summary>
        /// CreateMaterialRed
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Material CreateMaterialRed(Document document)
        {
            return CreateMaterial(document, Colors.Red);
        }

        /// <summary>
        /// CreateMaterialGreen
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Material CreateMaterialGreen(Document document)
        {
            return CreateMaterial(document, Colors.Green);
        }

        /// <summary>
        /// CreateMaterialBlue
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static Material CreateMaterialBlue(Document document)
        {
            return CreateMaterial(document, Colors.Blue);
        }

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

    }
}
