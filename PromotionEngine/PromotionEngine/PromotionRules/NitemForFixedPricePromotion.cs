using PromotionEngine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.PromotionRules
{
    public class NitemForFixedPricePromotion : PromotionRule
    {
        public string SKU { get; }
        public int NumberOfItems { get; }
        public int FixedPrice { get; }

        public NitemForFixedPricePromotion(string sku, int numberOfItems, int fixedPrice)
        {
            SKU = sku;
            NumberOfItems = numberOfItems;
            FixedPrice = fixedPrice;
        }

        public override void Execute(Cart cart)
        {
            var discountItemPrice = FixedPrice / NumberOfItems;
            var residue = 0f;

            while (IsApplicable(cart))
            {
                residue = FixedPrice - NumberOfItems * discountItemPrice;
                foreach (var item in cart.Items.Where(i => !i.PromotionApplied && SKU.Equals(i.Item.ID)).Take(NumberOfItems))
                {
                    item.FinalPrice = discountItemPrice + residue;
                    item.PromotionApplied = true;
                    residue = 0f;
                }
            }
        }

        public override bool IsApplicable(Cart cart)
        {
            return cart.Items
                .Where(i => !i.PromotionApplied && SKU.Equals(i.Item.ID))
                .Count() >= NumberOfItems;
        }
    }
}
