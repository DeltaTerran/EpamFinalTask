namespace AT_AutomationtestStore.Core
{
    using OpenQA.Selenium;

    /// <summary>
    /// Provides thread-local access to WebDriver instances.
    /// Ensures that each test execution thread uses its own WebDriver instance,
    /// allowing tests to run safely in parallel.
    /// </summary>
    public static class DriverSingleton
    {
        private static readonly ThreadLocal<IWebDriver?> InstanceValue = new ();

        /// <summary>
        /// Gets the WebDriver instance associated with the current thread.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the WebDriver has not been initialized
        /// for the current thread.
        /// </exception>
        public static IWebDriver Instance
        {
            get
            {
                return InstanceValue.Value
                    ?? throw new InvalidOperationException(
                        "DriverSingleton is not initialized.");
            }
        }

        /// <summary>
        /// Initializes a WebDriver instance for the current thread
        /// using the specified browser type.
        /// </summary>
        /// <param name="browser">
        /// The browser type used to create the WebDriver instance.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Thrown when a WebDriver instance has already been initialized
        /// for the current thread.
        /// </exception>
        public static void Initialize(BrowserType browser)
        {
            if (InstanceValue.Value is not null)
            {
                throw new InvalidOperationException(
                    "DriverSingleton has already been initialized for the current thread.");
            }

            InstanceValue.Value = BrowserFactory.Create(browser);
        }

        /// <summary>
        /// Closes and disposes the WebDriver instance associated
        /// with the current thread and clears the stored reference.
        /// </summary>
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
