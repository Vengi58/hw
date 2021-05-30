using NUnit.Framework;
using PromotionEngine.PromotionRules;
using System.Collections.Generic;

namespace PromotionEngineTests
{
    public class PromotionRuleExtensionTests
    {
        [Test]
        public void CombinedItemFixedPricePromotionParse()
        {
            var promotionText = "C & D for 30";

            var parsedPromotion = promotionText.ToCombinedItemFixedPricePromotion();

            Assert.NotNull(parsedPromotion);
            Assert.AreEqual(promotionText, parsedPromotion.Name);
            Assert.AreEqual(30, parsedPromotion.FixedPrice);
            Assert.AreEqual(new List<string> { "C", "D" }, parsedPromotion.SKUs);
        }

        [Test]
        public void NitemForFixedPricePromotionParse()
        {
            var promotionText = "3 of A's for 130";

            var parsedPromotion = promotionText.ToNitemForFixedPricePromotion();

            Assert.NotNull(parsedPromotion);
            Assert.AreEqual(promotionText, parsedPromotion.Name);
            Assert.AreEqual(130, parsedPromotion.FixedPrice);
            Assert.AreEqual(3, parsedPromotion.NumberOfItems);
            Assert.AreEqual("A", parsedPromotion.SKU);
        }
    }
}
