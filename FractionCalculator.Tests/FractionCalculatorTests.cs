using System;
using NUnit.Framework;

namespace FractionCalculator.Tests
{
    [TestFixture]
    public class FractionCalculatorTests
    {
        private FractionCalculator _calculator = new FractionCalculator();

        [TestCase(3, 2, 5, 4, 11, 4)]
        [TestCase(7, 4, 1, 4, 2, 1)]
        [TestCase(0, 1, 0, 1, 0, 1)]
        [TestCase(-1, 1, 2, 4, -1, 2)]
        [TestCase(-1, 1, -2, 4, -3, 2)]
        [TestCase(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue, 2, 1)]
        public void AddTest(
            int augendNumerator, 
            int augendDenominator, 
            int addendNumerator,
            int addendDenominator,
            int expectedNumerator,
            int expectedDenominator)
        {
            var augend = new Fraction(augendNumerator, augendDenominator);
            var addend = new Fraction(addendNumerator, addendDenominator);

            var sum = _calculator.Add(augend, addend);

            Assert.AreEqual(expectedNumerator, sum.Numerator);
            Assert.AreEqual(expectedDenominator, sum.Denominator);
        }
        
        [TestCase(7, 4, 1, 4, 3, 2)]
        [TestCase(0, 1, 0, 1, 0, 1)]
        [TestCase(-1, 1, -2, 4, -1, 2)]
        [TestCase(10, 2, -100, 4, 30, 1)]
        [TestCase(int.MaxValue, 1, 100, 1, 2147483547, 1)]
        [TestCase(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue, 0, 1)]
        public void SubstractTest(
           int minuendNumerator,
           int minuendDenominator,
           int subtrahendNumerator,
           int subtrahendDenominator,
           int expectedNumerator,
           int expectedDenominator)
        {
            var minuend = new Fraction(minuendNumerator, minuendDenominator);
            var subtrahend = new Fraction(subtrahendNumerator, subtrahendDenominator);

            var diff = _calculator.Substract(minuend, subtrahend);

            Assert.AreEqual(expectedNumerator, diff.Numerator);
            Assert.AreEqual(expectedDenominator, diff.Denominator);
        }

        [TestCase(7, 4, 1, 4, 7, 16)]
        [TestCase(0, 1, 0, 1, 0, 1)]
        [TestCase(-1, 1, -2, 4, 1, 2)]
        [TestCase(10, 2, -100, 4, -125, 1)]
        [TestCase(int.MaxValue, 1, 1, 1, int.MaxValue, 1)]
        [TestCase(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue, 1, 1)]
        public void MultiplicateTest(
          int multiplicandNumerator,
          int multiplicandDenominator,
          int multiplierNumerator,
          int multiplierDenominator,
          int expectedNumerator,
          int expectedDenominator)
        {
            var multiplicand = new Fraction(multiplicandNumerator, multiplicandDenominator);
            var multiplier = new Fraction(multiplierNumerator, multiplierDenominator);

            var product = _calculator.Multiplicate(multiplicand, multiplier);

            Assert.AreEqual(expectedNumerator, product.Numerator);
            Assert.AreEqual(expectedDenominator, product.Denominator);
        }

        [TestCase(7, 4, 7, 4, 1, 1)]
        [TestCase(0, 1, 1, 1, 0, 1)]
        [TestCase(-1, 1, -2, 4, -2, -1)]
        [TestCase(10, 2, -100, 4, 1, -5)]
        [TestCase(int.MaxValue, 1, 1, 1, int.MaxValue, 1)]
        [TestCase(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue, 1, 1)]
        public void DivideTest(
          int dividendNumerator,
          int dividendDenominator,
          int divisorNumerator,
          int divisorDenominator,
          int expectedNumerator,
          int expectedDenominator)
        {
            var dividend = new Fraction(dividendNumerator, dividendDenominator);
            var divisor = new Fraction(divisorNumerator, divisorDenominator);

            var quotient = _calculator.Divide(dividend, divisor);

            Assert.AreEqual(expectedNumerator, quotient.Numerator);
            Assert.AreEqual(expectedDenominator, quotient.Denominator);
        }

        [Test]
        public void Devide_DevideByZero_ArgumentExceptionThrown()
        {
            var dividend = new Fraction(1, 1);
            var divisor = new Fraction(0, 1);

            Assert.Throws<ArgumentException>(() => _calculator.Divide(dividend, divisor));
        }
    }
}