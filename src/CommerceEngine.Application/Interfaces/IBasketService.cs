using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommerceEngine.Application.Interfaces
{
    public interface IBasketService
    {
        Task AddItemToBasket(int basketId, int productId, decimal price, int quantity = 1);
    }
}
