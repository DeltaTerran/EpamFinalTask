using AT_AutomationtestStore.Configuration;
using AT_AutomationtestStore.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AT_AutomationtestStore.PageObjects.Authorization
{
    public class RegistrationPage : BasePage<RegistrationPage>
    {
        private readonly By firstNameBy = By.CssSelector("input[name='firstname']");
        private readonly By lastNameBy = By.CssSelector("input[name='lastname']");
        private readonly By emailBy = By.CssSelector("input[name='email']");
        private readonly By addressBy = By.CssSelector("input[name='address_1']");
        private readonly By cityBy = By.CssSelector("input[name='city']");
        private readonly By regionBy = By.CssSelector("select[name='zone_id']");
        private readonly By zipCodeBy = By.CssSelector("input[name='postcode']");
        private readonly By countryBy = By.CssSelector("select[name='country_id']");
        private readonly By loginBy = By.CssSelector("input[name='loginname']");
        private readonly By passwordBy = By.CssSelector("input[name='password']");
        private readonly By confirmPasswordBy = By.CssSelector("input[name='confirm']");
        private readonly By submitButtonBy = By.CssSelector("button[title='Continue']");
        private readonly By policyRadioButtonBy = By.CssSelector("input[name='agree']");
        private readonly By loginErrorLabel = By.CssSelector(".form-group:has(#AccountFrm_loginname) .help-block");

        protected override string Url => ConfigurationReader.BaseUrl + "?rt=account/create";

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

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
            driver.FindElement(cityBy).SendKeys(input);
            return this;
        }

        public RegistrationPage InputRegion(string zoneName)
        {
            var select = new SelectElement(driver.FindElement(regionBy));

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
            driver.FindElement(zipCodeBy).SendKeys(input);
            return this;
        }

        public RegistrationPage InputCountry(string zoneName)
        {
            var select = new SelectElement(driver.FindElement(countryBy));

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
            driver.FindElement(loginBy).SendKeys(input);
            return this;
        }

        public RegistrationPage InputPassword(string input)
        {
            driver.FindElement(passwordBy).SendKeys(input);
            return this;
        }

        public RegistrationPage InputConfirmPassword(string input)
        {
            driver.FindElement(confirmPasswordBy).SendKeys(input);
            return this;
        }

        public RegistrationPage FillRegistrationForm(UserRegistrationData user)
        {
            return InputFirstName(user.FirstName)
                .InputLastName(user.LastName)
                .InputEmail(user.Email)
                .InputAddress(user.Address)
                .InputCity(user.City)
                .InputCountry(user.Country)
                .InputRegion(user.Region)
                .InputZipCode(user.ZipCode)
                .InputLogin(user.Login)
                .InputPassword(user.Password)
                .InputConfirmPassword(user.Password);
        }

        public SuccessPage Register()
        {
            driver.FindElement(policyRadioButtonBy).Click();
            driver.FindElement(submitButtonBy).Click();
            return new SuccessPage(driver);
        }

        public RegistrationPage Submit()
        {
            driver.FindElement(policyRadioButtonBy).Click();
            driver.FindElement(submitButtonBy).Click();
            return this;
        }

        public string GetLoginErrorLabelText() => driver.FindElement(loginErrorLabel).Text;
    }
}
