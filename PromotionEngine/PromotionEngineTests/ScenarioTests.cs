using NUnit.Framework;
using PromotionEngine.Items;
using PromotionEngine.PromotionRules;

namespace PromotionEngineTests
{
    public class Tests
    {
        Cart cart;

        [SetUp]
        public void Setup()
        {
            cart = new Cart();
        }

        [Test]
        public void ScenarioA()
        {
            cart.AddItem(TestData.a);
            cart.AddItem(TestData.b);
            cart.AddItem(TestData.c);

            Assert.AreEqual(3, cart.Items.Count);
            Assert.AreEqual(cart.TotalPrice, 100);

            ApplyPromotionsOnCart();

            Assert.AreEqual(cart.TotalPrice, 100);
        }

        [Test]
        public void ScenarioB()
        {
            cart.AddItems(TestData.a, 5);
            cart.AddItems(TestData.b, 5);
            cart.AddItem(TestData.c);

            Assert.AreEqual(11, cart.Items.Count);
            Assert.AreEqual(cart.TotalPrice, 420);

            ApplyPromotionsOnCart();

            Assert.AreEqual(cart.TotalPrice, 370);
        }

        [Test]
        public void ScenarioC()
        {
            cart.AddItems(TestData.a, 3);
            cart.AddItems(TestData.b, 5);
            cart.AddItem(TestData.c);
            cart.AddItem(TestData.d);

            Assert.AreEqual(10, cart.Items.Count);
            Assert.AreEqual(cart.TotalPrice, 335);

            ApplyPromotionsOnCart();

            Assert.AreEqual(cart.TotalPrice, 280);
        }

        private void ApplyPromotionsOnCart()
        {
            TestData.promotions.ForEach(p => { if (p.IsApplicable(cart)) p.Execute(cart); });
        }
    }
}