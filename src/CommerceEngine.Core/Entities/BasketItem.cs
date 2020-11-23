﻿using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Core.Entities
{
    public class BasketItem : IEntity
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}