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
        /// <returns>A <see cref="FilterRule"/> that checks for no value.</returns>
        public static FilterRule RuleHasNoValue(this BuiltInParameter builtInParameter)
        {
            return new HasNoValueFilterRule(new ElementId(builtInParameter));
        }

        /// <summary>
        /// Creates a filter rule that checks if the parameter has a value.
        /// </summary>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <returns>A <see cref="FilterRule"/> that checks for a value.</returns>
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
        /// <returns>A <see cref="FilterRule"/> based on the string evaluator.</returns>
        public static FilterRule Rule<T>(this BuiltInParameter builtInParameter, string ruleString) where T : FilterStringRuleEvaluator, new()
        {
            return new T().Rule(builtInParameter, ruleString);
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
        /// Creates a filter rule using a numeric-based evaluator with an <see cref="Autodesk.Revit.DB.ElementId"/> value.
        /// </summary>
        /// <typeparam name="T">The type of the numeric rule evaluator.</typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The <see cref="Autodesk.Revit.DB.ElementId"/> value to evaluate.</param>
        /// <returns>A <see cref="FilterRule"/> based on the numeric evaluator.</returns>
        public static FilterRule Rule<T>(this BuiltInParameter builtInParameter, ElementId ruleValue) where T : FilterNumericRuleEvaluator, new()
        {
            return new T().Rule(builtInParameter, ruleValue);
        }

        /// <summary>
        /// Creates a filter rule using a numeric-based evaluator with an integer value.
        /// </summary>
        /// <typeparam name="T">The type of the numeric rule evaluator.</typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The integer value to evaluate.</param>
        /// <returns>A <see cref="FilterRule"/> based on the numeric evaluator.</returns>
        public static FilterRule Rule<T>(this BuiltInParameter builtInParameter, int ruleValue) where T : FilterNumericRuleEvaluator, new()
        {
            return new T().Rule(builtInParameter, ruleValue);
        }

        /// <summary>
        /// Creates a filter rule using a numeric-based evaluator with a double value.
        /// </summary>
        /// <typeparam name="T">The type of the numeric rule evaluator.</typeparam>
        /// <param name="builtInParameter">The built-in parameter to check.</param>
        /// <param name="ruleValue">The double value to evaluate.</param>
        /// <returns>A <see cref="FilterRule"/> based on the numeric evaluator.</returns>
        public static FilterRule Rule<T>(this BuiltInParameter builtInParameter, double ruleValue) where T : FilterNumericRuleEvaluator, new()
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
        /// <returns>A <see cref="FilterRule"/> based on the numeric evaluator.</returns>
        public static FilterRule Rule<T>(this BuiltInParameter builtInParameter, double ruleValue, double epsilon) where T : FilterNumericRuleEvaluator, new()
        {
            return new T().Rule(builtInParameter, ruleValue, epsilon);
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
    }
}