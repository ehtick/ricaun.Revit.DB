using Autodesk.Revit.DB;

namespace ricaun.Revit.DB
{
    /// <summary>
    /// Provides extension methods for creating various types of filter rules in Revit.
    /// </summary>
    public static class FilterRuleExtension
    {
        /// <summary>
        /// A small tolerance value used for fuzzy comparisons in double rules.
        /// </summary>
        private const double Epsilon = 1e-9;

        /// <summary>
        /// Creates an inverse of the given filter rule.
        /// </summary>
        /// <param name="filterRule">The filter rule to invert.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterInverseRule"/> that represents the inverse of the given filter rule.</returns>
        public static FilterInverseRule InverseRule(this FilterRule filterRule)
        {
            return new FilterInverseRule(filterRule);
        }
        /// <summary>
        /// Creates a FilterElementIdRule using a numeric evaluator, a parameter ID, and a rule value.
        /// </summary>
        /// <param name="evaluator">The numeric rule evaluator to use for comparison.</param>
        /// <param name="parameterId">The ID of the parameter to evaluate.</param>
        /// <param name="ruleValue">The ElementId value to compare against.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterElementIdRule"/> for use in Revit filtering.</returns>
        public static FilterElementIdRule Rule(this FilterNumericRuleEvaluator evaluator, ElementId parameterId, ElementId ruleValue)
            => evaluator.Rule(new ParameterValueProvider(parameterId), ruleValue);

        /// <summary>
        /// Creates a FilterIntegerRule using a numeric evaluator, a parameter ID, and an integer rule value.
        /// </summary>
        /// <param name="evaluator">The numeric rule evaluator to use for comparison.</param>
        /// <param name="parameterId">The ID of the parameter to evaluate.</param>
        /// <param name="ruleValue">The integer value to compare against.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterIntegerRule"/> for use in Revit filtering.</returns>
        public static FilterIntegerRule Rule(this FilterNumericRuleEvaluator evaluator, ElementId parameterId, int ruleValue)
            => evaluator.Rule(new ParameterValueProvider(parameterId), ruleValue);

        /// <summary>
        /// Creates a FilterDoubleRule using a numeric evaluator, a parameter ID, and a double rule value.
        /// </summary>
        /// <param name="evaluator">The numeric rule evaluator to use for comparison.</param>
        /// <param name="parameterId">The ID of the parameter to evaluate.</param>
        /// <param name="ruleValue">The double value to compare against.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterDoubleRule"/> for use in Revit filtering.</returns>
        public static FilterDoubleRule Rule(this FilterNumericRuleEvaluator evaluator, ElementId parameterId, double ruleValue)
            => evaluator.Rule(new ParameterValueProvider(parameterId), ruleValue);

        /// <summary>
        /// Creates a FilterDoubleRule using a numeric evaluator, a parameter ID, a double rule value, and a custom epsilon value.
        /// </summary>
        /// <param name="evaluator">The numeric rule evaluator to use for comparison.</param>
        /// <param name="parameterId">The ID of the parameter to evaluate.</param>
        /// <param name="ruleValue">The double value to compare against.</param>
        /// <param name="epsilon">The tolerance value for fuzzy comparisons.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterDoubleRule"/> for use in Revit filtering.</returns>
        public static FilterDoubleRule Rule(this FilterNumericRuleEvaluator evaluator, ElementId parameterId, double ruleValue, double epsilon)
            => evaluator.Rule(new ParameterValueProvider(parameterId), ruleValue, epsilon);

        /// <summary>
        /// Creates a FilterStringRule using a string evaluator, a parameter ID, and a string rule value.
        /// </summary>
        /// <param name="evaluator">The string rule evaluator to use for comparison.</param>
        /// <param name="parameterId">The ID of the parameter to evaluate.</param>
        /// <param name="ruleString">The string value to compare against.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterStringRule"/> for use in Revit filtering.</returns>
        public static FilterStringRule Rule(this FilterStringRuleEvaluator evaluator, ElementId parameterId, string ruleString)
            => evaluator.Rule(new ParameterValueProvider(parameterId), ruleString);

