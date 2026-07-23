using AT_AutomationtestStore.Core;
using Microsoft.Extensions.Configuration;

namespace AT_AutomationtestStore.Configuration
{
    public static class ConfigurationReader
    {
        private static readonly IConfigurationRoot Configuration =
        new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(
                "appsettings.json",
                optional: false,
                reloadOnChange: false)
            .Build();

        public static string BaseUrl =>
            GetRequiredString("BaseUrl");

        public static BrowserType Browser
        {
            get
            {
                string value = GetRequiredString(
                    "WebDriver:Browser");

                if (!Enum.TryParse(
                        value,
                        ignoreCase: true,
                        out BrowserType browser))
                {
                    throw new InvalidOperationException(
                        $"Unsupported browser in configuration: '{value}'.");
                }

                return browser;
            }
        }

        public static bool Headless =>
            Configuration.GetValue<bool>(
                "WebDriver:Headless");

        public static int ExplicitWaitSeconds =>
            Configuration.GetValue<int>(
                "WebDriver:ExplicitWaitSeconds");

        public static int PollingIntervalMilliseconds =>
            Configuration.GetValue<int>(
                "WebDriver:PollingIntervalMilliseconds");

        public static int PageLoadTimeoutSeconds =>
            Configuration.GetValue<int>(
                "WebDriver:PageLoadTimeoutSeconds");

        public static int ScriptTimeoutSeconds =>
            Configuration.GetValue<int>(
                "WebDriver:ScriptTimeoutSeconds");

        public static bool AcceptInsecureCertificates =>
            Configuration.GetValue<bool>(
                "WebDriver:AcceptInsecureCertificates");

        public static bool DisableNotifications =>
            Configuration.GetValue<bool>(
                "WebDriver:DisableNotifications");

        public static bool DisablePopupBlocking =>
            Configuration.GetValue<bool>(
                "WebDriver:DisablePopupBlocking");

        public static bool MaximizeWindow =>
            Configuration.GetValue<bool>(
                "WebDriver:Window:Maximize");

        public static int WindowWidth =>
            Configuration.GetValue<int>(
                "WebDriver:Window:Width");

        public static int WindowHeight =>
            Configuration.GetValue<int>(
                "WebDriver:Window:Height");

        private static string GetRequiredString(string key)
        {
            return Configuration[key]
                ?? throw new InvalidOperationException(
                    $"Configuration value '{key}' is missing.");
        }
    }
}
