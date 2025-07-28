using Autodesk.Revit.DB;
using NUnit.Framework;
using System.Linq;

namespace ricaun.Revit.DB.Tests
{
    public class RevitFilterExtensionTest
    {
        const double Epsilon = 1e-6;
        const BuiltInParameter builtInParameter = BuiltInParameter.ID_PARAM;

        [Test]
        public void RuleInverse()
        {
            var rule = builtInParameter.Rule(string.Empty);
            var inverse = rule.InverseRule();
            Assert.IsNotNull(inverse);

            Assert.IsAssignableFrom<FilterInverseRule>(inverse);
            Assert.IsAssignableFrom(rule.GetType(), inverse.GetInnerRule());
        }

        [Test]
        public void RuleIsNotNull()
        {
            var ruleString = builtInParameter.Rule(string.Empty);
            var ruleId = builtInParameter.Rule(ElementId.InvalidElementId);
            var ruleInteger = builtInParameter.Rule(0);
            var ruleDouble = builtInParameter.Rule(0.0);
            var ruleDoubleEpsilon = builtInParameter.Rule(0.0, Epsilon);

            Assert.IsNotNull(ruleString);
            Assert.IsNotNull(ruleId);
            Assert.IsNotNull(ruleInteger);
            Assert.IsNotNull(ruleDouble);
            Assert.IsNotNull(ruleDoubleEpsilon);
        }

        [Test]
        public void RuleIsAssignableFrom()
        {
            var ruleString = builtInParameter.Rule(string.Empty);
            var ruleId = builtInParameter.Rule(ElementId.InvalidElementId);
            var ruleInteger = builtInParameter.Rule(0);
            var ruleDouble = builtInParameter.Rule(0.0);
            var ruleDoubleEpsilon = builtInParameter.Rule(0.0, Epsilon);

            Assert.IsNotNull(ruleString);
            Assert.IsNotNull(ruleId);
            Assert.IsNotNull(ruleInteger);
            Assert.IsNotNull(ruleDouble);
            Assert.IsNotNull(ruleDoubleEpsilon);

            Assert.IsAssignableFrom(typeof(FilterStringRule), ruleString);
            Assert.IsAssignableFrom(typeof(FilterElementIdRule), ruleId);
            Assert.IsAssignableFrom(typeof(FilterIntegerRule), ruleInteger);
            Assert.IsAssignableFrom(typeof(FilterDoubleRule), ruleDouble);
            Assert.IsAssignableFrom(typeof(FilterDoubleRule), ruleDoubleEpsilon);

            Assert.IsAssignableFrom(typeof(FilterStringEquals), ruleString.GetEvaluator());
            Assert.IsAssignableFrom(typeof(FilterNumericEquals), ruleId.GetEvaluator());
            Assert.IsAssignableFrom(typeof(FilterNumericEquals), ruleInteger.GetEvaluator());
            Assert.IsAssignableFrom(typeof(FilterNumericEquals), ruleDouble.GetEvaluator());
            Assert.IsAssignableFrom(typeof(FilterNumericEquals), ruleDoubleEpsilon.GetEvaluator());
        }

        [Test]
        public void RuleIsAssignableFromString()
        {
            string value = string.Empty;

            var rule = builtInParameter.Rule(value);
            Assert.IsAssignableFrom<FilterStringEquals>(rule.GetEvaluator());

            rule = builtInParameter.Rule<FilterStringBeginsWith>(value);
            Assert.IsAssignableFrom<FilterStringBeginsWith>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterStringContains>(value);
            Assert.IsAssignableFrom<FilterStringContains>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterStringEndsWith>(value);
            Assert.IsAssignableFrom<FilterStringEndsWith>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterStringEquals>(value);
            Assert.IsAssignableFrom<FilterStringEquals>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterStringGreater>(value);
            Assert.IsAssignableFrom<FilterStringGreater>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterStringGreaterOrEqual>(value);
            Assert.IsAssignableFrom<FilterStringGreaterOrEqual>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterStringLess>(value);
            Assert.IsAssignableFrom<FilterStringLess>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterStringLessOrEqual>(value);
            Assert.IsAssignableFrom<FilterStringLessOrEqual>(rule.GetEvaluator());
        }

