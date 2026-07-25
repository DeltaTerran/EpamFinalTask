using AT_AutomationtestStore.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT_AutomationtestStore.PageObjects.Authorization
{
    public class AccountPage : BasePage<AccountPage>
    {

        private readonly By myAccountUserNameBy =
            By.CssSelector(".subtext");

        private readonly By welcomeMessageBy =
            By.CssSelector("#customer_menu_top");
        public AccountPage(IWebDriver driver) : base(driver)
        {
        }

        protected override string Url => ConfigurationReader.BaseUrl + "?rt=account/account";

        public string GetUserName()
        {
            return driver.FindElement(myAccountUserNameBy).Text;
        }

        public string GetWelcomeMessage()
        {
            return driver.FindElement(welcomeMessageBy).Text;
        }
    }
}
