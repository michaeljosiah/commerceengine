using CommerceEngine.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using CommerceEngine.Application.Interfaces;
using CommerceEngine.Application.Services;
using CommerceEngine.Core.Validators;
using CommerceEngine.Infrastructure.Data;

namespace CommerceEngine.PriceCalculator
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please supply the correct parameters e.g. PriceCalculator Apples Milk Bread.");
                Console.WriteLine("Press Enter to quit the application");
                Console.ReadLine();
                return;
            }
            RegisterServices();
            var calculatorService = (CalculatorService)_serviceProvider.GetService(typeof(CalculatorService));
            calculatorService.Execute(args);
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IDiscountRuleValidator,MinimumProductSkuCountValidator>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<CalculatorService>();
            services.AddSingleton<IDiscountRepository, MockDiscountRepository>();
            services.AddSingleton<IBasketRepository, MockBasketRepository>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductRepository, MockProductRepository>();
            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
