using System.Globalization;

using AT_AutomationtestStore.Configuration;
using AT_AutomationtestStore.Models;
using OpenQA.Selenium;

namespace AT_AutomationtestStore.PageObjects
{
    public class SpecialPage : BasePage<SpecialPage>
    {
        private readonly By productsBy = By.CssSelector(
            "#maincontainer div:has(> .fixed_wrapper):has(.thumbnail)");
        private readonly By productNameBy = By.CssSelector("a[class='prdocutname']");
        private readonly By productOldPriceBy = By.CssSelector(".priceold");
        private readonly By productNewPriceBy = By.CssSelector(".pricenew");

        protected override string Url => ConfigurationReader.BaseUrl + "?rt=product/special";

        public SpecialPage(IWebDriver driver) : base(driver)
        {
        }

        public IReadOnlyList<ProductPrice> GetProductPrices()
        {
            var products = driver.FindElements(productsBy);

            return products.Select(product =>
            {
                var name = product
                    .FindElement(productNameBy)
                    .Text;

                var oldPriceText = product
                    .FindElement(productOldPriceBy)
                    .Text;

                var newPriceText = product
                    .FindElement(productNewPriceBy)
                    .Text;

                return new ProductPrice(
                    name,
                    ParsePrice(oldPriceText),
                    ParsePrice(newPriceText));
            }).ToList();
        }

        private static decimal ParsePrice(string price)
        {
            return decimal.Parse(
                price.Replace("$", string.Empty),
                CultureInfo.InvariantCulture);
        }
    }
}
