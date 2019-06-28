using System.Dynamic;
using Newtonsoft.Json;
using RestSharp;

namespace RestApiTesting.Framework.Lynx.Helpers
{
    public class InputHelper
    {
        public static void AddToScenarioContext(ScenarioContext scenarioContext, string value, string valueKey)
        {
            var parsedValue = scenarioContext.GetObjectValue<object>(value);
            scenarioContext.Add(valueKey, parsedValue);
        }

        public static void AddContentToScenarioContext(ScenarioContext scenarioContext, string contentKey, string responseMessageKey)
        {
            var response = scenarioContext.GetObjectValue<RestResponse>(responseMessageKey);
            var content = JsonConvert.DeserializeObject<ExpandoObject>(response.Content);
            scenarioContext.Add(contentKey, content);
        }
    }
}
