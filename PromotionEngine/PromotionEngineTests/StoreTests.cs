using NUnit.Framework;
using PromotionEngine.Store;
using System.Linq;

namespace PromotionEngineTests
{
    public class StoreTests
    {
        Store store;
        [SetUp]
        public void Setup()
        {
            store = new Store()
                .AddSKUitem(TestData.a)
                .AddSKUitem(TestData.b)
                .AddSKUitem(TestData.c)
                .AddSKUitem(TestData.d)
                .AddPromotions(TestData.promotions);
        }

        [Test]
        public void Store_with_items_added_to_cart_after_checkout_should_apply_promotions()
        {
            store.AddItemToCart("A")
                .AddItemToCart("A")
                .AddItemToCart("A")
                .AddItemToCart("A")
                .AddItemToCart("A")
                .AddItemToCart("B")
                .AddItemToCart("B")
                .AddItemToCart("B")
                .AddItemToCart("B")
                .AddItemToCart("B")
                .AddItemToCart("C");

            Assert.AreEqual(420, store.Cart.TotalPrice);
            Assert.AreEqual(11, store.Cart.Items.Count);

            store.Checkout();
            Assert.AreEqual(370, store.Cart.TotalPrice);
        }
    }
}
