namespace Checkout.Core
{

    /// <summary>
    /// Represents a checkout system that allows scanning items and calculating the total price based on predefined products and offer rules.
    /// </summary>
    /// <param name="products">A dictionary containing the product SKUs and their corresponding prices.</param>
    /// <param name="offerRules">A dictionary containing the offer rules for specific SKUs.</param>
    public class Checkout(Dictionary<string, int> products, Dictionary<string, OfferRule> offerRules) : ICheckout
    {
        private readonly List<string> _items = new();
        private readonly Dictionary<string, int> _products = products;
        private readonly Dictionary<string, OfferRule> _offerRules = offerRules;

        /// <summary>
        /// Adds an item to the current scan session using the specified SKU.
        /// </summary>
        /// <param name="sku">The SKU identifier of the item to add. Cannot be null.</param>
        public void Scan(string sku)
        {
            if (string.IsNullOrEmpty(sku))
                throw new ArgumentException("SKU cannot be null or empty.", nameof(sku));

            if (!_products.ContainsKey(sku))
                throw new ArgumentException("SKU does not exist in the product list.", nameof(sku));

            _items.Add(sku);
        }

        /// <summary>
        /// Calculates the total price for all items in the current scan session.
        /// </summary>
        /// <returns>The total price as an integer value. Returns 0 if there are no items.</returns>
        public int GetTotalPrice()
        {
            var itemCounts = _items.GroupBy(sku => sku).ToDictionary(group => group.Key, group => group.Count());

            return itemCounts.Sum(
                i =>
                _offerRules.TryGetValue(i.Key, out var offerRule) ?
                offerRule.CalculatePrice(i.Value, _products[i.Key]) :
                i.Value * _products[i.Key]
            );
        }
    }
}
