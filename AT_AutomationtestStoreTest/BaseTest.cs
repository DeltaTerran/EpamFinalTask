using AT_AutomationtestStore.Configuration;
using AT_AutomationtestStore.Core;
using OpenQA.Selenium;

namespace AT_AutomationtestStoreTest
{
    public abstract class BaseTest : IDisposable
    {
        protected IWebDriver Driver => DriverSingleton.Instance;

        public BaseTest()
        {
            DriverSingleton.Initialize(
                ConfigurationReader.Browser);
        }

        public void Dispose()
        {
            DriverSingleton.Quit();
        }
    }
}
