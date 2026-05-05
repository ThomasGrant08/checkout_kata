namespace Checkout.Core
{
    public class Checkout(Dictionary<string, int> products, Dictionary<string, OfferRule> offerRules) : ICheckout
    {
        private readonly List<string> _items = new();
        private readonly Dictionary<string, int> _products = products;
        private readonly Dictionary<string, OfferRule> _offerRules = offerRules;

        public void Scan(string sku)
        {
            _items.Add(sku);
        }

        public int GetTotalPrice()
        {
            var totalPrice = 0;
            var itemCounts = _items.GroupBy(sku => sku).ToDictionary(group => group.Key, group => group.Count());
            foreach (var itemCount in itemCounts)
            {
                totalPrice +=
                    _offerRules.TryGetValue(itemCount.Key, out var offerRule) ?
                    offerRule.CalculatePrice(itemCount.Value, _products[itemCount.Key]) :
                    itemCount.Value * _products[itemCount.Key];
            }

            return totalPrice;
        }
    }
}
