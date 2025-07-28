using Autodesk.Revit.DB;

namespace ricaun.Revit.DB
{
    /// <summary>
    /// Provides extension methods for creating filter rules and element parameter filters
    /// based on <see cref="BuiltInParameter"/>.
    /// </summary>
    public static class FilterRuleBuiltInParameterExtension
    {
#if !NET47
        /// <summary>
        /// Creates a filter rule that checks if the parameter has no value.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilterRule"/> that checks for no value.</returns>
        public static FilterRule RuleHasNoValue(this BuiltInParameter builtInParameter)
        {
            return new HasNoValueFilterRule(new ElementId(builtInParameter));
        }

        /// <summary>
        /// Creates a filter rule that checks if the parameter has a value.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilterRule"/> that checks for a value.</returns>
        public static FilterRule RuleHasValue(this BuiltInParameter builtInParameter)
        {
            return new HasValueFilterRule(new ElementId(builtInParameter));
        }

        /// <summary>
        /// Creates an element parameter filter that checks if the parameter has no value.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <returns>An <see cref="ElementParameterFilter"/> that checks for no value.</returns>
        public static ElementParameterFilter FilterHasNoValue(this BuiltInParameter builtInParameter)
        {
            return builtInParameter.RuleHasNoValue().ToElementFilter();
        }

        /// <summary>
        /// Creates an element parameter filter that checks if the parameter has a value.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <returns>An <see cref="ElementParameterFilter"/> that checks for a value.</returns>
        public static ElementParameterFilter FilterHasValue(this BuiltInParameter builtInParameter)
        {
            return builtInParameter.RuleHasValue().ToElementFilter();
        }
#endif

        /// <summary>
        /// Creates a filter rule using a string-based evaluator.
        /// </summary>
        /// <typeparam name="T">The type of the string rule evaluator.</typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleString">The string value to evaluate.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilterRule"/> based on the string evaluator.</returns>
        public static FilterStringRule Rule<T>(this BuiltInParameter builtInParameter, string ruleString) where T : FilterStringRuleEvaluator, new()
        {
            return new T().Rule(builtInParameter, ruleString);
        }

        /// <summary>
        /// Creates a filter rule using a numeric-based evaluator with an <see cref="Autodesk.Revit.DB.ElementId"/> value.
        /// </summary>
        /// <typeparam name="T">The type of the numeric rule evaluator.</typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The <see cref="Autodesk.Revit.DB.ElementId"/> value to evaluate.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilterRule"/> based on the numeric evaluator.</returns>
        public static FilterElementIdRule Rule<T>(this BuiltInParameter builtInParameter, ElementId ruleValue) where T : FilterNumericRuleEvaluator, new()
        {
            return new T().Rule(builtInParameter, ruleValue);
        }

        /// <summary>
        /// Creates a filter rule using a numeric-based evaluator with an integer value.
        /// </summary>
        /// <typeparam name="T">The type of the numeric rule evaluator.</typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The integer value to evaluate.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilterRule"/> based on the numeric evaluator.</returns>
        public static FilterIntegerRule Rule<T>(this BuiltInParameter builtInParameter, int ruleValue) where T : FilterNumericRuleEvaluator, new()
        {
            return new T().Rule(builtInParameter, ruleValue);
        }

        /// <summary>
        /// Creates a filter rule using a numeric-based evaluator with a double value.
        /// </summary>
        /// <typeparam name="T">The type of the numeric rule evaluator.</typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The double value to evaluate.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilterRule"/> based on the numeric evaluator.</returns>
        public static FilterDoubleRule Rule<T>(this BuiltInParameter builtInParameter, double ruleValue) where T : FilterNumericRuleEvaluator, new()
        {
            return new T().Rule(builtInParameter, ruleValue);
        }

