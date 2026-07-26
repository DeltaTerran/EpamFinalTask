namespace AT_AutomationtestStore.PageObjects
{
    using System.Globalization;
    using AT_AutomationtestStore.Configuration;
    using AT_AutomationtestStore.Models;
    using OpenQA.Selenium;

    /// <summary>
    /// Represents the Special Offers page of the Automation Test Store.
    /// Provides access to products displayed on the page and their pricing information.
    /// </summary>
    public class SpecialPage : BasePage<SpecialPage>
    {
        private readonly By productsBy = By.CssSelector(
            "#maincontainer div:has(> .fixed_wrapper):has(.thumbnail)");

        private readonly By productNameBy = By.CssSelector("a[class='prdocutname']");
        private readonly By productOldPriceBy = By.CssSelector(".priceold");
        private readonly By productNewPriceBy = By.CssSelector(".pricenew");

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialPage"/> class.
        /// </summary>
        /// <param name="driver">
        /// The WebDriver instance used to interact with the Special Offers page.
        /// </param>
        public SpecialPage(IWebDriver driver)
            : base(driver)
        {
        }

        /// <summary>
        /// Gets the URL of the Special Offers page.
        /// </summary>
        protected override string Url => ConfigurationReader.BaseUrl + "?rt=product/special";

        /// <summary>
        /// Gets pricing information for all products displayed
        /// on the Special Offers page.
        /// </summary>
        /// <returns>
        /// A read-only list of <see cref="ProductPrice"/> objects containing
        /// the product name, old price, and new price.
        /// </returns>
        public IReadOnlyList<ProductPrice> GetProductPrices()
        {
            var products = this.Driver.FindElements(this.productsBy);

            return products.Select(product =>
            {
                var name = product
                    .FindElement(this.productNameBy)
                    .Text;

                var oldPriceText = product
                    .FindElement(this.productOldPriceBy)
                    .Text;

                var newPriceText = product
                    .FindElement(this.productNewPriceBy)
                    .Text;

                return new ProductPrice(
                    name,
                    ParsePrice(oldPriceText),
                    ParsePrice(newPriceText));
            }).ToList();
        }

        /// <summary>
        /// Converts a product price displayed on the page
        /// to its decimal representation.
        /// </summary>
        /// <param name="price">
        /// The price text to convert.
        /// </param>
        /// <returns>
        /// The numeric value of the specified price.
        /// </returns>
        private static decimal ParsePrice(string price)
        {
            return decimal.Parse(
                price.Replace("$", string.Empty),
                CultureInfo.InvariantCulture);
        }
    }
}
