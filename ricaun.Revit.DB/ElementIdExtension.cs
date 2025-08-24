using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB
{
    /// <summary>
    /// Provides extension methods for working with ElementId in Revit.
    /// </summary>
    public static class ElementIdExtension
    {
        /// <summary>
        /// Converts an ElementId to an Element.
        /// </summary>
        /// <param name="elementId">The ElementId to convert.</param>
        /// <param name="document">The Revit document containing the element.</param>
        /// <returns>The corresponding Element, or null if not found.</returns>
        public static Element ToElement(this ElementId elementId, Document document)
        {
            return document.GetElement(elementId);
        }

        /// <summary>
        /// Converts an ElementId to a specific type of Element.
        /// </summary>
        /// <typeparam name="TElement">The type of Element to convert to.</typeparam>
        /// <param name="elementId">The ElementId to convert.</param>
        /// <param name="document">The Revit document containing the element.</param>
        /// <returns>The corresponding Element of type TElement, or null if not found.</returns>
        public static TElement ToElement<TElement>(this ElementId elementId, Document document) where TElement : Element
        {
            return document.GetElement(elementId) as TElement;
        }

        /// <summary>
        /// Converts a collection of ElementIds to a collection of Elements.
        /// </summary>
        /// <param name="elementIds">The collection of ElementIds to convert.</param>
        /// <param name="document">The Revit document containing the elements.</param>
        /// <returns>A collection of corresponding Elements.</returns>
        public static IEnumerable<Element> ToElements(this IEnumerable<ElementId> elementIds, Document document)
        {
            return elementIds.Select(e => e.ToElement(document));
        }

        /// <summary>
        /// Converts a collection of Elements to a collection of ElementIds.
        /// </summary>
        /// <param name="elementIds">The collection of Elements to convert.</param>
        /// <returns>
        /// A collection of corresponding ElementIds as a <see cref="HashSet{ElementId}"/> to ensure uniqueness.
        /// </returns>
        /// <remarks>
        /// Uses <see cref="HashSet{ElementId}"/> for efficient lookups and to avoid duplicate ElementIds.
        /// </remarks>
        public static ICollection<ElementId> ToElementIds(this IEnumerable<Element> elementIds)
        {
            return elementIds.Select(e => e.Id).ToHashSet();
        }
#if NET47
        private static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source)
        {
            return new HashSet<TSource>(source);
        }
#endif
        /// <summary>
        /// Converts a collection of ElementIds to a collection of a specific type of Elements.
        /// </summary>
        /// <typeparam name="TElement">The type of Elements to convert to.</typeparam>
        /// <param name="elementIds">The collection of ElementIds to convert.</param>
        /// <param name="document">The Revit document containing the elements.</param>
        /// <returns>A collection of corresponding Elements of type TElement.</returns>
        public static IEnumerable<TElement> ToElements<TElement>(this IEnumerable<ElementId> elementIds, Document document) where TElement : Element
        {
            if (elementIds is ICollection<ElementId> collectionIds)
                return document.GetElements<TElement>(collectionIds);

            return document.GetElements<TElement>(elementIds.ToArray());
        }

        /// <summary>
        /// Checks if an ElementId is valid.
        /// </summary>
        /// <param name="elementId">The ElementId to check.</param>
        /// <returns>True if the ElementId is valid, otherwise false.</returns>
        public static bool IsValid(this ElementId elementId)
        {
            return elementId != null && elementId != ElementId.InvalidElementId;
        }

        /// <summary>
        /// Checks if an ElementId is greater than the invalid ElementId.
        /// </summary>
        /// <param name="elementId">The ElementId to check.</param>
        /// <returns>True if the ElementId is greater than the invalid ElementId, otherwise false.</returns>
        public static bool IsGreaterThanInvalid(this ElementId elementId)
        {
            return elementId > ElementId.InvalidElementId;
        }

        /// <summary>
        /// Checks if an ElementId is less than the invalid ElementId.
        /// </summary>
        /// <param name="elementId">The ElementId to check.</param>
        /// <returns>True if the ElementId is less than the invalid ElementId, otherwise false.</returns>
        public static bool IsLessThanInvalid(this ElementId elementId)
        {
            return elementId < ElementId.InvalidElementId;
        }

        /// <summary>
        /// Gets the value of an ElementId.
        /// </summary>
        /// <param name="elementId">The ElementId to get the value from.</param>
        /// <returns>The value of the ElementId.</returns>
        public static long GetValue(this ElementId elementId)
        {
#if NET47
            return elementId.IntegerValue;
#elif NET48
            return ElementIdValue.Get(elementId);
#else
            return elementId.Value;
#endif
        }

#if NET48
        /// <summary>
        /// Helper class for retrieving the value of an ElementId in .NET Framework 4.8.
        /// </summary>
        private static class ElementIdValue
        {
            /// <summary>
            /// Gets the PropertyInfo for the value of an ElementId.
            /// </summary>
            public static System.Reflection.PropertyInfo PropertyValue { get; } = typeof(ElementId).GetProperty("Value") ?? typeof(ElementId).GetProperty("IntegerValue");

            /// <summary>
            /// Gets the value of an ElementId.
            /// </summary>
            /// <param name="elementId">The ElementId to get the value from.</param>
            /// <returns>The value of the ElementId.</returns>
            public static long Get(ElementId elementId)
            {
                var value = PropertyValue.GetValue(elementId);
                if (value is long l) return l;
                return (int)value;
            }
        }
#endif

        /// <summary>
        /// Converts an ElementId to a BuiltInCategory.
        /// </summary>
        /// <param name="elementId">The ElementId to convert.</param>
        /// <returns>The corresponding BuiltInCategory.</returns>
        public static BuiltInCategory GetBuiltInCategory(this ElementId elementId)
        {
            return (BuiltInCategory)elementId.GetValue();
        }

        /// <summary>
        /// Converts an ElementId to a BuiltInParameter.
        /// </summary>
        /// <param name="elementId">The ElementId to convert.</param>
        /// <returns>The corresponding BuiltInParameter.</returns>
        public static BuiltInParameter GetBuiltInParameter(this ElementId elementId)
        {
            return (BuiltInParameter)elementId.GetValue();
        }

        /// <summary>
        /// Checks if an ElementId is equal to a specific BuiltInParameter.
        /// </summary>
        /// <param name="elementId">The ElementId to compare.</param>
        /// <param name="builtInParameter">The BuiltInParameter to compare to.</param>
        /// <returns>True if they are equal, otherwise false.</returns>
        public static bool AreEquals(this ElementId elementId, BuiltInParameter builtInParameter)
        {
            return elementId == new ElementId(builtInParameter);
        }

        /// <summary>
        /// Checks if an ElementId is equal to a specific BuiltInCategory.
        /// </summary>
        /// <param name="elementId">The ElementId to compare.</param>
        /// <param name="builtInCategory">The BuiltInCategory to compare to.</param>
        /// <returns>True if they are equal, otherwise false.</returns>
        public static bool AreEquals(this ElementId elementId, BuiltInCategory builtInCategory)
        {
            return elementId == new ElementId(builtInCategory);
        }
    }
}