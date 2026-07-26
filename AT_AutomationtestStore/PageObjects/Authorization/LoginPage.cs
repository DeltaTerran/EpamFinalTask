using AT_AutomationtestStore.Configuration;
using OpenQA.Selenium;

namespace AT_AutomationtestStore.PageObjects.Authorization
{
    public class LoginPage : BasePage<LoginPage>
    {
        private readonly By registerButtonBy = By.CssSelector("button[title='Continue']");

        protected override string Url => ConfigurationReader.BaseUrl + "?rt=account/login";

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public RegistrationPage RegisterButtonClick()
        {
            driver.FindElement(registerButtonBy).Click();
            return new RegistrationPage(driver);
        }
    }
}
