using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceEngine.Application.Model
{
    public class BasketItemDto
    {
        public Guid Id { get; set; }
        public Guid BasketId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