        [Test]
        public void RuleIsAssignableFromElementId()
        {
            var value = ElementId.InvalidElementId;

            var rule = builtInParameter.Rule(value);
            Assert.IsAssignableFrom<FilterNumericEquals>(rule.GetEvaluator());

            rule = builtInParameter.Rule<FilterNumericEquals>(value);
            Assert.IsAssignableFrom<FilterNumericEquals>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericGreater>(value);
            Assert.IsAssignableFrom<FilterNumericGreater>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericGreaterOrEqual>(value);
            Assert.IsAssignableFrom<FilterNumericGreaterOrEqual>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericLess>(value);
            Assert.IsAssignableFrom<FilterNumericLess>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericLessOrEqual>(value);
            Assert.IsAssignableFrom<FilterNumericLessOrEqual>(rule.GetEvaluator());
        }

        [Test]
        public void RuleIsAssignableFromInteger()
        {
            var value = 0;

            var rule = builtInParameter.Rule(value);
            Assert.IsAssignableFrom<FilterNumericEquals>(rule.GetEvaluator());

            rule = builtInParameter.Rule<FilterNumericEquals>(value);
            Assert.IsAssignableFrom<FilterNumericEquals>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericGreater>(value);
            Assert.IsAssignableFrom<FilterNumericGreater>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericGreaterOrEqual>(value);
            Assert.IsAssignableFrom<FilterNumericGreaterOrEqual>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericLess>(value);
            Assert.IsAssignableFrom<FilterNumericLess>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericLessOrEqual>(value);
            Assert.IsAssignableFrom<FilterNumericLessOrEqual>(rule.GetEvaluator());
        }

        [Test]
        public void RuleIsAssignableFromDouble()
        {
            var value = 0.0;

            var rule = builtInParameter.Rule(value);
            Assert.IsAssignableFrom<FilterNumericEquals>(rule.GetEvaluator());

            rule = builtInParameter.Rule<FilterNumericEquals>(value);
            Assert.IsAssignableFrom<FilterNumericEquals>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericGreater>(value);
            Assert.IsAssignableFrom<FilterNumericGreater>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericGreaterOrEqual>(value);
            Assert.IsAssignableFrom<FilterNumericGreaterOrEqual>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericLess>(value);
            Assert.IsAssignableFrom<FilterNumericLess>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericLessOrEqual>(value);
            Assert.IsAssignableFrom<FilterNumericLessOrEqual>(rule.GetEvaluator());

            rule = builtInParameter.Rule<FilterNumericEquals>(value, Epsilon);
            Assert.IsAssignableFrom<FilterNumericEquals>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericGreater>(value, Epsilon);
            Assert.IsAssignableFrom<FilterNumericGreater>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericGreaterOrEqual>(value, Epsilon);
            Assert.IsAssignableFrom<FilterNumericGreaterOrEqual>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericLess>(value, Epsilon);
            Assert.IsAssignableFrom<FilterNumericLess>(rule.GetEvaluator());
            rule = builtInParameter.Rule<FilterNumericLessOrEqual>(value, Epsilon);
            Assert.IsAssignableFrom<FilterNumericLessOrEqual>(rule.GetEvaluator());
        }

