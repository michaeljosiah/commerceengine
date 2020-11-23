using System;
using System.Linq;
using CommerceEngine.Application.Interfaces;
using CommerceEngine.Core.Entities;
using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Application.Services
{
    public class BasketService :IApplicationService, IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IDiscountRepository _discountRepository;

        public BasketService(IBasketRepository basketRepository, IDiscountRepository discountRepository)
        {
            _basketRepository = basketRepository;
            _discountRepository = discountRepository;
        }
        public Basket CreateBasket()
        {
            var basket = new Basket();
            _basketRepository.Insert(basket);
            return basket;
        }
        public void AddItemToBasket(Guid basketId, Guid productId, decimal price, int quantity = 1)
        {
            var basket = _basketRepository.GetBasketById(basketId);
            basket.AddItem(productId,price,quantity);

        }

        public void ApplyDiscounts(Guid basketId)
        {
            var basket = _basketRepository.GetBasketById(basketId);
            var discounts = _discountRepository.GetAvailabileDiscounts(DateTime.Now, DateTime.Now.AddDays(7));
            if(discounts.Any()) basket.ApplyDiscount(discounts.First());
        }

    }
}
