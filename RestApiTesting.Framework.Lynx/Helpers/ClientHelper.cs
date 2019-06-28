using System;
using System.Dynamic;
using RestApiTesting.Framework.Lynx.Constants;
using RestSharp;

namespace RestApiTesting.Framework.Lynx.Helpers
{
    public class ClientHelper
    {
        public static void GetClient(ScenarioContext scenarioContext, string httpClientKey)
        {
            var uri = new Uri(ConfigurationHelper.TestApiUrl);
            var client = new RestClient(uri);
            scenarioContext.Add(httpClientKey, client);
        }

        public static void GetResponse(ScenarioContext scenarioContext, string requestType, RestClient client, string uriTemplate, ExpandoObject model, string responseKey)
        {
            var uri = scenarioContext.GetObjectValue<string>(uriTemplate);

            IRestResponse response;
            RestRequest request;

            switch (requestType)
            {
                case RequestType.Get:
                    request = new RestRequest(uri, Method.GET);
                    response = client.Get(request);
                    break;
                case RequestType.Delete:
                    request = new RestRequest(uri, Method.DELETE);
                    response = client.Delete(request);
                    break;
                case RequestType.Post:
                    request = new RestRequest(uri, Method.POST);
                    request.AddJsonBody(model);
                    response = client.Post(request);
                    break;
                case RequestType.Put:
                    request = new RestRequest(uri, Method.PUT);
                    request.AddJsonBody(model);
                    response = client.Put(request);
                    break;
                case RequestType.Patch:
                    request = new RestRequest(uri, Method.PUT);
                    request.AddJsonBody(model);
                    response = client.Patch(request);
                    break;
                default:
                    throw new NotImplementedException($"Request type: {requestType} is not implemented.");
            }

            scenarioContext.Add(responseKey, response);
        }
    }
}