        /// <summary>
        /// Creates a FilterElementIdRule using a numeric evaluator, a built-in parameter, and a rule value.
        /// </summary>
        /// <param name="evaluator">The numeric rule evaluator to use for comparison.</param>
        /// <param name="parameterId">The built-in parameter to evaluate.</param>
        /// <param name="ruleValue">The ElementId value to compare against.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterElementIdRule"/> for use in Revit filtering.</returns>
        public static FilterElementIdRule Rule(this FilterNumericRuleEvaluator evaluator, BuiltInParameter parameterId, ElementId ruleValue)
            => evaluator.Rule(new ParameterValueProvider(new ElementId(parameterId)), ruleValue);

        /// <summary>
        /// Creates a FilterIntegerRule using a numeric evaluator, a built-in parameter, and an integer rule value.
        /// </summary>
        /// <param name="evaluator">The numeric rule evaluator to use for comparison.</param>
        /// <param name="parameterId">The built-in parameter to evaluate.</param>
        /// <param name="ruleValue">The integer value to compare against.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterIntegerRule"/> for use in Revit filtering.</returns>
        public static FilterIntegerRule Rule(this FilterNumericRuleEvaluator evaluator, BuiltInParameter parameterId, int ruleValue)
            => evaluator.Rule(new ParameterValueProvider(new ElementId(parameterId)), ruleValue);

        /// <summary>
        /// Creates a FilterDoubleRule using a numeric evaluator, a built-in parameter, and a double rule value.
        /// </summary>
        /// <param name="evaluator">The numeric rule evaluator to use for comparison.</param>
        /// <param name="parameterId">The built-in parameter to evaluate.</param>
        /// <param name="ruleValue">The double value to compare against.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterDoubleRule"/> for use in Revit filtering.</returns>
        public static FilterDoubleRule Rule(this FilterNumericRuleEvaluator evaluator, BuiltInParameter parameterId, double ruleValue)
            => evaluator.Rule(new ParameterValueProvider(new ElementId(parameterId)), ruleValue);

        /// <summary>
        /// Creates a FilterDoubleRule using a numeric evaluator, a built-in parameter, a double rule value, and a custom epsilon value.
        /// </summary>
        /// <param name="evaluator">The numeric rule evaluator to use for comparison.</param>
        /// <param name="parameterId">The built-in parameter to evaluate.</param>
        /// <param name="ruleValue">The double value to compare against.</param>
        /// <param name="epsilon">The tolerance value for fuzzy comparisons.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterDoubleRule"/> for use in Revit filtering.</returns>
        public static FilterDoubleRule Rule(this FilterNumericRuleEvaluator evaluator, BuiltInParameter parameterId, double ruleValue, double epsilon)
            => evaluator.Rule(new ParameterValueProvider(new ElementId(parameterId)), ruleValue, epsilon);

        /// <summary>
        /// Creates a FilterStringRule using a string evaluator, a built-in parameter, and a string rule value.
        /// </summary>
        /// <param name="evaluator">The string rule evaluator to use for comparison.</param>
        /// <param name="parameterId">The built-in parameter to evaluate.</param>
        /// <param name="ruleString">The string value to compare against.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterStringRule"/> for use in Revit filtering.</returns>
        public static FilterStringRule Rule(this FilterStringRuleEvaluator evaluator, BuiltInParameter parameterId, string ruleString)
            => evaluator.Rule(new ParameterValueProvider(new ElementId(parameterId)), ruleString);

        /// <summary>
        /// Creates a FilterElementIdRule by combining a value provider with a numeric evaluator and a rule value.
        /// </summary>
        /// <param name="evaluator">The numeric rule evaluator to use for comparison.</param>
        /// <param name="valueProvider">The provider that supplies values to be evaluated.</param>
        /// <param name="ruleValue">The ElementId value to compare against.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterElementIdRule"/> for use in Revit filtering.</returns>
        public static FilterElementIdRule Rule(this FilterNumericRuleEvaluator evaluator, FilterableValueProvider valueProvider, ElementId ruleValue)
        {
            return new FilterElementIdRule(valueProvider, evaluator, ruleValue);
        }

        /// <summary>
        /// Creates a FilterIntegerRule by combining a value provider with a numeric evaluator and an integer rule value.
        /// </summary>
        /// <param name="evaluator">The numeric rule evaluator to use for comparison.</param>
        /// <param name="valueProvider">The provider that supplies values to be evaluated.</param>
        /// <param name="ruleValue">The integer value to compare against.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterIntegerRule"/> for use in Revit filtering.</returns>
        public static FilterIntegerRule Rule(this FilterNumericRuleEvaluator evaluator, FilterableValueProvider valueProvider, int ruleValue)
        {
            return new FilterIntegerRule(valueProvider, evaluator, ruleValue);
        }

