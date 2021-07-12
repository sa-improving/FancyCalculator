using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A Console Calculator");
            bool running = true;
            while (running)
            {
                Console.WriteLine("Enter in the operation that you would like to perform.");
                var expressionInput = Console.ReadLine().Trim();
                if(expressionInput.ToLower().Equals("exit"))
                {
                    running = false;
                    return;
                }
                var expressionNumbers = expressionInput.Split(" ");

                decimal firstNumber;
                if (!Decimal.TryParse(expressionNumbers[0], out firstNumber))
                {
                    Console.WriteLine("The first value, {0}, was not a vaild number", expressionNumbers[0]);
                    return;
                }

                decimal secondNumber;
                if (!Decimal.TryParse(expressionNumbers[2], out secondNumber))
                {
                    Console.WriteLine("The second value, {0}, was not a vaild number", expressionNumbers[2]);
                    return;
                }

                switch (expressionNumbers[1])
                {
                    case "+":
                        Console.WriteLine("Result: {0}", Calculations.Addition(firstNumber, secondNumber));
                        break;
                    case "-":
                        Console.WriteLine("Result: {0}", Calculations.Subtracation(firstNumber, secondNumber));
                        break;
                    case "*":
                        Console.WriteLine("Result: {0}", Calculations.Multiplicaiton(firstNumber, secondNumber));
                        break;
                    case "/":
                        Console.WriteLine("Result: {0}", Calculations.Division(firstNumber, secondNumber));
                        break;
                    default:
                        Console.WriteLine("The operation {0} is invalid. You must use one of the following: + - * /", expressionNumbers[1]);
                        break;
                }
            }
            

            
        }
    }
}