        /// <summary>
        /// Creates a filter rule using a numeric-based evaluator with a double value and an epsilon.
        /// </summary>
        /// <typeparam name="T">The type of the numeric rule evaluator.</typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The double value to evaluate.</param>
        /// <param name="epsilon">The tolerance for the evaluation.</param>
        /// <returns>A <see cref="Autodesk.Revit.DB.FilterRule"/> based on the numeric evaluator.</returns>
        public static FilterDoubleRule Rule<T>(this BuiltInParameter builtInParameter, double ruleValue, double epsilon) where T : FilterNumericRuleEvaluator, new()
        {
            return new T().Rule(builtInParameter, ruleValue, epsilon);
        }

        /// <summary>
        /// Creates an element parameter filter using a string-based evaluator.
        /// </summary>
        /// <typeparam name="T">The type of the string rule evaluator.</typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleString">The string value to evaluate.</param>
        /// <returns>An <see cref="ElementParameterFilter"/> based on the string evaluator.</returns>
        public static ElementParameterFilter Filter<T>(this BuiltInParameter builtInParameter, string ruleString) where T : FilterStringRuleEvaluator, new()
        {
            return builtInParameter.Rule<T>(ruleString).ToElementFilter();
        }

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> using a string-based evaluator,
        /// and allows specifying whether the filter is inverted.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the string rule evaluator, which must inherit from <see cref="FilterStringRuleEvaluator"/> and have a parameterless constructor.
        /// </typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleString">The string value to evaluate against the parameter.</param>
        /// <param name="inverted">
        /// If <c>true</c>, the filter will be inverted, selecting elements that do not match the rule; otherwise, it will select elements that match.
        /// </param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> based on the string evaluator and inversion setting.
        /// </returns>
        public static ElementParameterFilter Filter<T>(this BuiltInParameter builtInParameter, string ruleString, bool inverted) where T : FilterStringRuleEvaluator, new()
        {
            return builtInParameter.Rule<T>(ruleString).ToElementFilter(inverted);
        }

        /// <summary>
        /// Creates an element parameter filter using a numeric-based evaluator with an <see cref="Autodesk.Revit.DB.ElementId"/> value.
        /// </summary>
        /// <typeparam name="T">The type of the numeric rule evaluator.</typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The <see cref="Autodesk.Revit.DB.ElementId"/> value to evaluate.</param>
        /// <returns>An <see cref="ElementParameterFilter"/> based on the numeric evaluator.</returns>
        public static ElementParameterFilter Filter<T>(this BuiltInParameter builtInParameter, ElementId ruleValue) where T : FilterNumericRuleEvaluator, new()
        {
            return builtInParameter.Rule<T>(ruleValue).ToElementFilter();
        }

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> using a numeric-based evaluator with an <see cref="Autodesk.Revit.DB.ElementId"/> value,
        /// and allows specifying whether the filter is inverted.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the numeric rule evaluator, which must inherit from <see cref="Autodesk.Revit.DB.FilterNumericRuleEvaluator"/> and have a parameterless constructor.
        /// </typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The <see cref="Autodesk.Revit.DB.ElementId"/> value to evaluate against the parameter.</param>
        /// <param name="inverted">
        /// If <c>true</c>, the filter will be inverted, selecting elements that do not match the rule; otherwise, it will select elements that match.
        /// </param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> based on the numeric evaluator and inversion setting.
        /// </returns>
        public static ElementParameterFilter Filter<T>(this BuiltInParameter builtInParameter, ElementId ruleValue, bool inverted) where T : FilterNumericRuleEvaluator, new()
        {
            return builtInParameter.Rule<T>(ruleValue).ToElementFilter(inverted);
        }

