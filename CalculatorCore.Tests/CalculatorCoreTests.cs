using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorCore.Tests
{
    [TestClass]
    public class CalculatorCoreTests
    {
        private Calculator _calc;

        [TestInitialize]
        public void SetupOrInitialize()
        {
            _calc = new Calculator(0);
        }
        
        [TestMethod]
        public void AddTwoNumbers()
        {
            var result = _calc.Evaluate("6 + 8").Result;
            Assert.AreEqual(14, result);
        }

        [TestMethod]
        public void IncorrectFirstValue()
        {
            var result = _calc.Evaluate("A + 2");
            Assert.AreEqual("The first value, 'A', is not a valid number", result.ErrorMessage);
        }

        [TestMethod]
        public void IncorrectSecondValue()
        {
            var result = _calc.Evaluate("2 + B");
            Assert.AreEqual("The second value, 'B', is not a valid number", result.ErrorMessage);
        }

        [TestMethod]
        public void SubtractNumberFromAnother()
        {
            var result = _calc.Evaluate("8 - 6").Result;
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void MultiplyTwoNumbers()
        {
            var result = _calc.Evaluate("16 * 2").Result;
            Assert.AreEqual(32, result);
        }

        [TestMethod]
        public void DivideANumber()
        {
            var result = _calc.Evaluate("16 / 2").Result;
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void ValidateOperator()
        {
            var result = _calc.Evaluate("2 minus 1");
            Assert.AreEqual("The operation, 'minus',  is invalid. You must use one of the following : + - * /", result.ErrorMessage);
        }

        [TestMethod]
        public void CountOperationPieces()
        {
            var result = _calc.Evaluate("2 + ");
            Assert.AreEqual("An operation must be in the form '5 + 8' or '+ 2'. Please try again.", result.ErrorMessage);
        }

        [TestMethod]
        public void ContinuingOpertaions()
        {
            _calc.Evaluate("5 * 5");
            var result = _calc.Evaluate("- 7");
            Assert.AreEqual(18, result.Result);
        }

        [TestMethod]
        public void ReturningHistory()
        {
            _calc.Evaluate("5 * 5");
            var result = _calc.Evaluate("history");
            Assert.AreEqual("5 * 5 = 25", result.History[0]);
        }
    }
}
