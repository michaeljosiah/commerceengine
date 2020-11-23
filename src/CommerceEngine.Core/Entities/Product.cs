using System;
using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Core.Entities
{
    public class Product : IAggregateRoot
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }

    }
}
