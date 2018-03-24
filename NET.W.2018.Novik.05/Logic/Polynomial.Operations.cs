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

            int[] degreesResult = new int[lhs.Count + rhs.Count];
            double[] coefficientResult = new double[lhs.Count + rhs.Count];

            int indexResultArray = 0;
            for (int j = 0; j < lhs.Count; j++)
            {
                degreesResult[indexResultArray] = lhs._degrees[j];
                coefficientResult[indexResultArray] = lhs._coefficients[j];
                indexResultArray++;
            }

            for (int j = 0; j < rhs.Count; j++)
            {
                degreesResult[indexResultArray] = lhs._degrees[j];
                coefficientResult[indexResultArray] = lhs._coefficients[j];
                indexResultArray++;
            }

            return Polynomial.ToStandart(new Polynomial(coefficientResult, degreesResult));
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
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            int[] degreesResult = new int[lhs.Count + rhs.Count];
            double[] coefficientResult = new double[lhs.Count + rhs.Count];

            int indexResultArray = 0;
            for (int j = 0; j < lhs.Count; j++)
            {
                degreesResult[indexResultArray] = lhs._degrees[j];
                coefficientResult[indexResultArray] = lhs._coefficients[j];
                indexResultArray++;
            }

            for (int j = 0; j < rhs.Count; j++)
            {
                degreesResult[indexResultArray] = lhs._degrees[j];
                coefficientResult[indexResultArray] = lhs._coefficients[j] * (-1);
                indexResultArray++;
            }

            return Polynomial.ToStandart(new Polynomial(coefficientResult, degreesResult));
        }

        #endregion
    }
}