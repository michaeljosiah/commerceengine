using CommerceEngine.Application.Interfaces;
using System;
using System.Linq;
using CommerceEngine.Core.Entities;
using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.PriceCalculator
{
    public class CalculatorService
    {
        private readonly IBasketService _basketService;
        private readonly IProductRepository _productRepository;

        public CalculatorService(IBasketService basketService, IProductRepository productRepository)
        {
            _basketService = basketService;
            _productRepository = productRepository;
        }

        public void Execute(string[] args)
        {
           var basket = _basketService.CreateBasket();
           foreach (var productName in args.ToList())
           {
               var product = _productRepository.GetProductByName(productName);
               var quantity = 1;
               if (product == null)
               {
                   throw new Exception($"Unknown product name {productName} passed as an argument.");
               }

               if (product.Name.Equals("Beans")) quantity = 2;
               _basketService.AddItemToBasket(basket.Id,product.Id,product.Price,quantity);
           }
           _basketService.ApplyDiscounts(basket.Id);
           PrintBasket(basket);
           Console.ReadLine();
        }

        private void PrintBasket(Basket basket)
        {
            Console.WriteLine($"Subtotal: £{basket.SubTotal}");
            var discountText = string.IsNullOrEmpty(basket.DiscountText)
                ? "(No offers available)"
                : $"{basket.DiscountText} : -{basket.DiscountAmount:0.00}";
            Console.WriteLine($"{discountText}");
            Console.WriteLine($"Total: £{basket.Total:0.00}");
        }
    }
}
