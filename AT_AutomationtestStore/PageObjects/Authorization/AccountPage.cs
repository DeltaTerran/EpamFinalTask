using AT_AutomationtestStore.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT_AutomationtestStore.PageObjects.Authorization
{
    public class AccountPage : BasePage<AccountPage>
    {
        public AccountPage(IWebDriver driver) : base(driver)
        {
        }

        protected override string Url => ConfigurationReader.BaseUrl + "?rt=account/account";
    }
}
