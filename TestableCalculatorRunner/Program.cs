using System;
using CalculatorCore;
namespace TestableCalculatorRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            Console.WriteLine("Enter in an expression to add 2 numbers.");
            string input = Console.ReadLine().Trim();

            EvaluationResult output = calculator.Evaluate(input);
            Console.WriteLine("Result: " + output.Result);
        }
    }
}
