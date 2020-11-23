using System;
using System.Collections.Generic;
using System.Text;
using CommerceEngine.Core.Entities;

namespace CommerceEngine.Core.Interfaces
{
    public interface IBasketRepository
    {
        Basket GetBasketById(int basketId);
    }
}
