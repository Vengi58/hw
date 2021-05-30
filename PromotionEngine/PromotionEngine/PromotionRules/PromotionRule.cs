using PromotionEngine.Items;

namespace PromotionEngine.PromotionRules
{
    public abstract class PromotionRule
    {
        public string Name { get { return ToString(); }}
        public abstract bool IsApplicable(Cart cart);
        public abstract void Execute(Cart cart);
        protected static bool IsEmptyCart(Cart cart)
        {
            return (cart == null) || cart.Items == null || cart.Items.Count == 0;
        }
    }
}
