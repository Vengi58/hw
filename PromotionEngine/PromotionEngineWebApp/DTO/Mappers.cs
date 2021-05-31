using PromotionEngine.Items;
using System.Linq;

namespace PromotionEngineWebApp.DTO
{
    public static class Mappers
    {
        public static SKUitemDTO ToDTO(this SKUitem skuItem)
        {
            return new SKUitemDTO { ID = skuItem.ID, UnitPrice = skuItem.UnitPrice };
        }

        public static SKUitem ToDAO(this SKUitemDTO sKUitemDTO)
        {
            return new SKUitem(sKUitemDTO.ID,sKUitemDTO.UnitPrice);
        }

        public static CartDTO ToDTO(this Cart cart)
        {
            return new CartDTO { Items = cart.Items.Select(i => i.ToDTO()).ToList(), TotalPrice = cart.TotalPrice };

        }
        public static CartItemDTO ToDTO(this CartItem cartItem)
        {
            return new CartItemDTO { Item = cartItem.Item.ToDTO(), FinalPrice = cartItem.FinalPrice, PromotionApplied = cartItem.PromotionApplied };
        }
    }
}
