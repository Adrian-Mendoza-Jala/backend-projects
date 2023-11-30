using System;
using System.Collections.Generic;

namespace Class_7
{

    class Program
    {
        static void Main(string[] args)
        {
            DataStorage<int> intStorage = new DataStorage<int>();
            intStorage.Add(10);
            intStorage.Add(20);
            intStorage.Add(30);
            intStorage.Add(40);
            intStorage.Add(50);
            intStorage.Add(100);
            Console.WriteLine("Int Storage:");
            intStorage.DisplayAll();

            DataStorage<SimpleClass> classStorage = new DataStorage<SimpleClass>();
            classStorage.Add(new SimpleClass());
            classStorage.Add(new SimpleClass());
            Console.WriteLine("\nClass Storage:");
            classStorage.DisplayAll();
        }
    }
}