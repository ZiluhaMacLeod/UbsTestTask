using System;
using Microsoft.Extensions.Configuration;
using UbsTestTask.Constants.Enums;

namespace UbsTestTask.Constants.Constants
{
    public static class TestSettings
    {
        static TestSettings()
        {
            SetDefaultValues();
        }

        public static IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();
        public static Browsers Browser { get; set; }
        public static string UbsGlobalLanguage { get; set; }
        public static string UbsGlobalBaseUrl { get; set; }
        public static string UbsGlobalBaseUrlBase { get; set; }
        public static int DefaultTimeoutSeconds { get; set; }
        public static int DefaultPollingIntervalMilliseconds { get; set; }

        public static void SetDefaultValues()
        {
            Browser = Enum.Parse<Browsers>(TestConfiguration["Settings:Common:Browser"]);
            UbsGlobalLanguage = TestConfiguration["Settings:Common:UbsGlobalLanguage"];
            UbsGlobalBaseUrlBase = TestConfiguration["Settings:Common:UbsGlobalBaseUrl"];
            UbsGlobalBaseUrl = string.Format(UbsGlobalBaseUrlBase, UbsGlobalLanguage);
            DefaultTimeoutSeconds = int.Parse(TestConfiguration["Settings:Common:TimeoutSeconds"]);
            DefaultPollingIntervalMilliseconds = int.Parse(TestConfiguration["Settings:Common:PollingIntervalMilliseconds"]);
        }
    }
}
