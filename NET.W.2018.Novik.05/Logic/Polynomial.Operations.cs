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
        /// <exception cref="ArgumentNullException">
        /// <paramref name="lhs"/> is null.
        /// <paramref name="rhs"/> is null.
        /// </exception>
        /// <returns>The polynomial in standart view.</returns>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return Add(lhs, rhs);
        }

        /// <summary>
        /// Multiplication of the left polynomial to the right polynomial.
        /// </summary>
        /// <param name="lhs">The first polynomial.</param>
        /// <param name="rhs">The second polynomial.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="lhs"/> is null.
        /// <paramref name="rhs"/> is null.
        /// </exception>
        /// <returns>The polynomial.</returns>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return Multiply(lhs, rhs);
        }

        /// <summary>
        /// Subtraction from the left polynomial of the right polynomial.
        /// </summary>
        /// <param name="lhs">The first polynomial.</param>
        /// <param name="rhs">The second polynomial.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="lhs"/> is null.
        /// <paramref name="rhs"/> is null.
        /// </exception>
        /// <returns>The polynomial in standart view.</returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return Subtract(lhs, rhs);
        }

        /// <summary>
        /// Negation of result of <see cref="operator ==(Polynomial, Polynomial)"/>.
        /// </summary>
        /// <param name="lhs">The first polynomial.</param>
        /// <param name="rhs">The second polynomial.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="lhs"/> is null.
        /// <paramref name="rhs"/> is null.
        /// </exception>
        /// <returns>Boolean.</returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return !(lhs == rhs);
        }

        /// <summary>
        /// Determines whether the object is considered equal
        /// </summary>
        /// <param name="lhs">The first polynomial.</param>
        /// <param name="rhs">The second polynomial.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="lhs"/> is null.
        /// <paramref name="rhs"/> is null.
        /// </exception>
        /// <returns>Boolean.</returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return lhs.Equals(rhs);
        }

        #endregion // public methods

        #region private methods

        private static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {
            int[] resultDegrees = new int[lhs.Count + rhs.Count];
            double[] resultCoefficients = new double[lhs.Count + rhs.Count];

            CopyDegreesAndCoefficients(lhs, resultCoefficients, resultDegrees, 0);
            CopyDegreesAndCoefficients(rhs, resultCoefficients, resultDegrees, lhs.Count);

            return Polynomial.ToStandart(new Polynomial(resultCoefficients, resultDegrees));
        }

        private static Polynomial Multiply(Polynomial lhs, Polynomial rhs)
        {
            int[] resultDegrees = new int[lhs.Count * rhs.Count];
            double[] resultCoefficients = new double[lhs.Count * rhs.Count];
            int indexResultArray = 0;

            for (int indexLhs = 0; indexLhs < lhs.Count; indexLhs++)
            {
                for (int indexRhs = 0; indexRhs < rhs.Count; indexRhs++)
                {
                    resultCoefficients[indexResultArray] = lhs._coefficients[indexLhs] * rhs._coefficients[indexRhs];
                    resultDegrees[indexResultArray] = lhs._degrees[indexLhs] + rhs._degrees[indexRhs];
                    indexResultArray++;
                }
            }

            return new Polynomial(resultCoefficients, resultDegrees);
        }

        private static Polynomial Subtract(Polynomial lhs, Polynomial rhs)
        {
            int[] resultDegrees = new int[lhs.Count + rhs.Count];
            double[] resultCoefficients = new double[lhs.Count + rhs.Count];

            CopyDegreesAndCoefficients(lhs, resultCoefficients, resultDegrees, 0);
            CopyDegreesAndCoefficients(rhs, resultCoefficients, resultDegrees, lhs.Count, -1);

            return Polynomial.ToStandart(new Polynomial(resultCoefficients, resultDegrees));
        }

        private static void CopyDegreesAndCoefficients(Polynomial source, double[] destinationCoefficients, int[] destinationDegrees, int startIndex, int signCoefficient = 1)
        {
            int indexResultArray = startIndex;

            for (int j = 0; j < source.Count; j++)
            {
                destinationDegrees[indexResultArray] = source._degrees[j];
                destinationCoefficients[indexResultArray] = source._coefficients[j] * signCoefficient;
                indexResultArray++;
            }
        }

        #endregion
    }
}