        /// <summary>
        /// Creates an element parameter filter using a numeric-based evaluator with an integer value.
        /// </summary>
        /// <typeparam name="T">The type of the numeric rule evaluator.</typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The integer value to evaluate.</param>
        /// <returns>An <see cref="ElementParameterFilter"/> based on the numeric evaluator.</returns>
        public static ElementParameterFilter Filter<T>(this BuiltInParameter builtInParameter, int ruleValue) where T : FilterNumericRuleEvaluator, new()
        {
            return builtInParameter.Rule<T>(ruleValue).ToElementFilter();
        }

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> using a numeric-based evaluator with an integer value,
        /// and allows specifying whether the filter is inverted.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the numeric rule evaluator, which must inherit from <see cref="Autodesk.Revit.DB.FilterNumericRuleEvaluator"/> and have a parameterless constructor.
        /// </typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The integer value to evaluate against the parameter.</param>
        /// <param name="inverted">
        /// If <c>true</c>, the filter will be inverted, selecting elements that do not match the rule; otherwise, it will select elements that match.
        /// </param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> based on the numeric evaluator and inversion setting.
        /// </returns>
        public static ElementParameterFilter Filter<T>(this BuiltInParameter builtInParameter, int ruleValue, bool inverted) where T : FilterNumericRuleEvaluator, new()
        {
            return builtInParameter.Rule<T>(ruleValue).ToElementFilter(inverted);
        }

        /// <summary>
        /// Creates an element parameter filter using a numeric-based evaluator with a double value.
        /// </summary>
        /// <typeparam name="T">The type of the numeric rule evaluator.</typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The double value to evaluate.</param>
        /// <returns>An <see cref="ElementParameterFilter"/> based on the numeric evaluator.</returns>
        public static ElementParameterFilter Filter<T>(this BuiltInParameter builtInParameter, double ruleValue) where T : FilterNumericRuleEvaluator, new()
        {
            return builtInParameter.Rule<T>(ruleValue).ToElementFilter();
        }

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> using a numeric-based evaluator with a double value,
        /// and allows specifying whether the filter is inverted.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the numeric rule evaluator, which must inherit from <see cref="Autodesk.Revit.DB.FilterNumericRuleEvaluator"/> and have a parameterless constructor.
        /// </typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The double value to evaluate against the parameter.</param>
        /// <param name="inverted">
        /// If <c>true</c>, the filter will be inverted, selecting elements that do not match the rule; otherwise, it will select elements that match.
        /// </param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> based on the numeric evaluator and inversion setting.
        /// </returns>
        public static ElementParameterFilter Filter<T>(this BuiltInParameter builtInParameter, double ruleValue, bool inverted) where T : FilterNumericRuleEvaluator, new()
        {
            return builtInParameter.Rule<T>(ruleValue).ToElementFilter(inverted);
        }

        /// <summary>
        /// Creates an element parameter filter using a numeric-based evaluator with a double value and an epsilon.
        /// </summary>
        /// <typeparam name="T">The type of the numeric rule evaluator.</typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The double value to evaluate.</param>
        /// <param name="epsilon">The tolerance for the evaluation.</param>
        /// <returns>An <see cref="ElementParameterFilter"/> based on the numeric evaluator.</returns>
        public static ElementParameterFilter Filter<T>(this BuiltInParameter builtInParameter, double ruleValue, double epsilon) where T : FilterNumericRuleEvaluator, new()
        {
            return builtInParameter.Rule<T>(ruleValue, epsilon).ToElementFilter();
        }

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> using a numeric-based evaluator with a double value and an epsilon,
        /// and allows specifying whether the filter is inverted.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the numeric rule evaluator, which must inherit from <see cref="Autodesk.Revit.DB.FilterNumericRuleEvaluator"/> and have a parameterless constructor.
        /// </typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The double value to evaluate against the parameter.</param>
        /// <param name="epsilon">The tolerance for the evaluation.</param>
        /// <param name="inverted">
        /// If <c>true</c>, the filter will be inverted, selecting elements that do not match the rule; otherwise, it will select elements that match.
        /// </param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> based on the numeric evaluator, epsilon, and inversion setting.
        /// </returns>
        public static ElementParameterFilter Filter<T>(this BuiltInParameter builtInParameter, double ruleValue, double epsilon, bool inverted) where T : FilterNumericRuleEvaluator, new()
        {
            return builtInParameter.Rule<T>(ruleValue, epsilon).ToElementFilter(inverted);
        }

