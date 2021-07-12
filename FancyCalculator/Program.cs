using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A Console Calculator");

            Console.WriteLine("Enter what you would like to see added.");
            var expressionInput = Console.ReadLine().Trim();
            var expressionNumbers = expressionInput.Split(" + ");


            //Console.WriteLine("Enter a Number");

            var firstInput = Console.ReadLine().Trim();
            double firstNumber;
            if (!Double.TryParse(expressionNumbers[0], out firstNumber))
            {
                Console.WriteLine("The first value, {0}, was not a vaild number", firstNumber);
                return;
            }

            //Console.WriteLine("Enter a second number, and I will add it to the first.");

            var secondInput = Console.ReadLine().Trim();
            double secondNumber;
            if (!Double.TryParse(expressionNumbers[1], out secondNumber))
            {
                Console.WriteLine("The second value, {0}, was not a vaild number", secondInput
                    );
                return;
            }

            Console.WriteLine("Result: {0}", Calculations.Addition(firstNumber, secondNumber));
        }
    }
}
