using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT_AutomationtestStore.Core
{
    public static class DriverSingleton
    {
        private static ThreadLocal<IWebDriver?> instance = new();

        public static IWebDriver Instance
        {
            get
            {
                return instance.Value
                    ?? throw new InvalidOperationException(
                        "DriverSingleton is not initialized.");
            }
        }
        public static void Initialize(BrowserType browser)
        {
            if (instance.Value is not null)
            {
                throw new InvalidOperationException(
                    "DriverSingleton has already been initialized for the current thread.");
            }

            instance.Value = BrowserFactory.Create(browser);
        }
        public static void Quit()
        {
            var driver = instance.Value;
            if (driver is null)
            {
                return;
            }

            try
            {
                driver.Quit();

            }
            finally
            {
                driver.Dispose();
                instance.Value = null;
            }
        }
    }
}
