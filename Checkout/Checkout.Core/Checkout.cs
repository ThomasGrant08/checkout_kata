namespace Checkout.Core
{
    public class Checkout : ICheckout
    {
        private readonly List<string> _items = new();

        public void Scan(string sku)
        {
            _items.Add(sku);
        }

        public int GetTotalPrice() => 0;
    }
}
