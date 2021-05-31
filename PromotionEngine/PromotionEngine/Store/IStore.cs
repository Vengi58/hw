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
        public Store AddItemToCart(string itemSKU);
        public Store EmptyCart();
        public Store Checkout();
        public List<SKUitem> GetSKUitems();
        public void UpdateSKUitemUnitPrice(string sku, float price);
        public void DeleteSKUitem(string sku);
    }
}