        [Test]
        public void FilterIsNotNull()
        {
            var filterString = builtInParameter.Filter(string.Empty);
            var filterId = builtInParameter.Filter(ElementId.InvalidElementId);
            var filterInteger = builtInParameter.Filter(0);
            var filterDouble = builtInParameter.Filter(0.0);
            var filterDoubleEpsilon = builtInParameter.Filter(0.0, Epsilon);

            Assert.IsNotNull(filterString);
            Assert.IsNotNull(filterId);
            Assert.IsNotNull(filterInteger);
            Assert.IsNotNull(filterDouble);
            Assert.IsNotNull(filterDoubleEpsilon);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void FilterIsInverted(bool inverted)
        {
            var filterString = builtInParameter.Filter(string.Empty, inverted);
            var filterId = builtInParameter.Filter(ElementId.InvalidElementId, inverted);
            var filterInteger = builtInParameter.Filter(0, inverted);
            var filterDouble = builtInParameter.Filter(0.0, inverted);
            var filterDoubleEpsilon = builtInParameter.Filter(0.0, Epsilon, inverted);

            Assert.IsNotNull(filterString);
            Assert.IsNotNull(filterId);
            Assert.IsNotNull(filterInteger);
            Assert.IsNotNull(filterDouble);
            Assert.IsNotNull(filterDoubleEpsilon);

            Assert.AreEqual(inverted, filterString.Inverted);
            Assert.AreEqual(inverted, filterId.Inverted);
            Assert.AreEqual(inverted, filterInteger.Inverted);
            Assert.AreEqual(inverted, filterDouble.Inverted);
            Assert.AreEqual(inverted, filterDoubleEpsilon.Inverted);
        }

        [Test]
        public void FilterIsAssignableFrom()
        {
            var filterString = builtInParameter.Filter(string.Empty);
            var filterId = builtInParameter.Filter(ElementId.InvalidElementId);
            var filterInteger = builtInParameter.Filter(0);
            var filterDouble = builtInParameter.Filter(0.0);
            var filterDoubleEpsilon = builtInParameter.Filter(0.0, Epsilon);

            Assert.IsAssignableFrom<ElementParameterFilter>(filterString);
            Assert.IsAssignableFrom<ElementParameterFilter>(filterId);
            Assert.IsAssignableFrom<ElementParameterFilter>(filterInteger);
            Assert.IsAssignableFrom<ElementParameterFilter>(filterDouble);
            Assert.IsAssignableFrom<ElementParameterFilter>(filterDoubleEpsilon);

            AssertParameterFilter<FilterStringEquals>(filterString);
            AssertParameterFilter<FilterNumericEquals>(filterId);
            AssertParameterFilter<FilterNumericEquals>(filterInteger);
            AssertParameterFilter<FilterNumericEquals>(filterDouble);
            AssertParameterFilter<FilterNumericEquals>(filterDoubleEpsilon);
        }

        [Test]
        public void FilterIsAssignableFromString()
        {
            string value = string.Empty;
            bool inverted = false;

            var filter = builtInParameter.Filter(value);
            AssertParameterFilter<FilterStringEquals>(filter);

            filter = builtInParameter.Filter<FilterStringBeginsWith>(value, inverted);
            AssertParameterFilter<FilterStringBeginsWith>(filter);
            filter = builtInParameter.Filter<FilterStringContains>(value);
            AssertParameterFilter<FilterStringContains>(filter);
            filter = builtInParameter.Filter<FilterStringEndsWith>(value);
            AssertParameterFilter<FilterStringEndsWith>(filter);
            filter = builtInParameter.Filter<FilterStringEquals>(value);
            AssertParameterFilter<FilterStringEquals>(filter);
            filter = builtInParameter.Filter<FilterStringGreater>(value);
            AssertParameterFilter<FilterStringGreater>(filter);
            filter = builtInParameter.Filter<FilterStringGreaterOrEqual>(value);
            AssertParameterFilter<FilterStringGreaterOrEqual>(filter);
            filter = builtInParameter.Filter<FilterStringLess>(value);
            AssertParameterFilter<FilterStringLess>(filter);
            filter = builtInParameter.Filter<FilterStringLessOrEqual>(value);
            AssertParameterFilter<FilterStringLessOrEqual>(filter);
        }

        [Test]
        public void FilterIsAssignableFromElementId()
        {
            var value = ElementId.InvalidElementId;
            bool inverted = false;

            var filter = builtInParameter.Filter(value);
            AssertParameterFilter<FilterNumericEquals>(filter);

            filter = builtInParameter.Filter<FilterNumericEquals>(value, inverted);
            AssertParameterFilter<FilterNumericEquals>(filter);
            filter = builtInParameter.Filter<FilterNumericGreater>(value);
            AssertParameterFilter<FilterNumericGreater>(filter);
            filter = builtInParameter.Filter<FilterNumericGreaterOrEqual>(value);
            AssertParameterFilter<FilterNumericGreaterOrEqual>(filter);
            filter = builtInParameter.Filter<FilterNumericLess>(value);
            AssertParameterFilter<FilterNumericLess>(filter);
            filter = builtInParameter.Filter<FilterNumericLessOrEqual>(value);
            AssertParameterFilter<FilterNumericLessOrEqual>(filter);
        }

        [Test]
        public void FilterIsAssignableFromInteger()
        {
            var value = 0;
            bool inverted = false;

            var filter = builtInParameter.Filter(value);
            AssertParameterFilter<FilterNumericEquals>(filter);

            filter = builtInParameter.Filter<FilterNumericEquals>(value, inverted);
            AssertParameterFilter<FilterNumericEquals>(filter);
            filter = builtInParameter.Filter<FilterNumericGreater>(value);
            AssertParameterFilter<FilterNumericGreater>(filter);
            filter = builtInParameter.Filter<FilterNumericGreaterOrEqual>(value);
            AssertParameterFilter<FilterNumericGreaterOrEqual>(filter);
            filter = builtInParameter.Filter<FilterNumericLess>(value);
            AssertParameterFilter<FilterNumericLess>(filter);
            filter = builtInParameter.Filter<FilterNumericLessOrEqual>(value);
            AssertParameterFilter<FilterNumericLessOrEqual>(filter);
        }

        [Test]
        public void FilterIsAssignableFromDouble()
        {
            var value = 0.0;
            bool inverted = false;

            var filter = builtInParameter.Filter(value);
            AssertParameterFilter<FilterNumericEquals>(filter);

            filter = builtInParameter.Filter<FilterNumericEquals>(value, inverted);
            AssertParameterFilter<FilterNumericEquals>(filter);
            filter = builtInParameter.Filter<FilterNumericGreater>(value);
            AssertParameterFilter<FilterNumericGreater>(filter);
            filter = builtInParameter.Filter<FilterNumericGreaterOrEqual>(value);
            AssertParameterFilter<FilterNumericGreaterOrEqual>(filter);
            filter = builtInParameter.Filter<FilterNumericLess>(value);
            AssertParameterFilter<FilterNumericLess>(filter);
            filter = builtInParameter.Filter<FilterNumericLessOrEqual>(value);
            AssertParameterFilter<FilterNumericLessOrEqual>(filter);

            filter = builtInParameter.Filter<FilterNumericEquals>(value, Epsilon);
            AssertParameterFilter<FilterNumericEquals>(filter);
            filter = builtInParameter.Filter<FilterNumericGreater>(value, Epsilon);
            AssertParameterFilter<FilterNumericGreater>(filter);
            filter = builtInParameter.Filter<FilterNumericGreaterOrEqual>(value, Epsilon);
            AssertParameterFilter<FilterNumericGreaterOrEqual>(filter);
            filter = builtInParameter.Filter<FilterNumericLess>(value, Epsilon);
            AssertParameterFilter<FilterNumericLess>(filter);
            filter = builtInParameter.Filter<FilterNumericLessOrEqual>(value, Epsilon);
            AssertParameterFilter<FilterNumericLessOrEqual>(filter);
        }

        private static void AssertParameterFilter<TRuleEvaluator>(ElementParameterFilter filter)
        {
            object GetEvaluator(FilterRule rule)
            {
                switch (rule)
                {
                    case FilterStringRule r:
                        return r.GetEvaluator();
                    case FilterElementIdRule r:
                        return r.GetEvaluator();
                    case FilterIntegerRule r:
                        return r.GetEvaluator();
                    case FilterDoubleRule r:
                        return r.GetEvaluator();
                }
                return null;
            }

            Assert.IsNotNull(filter);
            var firstRule = filter.GetRules().FirstOrDefault();
            var evaluator = GetEvaluator(firstRule);
            Assert.IsAssignableFrom<TRuleEvaluator>(evaluator);
        }

#if !NET47
        [Test]
        public void RuleHasValue()
        {
            var rule = builtInParameter.RuleHasValue();
            Assert.IsNotNull(rule);
            Assert.IsAssignableFrom<HasValueFilterRule>(rule);
        }

        [Test]
        public void RuleHasNoValue()
        {
            var rule = builtInParameter.RuleHasNoValue();
            Assert.IsNotNull(rule);
            Assert.IsAssignableFrom<HasNoValueFilterRule>(rule);
        }

        [Test]
        public void FilterHasValue()
        {
            var filter = builtInParameter.FilterHasValue();
            Assert.IsNotNull(filter);
            Assert.IsAssignableFrom<ElementParameterFilter>(filter);
            Assert.IsAssignableFrom<HasValueFilterRule>(filter.GetRules().FirstOrDefault());
        }

        [Test]
        public void FilterHasNoValue()
        {
            var filter = builtInParameter.FilterHasNoValue();
            Assert.IsNotNull(filter);
            Assert.IsAssignableFrom<ElementParameterFilter>(filter);
            Assert.IsAssignableFrom<HasNoValueFilterRule>(filter.GetRules().FirstOrDefault());
        }
#endif
    }
}
