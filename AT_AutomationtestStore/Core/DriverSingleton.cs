using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT_AutomationtestStore.Core
{
    public static class DriverSingleton
    {
        private static IWebDriver? instance;

        public static IWebDriver Instance
        {
            get
            {
                return instance
                    ?? throw new InvalidOperationException(
                        "DriverSingleton is not initialized.");
            }
        }
        public static void Initialize(BrowserType browser)
        {
                if (instance is not null)
                {
                    throw new InvalidOperationException(
                        "DriverSingleton has already been initialized.");
                }

                instance = BrowserFactory.Create(browser);
        }
        public static void Quit()
        {
            if (instance is null)
            {
                return;
            }

            try
            {
                instance.Quit();
            }
            finally
            {
                instance.Dispose();
                instance = null;
            }
        }
    }
}
