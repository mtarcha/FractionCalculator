using System;

namespace FractionCalculator
{
    public static class FractionExtensions
    {
        public static Fraction ToSimplified(this Fraction fraction)
        {
            if (fraction == null)
            {
                throw new ArgumentNullException(nameof(fraction));
            }

            var greatestCommonDivisor = ComputeGreatestCommonDivisor(fraction.Numerator, fraction.Denominator);

            return new Fraction(fraction.Numerator / greatestCommonDivisor, fraction.Denominator / greatestCommonDivisor);
        }
        
        private static int ComputeGreatestCommonDivisor(int numerator, int denominator)
        {
            if (numerator == denominator)
            {
                return numerator;
            }

            var a = Math.Abs(numerator);
            var b = Math.Abs(denominator);

            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }

            return a + b;
        }
    }
}