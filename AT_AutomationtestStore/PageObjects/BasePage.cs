using OpenQA.Selenium;

namespace AT_AutomationtestStore.PageObjects
{
    public abstract class BasePage<TPage> where TPage : BasePage<TPage>
    {
        protected readonly IWebDriver driver;

        protected abstract string Url { get; }

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public TPage Open()
        {
            driver.Navigate().GoToUrl(Url);
            return (TPage)this;
        }
    }
}
