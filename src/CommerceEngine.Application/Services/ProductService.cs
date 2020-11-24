using CommerceEngine.Application.Interfaces;
using CommerceEngine.Application.Model;
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
        public ProductDto GetProductByName(string productName)
        {
            var product = _productRepository.GetProductByName(productName);
            return new ProductDto
            {
                Id = product.Id,
                Price = product.Price,
                ShortDescription = product.ShortDescription,
                Name = product.Name
            };
        }
    }
}
