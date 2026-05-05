using Checkout.Core;
namespace Checkout.Tests
{
    public class CheckutTests
    {
        [Test]
        [TestCase(new[] { "A" }, 50)]
        [TestCase(new[] { "B" }, 30)]
        [TestCase(new[] { "C" }, 20)]
        [TestCase(new[] { "D" }, 15)]
        [TestCase(new[] { "A", "B", "C", "D" }, 115)]
        [TestCase(new[] { "A", "A", "A" }, 130)]
        [TestCase(new[] { "B", "B" }, 45)]
        [TestCase(new[] { "A", "A", "A", "A" }, 180)]
        public void Test_Scan_Items_And_Get_Total_Price(string[] skus, int expectedPrice)
        {
            var checkout = CreateCheckout();

            foreach (var sku in skus)
            {
                checkout.Scan(sku);
            }

            var totalPrice = checkout.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(expectedPrice));
        }

        [Test]
        [TestCase("")]
        [TestCase("E")]
        [TestCase(null)]
        public void Test_Scan_Invalid_Item_Should_Throw_Exception(string? sku)
        {
            var checkout = CreateCheckout();
            Assert.Throws<ArgumentException>(() => checkout.Scan(sku));
        }


        private ICheckout CreateCheckout()
        {
            var products = new Dictionary<string, int>
            {
                { "A", 50 },
                { "B", 30 },
                { "C", 20 },
                { "D", 15 }
            };

            var offers = new Dictionary<string, OfferRule>
            {
                { "A", new OfferRule("A", 3, 130) },
                { "B", new OfferRule("B", 2, 45) }
            };

            return new Core.Checkout(products, offers);
        }
    }
}
