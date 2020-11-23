using System;
using System.Collections.Generic;
using System.Text;
using CommerceEngine.Core.Enums;
using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Core.Entities
{
    public class Discount : IAggregateRoot
    {
        public Guid Id { get; set; }
        public DiscountType DiscountType { get; set; }
        public string Name { get; set; }
        public bool IsPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<DiscountRule> DiscountRules = new List<DiscountRule>();
        public Guid ProductId;

    }

    
}
