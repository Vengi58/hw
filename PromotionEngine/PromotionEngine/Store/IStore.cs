using PromotionEngine.Items;
using PromotionEngine.PromotionRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Store
{
    public interface IStore
    {
        public Store AddSKUitem(SKUitem item);
        public Store AddPromotions(List<PromotionRule> promotions);
        public Store AddPromotion(PromotionRule promotion);
        public Store AddPromotion(string promotion);
        public Store AddItemToCart(string itemSKU);
        public void DeletePromotion(string promotion);
        public Store EmptyCart();
        public Store Checkout();
        public void DeleteItemFromCart(string sku);
        public float GetCartTotal();
        public List<SKUitem> GetSKUitems();
        public void UpdateSKUitemUnitPrice(string sku, float price);
        public void DeleteSKUitem(string sku);
        public List<PromotionRule> GetPromotions();
        public List<SKUitem> GetAllItems();
        public SKUitem GetItem(string sku);
        public Cart GetCart();

    }
}
