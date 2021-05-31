using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngineWebApp.DTO
{
    public class CartItemDTO
    {
        public SKUitemDTO Item { get; set; }
        public bool PromotionApplied { get; set; }
        public float FinalPrice { get; set; }
    }
}
