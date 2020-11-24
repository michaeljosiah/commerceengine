using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommerceEngine.Application.Model;

namespace CommerceEngine.Application.Interfaces
{
    public interface IBasketService
    {
        BasketDto CreateBasket();
        void AddItemToBasket(Guid basketId, Guid productId, decimal price, int quantity = 1);
        void ApplyDiscounts(Guid basketId);
    }
}
