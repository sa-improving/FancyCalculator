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
            var expressionNumbers = expressionInput.Split(" ");


            //Console.WriteLine("Enter a Number");

            //var firstInput = Console.ReadLine().Trim();
            decimal firstNumber;
            if (!Decimal.TryParse(expressionNumbers[0], out firstNumber))
            {
                Console.WriteLine("The first value, {0}, was not a vaild number", expressionNumbers[0]);
                return;
            }

            //Console.WriteLine("Enter a second number, and I will add it to the first.");

            //var secondInput = Console.ReadLine().Trim();
            decimal secondNumber;
            if (!Decimal.TryParse(expressionNumbers[2], out secondNumber))
            {
                Console.WriteLine("The second value, {0}, was not a vaild number", expressionNumbers[2]);
                return;
            }

            switch(expressionNumbers[1])
            {
                case "+":
                    Console.WriteLine("Result: {0}", Calculations.Addition(firstNumber, secondNumber));
                    break;
                case "-":
                    Console.WriteLine("Result: {0}", Calculations.Subtracation(firstNumber, secondNumber));
                    break;
            }

            
        }
    }
}
