using Xunit.Gherkin.Quick;
using RestApiTesting.Framework.Lynx.Helpers;

public sealed partial class GetPosts
{

    [And(@"I get the content ""(.*)"" of the response ""(.*)""")]
    public void WhenIGetTheContentOfTheResponse(string contentKey, string responseMessageKey)
    {
        InputHelper.AddContentToScenarioContext(ScenarioContext, contentKey, responseMessageKey);
    }
}
