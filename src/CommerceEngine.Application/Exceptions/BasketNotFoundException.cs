using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceEngine.Application.Exceptions
{
    public class BasketNotFoundException : Exception
    {
        public BasketNotFoundException(string basketId):base($"Basket with the Id {basketId} not found.")
        {
                
        }
    }
}
