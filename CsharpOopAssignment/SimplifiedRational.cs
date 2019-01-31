using System;

namespace CsharpOopAssignment
{
    public class SimplifiedRational : RationalBase
    {
        
        /**
         * Determines the greatest common denominator for the given values
         *
         * @param a the first value to consider
         * @param b the second value to consider
         * @return the greatest common denominator, or shared factor, of `a` and `b`
         * @throws InvalidOperationException if a <= 0 or b < 0
         */
        public static int Gcd(int a, int b)
        {
            if (a <= 0 || b < 0)
                throw new InvalidOperationException();

            int i, gcd = 0;
            for (i = 0; i < a && i < b; i++)
                if (i != 0 && a % i == 0 && b % i == 0)
                    if (i > gcd)
                        gcd = i;

            return gcd;
        }

        /**
         * Simplifies the numerator and denominator of a rational value.
         * <p>
         * For example:
         * `simplify(10, 100) = [1, 10]`
         * or:
         * `simplify(0, 10) = [0, 1]`
         *
         * @param numerator   the numerator of the rational value to simplify
         * @param denominator the denominator of the rational value to simplify
         * @return a two element array representation of the simplified numerator and denominator
         * @throws InvalidOperationException if the given denominator is 0
         */
        public static int[] Simplify(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new InvalidOperationException();
            int gcd;
            try
            {
               gcd = Gcd(numerator, denominator);
            }
            catch
            {
                return new int[] {numerator, denominator};
            }

            return new int[] { numerator / gcd, denominator / gcd };
        }

        /**
         * Constructor for rational values of the type:
         * <p>
         * `numerator / denominator`
         * <p>
         * Simplification of numerator/denominator pair should occur in this method.
         * If the numerator is zero, no further simplification can be performed
         *
         * @param numerator   the numerator of the rational value
         * @param denominator the denominator of the rational value
         * @throws ArgumentException if the given denominator is 0
         */
        public SimplifiedRational(int numerator, int denominator) : base(numerator, denominator)
        { }

        /**
		 * Specialized constructor to take advantage of shared code between
		 * Rational and SimplifiedRational
		 * <p>
		 * Essentially, this method allows us to implement most of RationalBase methods
		 * directly in the interface while preserving the underlying type
		 *
		 * @param numerator
		 *            the numerator of the rational value to construct
		 * @param denominator
		 *            the denominator of the rational value to construct
		 * @return the constructed rational value
		 * @throws ArgumentException
		 *             if the given denominator is 0
		 */
        public override RationalBase Construct(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException();

            int[] t = Simplify(numerator, denominator);

            return new SimplifiedRational(t[0], t[1]);
        }

        /**
         * @param obj the object to check this against for equality
         * @return true if the given obj is a SimplifiedRational value and its
         * numerator and denominator are equal to this rational value's numerator and denominator,
         * false otherwise
         */
        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;

            SimplifiedRational t = null;

            if (obj is SimplifiedRational)
                t = (SimplifiedRational)obj;
            else
                return false;
            return (this.Numerator == t.Numerator && this.Denominator == t.Denominator);
        }

        /**
         * If this is positive, the string should be of the form `numerator/denominator`
         * <p>
         * If this is negative, the string should be of the form `-numerator/denominator`
         *
         * @return a string representation of this rational value
         */
        public override string ToString()
        {
            if (this.Numerator < 0)
                return $"-{this.Numerator}/{this.Denominator}";
            else
                return $"{this.Numerator}/{this.Denominator}";
        }
    }
}