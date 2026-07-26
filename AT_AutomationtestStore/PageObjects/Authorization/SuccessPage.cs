using AT_AutomationtestStore.Configuration;
using OpenQA.Selenium;

namespace AT_AutomationtestStore.PageObjects.Authorization
{
    public class SuccessPage : BasePage<SuccessPage>
    {
        private readonly By continueButtonBy = By.CssSelector("a[title='Continue']");
        private readonly By successHeaderBy = By.CssSelector("#maincontainer h1");

        protected override string Url => ConfigurationReader.BaseUrl + "?rt=account/success";

        public SuccessPage(IWebDriver driver) : base(driver)
        {
        }

        public AccountPage Continue()
        {
            driver.FindElement(continueButtonBy).Click();
            return new AccountPage(driver);
        }

        public bool IsOpened()
        {
            return driver.Url.Contains("rt=account/success")
                   && driver.FindElement(successHeaderBy).Displayed;
        }
    }
}
