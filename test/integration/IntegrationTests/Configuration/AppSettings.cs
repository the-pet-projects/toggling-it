namespace IntegrationTests.Configuration
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;

    public class AppSettings
    {
        public string ApiEndpoint { get; set; }

        public static AppSettings Current;

        static AppSettings()
        {
            var assembly = typeof(AssemblyInitialize).GetTypeInfo().Assembly;
            var fileName = "IntegrationTests.appsettings.json";
            using (var stream = assembly.GetManifestResourceStream(fileName))
            {
                var jsonString = new StreamReader(stream).ReadToEnd();
                var kvpList = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

                var builder = new ConfigurationBuilder()
                    .AddInMemoryCollection(kvpList)
                    .AddEnvironmentVariables();
                AppSettings.Current = builder.Build().Get<AppSettings>();
            }
        }
    }
}