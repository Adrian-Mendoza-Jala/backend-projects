using Class_6.Class_6;
using System;
using System.Collections.Generic;

namespace Class_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicles = new List<Vehicle>
            {
                new Car("Toyota", "Corolla"),
                new Motorcycle("Harley-Davidson", "Street 750"),
                new Helicopter("Bell", "777")
            };

            foreach (var vehicle in vehicles)
            {
                vehicle.Start();
                vehicle.Stop();
            }
        }
    }
}
