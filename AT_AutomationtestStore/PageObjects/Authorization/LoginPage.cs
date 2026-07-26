namespace AT_AutomationtestStore.PageObjects.Authorization
{
    using AT_AutomationtestStore.Configuration;
    using OpenQA.Selenium;

    /// <summary>
    /// Represents the login and registration page of the Automation Test Store.
    /// Provides navigation to the account registration page for new customers.
    /// </summary>
    public class LoginPage : BasePage<LoginPage>
    {
        private readonly By registerButtonBy = By.CssSelector("button[title='Continue']");

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver instance used to interact with the login page.
        /// </param>
        public LoginPage(IWebDriver driver)
            : base(driver)
        {
        }

        /// <summary>
        /// Gets the URL of the login and registration page.
        /// </summary>
        protected override string Url => ConfigurationReader.BaseUrl + "?rt=account/login";

        /// <summary>
        /// Clicks the Continue button in the new customer section
        /// and navigates to the account registration page.
        /// </summary>
        /// <returns>
        /// A new <see cref="RegistrationPage"/> instance representing
        /// the opened registration page.
        /// </returns>
        public RegistrationPage RegisterButtonClick()
        {
            this.Driver.FindElement(this.registerButtonBy).Click();
            return new RegistrationPage(this.Driver);
        }
    }
}
