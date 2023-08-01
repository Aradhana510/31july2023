using System;

namespace Assignment19_Part2
{
    public delegate T Operation<T>(T num1, T num2);

    internal class Program
    {
        static T Add<T>(T num1, T num2)
        {
            return (dynamic)num1 + (dynamic)num2;
        }

        static T Subtract<T>(T num1, T num2)
        {
            return (dynamic)num1 - (dynamic)num2;
        }

        static T Multiply<T>(T num1, T num2)
        {
            return (dynamic)num1 * (dynamic)num2;
        }

        static T Divide<T>(T num1, T num2)
        {
            if (num2.Equals(default(T)))
            {
                throw new ArgumentException("Cannot divide by zero.");
            }
            return (dynamic)num1 / (dynamic)num2;
        }

        static void Main(string[] args)
        {
            Operation<double> addDelegate = Add;
            Operation<double> subtractDelegate = Subtract;
            Operation<double> multiplyDelegate = Multiply;
            Operation<double> divideDelegate = Divide;

            Console.WriteLine("Enter the first value:");
            double value1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second value:");
            double value2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Result: {addDelegate(value1, value2)}");
                        break;
                    case 2:
                        Console.WriteLine($"Result: {subtractDelegate(value1, value2)}");
                        break;
                    case 3:
                        Console.WriteLine($"Result: {multiplyDelegate(value1, value2)}");
                        break;
                    case 4:
                        Console.WriteLine($"Result: {divideDelegate(value1, value2)}");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Invalid input or operation.");
            }
        }
    }
}
