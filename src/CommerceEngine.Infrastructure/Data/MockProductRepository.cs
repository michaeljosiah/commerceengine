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
                new Product {Id = Guid.Parse("BE06C990-8162-4B6E-83FB-E1F835E627D2"), Name = "Beans", Price = 0.65M, ShortDescription = "Beans"},
                new Product {Id = Guid.Parse("532580DA-14CB-470B-B616-703E8451A3E8"), Name = "Bread", Price = 0.80M, ShortDescription = "Bread"},
                new Product {Id = Guid.Parse("BE06C990-8162-4B6E-83FB-E1F835E627D2"), Name = "Milk", Price = 1.30M, ShortDescription = "Milk"},
                new Product {Id = Guid.Parse("BE06C990-8162-4B6E-83FB-E1F835E627D2"), Name = "Apples", Price = 1.00M, ShortDescription = "Apples"}
            };
        }

        public Product GetProductById(Guid productId)
        {
            return _products.FirstOrDefault(x=> x.Id.Equals(productId));
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
    }
}
