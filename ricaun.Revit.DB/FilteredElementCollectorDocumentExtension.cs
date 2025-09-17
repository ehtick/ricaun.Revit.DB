using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace ricaun.Revit.DB
{
    /// <summary>
    /// Provides extension methods for the <see cref="Document"/> class to simplify the creation of <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> instances.
    /// </summary>
    public static partial class FilteredElementCollectorDocumentExtension
    {
        /// <summary>
        /// Creates a new <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for the specified document.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> instance.</returns>
        public static FilteredElementCollector Select(this Document document)
        {
            return new FilteredElementCollector(document);
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> filtered by a specific category.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="category">The built-in category to filter by.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> filtered by the specified category.</returns>
        public static FilteredElementCollector Select(this Document document, BuiltInCategory category)
        {
            return document.Select().OfCategory(category);
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> filtered by a specific category and additional filters.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="category">The built-in category to filter by.</param>
        /// <param name="filters">Additional element filters to apply.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> filtered by the specified category and filters.</returns>
        public static FilteredElementCollector Select(this Document document, BuiltInCategory category, params IEnumerable<ElementFilter> filters)
        {
            return document.Select(category).WherePasses(filters);
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> filtered by additional filters.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="filters">Additional element filters to apply.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> filtered by the specified filters.</returns>
        public static FilteredElementCollector Select(this Document document, params IEnumerable<ElementFilter> filters)
        {
            return document.Select().WherePasses(filters);
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for a specific view.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="viewId">The ID of the view to filter by.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for the specified view.</returns>
        public static FilteredElementCollector Select(this Document document, ElementId viewId)
        {
            return new FilteredElementCollector(document, viewId);
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for a specific view and category.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="viewId">The ID of the view to filter by.</param>
        /// <param name="category">The built-in category to filter by.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for the specified view and category.</returns>
        public static FilteredElementCollector Select(this Document document, ElementId viewId, BuiltInCategory category)
        {
            return document.Select(viewId).OfCategory(category);
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for a specific view, category, and additional filters.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="viewId">The ID of the view to filter by.</param>
        /// <param name="category">The built-in category to filter by.</param>
        /// <param name="filters">Additional element filters to apply.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for the specified view, category, and filters.</returns>
        public static FilteredElementCollector Select(this Document document, ElementId viewId, BuiltInCategory category, params IEnumerable<ElementFilter> filters)
        {
            return document.Select(viewId, category).WherePasses(filters);
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for a specific view and additional filters.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="viewId">The ID of the view to filter by.</param>
        /// <param name="filters">Additional element filters to apply.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for the specified view and filters.</returns>
        public static FilteredElementCollector Select(this Document document, ElementId viewId, params IEnumerable<ElementFilter> filters)
        {
            return document.Select(viewId).WherePasses(filters);
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for a specific set of element IDs.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="elementIds">The collection of element IDs to filter by.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for the specified element IDs.</returns>
        public static FilteredElementCollector Select(this Document document, ICollection<ElementId> elementIds)
        {
            return new FilteredElementCollector(document, elementIds);
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for a specific set of element IDs and category.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="elementIds">The collection of element IDs to filter by.</param>
        /// <param name="category">The built-in category to filter by.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for the specified element IDs and category.</returns>
        public static FilteredElementCollector Select(this Document document, ICollection<ElementId> elementIds, BuiltInCategory category)
        {
            return document.Select(elementIds).OfCategory(category);
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for a specific set of element IDs, category, and additional filters.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="elementIds">The collection of element IDs to filter by.</param>
        /// <param name="category">The built-in category to filter by.</param>
        /// <param name="filters">Additional element filters to apply.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for the specified element IDs, category, and filters.</returns>
        public static FilteredElementCollector Select(this Document document, ICollection<ElementId> elementIds, BuiltInCategory category, params IEnumerable<ElementFilter> filters)
        {
            return document.Select(elementIds, category).WherePasses(filters);
        }

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for a specific set of element IDs and additional filters.
        /// </summary>
        /// <param name="document">The Revit document.</param>
        /// <param name="elementIds">The collection of element IDs to filter by.</param>
        /// <param name="filters">Additional element filters to apply.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> for the specified element IDs and filters.</returns>
        public static FilteredElementCollector Select(this Document document, ICollection<ElementId> elementIds, params IEnumerable<ElementFilter> filters)
        {
            return document.Select(elementIds).WherePasses(filters);
        }
    }
}