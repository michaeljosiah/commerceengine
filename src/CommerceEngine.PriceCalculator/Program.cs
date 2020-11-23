using System;
using System.Linq;

namespace CommerceEngine.PriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var tmpArgs = args.ToList();
            foreach (var tmp in tmpArgs)
            {
                Console.WriteLine(tmp);
            }
        }
    }
}
