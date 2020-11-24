using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceEngine.Core.Exceptions
{
    public class BasketItemNotFoundException : Exception
    {
        public BasketItemNotFoundException(string basketItemId) : 
            base($"Basket Item {basketItemId} not found.")
        {
                
        }
    }
}