        /// <summary>
        /// Creates a FilterDoubleRule by combining a value provider with a numeric evaluator and a double rule value.
        /// Uses the default epsilon value for fuzzy comparison.
        /// </summary>
        /// <param name="evaluator">The numeric rule evaluator to use for comparison.</param>
        /// <param name="valueProvider">The provider that supplies values to be evaluated.</param>
        /// <param name="ruleValue">The double value to compare against.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterDoubleRule"/> for use in Revit filtering.</returns>
        public static FilterDoubleRule Rule(this FilterNumericRuleEvaluator evaluator, FilterableValueProvider valueProvider, double ruleValue)
        {
            return evaluator.Rule(valueProvider, ruleValue, Epsilon);
        }

        /// <summary>
        /// Creates a FilterDoubleRule by combining a value provider with a numeric evaluator, a double rule value, and a custom epsilon value.
        /// </summary>
        /// <param name="evaluator">The numeric rule evaluator to use for comparison.</param>
        /// <param name="valueProvider">The provider that supplies values to be evaluated.</param>
        /// <param name="ruleValue">The double value to compare against.</param>
        /// <param name="epsilon">The tolerance value for fuzzy comparisons.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterDoubleRule"/> for use in Revit filtering.</returns>
        public static FilterDoubleRule Rule(this FilterNumericRuleEvaluator evaluator, FilterableValueProvider valueProvider, double ruleValue, double epsilon)
        {
            return new FilterDoubleRule(valueProvider, evaluator, ruleValue, epsilon);
        }

        /// <summary>
        /// Creates a FilterStringRule by combining a value provider with a string evaluator and a string rule value.
        /// </summary>
        /// <param name="evaluator">The string rule evaluator to use for comparison.</param>
        /// <param name="valueProvider">The provider that supplies values to be evaluated.</param>
        /// <param name="ruleString">The string value to compare against.</param>
        /// <returns>A new <see cref="Autodesk.Revit.DB.FilterStringRule"/> for use in Revit filtering.</returns>
        public static FilterStringRule Rule(this FilterStringRuleEvaluator evaluator, FilterableValueProvider valueProvider, string ruleString)
        {
#if NET47
            return new FilterStringRule(valueProvider, evaluator, ruleString, false);
#elif NET48
            return FilterStringRuleResolver.Invoke(valueProvider, evaluator, ruleString);
#else
            return new FilterStringRule(valueProvider, evaluator, ruleString);
#endif
        }

#if NET48
        /// <summary>
        /// Revit 2022 obsolete FilterStringRule constructor with case sensitivity parameter.
        /// </summary>
        private static class FilterStringRuleResolver
        {
            /// <summary>
            /// Gets the constructor information for the FilterStringRule class.
            /// </summary>
            public static System.Reflection.ConstructorInfo Constructor { get; } = typeof(FilterStringRule).GetConstructors()[0];

            /// <summary>
            /// Gets the number of parameters in the FilterStringRule constructor.
            /// </summary>
            public static int ConstructorLength { get; } = Constructor.GetParameters().Length;

            /// <summary>
            /// Invokes the appropriate FilterStringRule constructor based on the parameter count.
            /// </summary>
            /// <param name="valueProvider">The provider that supplies values to be evaluated.</param>
            /// <param name="evaluator">The string rule evaluator to use for comparison.</param>
            /// <param name="ruleString">The string value to compare against.</param>
            /// <returns>A new <see cref="Autodesk.Revit.DB.FilterStringRule"/> for use in Revit filtering.</returns>
            public static FilterStringRule Invoke(FilterableValueProvider valueProvider, FilterStringRuleEvaluator evaluator, string ruleString)
            {
                if (ConstructorLength == 3)
                    return (FilterStringRule)Constructor.Invoke(new object[] { valueProvider, evaluator, ruleString });
                return (FilterStringRule)Constructor.Invoke(new object[] { valueProvider, evaluator, ruleString, false });
            }
        }
#endif
    }
}