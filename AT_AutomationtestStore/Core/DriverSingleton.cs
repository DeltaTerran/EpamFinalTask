using OpenQA.Selenium;

namespace AT_AutomationtestStore.Core
{
    public static class DriverSingleton
    {
        private static readonly ThreadLocal<IWebDriver?> InstanceValue = new();

        public static IWebDriver Instance
        {
            get
            {
                return InstanceValue.Value
                    ?? throw new InvalidOperationException(
                        "DriverSingleton is not initialized.");
            }
        }

        public static void Initialize(BrowserType browser)
        {
            if (InstanceValue.Value is not null)
            {
                throw new InvalidOperationException(
                    "DriverSingleton has already been initialized for the current thread.");
            }

            InstanceValue.Value = BrowserFactory.Create(browser);
        }

        public static void Quit()
        {
            var driver = InstanceValue.Value;
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
                InstanceValue.Value = null;
            }
        }
    }
}
