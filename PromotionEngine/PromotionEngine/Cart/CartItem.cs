using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Items
{
    public class CartItem
    {
        public SKUitem Item { get; set; }
        public bool PromotionApplied { get; set; }
        public float FinalPrice { get; set; }

    }
}
