﻿using CommerceEngine.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using CommerceEngine.Application.Model;

namespace CommerceEngine.PriceCalculator
{
    public class CalculatorService
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public CalculatorService(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public void Execute(string[] args)
        {
           var basket = _basketService.CreateBasket();
           var products = GetProductsByNames(args);
           foreach (var product in products)
           {
               basket = _basketService.AddItemToBasket(basket.Id,product.Id,product.Price,1);
           }
           basket = _basketService.ApplyDiscounts(basket.Id);
           PrintBasket(basket);
           Console.ReadLine();
        }

        private IEnumerable<ProductDto> GetProductsByNames(string[] productNames)
        {
            var products = new List<ProductDto>();
            foreach (var productName in productNames.ToList())
            {
                var product = _productService.GetProductByName(productName);
                if (product == null)
                {
                    throw new Exception($"Unknown product name {productName} passed as an argument.");
                }
                products.Add(product);
            }

            return products;
        }

        private void PrintBasket(BasketDto basket)
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