        #region Equals Filters
        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> that checks if the parameter value equals the specified string.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleString">The string value to compare against the parameter value.</param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> that filters elements whose parameter value equals <paramref name="ruleString"/>.
        /// </returns>
        public static ElementParameterFilter Filter(this BuiltInParameter builtInParameter, string ruleString) => builtInParameter.Filter<FilterStringEquals>(ruleString);

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> that checks if the parameter value equals the specified string,
        /// and allows specifying whether the filter is inverted.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleString">The string value to compare against the parameter value.</param>
        /// <param name="inverted">
        /// If <c>true</c>, the filter will be inverted, selecting elements that do not match the rule; otherwise, it will select elements that match.
        /// </param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> that filters elements whose parameter value equals <paramref name="ruleString"/>,
        /// with optional inversion.
        /// </returns>
        public static ElementParameterFilter Filter(this BuiltInParameter builtInParameter, string ruleString, bool inverted) => builtInParameter.Filter<FilterStringEquals>(ruleString, inverted);

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> that checks if the parameter value equals the specified integer.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The integer value to compare against the parameter value.</param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> that filters elements whose parameter value equals <paramref name="ruleValue"/>.
        /// </returns>
        public static ElementParameterFilter Filter(this BuiltInParameter builtInParameter, int ruleValue) => builtInParameter.Filter<FilterNumericEquals>(ruleValue);

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> that checks if the parameter value equals the specified integer,
        /// and allows specifying whether the filter is inverted.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The integer value to compare against the parameter value.</param>
        /// <param name="inverted">
        /// If <c>true</c>, the filter will be inverted, selecting elements that do not match the rule; otherwise, it will select elements that match.
        /// </param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> that filters elements whose parameter value equals <paramref name="ruleValue"/>,
        /// with optional inversion.
        /// </returns>
        public static ElementParameterFilter Filter(this BuiltInParameter builtInParameter, int ruleValue, bool inverted) => builtInParameter.Filter<FilterNumericEquals>(ruleValue, inverted);

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> that checks if the parameter value equals the specified <see cref="Autodesk.Revit.DB.ElementId"/>.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The <see cref="Autodesk.Revit.DB.ElementId"/> value to compare against the parameter value.</param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> that filters elements whose parameter value equals <paramref name="ruleValue"/>.
        /// </returns>
        public static ElementParameterFilter Filter(this BuiltInParameter builtInParameter, ElementId ruleValue) => builtInParameter.Filter<FilterNumericEquals>(ruleValue);

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> that checks if the parameter value equals the specified <see cref="Autodesk.Revit.DB.ElementId"/>,
        /// and allows specifying whether the filter is inverted.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The <see cref="Autodesk.Revit.DB.ElementId"/> value to compare against the parameter value.</param>
        /// <param name="inverted">
        /// If <c>true</c>, the filter will be inverted, selecting elements that do not match the rule; otherwise, it will select elements that match.
        /// </param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> that filters elements whose parameter value equals <paramref name="ruleValue"/>,
        /// with optional inversion.
        /// </returns>
        public static ElementParameterFilter Filter(this BuiltInParameter builtInParameter, ElementId ruleValue, bool inverted) => builtInParameter.Filter<FilterNumericEquals>(ruleValue, inverted);

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> that checks if the parameter value equals the specified double.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The double value to compare against the parameter value.</param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> that filters elements whose parameter value equals <paramref name="ruleValue"/>.
        /// </returns>
        public static ElementParameterFilter Filter(this BuiltInParameter builtInParameter, double ruleValue) => builtInParameter.Filter<FilterNumericEquals>(ruleValue);

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> that checks if the parameter value equals the specified double,
        /// and allows specifying whether the filter is inverted.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The double value to compare against the parameter value.</param>
        /// <param name="inverted">
        /// If <c>true</c>, the filter will be inverted, selecting elements that do not match the rule; otherwise, it will select elements that match.
        /// </param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> that filters elements whose parameter value equals <paramref name="ruleValue"/>,
        /// with optional inversion.
        /// </returns>
        public static ElementParameterFilter Filter(this BuiltInParameter builtInParameter, double ruleValue, bool inverted) => builtInParameter.Filter<FilterNumericEquals>(ruleValue, inverted);

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> that checks if the parameter value equals the specified double within a given tolerance.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The double value to compare against the parameter value.</param>
        /// <param name="epsilon">The tolerance for the comparison.</param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> that filters elements whose parameter value equals <paramref name="ruleValue"/> within <paramref name="epsilon"/> tolerance.
        /// </returns>
        public static ElementParameterFilter Filter(this BuiltInParameter builtInParameter, double ruleValue, double epsilon) => builtInParameter.Filter<FilterNumericEquals>(ruleValue, epsilon);

