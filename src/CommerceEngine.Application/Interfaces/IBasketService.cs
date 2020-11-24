using System;
using CommerceEngine.Application.Model;

namespace CommerceEngine.Application.Interfaces
{
    public interface IBasketService
    {
        BasketDto CreateBasket();
        BasketDto AddItemToBasket(Guid basketId, Guid productId, decimal price, int quantity = 1);
        BasketDto ApplyDiscounts(Guid basketId);
    }
}
