using PromotionEngine.Items;
using PromotionEngine.PromotionRules;
using System;
using System.Collections.Generic;

namespace PromotionEngineTests
{
    public static class TestData
    {
        public static readonly SKUitem a = new("A", 50);
        public static readonly SKUitem b = new("B", 30);
        public static readonly SKUitem c = new("C", 20);
        public static readonly SKUitem d = new("D", 15);
        public static readonly NitemForFixedPricePromotion pr1 = new("A", 3, 130);
        public static readonly NitemForFixedPricePromotion pr2 = new("B", 2, 45);
        public static readonly CombinedItemFixedPricePromotion pr3 = new(new List<string> { "C", "D" }, 30);
        public static readonly List<PromotionRule> promotions = new() { pr1, pr2, pr3 };
        public static readonly string CandDfor30 = "C & D for 30";
        public static readonly string ThreeAfor130 = "3 of A's for 130";
    }
}
