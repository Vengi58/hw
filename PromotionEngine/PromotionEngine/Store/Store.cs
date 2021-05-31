using PromotionEngine.Items;
using PromotionEngine.PromotionRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PromotionEngine.Store
{
    public class Store : IStore
    {
        public Cart Cart { get; private set; }
        public List<PromotionRule> Promotions { get; }
        public List<SKUitem> Items { get; }
        public Store()
        {
            Cart = new Cart();
            Promotions = new List<PromotionRule>();
            Items = new List<SKUitem>();
        }

        public Store AddSKUitem(SKUitem item)
        {
            if( item != null ) Items.Add(item);
            return this;
        }

        public Store AddPromotions(List<PromotionRule> promotions)
        {
            if ( promotions != null && promotions.Count > 0 )Promotions.AddRange(promotions);
            return this;
        }

        public Store AddPromotion(PromotionRule promotion)
        {
            if ( promotion != null ) Promotions.Add(promotion);
            return this;
        }
        public Store AddPromotion(string promotion)
        {
            if (Regex.IsMatch(promotion, @"^\d"))
            {
                AddPromotion(promotion.ToNitemForFixedPricePromotion());
            }
            else
            {
                AddPromotion(promotion.ToCombinedItemFixedPricePromotion());
            }
            return this;
        }
        public void DeletePromotion(string promotion)
        {
            var promotionIndex = Promotions.FindIndex(p => promotion.Equals(p.ToString()));
            if (promotionIndex == -1) throw new ArgumentException("Promotion not found!");
            Promotions.RemoveAt(promotionIndex);
        }

        public Store AddItemToCart(string itemSKU)
        {
            if (!IsValidSKU(itemSKU)) throw new ArgumentException("SKU not found!");

            if ( !string.IsNullOrWhiteSpace(itemSKU) ) Cart.AddItem(Items.First(i => itemSKU.Equals(i.ID)));
            return this;
        }

        public Store EmptyCart()
        {
            Cart = new Cart();
            return this;
        }

        public Store Checkout()
        {
            Promotions.ForEach(p => { if (p.IsApplicable(Cart)) p.Execute(Cart); });
            return this;
        }

        public List<SKUitem> GetSKUitems()
        {
            return Items;
        }
        public void UpdateSKUitemUnitPrice(string sku, float price)
        {
            if (!IsValidSKU(sku)) throw new ArgumentException("SKU not found!");

            foreach (var item in Items)
            {
                if(sku.Equals(item.ID))
                {
                    item.UpdateUnitPrice(price);
                }
            }
        }

        public void DeleteSKUitem(string sku)
        {
            if (!IsValidSKU(sku)) throw new ArgumentException("SKU not found!");

            Items.RemoveAt(Items.FindIndex(i => sku.Equals(i.ID)));
        }

        public List<PromotionRule> GetPromotions()
        {
            return Promotions;
        }

        public List<SKUitem> GetAllItems()
        {
            return Items;
        }

        public SKUitem GetItem(string sku)
        {
            if (!IsValidSKU(sku)) throw new ArgumentException("SKU not found!");

            return Items.First(i => sku.Equals(i.ID));
        }

        public void DeleteItemFromCart(string sku)
        {
            if (!IsValidSKU(sku)) throw new ArgumentException("SKU not found!");
            Cart.RemoveItem(sku);
        }

        public float GetCartTotal()
        {
            return Cart.TotalPrice;
        }

        public Cart GetCart()
        {
            return Cart;
        }

        private bool IsValidSKU(string sku)
        {
            return Items.Any(i => sku.Equals(i.ID));
        }
    }
}
