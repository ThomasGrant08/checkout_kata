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

        public int CalculatePrice(int itemCount, int unitPrice)
        {
            var offerGroups = itemCount / Quantity;
            var remainder = itemCount % Quantity;

            return (offerGroups * OfferPrice) + (remainder * unitPrice);
        }
    }
}
