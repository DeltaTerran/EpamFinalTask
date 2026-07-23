using AT_AutomationtestStore.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT_AutomationtestStore.PageObjects.Authorization
{
    public class RegistrationPage : BasePage<RegistrationPage>
    {
        private readonly By firstNameBy = By.CssSelector("input[name='firstname']");
        private readonly By lastNameBy = By.CssSelector("input[name='lastname']");
        private readonly By emailBy = By.CssSelector("input[name='email']");
        private readonly By addressBy = By.CssSelector("input[name='address_1']");
        private readonly By CityBy = By.CssSelector("input[name='city']");
        private readonly By RegionBy = By.CssSelector("select[name='zone_id']");
        private readonly By ZipCodeBy = By.CssSelector("input[name='postcode']");
        private readonly By CountryBy = By.CssSelector("select[name='country_id']");
        private readonly By LoginBy = By.CssSelector("input[name='loginname']");
        private readonly By PasswordBy = By.CssSelector("input[name='password']");
        private readonly By ConfirmPasswordBy = By.CssSelector("input[name='confirm']");
        private readonly By SubmitButton = By.CssSelector("button[title='Continue']");

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        protected override string Url => ConfigurationReader.BaseUrl + "/index.php?rt=account/create";
        public RegistrationPage InputFirstName(string input)
        {
            driver.FindElement(firstNameBy).SendKeys(input);
            return this;
        }

        public RegistrationPage InputLastName(string input)
        {
            driver.FindElement(lastNameBy).SendKeys(input);
            return this;
        }

        public RegistrationPage InputEmail(string input)
        {
            driver.FindElement(emailBy).SendKeys(input);
            return this;
        }

        public RegistrationPage InputAddress(string input)
        {
            driver.FindElement(addressBy).SendKeys(input);
            return this;
        }

        public RegistrationPage InputCity(string input)
        {
            driver.FindElement(CityBy).SendKeys(input);
            return this;
        }

        public RegistrationPage InputRegion(string zoneName)
        {
            var select = new SelectElement(driver.FindElement(RegionBy));

            var option = select.Options
                .FirstOrDefault(x => x.Text.Equals(zoneName, StringComparison.OrdinalIgnoreCase));

            if (option == null)
            {
                throw new ArgumentException(
                    $"Zone '{zoneName}' doesn't exist in the dropdown.");
            }

            select.SelectByText(option.Text);

            return this;
        }

        public RegistrationPage InputZipCode(string input)
        {
            driver.FindElement(ZipCodeBy).SendKeys(input);
            return this;
        }

        public RegistrationPage inputCountry(string zoneName)
        {
            var select = new SelectElement(driver.FindElement(CountryBy));

            var option = select.Options
                .FirstOrDefault(x => x.Text.Equals(zoneName, StringComparison.OrdinalIgnoreCase));

            if (option == null)
            {
                throw new ArgumentException(
                    $"Zone '{zoneName}' doesn't exist in the dropdown.");
            }

            select.SelectByText(option.Text);

            return this;
        }

        public RegistrationPage InputLogin(string input)
        {
            driver.FindElement(LoginBy).SendKeys(input);
            return this;
        }

        public RegistrationPage InputPassword(string input)
        {
            driver.FindElement(PasswordBy).SendKeys(input);
            return this;
        }

        public RegistrationPage InputConfirmPassword(string input)
        {
            driver.FindElement(ConfirmPasswordBy).SendKeys(input);
            return this;
        }
    }
}
