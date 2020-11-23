using System;
using System.Threading.Tasks;
using CommerceEngine.Application.Interfaces;

namespace CommerceEngine.Application.Services
{
    public class BasketService :IApplicationService, IBasketService
    {
        public Task AddItemToBasket(int basketId, int productId, decimal price, int quantity = 1)
        {
            throw new NotImplementedException();
        }
    }
}
