using NUnit.Framework;
using PromotionEngine.Items;
using PromotionEngine.PromotionRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineTests
{
    public class PromotionRuleTests
    {
        [Test]
        public void NitemForFixedPricePromotion_for_valid_data_should_create_instance()
        {
            var promotion = new NitemForFixedPricePromotion("A", 3, 130);
            Assert.NotNull(promotion);
            Assert.AreEqual("A", promotion.SKU);
            Assert.AreEqual(3, promotion.NumberOfItems);
            Assert.AreEqual(130, promotion.FixedPrice);
            Assert.AreEqual("3 of A's for 130", promotion.Name);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\t")]
        [TestCase("\n")]
        public void NitemForFixedPricePromotion_for_invalid_SKU_should_throw_ArgumentException(string sku)
        {
            Assert.Throws<ArgumentException>(() => new NitemForFixedPricePromotion(sku, 3, 130));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void NitemForFixedPricePromotion_for_invalid_numberOfItems_should_throw_ArgumentException(int numberOfItems)
        {
            Assert.Throws<ArgumentException>(() => new NitemForFixedPricePromotion("A", numberOfItems, 130));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void NitemForFixedPricePromotion_for_invalid_fixedPrice_should_throw_ArgumentException(int fixedPrice)
        {
            Assert.Throws<ArgumentException>(() => new NitemForFixedPricePromotion("A", 3, fixedPrice));
        }

        [Test]
        public void NitemForFixedPricePromotion_IsApplicable_for_empty_cart_should_return_false()
        {
            var promotion = new NitemForFixedPricePromotion("A", 3, 130);
            Assert.False(promotion.IsApplicable(null));
            Assert.False(promotion.IsApplicable(new Cart()));
        }

        [Test]
        public void CombinedItemFixedPricePromotion_for_valid_data_should_create_instance()
        {
            var promotion = new CombinedItemFixedPricePromotion(new List<string> { "C", "D" }, 30);
            Assert.NotNull(promotion);
            Assert.AreEqual(new List<string> { "C", "D" }, promotion.SKUs);
            Assert.AreEqual(30, promotion.FixedPrice);
            Assert.AreEqual("C & D for 30", promotion.Name);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\t")]
        [TestCase("\n")]
        public void CombinedItemFixedPricePromotion_for_invalid_SKUs_should_throw_ArgumentException(string sku)
        {
            Assert.Throws<ArgumentException>(() => new CombinedItemFixedPricePromotion(sku.Split(" ").ToList(), 30));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void CombinedItemFixedPricePromotion_for_invalid_fixedPrice_should_throw_ArgumentException(int fixedPrice)
        {
            Assert.Throws<ArgumentException>(() => new CombinedItemFixedPricePromotion(new List<string> { "C", "D" }, fixedPrice));
        }

        [Test]
        public void CombinedItemFixedPricePromotion_IsApplicable_for_empty_cart_should_return_false()
        {
            var promotion = new CombinedItemFixedPricePromotion(new List<string>{ "C", "D" }, 30);
            Assert.False(promotion.IsApplicable(null));
            Assert.False(promotion.IsApplicable(new Cart()));
        }
    }
}
