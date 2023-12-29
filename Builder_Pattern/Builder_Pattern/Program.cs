using System;

namespace Builder_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ProductBuilder();
            var product = builder
                .SetName("Example")
                .SetDescription("This is an example product.")
                .SetPrice(100)
                .Build();

            Console.WriteLine(product.ToString());
        }
    }
}