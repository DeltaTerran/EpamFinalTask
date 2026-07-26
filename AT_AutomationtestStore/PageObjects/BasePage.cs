namespace AT_AutomationtestStore.PageObjects
{
    using OpenQA.Selenium;

    /// <summary>
    /// Represents a base class for all Page Object classes.
    /// Provides common functionality for navigating to a page.
    /// </summary>
    /// <typeparam name="TPage">
    /// The type of the Page Object that inherits from this base class.
    /// </typeparam>
    public abstract class BasePage<TPage>
        where TPage : BasePage<TPage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage{TPage}"/> class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver instance used to interact with the browser.
        /// </param>
        protected BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Gets the WebDriver instance used by the page.
        /// </summary>
        protected IWebDriver Driver { get; }

        /// <summary>
        /// Gets the URL associated with the page.
        /// </summary>
        protected abstract string Url { get; }

        /// <summary>
        /// Opens the page by navigating the browser to its URL.
        /// </summary>
        /// <returns>
        /// The current Page Object instance to support fluent method chaining.
        /// </returns>
        public TPage Open()
        {
            this.Driver.Navigate().GoToUrl(this.Url);
            return (TPage)this;
        }
    }
}
