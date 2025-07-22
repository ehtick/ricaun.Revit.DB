using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace ricaun.Revit.DB
{
    /// <summary>
    /// Provides extension methods for creating <see cref="ElementParameterFilter"/> objects from <see cref="FilterRule"/> instances.
    /// </summary>
    public static class ElementParameterFilterExtension
    {
        /// <summary>
        /// Converts a collection of <see cref="FilterRule"/> objects into an <see cref="ElementParameterFilter"/>.
        /// </summary>
        /// <param name="filters">The collection of <see cref="FilterRule"/> objects.</param>
        /// <returns>An <see cref="ElementParameterFilter"/> created from the provided filter rules.</returns>
        public static ElementParameterFilter ToElementFilter(this IEnumerable<FilterRule> filters)
        {
            return new ElementParameterFilter(filters.ToList());
        }

        /// <summary>
        /// Converts a collection of <see cref="FilterRule"/> objects into an <see cref="ElementParameterFilter"/>, with an option to invert the filter.
        /// </summary>
        /// <param name="filters">The collection of <see cref="FilterRule"/> objects.</param>
        /// <param name="inverted">A boolean indicating whether the filter should be inverted.</param>
        /// <returns>An <see cref="ElementParameterFilter"/> created from the provided filter rules, with the specified inversion setting.</returns>
        public static ElementParameterFilter ToElementFilter(this IEnumerable<FilterRule> filters, bool inverted)
        {
            return new ElementParameterFilter(filters.ToList(), inverted);
        }

        /// <summary>
        /// Converts a single <see cref="FilterRule"/> into an <see cref="ElementParameterFilter"/>.
        /// </summary>
        /// <param name="filter">The <see cref="FilterRule"/> to convert.</param>
        /// <returns>An <see cref="ElementParameterFilter"/> created from the provided filter rule.</returns>
        public static ElementParameterFilter ToElementFilter(this FilterRule filter)
        {
            return new ElementParameterFilter(filter);
        }

        /// <summary>
        /// Converts a single <see cref="FilterRule"/> into an <see cref="ElementParameterFilter"/>, with an option to invert the filter.
        /// </summary>
        /// <param name="filter">The <see cref="FilterRule"/> to convert.</param>
        /// <param name="inverted">A boolean indicating whether the filter should be inverted.</param>
        /// <returns>An <see cref="ElementParameterFilter"/> created from the provided filter rule, with the specified inversion setting.</returns>
        public static ElementParameterFilter ToElementFilter(this FilterRule filter, bool inverted)
        {
            return new ElementParameterFilter(filter, inverted);
        }
    }
}