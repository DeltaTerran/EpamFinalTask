using AT_AutomationtestStore.PageObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT_AutomationtestStoreTest
{
    public class SpecialTest : BaseTest
    {
        [Fact]
        public void UC3_Products_AllHaveDiscount()
        {
            //Arrange
            var specialPage = new SpecialPage(Driver);

            //Act
            var products = specialPage.Open().GetProductPrices();

            //Assert
            products.Should().NotBeEmpty();

            products.Should().AllSatisfy(product =>
                product.NewPrice.Should().BeLessThan(product.OldPrice));
        }
    }
}
