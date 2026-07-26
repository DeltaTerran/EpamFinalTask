namespace AT_AutomationtestStore.Models
{
    /// <summary>
    /// Represents pricing information for a product,
    /// including its original and current prices.
    /// </summary>
    public sealed class ProductPrice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductPrice"/> class.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="oldPrice">The original price of the product.</param>
        /// <param name="newPrice">The current price of the product.</param>
        public ProductPrice(string name, decimal oldPrice, decimal newPrice)
        {
            this.Name = name;
            this.OldPrice = oldPrice;
            this.NewPrice = newPrice;
        }

        /// <summary>
        /// Gets the name of the product.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the original price of the product before the discount.
        /// </summary>
        public decimal OldPrice { get; }

        /// <summary>
        /// Gets the current price of the product after the discount.
        /// </summary>
        public decimal NewPrice { get; }
    }
}
