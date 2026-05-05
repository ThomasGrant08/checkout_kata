namespace Checkout.Core
{
    public interface ICheckout
    {
        void Scan(string sku);
        int GetTotalPrice();
    }
}
