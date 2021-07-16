using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class EvaluationResult
    {
        public string ErrorMessage { get; set; }
        public decimal Result { get; set; }
        public List<string> History { get; set; }
    }
}
