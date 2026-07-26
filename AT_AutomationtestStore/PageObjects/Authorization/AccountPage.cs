namespace AT_AutomationtestStore.PageObjects.Authorization
{
    using AT_AutomationtestStore.Configuration;
    using OpenQA.Selenium;

    /// <summary>
    /// Represents the user's account page of the Automation Test Store.
    /// Provides access to account-related information displayed after login
    /// or successful registration.
    /// </summary>
    public class AccountPage : BasePage<AccountPage>
    {
        private readonly By myAccountUserNameBy = By.CssSelector(".subtext");
        private readonly By welcomeMessageBy = By.CssSelector("#customer_menu_top");

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountPage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver instance used to interact with the account page.
        /// </param>
        public AccountPage(IWebDriver driver)
            : base(driver)
        {
        }

        /// <summary>
        /// Gets the URL of the user's account page.
        /// </summary>
        protected override string Url => ConfigurationReader.BaseUrl + "?rt=account/account";

        /// <summary>
        /// Gets the user name displayed on the account page.
        /// </summary>
        /// <returns>
        /// The text containing the displayed user name.
        /// </returns>
        public string GetUserName()
        {
            return this.Driver.FindElement(this.myAccountUserNameBy).Text;
        }

        /// <summary>
        /// Gets the welcome message displayed in the page header.
        /// </summary>
        /// <returns>
        /// The welcome message text for the currently logged-in user.
        /// </returns>
        public string GetWelcomeMessage()
        {
            return this.Driver.FindElement(this.welcomeMessageBy).Text;
        }
    }
}
