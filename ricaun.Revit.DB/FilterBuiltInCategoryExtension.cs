using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace ricaun.Revit.DB
{
    /// <summary>
    /// Provides extension methods for creating Revit category filters from <see cref="Autodesk.Revit.DB.BuiltInCategory"/> values.
    /// </summary>
    public static class FilterBuiltInCategoryExtension
    {
        /// <summary>
        /// Creates an <see cref="Autodesk.Revit.DB.ElementCategoryFilter"/> for the specified <see cref="Autodesk.Revit.DB.BuiltInCategory"/>.
        /// </summary>
        /// <param name="category">The built-in category to filter by.</param>
        /// <returns>An <see cref="Autodesk.Revit.DB.ElementCategoryFilter"/> for the specified category.</returns>
        public static ElementCategoryFilter Filter(this BuiltInCategory category)
        {
            return new ElementCategoryFilter(category);
        }

        /// <summary>
        /// Creates an <see cref="Autodesk.Revit.DB.ElementCategoryFilter"/> for the specified <see cref="Autodesk.Revit.DB.BuiltInCategory"/>, with an option to invert the filter.
        /// </summary>
        /// <param name="category">The built-in category to filter by.</param>
        /// <param name="inverted">If <c>true</c>, the filter will exclude elements of the specified category; otherwise, it will include them.</param>
        /// <returns>An <see cref="Autodesk.Revit.DB.ElementCategoryFilter"/> for the specified category, with optional inversion.</returns>
        public static ElementCategoryFilter Filter(this BuiltInCategory category, bool inverted)
        {
            return new ElementCategoryFilter(category, inverted);
        }

        /// <summary>
        /// Creates an <see cref="Autodesk.Revit.DB.ElementMulticategoryFilter"/> for the specified collection of <see cref="Autodesk.Revit.DB.BuiltInCategory"/> values.
        /// </summary>
        /// <param name="categories">The collection of built-in categories to filter by.</param>
        /// <returns>An <see cref="Autodesk.Revit.DB.ElementMulticategoryFilter"/> for the specified categories.</returns>
        public static ElementMulticategoryFilter Filter(this ICollection<BuiltInCategory> categories)
        {
            return new ElementMulticategoryFilter(categories);
        }

        /// <summary>
        /// Creates an <see cref="Autodesk.Revit.DB.ElementMulticategoryFilter"/> for the specified collection of <see cref="Autodesk.Revit.DB.BuiltInCategory"/> values, with an option to invert the filter.
        /// </summary>
        /// <param name="categories">The collection of built-in categories to filter by.</param>
        /// <param name="inverted">If <c>true</c>, the filter will exclude elements of the specified categories; otherwise, it will include them.</param>
        /// <returns>An <see cref="Autodesk.Revit.DB.ElementMulticategoryFilter"/> for the specified categories, with optional inversion.</returns>
        public static ElementMulticategoryFilter Filter(this ICollection<BuiltInCategory> categories, bool inverted)
        {
            return new ElementMulticategoryFilter(categories, inverted);
        }
    }
}