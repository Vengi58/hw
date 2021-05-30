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
            var prom = TestData.CandDfor30.ToCombinedItemFixedPricePromotion();
            var promn = TestData.ThreeAfor130.ToNitemForFixedPricePromotion();
        }

        [Test]
        public void ScenarioA()
        {
            cart.AddItem(TestData.a);
            cart.AddItem(TestData.b);
            cart.AddItem(TestData.c);
            foreach (var pr in TestData.promotions)
            {
                if (pr.IsApplicable(cart))
                {
                    pr.Execute(cart);
                }
            }
        }

        [Test]
        public void ScenarioB()
        {
            cart.AddItems(TestData.a, 5);
            cart.AddItems(TestData.b, 5);
            cart.AddItem(TestData.c);
            foreach (var pr in TestData.promotions)
            {
                if (pr.IsApplicable(cart))
                {
                    pr.Execute(cart);
                }
            }
        }

        [Test]
        public void ScenarioC()
        {
            cart.AddItems(TestData.a, 3);
            cart.AddItems(TestData.b, 5);
            cart.AddItem(TestData.c);
            cart.AddItem(TestData.d);
            foreach (var pr in TestData.promotions)
            {
                if (pr.IsApplicable(cart))
                {
                    pr.Execute(cart);
                }
            }
        }
    }
}