using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceEngine.Application.Model
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
    }
}
