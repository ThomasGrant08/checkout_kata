namespace Checkout.Core
{
    /// <summary>
    /// A checkout interface that defines the methods for scanning items and calculating the total price.
    /// </summary>
    public interface ICheckout
    {
        /// <summary>
        /// Scans an item by its SKU and adds it to the checkout.
        /// </summary>
        /// <param name="sku">The SKU identifier of the item to add. Cannot be null or empty.</param>
        void Scan(string sku);

        /// <summary>
        /// Calculates the total price for all items in the current context.
        /// </summary>
        /// <returns>The total price as an integer value. Returns 0 if there are no items.</returns>
        int GetTotalPrice();
    }
}
