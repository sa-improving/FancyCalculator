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
            var inputArray = input.Split(" ");

            decimal firstNumber;
            decimal secondNumber;

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

            return new EvaluationResult
            {
                Result = firstNumber + secondNumber
            };
        }
    }
}

