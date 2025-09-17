using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB
{
    /// <summary>
    /// Provides extension methods for the <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> class to simplify filtering and querying elements in Revit.
    /// </summary>
    public static class FilteredElementCollectorExtension
    {
        /// <summary>
        /// Applies multiple <see cref="Autodesk.Revit.DB.ElementFilter"/> objects to the <see cref="Autodesk.Revit.DB.FilteredElementCollector"/>.
        /// </summary>
        /// <param name="collection">The <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> to apply the filters to.</param>
        /// <param name="filters">An array of <see cref="Autodesk.Revit.DB.ElementFilter"/> to apply.</param>
        /// <returns>The updated <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> with the filters applied.</returns>
        public static FilteredElementCollector WherePasses(this FilteredElementCollector collection, params IEnumerable<ElementFilter> filters)
        {
            foreach (var filter in filters)
                collection.WherePasses(filter);

            return collection;
        }

        /// <summary>
        /// Filters the <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> to include elements of a specific type.
        /// </summary>
        /// <param name="collection">The <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> to filter.</param>
        /// <param name="type">The <see cref="Type"/> of elements to include.</param>
        /// <returns>The updated <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> with the type filter applied.</returns>
        public static FilteredElementCollector WhereElementIs(this FilteredElementCollector collection, Type type)
        {
            if (type == typeof(Element))
                return collection.WhereElementIsNotElementType();

            collection.OfClass(type);

            if (typeof(ElementType).IsAssignableFrom(type))
                return collection.WhereElementIsElementType();

            return collection.WhereElementIsNotElementType();
        }

        /// <summary>
        /// Filters the <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> to include elements of a specific generic type.
        /// </summary>
        /// <typeparam name="TElement">The type of elements to include, derived from <see cref="Autodesk.Revit.DB.Element"/>.</typeparam>
        /// <param name="collection">The <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> to filter.</param>
        /// <returns>The updated <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> with the type filter applied.</returns>
        public static FilteredElementCollector WhereElementIs<TElement>(this FilteredElementCollector collection) where TElement : Element
        {
            return collection.WhereElementIs(typeof(TElement));
        }

        /// <summary>
        /// Retrieves the first element of the specified type from the <see cref="Autodesk.Revit.DB.FilteredElementCollector"/>.
        /// </summary>
        /// <typeparam name="TElement">The type of element to retrieve, derived from <see cref="Autodesk.Revit.DB.Element"/>.</typeparam>
        /// <param name="collection">The <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> to query.</param>
        /// <returns>The first element of the specified type, or <c>null</c> if no such element exists.</returns>
        public static TElement FirstElement<TElement>(this FilteredElementCollector collection) where TElement : Element
        {
            return collection.FirstElement() as TElement;
        }

        /// <summary>
        /// Converts the <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> to an <see cref="IEnumerable{TElement}"/> of the specified type.
        /// </summary>
        /// <typeparam name="TElement">The type of elements to include, derived from <see cref="Autodesk.Revit.DB.Element"/>.</typeparam>
        /// <param name="collection">The <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> to convert.</param>
        /// <returns>An <see cref="IEnumerable{TElement}"/> containing elements of the specified type.</returns>
        public static IEnumerable<TElement> ToElements<TElement>(this FilteredElementCollector collection) where TElement : Element
        {
            return collection.OfType<TElement>();
        }
    }
}