using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommerceEngine.Core.Entities;

namespace CommerceEngine.Application.Interfaces
{
    public interface IBasketService
    {
        Basket CreateBasket();
        void AddItemToBasket(Guid basketId, Guid productId, decimal price, int quantity = 1);
    }
}
