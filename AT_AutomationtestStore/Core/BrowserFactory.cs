using AT_AutomationtestStore.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT_AutomationtestStore.Core
{
    public static class BrowserFactory
    {
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
