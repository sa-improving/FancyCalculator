using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalculator
{
    class NumberChecker
    {
        public static void NumberVerification(string input, string placement, double number)
        {
            if(!Double.TryParse(input, out number))
            {
                Console.WriteLine("The {0} value, {1}, was not a vaild number", placement, input);
                return;
            }
        }
    }
}
