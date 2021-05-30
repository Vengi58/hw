using PromotionEngine.Items;
using System;
using System.Linq;

namespace PromotionEngine.PromotionRules
{
    public class NitemForFixedPricePromotion : PromotionRule
    {
        public string SKU { get; }
        public int NumberOfItems { get; }
        public int FixedPrice { get; }

        public NitemForFixedPricePromotion(string sku, int numberOfItems, int fixedPrice)
        {
            if (string.IsNullOrWhiteSpace(sku)) throw new ArgumentException("Invalid or missing SKU!");
            if (numberOfItems <= 0) throw new ArgumentException("Invalid number of items in promotion rule! It must be grater than zero!");
            if (fixedPrice <= 0) throw new ArgumentException("Invalid number for fixed price in promotion rule! It must be grater than zero!");
            
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
            return !IsEmptyCart(cart) &&
                cart.Items
                .Where(i => !i.PromotionApplied && SKU.Equals(i.Item.ID))
                .Count() >= NumberOfItems;
        }

        public override string ToString()
        {
            return $"{NumberOfItems} of {SKU}'s for {FixedPrice}";
        }
    }
}
