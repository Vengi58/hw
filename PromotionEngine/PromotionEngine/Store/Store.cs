using PromotionEngine.Items;
using PromotionEngine.PromotionRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Store
{
    public class Store
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
            Items.Add(item);
            return this;
        }

        public Store AddPromotions(List<PromotionRule> promotions)
        {
            Promotions.AddRange(promotions);
            return this;
        }

        public Store AddPromotion(PromotionRule promotion)
        {
            Promotions.Add(promotion);
            return this;
        }

        public Store AddItemToCart(string itemSKU)
        {
            Cart.AddItem(Items.First(i => itemSKU.Equals(i.ID)));
            return this;
        }

        public Store EmptyCart()
        {
            Cart = new Cart();
            return this;
        }

        public Store Checkout()
        {
            foreach (var pr in Promotions)
            {
                if (pr.IsApplicable(Cart))
                {
                    pr.Execute(Cart);
                }
            }
            return this;
        }
    }
}
