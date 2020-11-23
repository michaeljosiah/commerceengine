using System;
using System.Collections.Generic;
using System.Text;
using CommerceEngine.Core.Entities;
using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Infrastructure.Data
{
    public class MockBasketRepository : IBasketRepository
    {

        public MockBasketRepository()
        {
            
        }
        public Basket GetBasketById(int basketId)
        {
            throw new NotImplementedException();
        }
    }
}
