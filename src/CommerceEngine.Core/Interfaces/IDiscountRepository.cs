using System;
using System.Collections.Generic;
using System.Text;
using CommerceEngine.Core.Entities;

namespace CommerceEngine.Core.Interfaces
{
    public interface IDiscountRepository
    {
        List<Discount> GetAvailabileDiscounts(DateTime startDate, DateTime endDate);
    }
}
