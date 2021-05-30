using PromotionEngine.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.PromotionRules
{
    public class CombinedItemFixedPricePromotion : PromotionRule
    {
        public List<string> SKUs { get; }
        public int FixedPrice { get; }
        public CombinedItemFixedPricePromotion(List<string> skus, int fixedPrice)
        {
            if (skus == null || skus.Count() < 2 || skus.Any(s => string.IsNullOrWhiteSpace(s))) throw new ArgumentException("Invalid or missing SKUs! At least 2 SKU must be provided for this promotion");
            if (fixedPrice <= 0) throw new ArgumentException("Invalid number for fixed price in promotion rule! It must be grater than zero!");

            SKUs = skus;
            FixedPrice = fixedPrice;
        }

        public override void Execute(Cart cart)
        {
            while (IsApplicable(cart))
            {
                var unusedSKUs = new List<string>(SKUs);

                foreach (var item in cart.Items.Where(i => !i.PromotionApplied))
                {
                    if (unusedSKUs.Contains(item.Item.ID))
                    {
                        item.FinalPrice = FixedPrice / SKUs.Count;
                        item.PromotionApplied = true;
                        unusedSKUs.Remove(item.Item.ID);
                    }
                }
            }
        }

        public override bool IsApplicable(Cart cart)
        {
            if (IsEmptyCart(cart)) return false;

            var cartItemsWithoutPromotion = cart.Items
                .Where(i => !i.PromotionApplied);
            var applicable = true;
            foreach (var sku in SKUs)
            {
                applicable &= cartItemsWithoutPromotion.Any(i => sku.Equals(i.Item.ID));
            }
            return applicable;
        }

        public override string ToString()
        {
            return $"{string.Join(" & ", SKUs)} for {FixedPrice}";
        }
    }
}