        /// <summary>
        /// Creates an <see cref="ElementParameterFilter"/> that checks if the parameter value equals the specified double within a given tolerance and allows specifying whether the filter is inverted.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The double value to compare against the parameter value.</param>
        /// <param name="epsilon">The tolerance for the comparison.</param>
        /// <param name="inverted">
        /// If <c>true</c>, the filter will be inverted, selecting elements that do not match the rule; otherwise, it will select elements that match.
        /// </param>
        /// <returns>
        /// An <see cref="ElementParameterFilter"/> that filters elements whose parameter value equals <paramref name="ruleValue"/> within <paramref name="epsilon"/> tolerance, with optional inversion.
        /// </returns>
        public static ElementParameterFilter Filter(this BuiltInParameter builtInParameter, double ruleValue, double epsilon, bool inverted) => builtInParameter.Filter<FilterNumericEquals>(ruleValue, epsilon, inverted);
        #endregion

        #region Equals Rule
        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilterRule"/> that checks if the parameter value equals the specified string.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleString">The string value to compare against the parameter value.</param>
        /// <returns>
        /// A <see cref="Autodesk.Revit.DB.FilterRule"/> that evaluates whether the parameter value equals <paramref name="ruleString"/>.
        /// </returns>
        public static FilterStringRule Rule(this BuiltInParameter builtInParameter, string ruleString) => builtInParameter.Rule<FilterStringEquals>(ruleString);

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilterRule"/> that checks if the parameter value equals the specified integer.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The integer value to compare against the parameter value.</param>
        /// <returns>
        /// A <see cref="Autodesk.Revit.DB.FilterRule"/> that evaluates whether the parameter value equals <paramref name="ruleValue"/>.
        /// </returns>
        public static FilterIntegerRule Rule(this BuiltInParameter builtInParameter, int ruleValue) => builtInParameter.Rule<FilterNumericEquals>(ruleValue);

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilterRule"/> that checks if the parameter value equals the specified <see cref="Autodesk.Revit.DB.ElementId"/>.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The <see cref="Autodesk.Revit.DB.ElementId"/> value to compare against the parameter value.</param>
        /// <returns>
        /// A <see cref="Autodesk.Revit.DB.FilterRule"/> that evaluates whether the parameter value equals <paramref name="ruleValue"/>.
        /// </returns>
        public static FilterElementIdRule Rule(this BuiltInParameter builtInParameter, ElementId ruleValue) => builtInParameter.Rule<FilterNumericEquals>(ruleValue);

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilterRule"/> that checks if the parameter value equals the specified double.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The double value to compare against the parameter value.</param>
        /// <returns>
        /// A <see cref="Autodesk.Revit.DB.FilterRule"/> that evaluates whether the parameter value equals <paramref name="ruleValue"/>.
        /// </returns>
        public static FilterDoubleRule Rule(this BuiltInParameter builtInParameter, double ruleValue) => builtInParameter.Rule<FilterNumericEquals>(ruleValue);

        /// <summary>
        /// Creates a <see cref="Autodesk.Revit.DB.FilterRule"/> that checks if the parameter value equals the specified double within a given tolerance.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The double value to compare against the parameter value.</param>
        /// <param name="epsilon">The tolerance for the comparison.</param>
        /// <returns>
        /// A <see cref="Autodesk.Revit.DB.FilterRule"/> that evaluates whether the parameter value equals <paramref name="ruleValue"/> within <paramref name="epsilon"/> tolerance.
        /// </returns>
        public static FilterDoubleRule Rule(this BuiltInParameter builtInParameter, double ruleValue, double epsilon) => builtInParameter.Rule<FilterNumericEquals>(ruleValue, epsilon);
        #endregion
    }
}