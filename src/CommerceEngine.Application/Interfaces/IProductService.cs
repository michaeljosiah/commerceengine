using System;
using System.Collections.Generic;
using System.Text;
using CommerceEngine.Core.Entities;

namespace CommerceEngine.Application.Interfaces
{
    public interface IProductService
    {
        Product GetProductByName(string productName);
    }
}
