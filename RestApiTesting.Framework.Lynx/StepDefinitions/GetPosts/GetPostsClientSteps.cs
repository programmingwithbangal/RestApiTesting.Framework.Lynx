using Xunit.Gherkin.Quick;
using RestApiTesting.Framework.Lynx.Helpers;
using RestSharp;

public sealed partial class GetPosts
{
    [Given(@"I have a client ""(.*)""")]
    public void GivenIHaveAClient(string httpClientKey)
    {
        ClientHelper.GetClient(ScenarioContext, httpClientKey);
    }

    [When(@"I send a ""(.*)"" request to ""(.*)"" using client ""(.*)"" and get the response ""(.*)""")]
    public void WhenISendARequestToUsingClientAndGetTheResponseAsync(string apiRequestType, string uriTemplate, string clientKey, string responseKey)
    {
        var client = ScenarioContext.GetObjectValue<RestClient>(clientKey);
        ClientHelper.GetResponse(ScenarioContext, apiRequestType, client, uriTemplate, null, responseKey);
    }
}
