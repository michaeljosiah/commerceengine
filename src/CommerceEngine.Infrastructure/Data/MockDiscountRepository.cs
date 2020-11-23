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
                    Id = Guid.Parse("E1D078F9-322B-42A4-BA1B-8C761DF4ADA2") ,
                    DiscountAmount = 10,
                    DiscountType = Core.Enums.DiscountType.AssignedToProduct,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.Now.AddDays(7),
                    IsPercentage = true,
                    Name = "Apples 10% off",
                    ProductId = Guid.Parse("F93F6133-98EB-407B-9F4A-93ACEA13CCC0")
                },
                new Discount
                {
                    Id = Guid.Parse("F4AD16A0-AE90-42D8-9528-8D5FAE49B7D8"),
                    DiscountAmount = 10,
                    DiscountType = Core.Enums.DiscountType.AssignedToProduct,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.Now.AddDays(7),
                    IsPercentage = true,
                    Name = "Buy 2 cans of Bean and get 50% off loaf of bread",
                    ProductId = Guid.Parse("532580DA-14CB-470B-B616-703E8451A3E8"),
                    DiscountRules =new List<DiscountRule>
                    {
                        new DiscountRule
                        {
                            RuleName = "MinimumProductSkuCount",
                            DiscountId = Guid.Parse("F4AD16A0-AE90-42D8-9528-8D5FAE49B7D8"),
                            Id = Guid.Parse("C93930FF-2419-4FC8-923B-F7E8FD3F4B64"),
                            RuleValue = "BE06C990-8162-4B6E-83FB-E1F835E627D2",
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
