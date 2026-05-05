namespace Checkout.Core
{
    public class OfferRule
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public int OfferPrice { get; set; }
        public OfferRule(string sku, int quantity, int offerPrice)
        {
            Sku = sku;
            Quantity = quantity;
            OfferPrice = offerPrice;
        }

        /// <summary>
        /// Takes in the number of items and the unit price, calculates the total price based on the offer rule, and returns it.
        /// </summary>
        /// <param name="itemCount">The number of items being purchased.</param>
        /// <param name="unitPrice">The price per individual item.</param>
        /// <returns>The total price for the given number of items, considering any applicable offer.</returns>
        public int CalculatePrice(int itemCount, int unitPrice)
        {
            var offerGroups = itemCount / Quantity;
            var remainder = itemCount % Quantity;

            return (offerGroups * OfferPrice) + (remainder * unitPrice);
        }
    }
}
