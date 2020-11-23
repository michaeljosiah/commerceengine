using System;
using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Core.Entities
{
    public class DiscountRule : IEntity
    {
        public Guid Id { get; set; }
        public Guid DiscountId { get; set; }
        public string RuleName { get; set; }
        public string RuleValue { get; set; }
        public string RuleValue2 { get; set; }
    }
}
