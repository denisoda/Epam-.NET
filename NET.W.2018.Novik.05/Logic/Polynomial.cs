using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    /// <summary>
    /// Immutable class to work with Polynomials.
    /// </summary>
    public sealed partial class Polynomial : ICloneable
    {
        #region Private fields

        private double[] _coefficients;
        private int[] _degrees;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class by array of coefficientes
        /// and array of degrees.
        /// </summary>
        /// <param name="coefficients">Array of coefficients.</param>
        /// <param name="degrees">Array of degrees.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="coefficients"/> and <paramref name="degrees"/>
        /// lengths are not the same.
        /// Thrown when <paramref name="coefficients"/> contains 0.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="coefficients"/> is null.
        /// Thrown when <paramref name="degrees"/> is null.
        /// </exception>
        public Polynomial(double[] coefficients, int[] degrees)
        {
            if (coefficients is null)
            {
                throw new ArgumentNullException(nameof(coefficients));
            }

            if (degrees is null)
            {
                throw new ArgumentNullException(nameof(degrees));
            }

            if (coefficients.Length != degrees.Length)
            {
                throw new ArgumentException($"{nameof(coefficients)} and {nameof(degrees)}'s must be the same");
            }

            this._degrees = new int[degrees.Length];
            this._coefficients = new double[coefficients.Length];

            for (int i = 0; i < degrees.Length; i++)
            {
                this.AddCoefficient(coefficients[i], i);
                this.AddDegree(degrees[i], i);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Count of elements in Polynomial.
        /// </summary>
        public int Count => this._coefficients.Length;

        /// <summary>
        /// The greatest degree.
        /// </summary>
        public int Degree
        {
            get
            {
                if (this.Count == 0)
                {
                    return -1;
                }

                int max = 0;

                for (int i = 1; i < this._degrees.Length; i++)
                {
                    if (this._degrees[max] < this._degrees[i])
                    {
                        max = i;
                    }
                }

                return this._degrees[max];
            }
        }

        public double[] Coefficients
        {
            get
            {
                var result = new double[this._coefficients.Length];
                Array.Copy(this._coefficients, result, this._coefficients.Length);
                return result;
            }
        }

        public int[] Degrees
        {
            get
            {
                var result = new int[this._degrees.Length];
                Array.Copy(this._degrees, result, this._degrees.Length);
                return result;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Cast a polynomial to standart view. Sorting in descending order of degrees.
        /// Addition elements with the same degrees.
        /// </summary>
        /// <param name="value">The polynomial.</param>
        /// <returns>The polynomial by standart view.</returns>
        public static Polynomial ToStandart(Polynomial value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            int[] arrDegrees = value.Degrees;
            double[] arrCoefficients = value.Coefficients;

            double coefficient = 0;
            int degree = 0;
            int count = 0;

            for (int i = 0; i < arrDegrees.Length; i++)
            {
                if (arrCoefficients[i] == 0)
                {
                    continue;
                }

                coefficient = arrCoefficients[i];
                degree = arrDegrees[i];

                for (int j = i + 1; j < arrDegrees.Length; j++)
                {
                    if (degree == arrDegrees[j])
                    {
                        coefficient += arrCoefficients[j];
                        arrCoefficients[j] = 0;
                    }
                }

                if (coefficient != 0)
                {
                    count++;
                    arrCoefficients[i] = coefficient;
                }
            }

            int[] resultDegrees;
            double[] resultCoefficients;

            GetNonZeroValues(arrDegrees, out resultDegrees, arrCoefficients, out resultCoefficients, count);
            SortPolynomialByDegreesDesc(ref resultCoefficients, ref resultDegrees);

            return new Polynomial(resultCoefficients, resultDegrees);
        }

        /// <summary>
        /// Convert the polynomial value of this instance to its equivalent string representation.
        /// </summary>
        /// <example>
        /// (2x^3) + (7x^1) + (-5x^0) + (-5x^0).
        /// </example>
        /// <returns>The string.</returns>
        public override string ToString()
        {
            string result = string.Empty;
            string letter = "x";
            for (int i = 0; i < this.Count; i++)
            {
                result += $"({this._coefficients[i]}{letter}^{this._degrees[i]}) + ";
            }

            return result.Substring(0, result.Length - 3);
        }

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Polynomial))
            {
                return false;
            }

            Polynomial lhs = (Polynomial)obj;

            if (lhs.Count != this.Count)
            {
                return false;
            }

            bool isEquals = true;
            for (int i = 0; i < lhs.Count && isEquals; i++)
            {
                isEquals = false;
                for (int j = 0; j < this.Count; j++)
                {
                    if (this._coefficients[i] == lhs._coefficients[i] &&
                        this._degrees[i] == lhs._degrees[i])
                    {
                        isEquals = true;
                    }
                }
            }

            return isEquals;
        }

        public override int GetHashCode()
        {
            double result = base.GetHashCode();
            int magic = 8;

            for (int i = 0; i < this._coefficients.Length; i++)
            {
                result += this._degrees[i] + this._coefficients[i];
            }

            return (int)result * magic;
        }

        object ICloneable.Clone()
        {
            return new Polynomial(this.Coefficients, this.Degrees);
        }

        #endregion

        #region private static methods

        private static void GetNonZeroValues(int[] sourceDegreesArray, out int[] destinationDegreesArray, double[] sourceCoefficientArray, out double[] destinationCoefficientArray, int count)
        {
            destinationCoefficientArray = new double[count];
            destinationDegreesArray = new int[count];

            int indexDestinationArray = 0;
            for (int i = 0; i < sourceCoefficientArray.Length && indexDestinationArray < destinationCoefficientArray.Length; i++)
            {
                double coefficient = sourceCoefficientArray[i];
                if (coefficient != 0)
                {
                    destinationCoefficientArray[indexDestinationArray] = coefficient;
                    destinationDegreesArray[indexDestinationArray] = sourceDegreesArray[i];
                    indexDestinationArray++;
                }
            }
        }

        private static void SortPolynomialByDegreesDesc(ref double[] coefficient, ref int[] degrees)
        {
            bool isSort = false;
            for (int i = 0; i < coefficient.Length && !isSort; i++)
            {
                isSort = true;
                for (int j = 0; j < coefficient.Length - i - 1; j++)
                {
                    if (degrees[j] < degrees[j + 1])
                    {
                        var temp = degrees[j];
                        degrees[j] = degrees[j + 1];
                        degrees[j + 1] = temp;
                        isSort = false;
                    }
                }
            }
        }

        #endregion

        #region private methods

        private void AddCoefficient(double value, int index)
        {
            if (value == 0)
            {
                throw new ArgumentException("Coefficient must not equal 0");
            }

            this._coefficients[index] = value;
        }

        private void AddDegree(int value, int index)
        {
            this._degrees[index] = value;
        }

        #endregion // private methods

    }
}
