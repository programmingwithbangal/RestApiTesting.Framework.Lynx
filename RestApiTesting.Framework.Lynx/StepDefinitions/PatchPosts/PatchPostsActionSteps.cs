using Xunit.Gherkin.Quick;
using Gherkin.Ast;
using RestApiTesting.Framework.Lynx.Helpers;

public sealed partial class PatchPosts
{
    [Given(@"I have a model ""(.*)"" with the following values:")]
    public void GivenIHaveAModelWithTheFollowingValues(string modelKey, DataTable dataTable)
    {
        TransformationHelper.ModelFromDataTable(ScenarioContext, modelKey, dataTable);
    }

    [And(@"I get the content ""(.*)"" of the response ""(.*)""")]
    public void WhenIGetTheContentOfTheResponse(string contentKey, string responseMessageKey)
    {
        InputHelper.AddContentToScenarioContext(ScenarioContext, contentKey, responseMessageKey);
    }
}