using System;

namespace FractionCalculator
{
    public sealed class FractionCalculator
    {
        public Fraction Add(Fraction augend, Fraction addend)
        {
            ValidateForNull(augend, nameof(augend));
            ValidateForNull(addend, nameof(addend));
            
            var simplifiedAugend = augend.ToSimplified();
            var simplifiedAddend = addend.ToSimplified();

            var numerator = simplifiedAugend.Numerator * simplifiedAddend.Denominator +
                            simplifiedAddend.Numerator * simplifiedAugend.Denominator;

            var denomicator = simplifiedAugend.Denominator * simplifiedAddend.Denominator;

            return new Fraction(numerator, denomicator).ToSimplified();
        }
        
        public Fraction Substract(Fraction minuend, Fraction subtrahend)
        {
            ValidateForNull(minuend, nameof(minuend));
            ValidateForNull(subtrahend, nameof(subtrahend));

            var simplifiedMinuend = minuend.ToSimplified();
            var simplifiedSubtrahend = subtrahend.ToSimplified();

            var numerator = simplifiedMinuend.Numerator * simplifiedSubtrahend.Denominator -
                            simplifiedSubtrahend.Numerator * simplifiedMinuend.Denominator;

            var denomicator = simplifiedMinuend.Denominator * simplifiedSubtrahend.Denominator;

            return new Fraction(numerator, denomicator).ToSimplified();
        }
        
        public Fraction Multiplicate(Fraction multiplicand, Fraction multiplier)
        {
            ValidateForNull(multiplicand, nameof(multiplicand));
            ValidateForNull(multiplier, nameof(multiplier));

            var simplifiedMultiplicand = multiplicand.ToSimplified();
            var simplifiedMultiplier = multiplier.ToSimplified();

            var numerator = simplifiedMultiplicand.Numerator * simplifiedMultiplier.Numerator;
            var denomicator = simplifiedMultiplicand.Denominator * simplifiedMultiplier.Denominator;

            return new Fraction(numerator, denomicator).ToSimplified();
        }
        
        public Fraction Divide(Fraction dividend, Fraction divisor)
        {
            ValidateForNull(dividend, nameof(dividend));
            ValidateForNull(divisor, nameof(divisor));

            if (divisor.Numerator == 0)
            {
                throw new ArgumentException("Cannot divide by 0.");
            }

            var simplifiedDividend = dividend.ToSimplified();
            var simplifiedDivisor = divisor.ToSimplified();

            var numerator = simplifiedDividend.Numerator * simplifiedDivisor.Denominator;
            var denomicator = simplifiedDividend.Denominator * simplifiedDivisor.Numerator;

            return new Fraction(numerator, denomicator).ToSimplified();
        }

        private static void ValidateForNull(Fraction fraction, string operandName)
        {
            if (fraction == null)
            {
                throw new ArgumentNullException(operandName);
            }
        }
    }
}