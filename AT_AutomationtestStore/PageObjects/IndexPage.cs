using AT_AutomationtestStore.Configuration;
using AT_AutomationtestStore.PageObjects.Authorization;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT_AutomationtestStore.PageObjects
{
    public class IndexPage : BasePage<IndexPage>
    {
        private readonly By loginOrRegisteBy = By.CssSelector("a[href*='account/login']");
        public IndexPage(IWebDriver driver) : base(driver)
        {
        }

        protected override string Url => ConfigurationReader.BaseUrl;
        public LoginPage EnterloginOrRegisterPage()
        {
            driver.FindElement(loginOrRegisteBy).Click();
            return new LoginPage(driver);
        }
    }
}
