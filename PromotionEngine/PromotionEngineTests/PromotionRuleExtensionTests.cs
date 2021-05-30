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
            var parsedPromotion = TestData.CandDfor30.ToCombinedItemFixedPricePromotion();

            Assert.NotNull(parsedPromotion);
            Assert.AreEqual(TestData.CandDfor30, parsedPromotion.Name);
            Assert.AreEqual(30, parsedPromotion.FixedPrice);
            Assert.AreEqual(new List<string> { "C", "D" }, parsedPromotion.SKUs);
        }

        [Test]
        public void NitemForFixedPricePromotionParse()
        {
            var parsedPromotion = TestData.ThreeAfor130.ToNitemForFixedPricePromotion();

            Assert.NotNull(parsedPromotion);
            Assert.AreEqual(TestData.ThreeAfor130, parsedPromotion.Name);
            Assert.AreEqual(130, parsedPromotion.FixedPrice);
            Assert.AreEqual(3, parsedPromotion.NumberOfItems);
            Assert.AreEqual("A", parsedPromotion.SKU);
        }
    }
}
