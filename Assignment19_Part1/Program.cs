using System;

namespace Assignment19_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Ask the user to input two integers.
            Console.WriteLine("Enter the Number1:");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Number2:");
            int num2 = int.Parse(Console.ReadLine());

            // Step 2: Choose the options by the user.
            Console.WriteLine("Choose an arithmetic operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");

            int choice = int.Parse(Console.ReadLine());

            // Step 3: Define lambda expressions for each arithmetic operation.
            Func<int, int, int> addDelegate = (x, y) => x + y;
            Func<int, int, int> subtractDelegate = (x, y) => x - y;
            Func<int, int, int> multiplyDelegate = (x, y) => x * y;
            Func<int, int, int> divideDelegate = (x, y) =>
            {
                if (y == 0)
                {
                    throw new ArgumentException("Cannot divide by zero.");
                }
                return x / y;
            };

            // Step 4: Call the corresponding lambda expression based on the user's choice.
            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Addition of given Numbers is {addDelegate(num1, num2)}");
                    break;
                case 2:
                    Console.WriteLine($"Subtraction of given Numbers is {subtractDelegate(num1, num2)}");
                    break;
                case 3:
                    Console.WriteLine($"Multiplication of given Numbers is {multiplyDelegate(num1, num2)}");
                    break;
                case 4:
                    try
                    {
                        Console.WriteLine($"Division of given Numbers is {divideDelegate(num1, num2)}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            Console.ReadLine();
        }
    }
}
