using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngineWebApp.DTO
{
    public class CartDTO
    {
        public List<CartItemDTO> Items { get; set;  }

        public float TotalPrice { get; set; }
    }
}
