using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Calculator
    {
        private decimal recentValue = 0;
        public List<String> history { get; set; }

        public Calculator(decimal value)
        {
            recentValue = value;
            history = new List<string>();
        }

        public Calculator(string latestValue)
        {
            decimal value;
            decimal.TryParse(latestValue, out value);
            recentValue = value;
            history = new List<string>();
        }
        public EvaluationResult Evaluate(string input)
        {
            var inputArray = input.Trim().Split(" ");

            decimal firstNumber = 0;
            decimal secondNumber = 0;
            string op = "";

            if(input.ToLower().Equals("history"))
            {
                return new EvaluationResult
                {
                    History = history
                };
            }

            if(inputArray.Length != 3 && inputArray.Length != 2)
            {
                return new EvaluationResult
                {
                    ErrorMessage = "An operation must be in the form '5 + 8' or '+ 2'. Please try again."
                };
            }

            if (inputArray.Length == 2)
            {
                op = inputArray[0];
                firstNumber = recentValue;
                if (!decimal.TryParse(inputArray[1], out secondNumber))
                {
                    return new EvaluationResult
                    {
                        ErrorMessage = $"An operation must be in the form '5 + 8' or '+ 2'. Please try again."
                    };

                }
            }

            if(inputArray.Length == 3)
            {
                op = inputArray[1];

                if (!decimal.TryParse(inputArray[0], out firstNumber))
                {
                    return new EvaluationResult
                    {
                        ErrorMessage = $"The first value, '{inputArray[0]}', is not a valid number"
                    };
                }

                if (!decimal.TryParse(inputArray[2], out secondNumber))
                {
                    return new EvaluationResult
                    {
                        ErrorMessage = $"The second value, '{inputArray[2]}', is not a valid number"
                    };
                }
            }
            


            var result = new EvaluationResult();

            switch(op)
            {
                case "+":
                    result.Result = firstNumber + secondNumber;
                    recentValue = result.Result;
                    history.Add(input + " = " + recentValue);
                    break;
                case "-":
                    result.Result = firstNumber - secondNumber;
                    recentValue = result.Result;
                    history.Add(input + " = " + recentValue);
                    break;
                case "*":
                    result.Result = firstNumber * secondNumber;
                    recentValue = result.Result;
                    history.Add(input + " = " + recentValue);
                    break;
                case "/":
                    result.Result = firstNumber / secondNumber;
                    recentValue = result.Result;
                    history.Add(input + " = " + recentValue);
                    break;
                default:
                    result.ErrorMessage = $"The operation, '{inputArray[1]}',  is invalid. You must use one of the following : + - * /";
                    break;
            }

            return result;
        }
    }
}
