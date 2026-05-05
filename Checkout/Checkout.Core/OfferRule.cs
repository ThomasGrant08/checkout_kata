namespace Checkout.Core
{
    public class OfferRule
    {
        public string Sku { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int OfferPrice { get; set; }
        public OfferRule(string sku, int unitPrice, int quantity, int offerPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
            Quantity = quantity;
            OfferPrice = offerPrice;
        }

        public int CalculatePrice(int quantity)
        {
            int offerCount = quantity / Quantity;
            int remainingCount = quantity % Quantity;
            return offerCount * OfferPrice + remainingCount * UnitPrice;
        }
    }
}
