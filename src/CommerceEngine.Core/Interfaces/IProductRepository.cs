using System;
using System.Collections.Generic;
using System.Text;
using CommerceEngine.Core.Entities;

namespace CommerceEngine.Core.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(Guid productId);
    }
}
