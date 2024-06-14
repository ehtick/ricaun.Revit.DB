using Autodesk.Revit.DB;

namespace ricaun.Revit.DB.Shape.Tests.Utils
{
    public static class ElementIdUtils
    {
        public static ElementId MaterialId => new ElementId(BuiltInCategory.OST_Materials);
        public static ElementId GraphicsStyleId => new ElementId(BuiltInCategory.OST_Lines);
    }
}