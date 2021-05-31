using PromotionEngine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
