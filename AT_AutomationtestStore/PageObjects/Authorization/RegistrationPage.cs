namespace AT_AutomationtestStore.PageObjects.Authorization
{
    using AT_AutomationtestStore.Configuration;
    using AT_AutomationtestStore.Models;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Represents the account registration page of the Automation Test Store.
    /// Provides methods for filling in registration fields, submitting the form,
    /// and retrieving validation messages.
    /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationPage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver instance used to interact with the registration page.
        /// </param>
        public RegistrationPage(IWebDriver driver)
            : base(driver)
        {
        }

        /// <summary>
        /// Gets the URL of the account registration page.
        /// </summary>
        protected override string Url => ConfigurationReader.BaseUrl + "?rt=account/create";

        /// <summary>
        /// Enters the specified first name into the registration form.
        /// </summary>
        /// <param name="input">The first name to enter.</param>
        /// <returns>The current registration page instance.</returns>
        public RegistrationPage InputFirstName(string input)
        {
            this.Driver.FindElement(this.firstNameBy).SendKeys(input);
            return this;
        }

        /// <summary>
        /// Enters the specified last name into the registration form.
        /// </summary>
        /// <param name="input">The last name to enter.</param>
        /// <returns>The current registration page instance.</returns>
        public RegistrationPage InputLastName(string input)
        {
            this.Driver.FindElement(this.lastNameBy).SendKeys(input);
            return this;
        }

        /// <summary>
        /// Enters the specified email address into the registration form.
        /// </summary>
        /// <param name="input">The email address to enter.</param>
        /// <returns>The current registration page instance.</returns>
        public RegistrationPage InputEmail(string input)
        {
            this.Driver.FindElement(this.emailBy).SendKeys(input);
            return this;
        }

        /// <summary>
        /// Enters the specified address into the registration form.
        /// </summary>
        /// <param name="input">The address to enter.</param>
        /// <returns>The current registration page instance.</returns>
        public RegistrationPage InputAddress(string input)
        {
            this.Driver.FindElement(this.addressBy).SendKeys(input);
            return this;
        }

        /// <summary>
        /// Enters the specified city into the registration form.
        /// </summary>
        /// <param name="input">The city to enter.</param>
        /// <returns>The current registration page instance.</returns>
        public RegistrationPage InputCity(string input)
        {
            this.Driver.FindElement(this.cityBy).SendKeys(input);
            return this;
        }

        /// <summary>
        /// Selects the specified region from the region dropdown.
        /// The lookup is performed without regard to character casing.
        /// </summary>
        /// <param name="zoneName">The region name to select.</param>
        /// <returns>The current registration page instance.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the specified region cannot be found in the dropdown.
        /// </exception>
        public RegistrationPage InputRegion(string zoneName)
        {
            var select = new SelectElement(this.Driver.FindElement(this.regionBy));

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

        /// <summary>
        /// Enters the specified ZIP or postal code into the registration form.
        /// </summary>
        /// <param name="input">The ZIP or postal code to enter.</param>
        /// <returns>The current registration page instance.</returns>
        public RegistrationPage InputZipCode(string input)
        {
            this.Driver.FindElement(this.zipCodeBy).SendKeys(input);
            return this;
        }

        /// <summary>
        /// Selects the specified country from the country dropdown.
        /// The lookup is performed without regard to character casing.
        /// </summary>
        /// <param name="zoneName">The country name to select.</param>
        /// <returns>The current registration page instance.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the specified country cannot be found in the dropdown.
        /// </exception>
        public RegistrationPage InputCountry(string zoneName)
        {
            var select = new SelectElement(this.Driver.FindElement(this.countryBy));

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

        /// <summary>
        /// Enters the specified login name into the registration form.
        /// </summary>
        /// <param name="input">The login name to enter.</param>
        /// <returns>The current registration page instance.</returns>
        public RegistrationPage InputLogin(string input)
        {
            this.Driver.FindElement(this.loginBy).SendKeys(input);
            return this;
        }

        /// <summary>
        /// Enters the specified password into the registration form.
        /// </summary>
        /// <param name="input">The password to enter.</param>
        /// <returns>The current registration page instance.</returns>
        public RegistrationPage InputPassword(string input)
        {
            this.Driver.FindElement(this.passwordBy).SendKeys(input);
            return this;
        }

        /// <summary>
        /// Enters the specified password into the confirmation field.
        /// </summary>
        /// <param name="input">The password confirmation value.</param>
        /// <returns>The current registration page instance.</returns>
        public RegistrationPage InputConfirmPassword(string input)
        {
            this.Driver.FindElement(this.confirmPasswordBy).SendKeys(input);
            return this;
        }

        /// <summary>
        /// Fills all registration fields using the supplied user data.
        /// </summary>
        /// <param name="user">
        /// The user registration data used to populate the form.
        /// </param>
        /// <returns>The current registration page instance.</returns>
        public RegistrationPage FillRegistrationForm(UserRegistrationData user)
        {
            return this.InputFirstName(user.FirstName)
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

        /// <summary>
        /// Accepts the privacy policy and submits the registration form,
        /// expecting successful registration.
        /// </summary>
        /// <returns>
        /// A new <see cref="SuccessPage"/> instance representing
        /// the expected successful registration page.
        /// </returns>
        public SuccessPage Register()
        {
            this.Driver.FindElement(this.policyRadioButtonBy).Click();
            this.Driver.FindElement(this.submitButtonBy).Click();
            return new SuccessPage(this.Driver);
        }

        /// <summary>
        /// Accepts the privacy policy and submits the registration form
        /// while remaining on the current page object.
        /// </summary>
        /// <returns>The current registration page instance.</returns>
        public RegistrationPage Submit()
        {
            this.Driver.FindElement(this.policyRadioButtonBy).Click();
            this.Driver.FindElement(this.submitButtonBy).Click();
            return this;
        }

        /// <summary>
        /// Gets the validation message displayed for the login name field.
        /// </summary>
        /// <returns>The login name validation message text.</returns>
        public string GetLoginErrorLabelText() => this.Driver.FindElement(this.loginErrorLabel).Text;
    }
}
