namespace AT_AutomationtestStore.PageObjects.Authorization
{
    using AT_AutomationtestStore.Configuration;
    using OpenQA.Selenium;

    /// <summary>
    /// Represents the successful account registration page
    /// of the Automation Test Store.
    /// Provides navigation to the user's account page
    /// after successful registration.
    /// </summary>
    public class SuccessPage : BasePage<SuccessPage>
    {
        private readonly By continueButtonBy = By.CssSelector("a[title='Continue']");

        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessPage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver instance used to interact with the success page.
        /// </param>
        public SuccessPage(IWebDriver driver)
            : base(driver)
        {
        }

        /// <summary>
        /// Gets the URL of the successful account registration page.
        /// </summary>
        protected override string Url => ConfigurationReader.BaseUrl + "?rt=account/success";

        /// <summary>
        /// Clicks the Continue button and navigates to the user's account page.
        /// </summary>
        /// <returns>
        /// A new <see cref="AccountPage"/> instance representing
        /// the opened account page.
        /// </returns>
        public AccountPage Continue()
        {
            this.Driver.FindElement(this.continueButtonBy).Click();
            return new AccountPage(this.Driver);
        }
    }
}
