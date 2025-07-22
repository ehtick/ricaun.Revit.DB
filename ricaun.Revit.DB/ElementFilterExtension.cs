using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace ricaun.Revit.DB
{
    /// <summary>
    /// Provides extension methods for working with Revit ElementFilter objects.
    /// </summary>
    public static class ElementFilterExtension
    {
        /// <summary>
        /// Combines two ElementFilter objects using a logical AND operation.
        /// </summary>
        /// <param name="filter1">The first ElementFilter.</param>
        /// <param name="filter2">The second ElementFilter.</param>
        /// <returns>A new ElementFilter that represents the logical AND of the two filters.</returns>
        public static ElementFilter And(this ElementFilter filter1, ElementFilter filter2)
        {
            if (filter1 is LogicalAndFilter logicalFilter)
            {
                return logicalFilter.AddFilter(filter1);
            }
            return new LogicalAndFilter(filter1, filter2);
        }

        /// <summary>
        /// Combines two ElementFilter objects using a logical OR operation.
        /// </summary>
        /// <param name="filter1">The first ElementFilter.</param>
        /// <param name="filter2">The second ElementFilter.</param>
        /// <returns>A new ElementFilter that represents the logical OR of the two filters.</returns>
        public static ElementFilter Or(this ElementFilter filter1, ElementFilter filter2)
        {
            if (filter1 is LogicalOrFilter logicalFilter)
            {
                return logicalFilter.AddFilter(filter1);
            }
            return new LogicalOrFilter(filter1, filter2);
        }

        /// <summary>
        /// Adds an ElementFilter to an existing ElementLogicalFilter.
        /// </summary>
        /// <param name="elementLogicalFilter">The ElementLogicalFilter to which the filter will be added.</param>
        /// <param name="elementFilter">The ElementFilter to add.</param>
        /// <returns>The updated ElementLogicalFilter with the new filter added.</returns>
        public static ElementLogicalFilter AddFilter(this ElementLogicalFilter elementLogicalFilter, ElementFilter elementFilter)
        {
            var filters = elementLogicalFilter.GetFilters();
            var similarFilters = elementFilter.GetSimilarFilters(elementLogicalFilter);

            foreach (var filter in similarFilters)
            {
                filters.Add(filter);
            }
#if NET47
            if (elementLogicalFilter is LogicalAndFilter)
                return new LogicalAndFilter(filters);
            return new LogicalOrFilter(filters);
#else
            elementLogicalFilter.SetFilters(filters);
            return elementLogicalFilter;
#endif
        }

        /// <summary>
        /// Retrieves filters from an ElementFilter that are similar to those in a specified ElementLogicalFilter.
        /// </summary>
        /// <param name="elementFilter">The ElementFilter to analyze.</param>
        /// <param name="elementLogicalFilter">The ElementLogicalFilter to compare against.</param>
        /// <returns>A list of ElementFilter objects that are similar to the filters in the ElementLogicalFilter.</returns>
        private static IList<ElementFilter> GetSimilarFilters(this ElementFilter elementFilter, ElementLogicalFilter elementLogicalFilter)
        {
            if (elementFilter is LogicalAndFilter logicalAndFilter && elementLogicalFilter is LogicalAndFilter)
            {
                return logicalAndFilter.GetFilters();
            }
            else if (elementFilter is LogicalOrFilter logicalOrFilter && elementLogicalFilter is LogicalOrFilter)
            {
                return logicalOrFilter.GetFilters();
            }
            return new List<ElementFilter>() { elementFilter };
        }
    }
}