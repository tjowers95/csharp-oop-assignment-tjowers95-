using System;

namespace CsharpOopAssignment
{
    public abstract class RationalBase
    {
	    
        public int Numerator { get; protected set; }
		public int Denominator { get; protected set; }
	    
	    /**
         * Constructor for rational values of the type:
         * <p>
         * `numerator / denominator`
         * <p>
         * No simplification of the numerator/denominator pair should occur in this method.
         *
         * @param numerator   the numerator of the rational value
         * @param denominator the denominator of the rational value
         * @throws ArgumentException if the given denominator is 0
         */
	    public RationalBase(int numerator, int denominator)
	    {
            if (denominator == 0)
                throw new ArgumentException();
            this.Numerator = numerator;
            this.Denominator = denominator;
	    }

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
        public abstract RationalBase Construct(int numerator, int denominator);

        /**
         * negation of rational values
         * <p>
         * definition: `negate(n / d) = -n / d`
         *
         * @return the negation of this
         */
        public RationalBase Negate()
        {
            return Construct(-(this.Numerator), this.Denominator);
        }

        /**
		 * inversion of rational values
		 * <p>
		 * definition: `invert(n / d) = d / n`
		 *
		 * @return the inversion of this
		 * @throws InvalidOperationException
		 *             if the numerator of this rational value is 0
		 */
        public RationalBase Invert()
        {
            if (this.Numerator == 0)
                throw new InvalidOperationException();
            return Construct(this.Denominator, this.Numerator);
        }

        /**
         * addition of rational values
         * <p>
         * definition: `(n1 / d1) + (n2 / d2) = ((n1 * d2) + (n2 * d1)) / (d1 * d2)`
         *
         * @param that
         *            the value to add to this
         * @return the sum of this and that
         * @throws InvalidOperationException
         *             if that is null
         */
        public RationalBase Add(RationalBase that)
        {
            if (that == null)
                throw new InvalidOperationException();
            return Construct((this.Numerator * that.Denominator) + (that.Numerator * this.Denominator), (this.Denominator * that.Denominator));
        }

        /**
         * subtraction of rational values
         * <p>
         * definition: `(n1 / d1) - (n2 / d2) = ((n1 * d2) - (n2 * d1)) / (d1 * d2)`
         *
         * @param that
         *            the value to subtract from this
         * @return the difference between this and that
         * @throws InvalidOperationException
         *             if that is null
         */
        public RationalBase Sub(RationalBase that)
        {
            if (that == null)
                throw new InvalidOperationException();
            return Construct((this.Numerator * that.Denominator) - (that.Numerator * this.Denominator), this.Denominator * that.Denominator);
        }

        /**
         * multiplication of rational values
         * <p>
         * definition: `(n1 / d1) * (n2 / d2) = (n1 * n2) / (d1 * d2)`
         *
         * @param that
         *            the value to multiply this by
         * @return the product of this and that
         * @throws InvalidOperationException
         *             if that is null
         */
        public RationalBase Mul(RationalBase that)
        {
            if (that == null)
                throw new InvalidOperationException();
            return Construct( this.Numerator * that.Numerator, this.Denominator * that.Denominator);
        }

        /**
		 * division of rational values
		 * <p>
		 * definition: `(n1 / d1) / (n2 / d2) = (n1 * d2) / (d1 * n2)`
		 * <p>
		 * @param that
		 *            the value to divide this by
		 * @return the ratio of this to that
		 * @throws InvalidOperationException
		 *             if that is null or if the numerator of that is 0
		 */
        public RationalBase Div(RationalBase that)
        {
            if (that == null || that.Numerator == 0)
                throw new InvalidOperationException();
            return Construct( this.Numerator * that.Denominator, this.Denominator * that.Numerator);
        }
    }
}