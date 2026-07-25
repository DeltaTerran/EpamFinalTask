using AT_AutomationtestStore.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT_AutomationtestStore.PageObjects.Authorization
{
    public class SuccessPage : BasePage<SuccessPage>
    {
        readonly By ContinueButtonBy = By.CssSelector("a[title='Continue']");
        readonly By successHeaderBy =
        By.CssSelector("#maincontainer h1");

        public SuccessPage(IWebDriver driver) : base(driver)
        {
        }

        protected override string Url => ConfigurationReader.BaseUrl + "?rt=account/success";

        public AccountPage Continue()
        {
            driver.FindElement(ContinueButtonBy).Click();
            return new AccountPage(driver);
        }
        public bool IsOpened()
        {
            return driver.Url.Contains("rt=account/success")
                   && driver.FindElement(successHeaderBy).Displayed;
        }
    }
}