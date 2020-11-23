using System;
using System.Collections.Generic;
using System.Text;
using CommerceEngine.Core.Entities;

namespace CommerceEngine.Core.Interfaces
{
    public interface IBasketRepository
    {
        Basket GetBasketById(Guid basketId);
        Basket Insert(Basket basket);
    }
}
