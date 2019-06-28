using Xunit.Gherkin.Quick;
using RestApiTesting.Framework.Lynx.Helpers;
using Gherkin.Ast;
using RestSharp;

public sealed partial class GetPosts
{
    [Then(@"the response ""(.*)"" should have the status code ""(.*)""")]
    public void ThenTheResponseShouldHaveTheStatusCode(string responseKey, string expectedStatusCode)
    {
        var response = ScenarioContext.GetObjectValue<RestResponse>(responseKey);
        AssertionHelper.AssertStrings(response.StatusCode.ToString(), expectedStatusCode);
    }

    [And(@"the model ""(.*)"" should match the following values:")]
    public void ThenTheResponseShouldMatchTheFollowingValues(string actualModelKey, DataTable dataTable)
    {
        AssertionHelper.AssertModelMatchTable(ScenarioContext, actualModelKey, dataTable);
    }
}