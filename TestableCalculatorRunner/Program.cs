using System;
using CalculatorCore;
namespace TestableCalculatorRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            Console.WriteLine("Enter in an expression for 2 numbers.");
            string input = Console.ReadLine().Trim();

            EvaluationResult output = calculator.Evaluate(input);
            if(String.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("Result: {0}", output.Result);
            }
            else
            {
                Console.WriteLine("\u001b[91m" + output.ErrorMessage + "\u001b[0m");
            }
        }
    }
}
