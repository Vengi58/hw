using PromotionEngine.Items;

namespace PromotionEngine.PromotionRules
{
    public abstract class PromotionRule
    {
        public string Name
        {
            get { return this.ToString(); }
        }
        public abstract bool IsApplicable(Cart cart);
        public abstract void Execute(Cart cart);

    }
}
