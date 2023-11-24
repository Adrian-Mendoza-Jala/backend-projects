using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static List<string> textCommands = new List<string>();
        static List<int> numericCommands = new List<int>();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Input Commands");
                Console.WriteLine("2. Show categories");
                Console.WriteLine("3. Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        InputCommands();
                        break;
                    case "2":
                        ShowCategories();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;
                }
            }
        }

        static void InputCommands()
        {
            Console.WriteLine("Enter your command:");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                bool isNumeric = int.TryParse(input, out int numericCommand);
                if (isNumeric)
                {
                    numericCommands.Add(numericCommand);
                    Console.WriteLine("Numeric command added.");
                }
                else
                {
                    textCommands.Add(input);
                    Console.WriteLine("Text command added.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid command.");
            }
        }


        static void ShowCategories()
        {
            Console.WriteLine("Text Commands:");
            foreach (var text in textCommands)
            {
                Console.WriteLine(text);
            }

            Console.WriteLine("\nNumeric Commands:");
            foreach (var number in numericCommands)
            {
                Console.WriteLine(number);
            }
        }
    }
}
