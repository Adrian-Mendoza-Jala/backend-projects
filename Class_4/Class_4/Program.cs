using System;

namespace Class_4
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Adding 10 and 20: " + AddCalculator.AddValues(10, 20));
                Console.WriteLine("Adding 3.14 and 2.56: " + AddCalculator.AddValues(3.14, 2.56));
                Console.WriteLine("Concatenating 'Hello' and 'World': " + AddCalculator.AddValues("Hello", "World"));
                Console.WriteLine("Adding 'Hello' and 10: " + AddCalculator.AddValues("Hello", 10));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error: " + error.Message);
            }
        }
    }
}
