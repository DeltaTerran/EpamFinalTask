using AT_AutomationtestStore.PageObjects;
using FluentAssertions;

namespace AT_AutomationtestStoreTest
{
    public class SpecialTest : BaseTest
    {
        [Fact]
        public void UC3_Products_AllHaveDiscount()
        {
            // Arrange
            var specialPage = new IndexPage(Driver).Open().EnterSpecialPage();

            // Act
            var products = specialPage.GetProductPrices();

            // Assert
            products.Should().NotBeEmpty();

            products.Should().AllSatisfy(product =>
                product.NewPrice.Should().BeLessThan(product.OldPrice));
        }
    }
}
