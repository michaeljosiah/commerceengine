using CommerceEngine.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using CommerceEngine.Core.Validators;
using CommerceEngine.Infrastructure.Data;

namespace CommerceEngine.PriceCalculator
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            var tmpArgs = args.ToList();
            foreach (var tmp in tmpArgs)
            {
                Console.WriteLine(tmp);
            }
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IDiscountRuleValidator,MinimumProductSkuCountValidator>();
            services.AddSingleton<IDiscountRepository, MockDiscountRepository>();
            services.AddSingleton<IBasketRepository, MockBasketRepository>();
            services.AddSingleton<IProductRepository, MockProductRepository>();
            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
