using CommerceEngine.Application.Model;

namespace CommerceEngine.Application.Interfaces
{
    public interface IProductService
    {
        ProductDto GetProductByName(string productName);
    }
}
