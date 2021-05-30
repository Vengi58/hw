using PromotionEngine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.PromotionRules
{
    public abstract class PromotionRule
    {
        public string Name { get; set; }
        public abstract bool IsApplicable(Cart cart);
        public abstract void Execute(Cart cart);

    }
}
