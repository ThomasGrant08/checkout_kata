namespace Checkout.Core
{
    public class OfferRule
    {
        public string Sku { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int OfferPrice { get; set; }
        public OfferRule(Product product, int quantity, int offerPrice)
        {
            Sku = product.Sku;
            UnitPrice = product.UnitPrice;
            Quantity = quantity;
            OfferPrice = offerPrice;
        }
    }
}
