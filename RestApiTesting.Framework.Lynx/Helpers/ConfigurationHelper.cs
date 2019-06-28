using System.IO;
using Microsoft.Extensions.Configuration;

namespace RestApiTesting.Framework.Lynx.Helpers
{
    public class ConfigurationHelper
    {
        public static IConfigurationRoot ConfigurationRoot { get; private set; }

        public static string TestApiUrl => ConfigurationRoot[nameof(TestApiUrl)];

        public static void BuildConfiguration()
        {
            if (ConfigurationRoot != null)
            {
                return;
            }

            IConfigurationBuilder configbuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", false)
                .AddEnvironmentVariables();
            ConfigurationRoot = configbuilder.Build();
        }
    }
}