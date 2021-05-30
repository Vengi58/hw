using NUnit.Framework;
using PromotionEngine.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void CreateStore()
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
            Assert.AreEqual(11, store.Cart.Items.Count());


            store.Checkout();
            Assert.AreEqual(370, store.Cart.TotalPrice);
        }
    }
}
