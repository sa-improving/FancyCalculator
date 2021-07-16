using System;
using CalculatorCore;
namespace TestableCalculatorRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator(0);
            bool running = true;
            while(running)
            {
                Console.WriteLine("Enter in an expression for 2 numbers.");
                string input = Console.ReadLine().Trim();

                if(input.ToLower().Equals("exit"))
                {
                    running = false;
                    return;
                }

                if(input.ToLower().Equals("history"))
                {
                    if(calculator.history.Count == 0)
                    {
                        Console.WriteLine("No history available.");
                    }
                    else
                    {
                        calculator.history.ForEach(x => Console.WriteLine(x));
                    }
                    continue;
                }

                EvaluationResult output = calculator.Evaluate(input);
                if (String.IsNullOrEmpty(output.ErrorMessage))
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
}
