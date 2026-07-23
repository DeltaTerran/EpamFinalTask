using AT_AutomationtestStore.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT_AutomationtestStore.PageObjects.Authorization
{
    public class LoginPage : BasePage<LoginPage>
    {
        By RegisterButtonBy = By.CssSelector("button[title='Continue']");
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        protected override string Url => ConfigurationReader.BaseUrl + "/index.php?rt=account/login";
        public RegistrationPage RegisterButtonClick()
        {
            driver.FindElement(RegisterButtonBy).Click();
            return new RegistrationPage(driver);
        }
    }
}
