using System;

namespace FractionCalculator
{
    public sealed class Fraction
    {
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator can not be 0.");
            }
            
            Numerator = numerator;
            Denominator = denominator;
        }

        public int Numerator { get; }

        public int Denominator { get; }
    }
}