namespace Classroom.SimpleCalculator.Tests
{
    public class Tests
    {
        public SimpleCalculator simpleCalculator = new SimpleCalculator();
        [TestCase(3, 5, 8)]
        public void TwoNumbersAdditionShouldReturnExpectedValue(double a, double b, double c)
        {
            
            double result = simpleCalculator.Add(a, b);
            Assert.AreEqual(c, result);
        }

        [TestCase(-3, 30, 27)]
        public void NegativeNumberPlusPositiveNumberShouldReturnExpectedValue(double a, double b, double c)
        {
            double negativeResult = simpleCalculator.Add(a, b);
            Assert.AreEqual(c, negativeResult);
        }

        [Test]
        public void SubtractNegativeNumberToPositiveNumberShouldReturnExpectedResult()
        {
            double result = simpleCalculator.Subtract(1, 2);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void MultiplateTwoNumbersShouldReturnExpectedResult()
        {
            double result = simpleCalculator.Multiplication(4, 5);
            Assert.AreEqual(20, result);
        }

        [Test]
        public void DivideTwoNumbersShouldReturnExpectedResult()
        {
            double result = simpleCalculator.Divide(4, 2);
            Assert.AreEqual(2, result);
        }
    }
}