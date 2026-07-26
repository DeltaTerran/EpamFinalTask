using AT_AutomationtestStore.Configuration;
using AT_AutomationtestStore.PageObjects.Authorization;
using OpenQA.Selenium;

namespace AT_AutomationtestStore.PageObjects
{
    public class IndexPage : BasePage<IndexPage>
    {
        private readonly By loginOrRegisteBy = By.CssSelector("a[href*='account/login']");
        private readonly By specialBy = By.CssSelector("a[href*='product/special']");

        protected override string Url => ConfigurationReader.BaseUrl;

        public IndexPage(IWebDriver driver) : base(driver)
        {
        }

        public LoginPage EnterloginOrRegisterPage()
        {
            driver.FindElement(loginOrRegisteBy).Click();
            return new LoginPage(driver);
        }

        public SpecialPage EnterSpecialPage()
        {
            driver.FindElement(specialBy).Click();
            return new SpecialPage(driver);
        }
    }
}
