using System;

namespace CsharpOopAssignment
{
    public class Rational : RationalBase
    { 
        public Rational(int numerator, int denominator) : base(numerator, denominator){}
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
            return new Rational(numerator, denominator);     
        }

        /**
         * @param obj the object to check this against for equality
         * @return true if the given obj is a rational value and its
         * numerator and denominator are equal to this rational value's numerator and denominator,
         * false otherwise
         */
        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj == null) return false;

            Rational tmp = null;

            if (obj is Rational)
                tmp = (Rational)obj;

            return (tmp.Numerator == this.Numerator && tmp.Denominator == this.Denominator);
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