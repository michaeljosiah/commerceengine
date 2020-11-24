using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceEngine.Application.Model
{
    public class BasketDto
    {
        public Guid Id { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal DiscountAmount { get; set; }
        public string DiscountText { get; set; }
        public List<BasketItemDto> Items = new List<BasketItemDto>();
    }
}
