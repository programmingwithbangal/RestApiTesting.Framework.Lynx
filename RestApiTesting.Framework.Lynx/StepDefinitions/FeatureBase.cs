using System;
using RestApiTesting.Framework.Lynx.Helpers;
using Xunit.Gherkin.Quick;

namespace RestApiTesting.Framework.Lynx.StepDefinitions
{
    public abstract class FeatureBase : Feature, IDisposable
    {
        public ScenarioContext ScenarioContext = new ScenarioContext();

        protected FeatureBase()
        {
            InitializeHelper.AddSetupToScenarioContext(ScenarioContext);
        }

        public void Dispose()
        {
            foreach (object value in ScenarioContext.GetValues())
            {
                if (value is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}