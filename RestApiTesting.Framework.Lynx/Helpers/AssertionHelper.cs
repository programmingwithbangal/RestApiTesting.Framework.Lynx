using System.Dynamic;
using FluentAssertions;
using Gherkin.Ast;

namespace RestApiTesting.Framework.Lynx.Helpers
{
    public class AssertionHelper
    {
        public static void AssertModelMatchTable(ScenarioContext scenarioContext, string actualModelKey, DataTable dataTable)
        {
            var actualModel = scenarioContext.GetObjectValue<ExpandoObject>(actualModelKey);
            var expectedModel = TransformationHelper.GetExpandoObject(scenarioContext, dataTable);
            actualModel.Should().BeEquivalentTo(expectedModel);
        }

        public static void AssertStrings(string actual, string expected)
        {
            actual.Should().Be(expected);
        }
    }
}