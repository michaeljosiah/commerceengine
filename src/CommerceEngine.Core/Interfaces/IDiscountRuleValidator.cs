using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommerceEngine.Core.Entities;

namespace CommerceEngine.Core.Interfaces
{
    public interface IDiscountRuleValidator
    {
        bool IsValid(Basket basket, DiscountRule discountRule);
    }
}
