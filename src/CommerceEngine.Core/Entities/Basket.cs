using System;
using System.Collections.Generic;
using System.Linq;
using CommerceEngine.Core.Enums;
using CommerceEngine.Core.Interfaces;
using CommerceEngine.Shared.Extensions;

namespace CommerceEngine.Core.Entities
{
    public class Basket : IAggregateRoot
    {
        public Guid Id { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal DiscountAmount { get; set; }
        public string DiscountText { get; set; }
        public List<BasketItem> Items = new List<BasketItem>();

        public Basket()
        {
                
        }
        public void AddItem(int productId, decimal price, int quantity = 1)
        {
            if (Items.All(i => i.ProductId != productId))
            {
                Items.Add(new BasketItem()
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = price
                });
                CalculateTotals();
                return;
            }
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null) existingItem.Quantity += quantity;
            CalculateTotals();
        }


        public void ApplyDiscount(Discount discount)
        {
            if (discount.DiscountRules.Any())
            {
                foreach (var discountRule in discount.DiscountRules)
                {
                    var validator = DiscountRuleValidatorFactory.GetDiscountRuleValidator(discountRule.RuleName.ToEnum<DiscountRuleType>());
                    var result = validator.IsValid(this,discountRule);
                    if (result == false) return;
                }
            }
            
            decimal amount = 0;
            if (discount.DiscountType == DiscountType.AssignedToProduct)
            {
                amount = discount.IsPercentage ? (discount.DiscountAmount /100) * 5 : discount.DiscountAmount;
            }

            DiscountAmount = amount;
            DiscountText = discount.Name;
            CalculateTotals();
        }

        public void CalculateTotals()
        {
            SubTotal = Items.Sum(x => x.Price * x.Quantity);
            Total = SubTotal - DiscountAmount;
        }
    }
}
