using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Calculator
    {
        public EvaluationResult Evaluate(string input)
        {
            var inputArray = input.Trim().Split(" ");

            decimal firstNumber;
            decimal secondNumber;

            if(inputArray.Length < 3)
            {
                return new EvaluationResult
                {
                    ErrorMessage = "An operation must be in the form '5 + 8'. Please try again."
                };
            }

            if (!decimal.TryParse(inputArray[0], out firstNumber))
            {
                return new EvaluationResult
                {
                    ErrorMessage = $"The first value, '{inputArray[0]}', is not a valid number"
                };
            }
        
            if(!decimal.TryParse(inputArray[2], out secondNumber))
            {
                return new EvaluationResult
                {
                    ErrorMessage = $"The second value, '{inputArray[2]}', is not a valid number"
                };
            }


            var result = new EvaluationResult();

            switch(inputArray[1])
            {
                case "+":
                    result.Result = firstNumber + secondNumber;
                    break;
                case "-":
                    result.Result = firstNumber - secondNumber;
                    break;
                case "*":
                    result.Result = firstNumber * secondNumber;
                    break;
                case "/":
                    result.Result = firstNumber / secondNumber;
                    break;
                default:
                    result.ErrorMessage = $"The operation, '{inputArray[1]}',  is invalid. You must use one of the following : + - * /";
                    break;
            }

            return result;
        }
    }
}
