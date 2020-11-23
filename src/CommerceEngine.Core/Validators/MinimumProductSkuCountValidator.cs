using System;
using System.Linq;
using CommerceEngine.Core.Entities;
using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Core.Validators
{
    public class MinimumProductSkuCountValidator :IDiscountRuleValidator
    {
      

        public bool IsValid(Basket basket, DiscountRule discountRule)
        {
            if (basket.Items.All(x => x.ProductId != Guid.Parse(discountRule.RuleValue)))
            {
                return false;
            }

            var product = basket.Items.Find(x => x.ProductId == Guid.Parse(discountRule.RuleValue));
            if (product.Quantity < Convert.ToInt32(discountRule.RuleValue2))
            {
                return false;
            }

            return true;
        }
    }
}
