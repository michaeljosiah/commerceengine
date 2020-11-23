using System;
using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Core.Entities
{
    public class BasketItem : IEntity
    {
        public Guid Id { get; set; }
        public Guid BasketId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
