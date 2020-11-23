using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Core.Entities
{
    public class DiscountRule : IEntity
    {
        public int Id { get; set; }
        public int DiscountId { get; set; }
        public string RuleName { get; set; }
        public string RuleValue { get; set; }
        public string RuleValue2 { get; set; }
    }
}
