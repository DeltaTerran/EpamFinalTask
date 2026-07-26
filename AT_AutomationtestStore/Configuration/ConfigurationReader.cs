namespace AT_AutomationtestStore.Configuration
{
    using AT_AutomationtestStore.Core;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Provides centralized access to application and WebDriver configuration
    /// values defined in the appsettings.json file.
    /// </summary>
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

        /// <summary>
        /// Gets the base URL of the application under test.
        /// </summary>
        public static string BaseUrl =>
            GetRequiredString("BaseUrl");

        /// <summary>
        /// Gets the browser type configured for WebDriver execution.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the configured browser value is missing
        /// or cannot be converted to a supported <see cref="BrowserType"/>.
        /// </exception>
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

        /// <summary>
        /// Gets a value indicating whether the browser should run
        /// in headless mode.
        /// </summary>
        public static bool Headless =>
            Configuration.GetValue<bool>(
                "WebDriver:Headless");

        /// <summary>
        /// Gets the explicit wait timeout, in seconds.
        /// </summary>
        public static int ExplicitWaitSeconds =>
            Configuration.GetValue<int>(
                "WebDriver:ExplicitWaitSeconds");

        /// <summary>
        /// Gets the polling interval, in milliseconds, used by explicit waits.
        /// </summary>
        public static int PollingIntervalMilliseconds =>
            Configuration.GetValue<int>(
                "WebDriver:PollingIntervalMilliseconds");

        /// <summary>
        /// Gets the page load timeout, in seconds.
        /// </summary>
        public static int PageLoadTimeoutSeconds =>
            Configuration.GetValue<int>(
                "WebDriver:PageLoadTimeoutSeconds");

        /// <summary>
        /// Gets the asynchronous JavaScript execution timeout, in seconds.
        /// </summary>
        public static int ScriptTimeoutSeconds =>
            Configuration.GetValue<int>(
                "WebDriver:ScriptTimeoutSeconds");

        /// <summary>
        /// Gets a value indicating whether WebDriver should accept
        /// insecure SSL certificates.
        /// </summary>
        public static bool AcceptInsecureCertificates =>
            Configuration.GetValue<bool>(
                "WebDriver:AcceptInsecureCertificates");

        /// <summary>
        /// Gets a value indicating whether browser notifications
        /// should be disabled.
        /// </summary>
        public static bool DisableNotifications =>
            Configuration.GetValue<bool>(
                "WebDriver:DisableNotifications");

        /// <summary>
        /// Gets a value indicating whether browser popup blocking
        /// should be disabled.
        /// </summary>
        public static bool DisablePopupBlocking =>
            Configuration.GetValue<bool>(
                "WebDriver:DisablePopupBlocking");

        /// <summary>
        /// Gets a value indicating whether the browser window
        /// should be maximized after startup.
        /// </summary>
        public static bool MaximizeWindow =>
            Configuration.GetValue<bool>(
                "WebDriver:Window:Maximize");

        /// <summary>
        /// Gets the configured browser window width, in pixels.
        /// </summary>
        public static int WindowWidth =>
            Configuration.GetValue<int>(
                "WebDriver:Window:Width");

        /// <summary>
        /// Gets the configured browser window height, in pixels.
        /// </summary>
        public static int WindowHeight =>
            Configuration.GetValue<int>(
                "WebDriver:Window:Height");

        /// <summary>
        /// Gets a required string value from the application configuration.
        /// </summary>
        /// <param name="key">
        /// The configuration key identifying the required value.
        /// </param>
        /// <returns>
        /// The configuration value associated with the specified key.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the specified configuration value is missing.
        /// </exception>
        private static string GetRequiredString(string key)
        {
            return Configuration[key]
                ?? throw new InvalidOperationException(
                    $"Configuration value '{key}' is missing.");
        }
    }
}
