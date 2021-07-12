using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorCore.Tests
{
    [TestClass]
    public class CalculatorCoreTests
    {
        Calculator calc = new Calculator();
        [TestMethod]
        public void AddTwoNumbers()
        {
            
            var result = calc.Evaluate("6 + 8").Result;
            Assert.AreEqual(14, result);
        }

        public void IncorrectFirstValue()
        {
            var result = calc.Evaluate("A + 2").ErrorMessage;
            Assert.AreEqual("The first value, A, is not a valid number", result);
        }

        public void IncorrectSecondValue()
        {
            var result = calc.Evaluate("2 + B").ErrorMessage;
            Assert.AreEqual("The secon value, B, is not a valid number", result);
        }
    }
}
