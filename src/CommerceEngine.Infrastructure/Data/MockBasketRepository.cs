using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommerceEngine.Core.Entities;
using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Infrastructure.Data
{
    public class MockBasketRepository : IBasketRepository
    {
        private List<Basket> _baskets;

        public MockBasketRepository()
        {
           _baskets = new List<Basket>();
        }



        public Basket GetBasketById(Guid basketId)
        {
            return _baskets.FirstOrDefault(x => x.Id == basketId);
        }

        public Basket Insert(Basket basket)
        {
            _baskets.Add(basket);
            return basket;
        }
    }
}
