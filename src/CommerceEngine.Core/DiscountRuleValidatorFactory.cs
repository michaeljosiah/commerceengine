using System;
using System.Collections.Generic;
using System.Text;
using CommerceEngine.Core.Enums;
using CommerceEngine.Core.Interfaces;
using CommerceEngine.Core.Validators;

namespace CommerceEngine.Core
{
    public static class DiscountRuleValidatorFactory
    {
        public static IDiscountRuleValidator GetDiscountRuleValidator(DiscountRuleType discountRuleType)
        {
            switch (discountRuleType)
            {
                case DiscountRuleType.MinimumProductSkuCount:
                    return new MinimumProductSkuCountValidator();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
