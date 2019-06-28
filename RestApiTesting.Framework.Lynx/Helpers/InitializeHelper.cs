namespace RestApiTesting.Framework.Lynx.Helpers
{
    public class InitializeHelper
    {
        public static void AddSetupToScenarioContext(ScenarioContext scenarioContext)
        {
            ConfigurationHelper.BuildConfiguration();

            scenarioContext.Add(nameof(ConfigurationHelper.TestApiUrl), ConfigurationHelper.TestApiUrl);
        }
    }
}