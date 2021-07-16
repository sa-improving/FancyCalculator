using System;
using System.Collections.Generic;
using System.Linq;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A Console Calculator");
            bool running = true;
            decimal previousTotal = 0;
            List<string> history = new List<string>();
            while (running)
            {
                Console.WriteLine("Enter in the operation that you would like to perform.");
                var expressionInput = Console.ReadLine().Trim();
                if(expressionInput.ToLower().Equals("exit"))
                {
                    running = false;
                    return;
                }
                if(expressionInput.ToLower().Contains("history"))
                {
                    if(history.Count == 0)
                    {

                        Console.WriteLine("No operations have been performed");
                    }
                    else
                    {
                        var historyExpressionArray = expressionInput.Split(" ");
                        if (historyExpressionArray.Length > 1)
                        {
                            List<String> operatorHistory;
                            switch (historyExpressionArray[1])
                            {
                                case "+":
                                    operatorHistory = history.Where(x => x.Contains("+")).ToList();
                                    operatorHistory.ForEach(x => Console.Write("{0}\n", x));
                                    break;
                                case "-":
                                    operatorHistory = history.Where(x => x.Contains("-")).ToList();
                                    operatorHistory.ForEach(x => Console.Write("{0}\n", x));
                                    break;
                                case "*":
                                    operatorHistory = history.Where(x => x.Contains("*")).ToList();
                                    operatorHistory.ForEach(x => Console.Write("{0}\n", x));
                                    break;
                                case "/":
                                    operatorHistory = history.Where(x => x.Contains("/")).ToList();
                                    operatorHistory.ForEach(x => Console.Write("{0}\n", x));
                                    break;
                                default:
                                    history.ForEach(x => Console.Write("{0}\n", x));
                                    break;
                            }
                        }
                        else
                        {
                            history.ForEach(x => Console.Write("{0}\n", x));
                        }    
                    }
                    continue;
                }
                var expressionNumbers = expressionInput.Split(" ");

                decimal continuingValue;

                switch (expressionNumbers[0])
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        if (!Decimal.TryParse(expressionNumbers[1], out continuingValue))
                        {
                            Console.WriteLine("The second value, {0}, was not a vaild number", expressionNumbers[1]);
                            break;
                        }
                        decimal starterValue = previousTotal;
                        previousTotal =
                            StandAloneExpression(expressionNumbers[0], previousTotal, continuingValue);
                        history.Add("_"+starterValue+"_" + " " + expressionInput + " = " + previousTotal);
                        continue;
                }

                if (expressionNumbers.Length < 3)
                {
                    Console.WriteLine("An operation must be in the form '5 + 8'. Please try again.");
                    continue;
                }

                decimal firstNumber;
                if (!Decimal.TryParse(expressionNumbers[0], out firstNumber))
                {
                    Console.WriteLine("The first value, {0}, was not a vaild number", expressionNumbers[0]);
                    continue;
                }

                decimal secondNumber;
                if (!Decimal.TryParse(expressionNumbers[2], out secondNumber))
                {
                    Console.WriteLine("The second value, {0}, was not a vaild number", expressionNumbers[2]);
                    continue;
                }

                var result = StandAloneExpression(expressionNumbers[1], firstNumber, secondNumber);
                if(result != 0)
                {
                    previousTotal = result;
                    history.Add(expressionInput + " = " + result);
                }
            }           
        }

        

        static decimal StandAloneExpression(string op, decimal first, decimal second)
        {
            switch (op)
            {
                case "+":
                    Console.WriteLine("Result: {0}", Calculations.Addition(first, second));
                    return Calculations.Addition(first, second);
                case "-":
                    Console.WriteLine("Result: {0}", Calculations.Subtracation(first, second));
                    return Calculations.Subtracation(first, second);
                case "*":
                    Console.WriteLine("Result: {0}", Calculations.Multiplicaiton(first, second));
                    return Calculations.Multiplicaiton(first, second);
                case "/":
                    Console.WriteLine("Result: {0}", Calculations.Division(first, second));
                    return Calculations.Division(first, second);
                default:
                    Console.WriteLine("The operation {0} is invalid. You must use one of the following: + - * /", op);
                    return 0;
            }
        }
    }
}
