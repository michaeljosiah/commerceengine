using System;
using System.Collections.Generic;
using System.Linq;
using CommerceEngine.Core.Enums;
using CommerceEngine.Core.Exceptions;
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
            this.Id = Guid.NewGuid();
        }
        public void AddItem(Guid productId, decimal price, int quantity = 1)
        {
            if (Items.All(i => i.ProductId != productId))
            {
                Items.Add(new BasketItem()
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = price,
                    BasketId = this.Id,
                    Id = Guid.NewGuid()
                });

                CalculateTotals();
                return;
            }
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null) existingItem.Quantity += quantity;
            CalculateTotals();
        }


        public void ApplyDiscount(List<Discount> discounts)
        {
            foreach (var discount in discounts)
            {
                if (discount.DiscountRules.Any())
                {
                    var validDiscountRule = true;
                    foreach (var discountRule in discount.DiscountRules)
                    {
                        var validator = DiscountRuleValidatorFactory.GetDiscountRuleValidator(discountRule.RuleName.ToEnum<DiscountRuleType>());
                        validDiscountRule = validator.IsValid(this, discountRule);
                    }
                    if (!validDiscountRule)continue;
                }
                
                var amount = 0m;
                if (discount.DiscountType == DiscountType.AssignedToProduct)
                {
                    var discountedProduct = this.Items.FirstOrDefault(x => x.ProductId == discount.ProductId);
                    if (discountedProduct == null) continue;
                    amount = discount.IsPercentage ? (discount.DiscountAmount / 100) * discountedProduct.Price : discount.DiscountAmount;
                }
                DiscountAmount += amount;
                DiscountText = discount.Name;
            }
            
            CalculateTotals();
        }

        public void CalculateTotals()
        {
            SubTotal = Items.Sum(x => x.Price * x.Quantity);
            Total = SubTotal - DiscountAmount;
        }

        public void DeleteBasketItem(Guid basketItemId)
        {
            var item = Items.FirstOrDefault(x => x.Id == basketItemId);
            if (item == null) throw new BasketItemNotFoundException(basketItemId.ToString());
            Items.Remove(item);
        }
    }
}
