using Xunit.Gherkin.Quick;
using System.Dynamic;
using RestApiTesting.Framework.Lynx.Helpers;
using RestSharp;

public sealed partial class UpdatePosts
{
    [Given(@"I have a client ""(.*)""")]
    public void GivenIHaveAClientWithANon_AuthenticatedUser(string httpClientKey)
    {
        ClientHelper.GetClient(ScenarioContext, httpClientKey);
    }

    [When(@"I send a ""(.*)"" request to ""(.*)"" with model ""(.*)"" using client ""(.*)"" and get the response ""(.*)""")]
    public void WhenISendARequestToWithModelUsingClientAndGetTheResponse(string apiRequestType, string uriTemplate, string modelKey, string clientKey, string responseKey)
    {
        var model = ScenarioContext.GetObjectValue<ExpandoObject>(modelKey);
        var client = ScenarioContext.GetObjectValue<RestClient>(clientKey);
        ClientHelper.GetResponse(ScenarioContext, apiRequestType, client, uriTemplate, model, responseKey);
    }
}
