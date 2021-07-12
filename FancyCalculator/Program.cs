using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A Console Calculator");

            Console.WriteLine("Enter a Number");

            var firstInput = Console.ReadLine().Trim();
            double firstNumber;
            if (!Double.TryParse(firstInput, out firstNumber))
            {
                Console.WriteLine("The first value, {0}, was not a vaild number", firstNumber);
                return;
            }

            Console.WriteLine("Enter a second number, and I will add it to the first.");

            var secondInput = Console.ReadLine().Trim();
            double secondNumber;
            if (!Double.TryParse(secondInput, out secondNumber))
            {
                Console.WriteLine("The second value, {0}, was not a vaild number", secondInput);
                return;
            }

            Console.WriteLine("Result: {0}", Calculations.Addition(firstNumber, secondNumber));
        }
    }
}
