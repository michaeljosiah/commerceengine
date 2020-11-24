using System;
using System.Collections.Generic;
using System.Text;
using CommerceEngine.Application.Interfaces;
using CommerceEngine.Core.Entities;
using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product GetProductByName(string productName)
        {
            return _productRepository.GetProductByName(productName);
        }
    }
}
