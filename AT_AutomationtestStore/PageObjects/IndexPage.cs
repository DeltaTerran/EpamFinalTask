namespace AT_AutomationtestStore.PageObjects
{
    using AT_AutomationtestStore.Configuration;
    using AT_AutomationtestStore.PageObjects.Authorization;
    using OpenQA.Selenium;

    /// <summary>
    /// Represents the home page of the Automation Test Store application.
    /// Provides navigation to the login/registration and special offers pages.
    /// </summary>
    public class IndexPage : BasePage<IndexPage>
    {
        private readonly By loginOrRegiserBy = By.CssSelector("a[href*='account/login']");
        private readonly By specialBy = By.CssSelector("a[href*='product/special']");

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexPage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver instance used to interact with the browser.
        /// </param>
        public IndexPage(IWebDriver driver)
            : base(driver)
        {
        }

        /// <summary>
        /// Gets the URL of the home page.
        /// </summary>
        protected override string Url => ConfigurationReader.BaseUrl;

        /// <summary>
        /// Navigates to the login and registration page
        /// by clicking the corresponding link in the page header.
        /// </summary>
        /// <returns>
        /// A new instance of <see cref="LoginPage"/> representing
        /// the opened login and registration page.
        /// </returns>
        public LoginPage EnterloginOrRegisterPage()
        {
            this.Driver.FindElement(this.loginOrRegiserBy).Click();
            return new LoginPage(this.Driver);
        }

        /// <summary>
        /// Navigates to the special offers page
        /// by clicking the Specials link in the page header.
        /// </summary>
        /// <returns>
        /// A new instance of <see cref="SpecialPage"/> representing
        /// the opened special offers page.
        /// </returns>
        public SpecialPage EnterSpecialPage()
        {
            this.Driver.FindElement(this.specialBy).Click();
            return new SpecialPage(this.Driver);
        }
    }
}
