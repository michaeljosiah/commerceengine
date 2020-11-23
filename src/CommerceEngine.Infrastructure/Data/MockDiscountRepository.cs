using System;
using System.Collections.Generic;
using CommerceEngine.Core.Entities;
using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Infrastructure.Data
{
    public class MockDiscountRepository : IDiscountRepository
    {
        private List<Discount> _discounts;
        public MockDiscountRepository()
        {
            if (_discounts == null)
            {
                InitialiseDiscounts();
            }
        }

        private void InitialiseDiscounts()
        {
            _discounts = new List<Discount>
            {
                new Discount
                {
                    Id = 1,
                    DiscountAmount = 10,
                    DiscountType = Core.Enums.DiscountType.AssignedToProduct,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.Now.AddDays(7),
                    IsPercentage = true,
                    Name = "Apples 10% off",
                    ProductId = 4
                },
                new Discount
                {
                    Id = 2,
                    DiscountAmount = 10,
                    DiscountType = Core.Enums.DiscountType.AssignedToProduct,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.Now.AddDays(7),
                    IsPercentage = true,
                    Name = "Buy 2 cans of Bean and get 50% off loaf of bread",
                    ProductId = 2,
                    DiscountRules =new List<DiscountRule>
                    {
                        new DiscountRule
                        {
                            RuleName = "MinimumProductSkuCount",
                            DiscountId = 2,
                            Id = 1,
                            RuleValue = "1",
                            RuleValue2 = "2"
                        }
                    }
                }
            };
        }
        public List<Discount> GetAvailabileDiscounts(DateTime startDate, DateTime endDate)
        {
            return _discounts;
        }
    }
}
