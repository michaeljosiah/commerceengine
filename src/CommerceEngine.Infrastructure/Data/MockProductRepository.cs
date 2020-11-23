using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommerceEngine.Core.Entities;
using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Infrastructure.Data
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _products;
        public MockProductRepository()
        {
            if (_products == null)
            {
                InitialiseProducts();
            }
        }

        private void InitialiseProducts()
        {
            _products = new List<Product>
            {
                new Product {Id = 1, Name = "Beans", Price = 0.65M, ShortDescription = "Beans"},
                new Product {Id = 2, Name = "Bread", Price = 0.80M, ShortDescription = "Bread"},
                new Product {Id = 3, Name = "Milk", Price = 1.30M, ShortDescription = "Milk"},
                new Product {Id = 4, Name = "Apples", Price = 1.00M, ShortDescription = "Apples"}
            };
        }

        public Product GetProductById(int productId)
        {
            return _products.FirstOrDefault(x=> x.Id == productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
    }
}
