using System;
using System.Collections.Generic;

namespace Logic
{
    public sealed partial class Polynomial
    {
        #region public methods

        /// <summary>
        /// Addition of the left polynomial to the right polynomial.
        /// </summary>
        /// <param name="lhs">The first polynomial.</param>
        /// <param name="rhs">The second polynomial.</param>
        /// <returns>The polynomial.</returns>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs) =>
            Add(lhs, rhs);

        /// <summary>
        /// Multiplication of the left polynomial to the right polynomial.
        /// </summary>
        /// <param name="lhs">The first polynomial.</param>
        /// <param name="rhs">The second polynomial.</param>
        /// <returns>The polynomial.</returns>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs) =>
            Multiplication(lhs, rhs);

        /// <summary>
        /// Subtraction from the left polynomial of the right polynomial.
        /// </summary>
        /// <param name="lhs">The first polynomial.</param>
        /// <param name="rhs">The second polynomial.</param>
        /// <returns>The polynomial.</returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs) =>
            Subtract(lhs, rhs);

        /// <summary>
        /// Negation of result of <see cref="operator ==(Polynomial, Polynomial)"/>.
        /// </summary>
        /// <param name="lhs">The first polynomial.</param>
        /// <param name="rhs">The second polynomial.</param>
        /// <returns>Boolean.</returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// Determines whether the object is considered equal
        /// </summary>
        /// <param name="lhs">The first polynomial.</param>
        /// <param name="rhs">The second polynomial.</param>
        /// <returns>Boolean.</returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            return lhs.Equals(rhs);
        }

        #endregion // public methods

        #region private methods

        private static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            List<Monomial> monomials = new List<Monomial>();

            for (int i = 0; i < lhs.GetsCount; i++)
            {
                Monomial monomial = new Monomial();
                monomial.Coefficient = lhs.coefficients[i];
                monomial.Degree = lhs.degrees[i];
                monomials.Add(monomial);
            }

            for (int i = 0; i < rhs.GetsCount; i++)
            {
                Monomial monomial = new Monomial();
                monomial.Coefficient = rhs.coefficients[i];
                monomial.Degree = rhs.degrees[i];
                monomials.Add(monomial);
            }

            return Polynomial.ToStandart(new Polynomial(monomials));
        }

        private static Polynomial Multiplication(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            List<Monomial> result = new List<Monomial>();

            for (int indexLhs = 0; indexLhs < lhs.GetsCount; indexLhs++)
            {
                for (int indexRhs = 0; indexRhs < rhs.GetsCount; indexRhs++)
                {
                    Monomial monomial = new Monomial();
                    monomial.Coefficient = lhs.coefficients[indexLhs] * rhs.coefficients[indexRhs];
                    monomial.Degree = lhs.degrees[indexLhs] + rhs.degrees[indexRhs];
                    result.Add(monomial);
                }
            }

            return new Polynomial(result);
        }

        private static Polynomial Subtract(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            List<Monomial> monomials = new List<Monomial>();

            for (int i = 0; i < lhs.GetsCount; i++)
            {
                Monomial monomial = new Monomial();
                monomial.Coefficient = lhs.coefficients[i];
                monomial.Degree = lhs.degrees[i];
                monomials.Add(monomial);
            }

            for (int i = 0; i < rhs.GetsCount; i++)
            {
                Monomial monomial = new Monomial();
                monomial.Coefficient = rhs.coefficients[i] * (-1);
                monomial.Degree = rhs.degrees[i];
                monomials.Add(monomial);
            }

            return Polynomial.ToStandart(new Polynomial(monomials));
        }

        #endregion
    }
}