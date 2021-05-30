using NUnit.Framework;
using PromotionEngine.Items;
using PromotionEngine.PromotionRules;
using System.Collections.Generic;

namespace PromotionEngineTests
{
    public class Tests
    {
        readonly SKUitem a = new() { ID = "A", UnitPrice = 50 };
        readonly SKUitem b = new() { ID = "B", UnitPrice = 30 };
        readonly SKUitem c = new() { ID = "C", UnitPrice = 20 };
        readonly SKUitem d = new() { ID = "D", UnitPrice = 15 };
        static readonly NitemForFixedPricePromotion pr1 = new("A", 3, 130);
        static readonly NitemForFixedPricePromotion pr2 = new("B", 2, 45);
        static readonly CombinedItemFixedPricePromotion pr3 = new(new List<string> { "C", "D" }, 30);
        static readonly List<PromotionRule> promotions = new() { pr1, pr2, pr3 };
        Cart cart;

        [SetUp]
        public void Setup()
        {
            cart = new Cart();
        }

        [Test]
        public void ScenarioA()
        {
            cart.AddItem(a);
            cart.AddItem(b);
            cart.AddItem(c);
            foreach (var pr in promotions)
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
            cart.AddItems(a, 5);
            cart.AddItems(b, 5);
            cart.AddItem(c);
            foreach (var pr in promotions)
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
            cart.AddItems(a, 3);
            cart.AddItems(b, 5);
            cart.AddItem(c);
            cart.AddItem(d);
            foreach (var pr in promotions)
            {
                if (pr.IsApplicable(cart))
                {
                    pr.Execute(cart);
                }
            }
        }
    }
}