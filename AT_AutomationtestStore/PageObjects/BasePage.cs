using AT_AutomationtestStore.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT_AutomationtestStore.PageObjects
{
    public abstract class BasePage<TPage> where TPage : BasePage<TPage>
    {
        protected IWebDriver driver;
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
