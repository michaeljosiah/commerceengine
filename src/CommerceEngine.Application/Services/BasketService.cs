using System;
using System.Collections.Generic;
using System.Linq;
using CommerceEngine.Application.Exceptions;
using CommerceEngine.Application.Interfaces;
using CommerceEngine.Application.Model;
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
        public BasketDto CreateBasket()
        {
            var basket = new Basket();
            _basketRepository.Insert(basket);
            return MapBasketToBasketDto(basket);
        }
        public BasketDto AddItemToBasket(Guid basketId, Guid productId, decimal price, int quantity = 1)
        {
            var basket = _basketRepository.GetBasketById(basketId);
            if(basket == null)throw new BasketNotFoundException(basketId.ToString());

            basket.AddItem(productId,price,quantity);
            return MapBasketToBasketDto(basket);
        }

        public BasketDto ApplyDiscounts(Guid basketId)
        {
            var basket = _basketRepository.GetBasketById(basketId);
            if (basket == null) throw new BasketNotFoundException(basketId.ToString());

            var discounts = _discountRepository.GetAvailabileDiscounts(DateTime.Now, DateTime.Now.AddDays(7));
            if(discounts.Any()) basket.ApplyDiscount(discounts.First());
            return MapBasketToBasketDto(basket);
        }

        private BasketDto MapBasketToBasketDto(Basket basket)
        {
            return new BasketDto
            {
                Id = basket.Id,
                DiscountAmount = basket.DiscountAmount,
                SubTotal = basket.SubTotal,
                DiscountText = basket.DiscountText,
                Total = basket.Total,
                Items = basket.Items.Select(item => new BasketItemDto
                {
                    ProductId = item.ProductId,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    BasketId = item.BasketId,
                    Id = item.Id
                }).ToList()
            };
        }

    }
}
