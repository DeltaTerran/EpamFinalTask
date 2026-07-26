namespace AT_AutomationtestStore.Core
{
    using AT_AutomationtestStore.Configuration;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;

    /// <summary>
    /// Provides factory methods for creating and configuring WebDriver
    /// instances for supported browsers.
    /// </summary>
    public static class BrowserFactory
    {
        /// <summary>
        /// Creates and configures a WebDriver instance for the specified browser.
        /// </summary>
        /// <param name="browser">
        /// The browser type for which the WebDriver instance should be created.
        /// </param>
        /// <returns>
        /// A configured <see cref="IWebDriver"/> instance for the specified browser.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the specified browser type is not supported.
        /// </exception>
        public static IWebDriver Create(BrowserType browser)
        {
            IWebDriver driver = browser switch
            {
                BrowserType.Chrome => CreateChrome(),
                BrowserType.FireFox => CreateFirefox(),

                _ => throw new ArgumentOutOfRangeException(
                    nameof(browser),
                    browser,
                    "Unsupported browser."),
            };

            ConfigurateDriver(driver);
            return driver;
        }

        /// <summary>
        /// Creates a Chrome WebDriver instance using the configured
        /// Chrome-specific browser options.
        /// </summary>
        /// <returns>
        /// A new <see cref="ChromeDriver"/> instance.
        /// </returns>
        private static IWebDriver CreateChrome()
        {
            var options = new ChromeOptions
            {
                AcceptInsecureCertificates =
                ConfigurationReader.AcceptInsecureCertificates,
            };

            if (ConfigurationReader.Headless)
            {
                options.AddArgument("--headless=new");
            }

            if (ConfigurationReader.DisableNotifications)
            {
                options.AddArgument("--disable-notifications");
            }

            if (ConfigurationReader.DisablePopupBlocking)
            {
                options.AddArgument("--disable-popup-blocking");
            }

            if (!ConfigurationReader.MaximizeWindow)
            {
                options.AddArgument(
                    $"--window-size={ConfigurationReader.WindowWidth}," +
                    $"{ConfigurationReader.WindowHeight}");
            }

            return new ChromeDriver(options);
        }

        /// <summary>
        /// Creates a Firefox WebDriver instance using the configured
        /// Firefox-specific browser options.
        /// </summary>
        /// <returns>
        /// A new <see cref="FirefoxDriver"/> instance.
        /// </returns>
        private static IWebDriver CreateFirefox()
        {
            var options = new FirefoxOptions
            {
                AcceptInsecureCertificates =
                ConfigurationReader.AcceptInsecureCertificates,
            };

            if (ConfigurationReader.Headless)
            {
                options.AddArgument("-headless");
            }

            return new FirefoxDriver(options);
        }

        /// <summary>
        /// Applies common WebDriver settings, including timeouts
        /// and browser window configuration.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver instance to configure.
        /// </param>
        private static void ConfigurateDriver(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait =
            TimeSpan.Zero;

            driver.Manage().Timeouts().PageLoad =
                TimeSpan.FromSeconds(
                    ConfigurationReader.PageLoadTimeoutSeconds);

            driver.Manage().Timeouts().AsynchronousJavaScript =
                TimeSpan.FromSeconds(
                    ConfigurationReader.ScriptTimeoutSeconds);

            if (ConfigurationReader.MaximizeWindow)
            {
                driver.Manage().Window.Maximize();
            }
            else
            {
                driver.Manage().Window.Size =
                    new System.Drawing.Size(
                        ConfigurationReader.WindowWidth,
                        ConfigurationReader.WindowHeight);
            }
        }
    }
}
