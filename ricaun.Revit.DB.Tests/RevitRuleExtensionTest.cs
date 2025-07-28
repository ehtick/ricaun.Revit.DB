using Autodesk.Revit.DB;
using NUnit.Framework;

namespace ricaun.Revit.DB.Tests
{
    public class RevitRuleExtensionTest
    {
        FilterRule rule = new FilterCategoryRule(new[] { ElementId.InvalidElementId });

        [Test]
        public void RuleToFilter()
        {
            var filter = rule.Filter();
            var filterInverted = rule.Filter(true);

            Assert.IsFalse(filter.Inverted);
            Assert.IsTrue(filterInverted.Inverted);

            var filters = new[] { rule, rule }.Filter();
            var filtersInverted = new[] { rule, rule }.Filter(true);

            Assert.IsFalse(filter.Inverted);
            Assert.IsTrue(filterInverted.Inverted);
        }

        [Test]
        public void RuleInverse()
        {
            var inverse = rule.InverseRule();
            Assert.IsNotNull(inverse);

            Assert.IsAssignableFrom<FilterInverseRule>(inverse);
            Assert.IsAssignableFrom(rule.GetType(), inverse.GetInnerRule());
        }

        [Test]
        public void RuleEvaluator()
        {
            new FilterStringEquals().Rule(ElementId.InvalidElementId, string.Empty);
            new FilterNumericEquals().Rule(ElementId.InvalidElementId, 0);
            new FilterNumericEquals().Rule(ElementId.InvalidElementId, 0.0);
            new FilterNumericEquals().Rule(ElementId.InvalidElementId, 0.0, 0.0);

            new FilterStringEquals().Rule(BuiltInParameter.INVALID, string.Empty);
            new FilterNumericEquals().Rule(BuiltInParameter.INVALID, 0);
            new FilterNumericEquals().Rule(BuiltInParameter.INVALID, 0.0);
            new FilterNumericEquals().Rule(BuiltInParameter.INVALID, 0.0, 0.0);
        }
    }
}
