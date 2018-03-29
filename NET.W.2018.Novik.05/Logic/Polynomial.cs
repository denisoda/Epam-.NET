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

        private readonly double[] _coefficients;
        private readonly int[] _degrees;
        private readonly int _maxDegree;
        private readonly int hashCode;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class by array of coefficientes
        /// and array of degrees.
        /// </summary>
        /// <param name="coefficients">Array of coefficients.</param>
        /// <param name="degrees">Array of degrees.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="coefficients"/> and <paramref name="degrees"/>
        /// lengths are not the same.
        /// <paramref name="coefficients"/> contains 0.
        /// <paramref name="degrees"/> contains numbers less than 0.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="coefficients"/> is null.
        /// <paramref name="degrees"/> is null.
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
            this._maxDegree = -1;

            for (int i = 0; i < degrees.Length; i++)
            {
                this.AddCoefficient(coefficients[i], i);
                this.AddDegree(degrees[i], i);
                this._maxDegree = Math.Max(this._maxDegree, degrees[i]);
            }

            this.hashCode = this.ComputeHashCode();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Count of elements in Polynomial.
        /// </summary>
        public int Count => this._coefficients.Length;

        /// <summary>
        /// The greatest degree. If the polynomial is empty then return -1.
        /// </summary>
        public int MaxDegree => this._maxDegree;

        public double[] Coefficients
        {
            get
            {
                var copyCoefficients = new double[this._coefficients.Length];
                Array.Copy(this._coefficients, copyCoefficients, this._coefficients.Length);
                return copyCoefficients;
            }
        }

        public int[] Degrees
        {
            get
            {
                var copyDegrees = new int[this._degrees.Length];
                Array.Copy(this._degrees, copyDegrees, this._degrees.Length);
                return copyDegrees;
            }
        }

        public bool IsEmpty => this.Count <= 0;

        #endregion

        #region Public methods

        /// <summary>
        /// Cast a polynomial to standart view. Sorting in descending order of degrees.
        /// Addition elements with the same degrees.
        /// </summary>
        /// <param name="value">The polynomial.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="value"/> is null.
        /// <paramref name="value"/> is empty.
        /// </exception>
        /// <returns>The polynomial by standart view.</returns>
        public static Polynomial ToStandart(Polynomial value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.IsEmpty)
            {
                return value;
            }

            int[] sourceDegrees = value.Degrees;
            double[] sourceCoefficients = value.Coefficients;
            int[] resultDegrees;
            double[] resultCoefficients;

            AddElementsTheSameDegree(sourceCoefficients, sourceDegrees, out resultCoefficients, out resultDegrees);
            SortPolynomialByDegreeDesc(resultCoefficients, resultDegrees);

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
            int lengthToClipping = 3;

            for (int i = 0; i < this.Count; i++)
            {
                result += $"({this._coefficients[i]}{letter}^{this._degrees[i]}) + ";
            }

            return result.Substring(0, result.Length - lengthToClipping);
        }

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Polynomial))
            {
                return false;
            }

            Polynomial lhs = (Polynomial)obj;

            if (this.Count != lhs.Count)
            {
                return false;
            }

            bool isEquals = true;

            for (int i = 0; i < lhs.Count && isEquals; i++)
            {
                isEquals = false;
                for (int j = 0; j < this.Count; j++)
                {
                    if (this.AreCoefficientSimilar(this._coefficients[i], lhs._coefficients[j]) &&
                        this._degrees[i] == lhs._degrees[j])
                    {
                        isEquals = true;
                    }
                }
            }

            return isEquals;
        }

        public override int GetHashCode() => this.hashCode;

        object ICloneable.Clone()
        {
            return new Polynomial(this.Coefficients, this.Degrees);
        }

        #endregion

        #region private static methods

        private static void AddElementsTheSameDegree(double[] sourceCoefficients, int[] sourceDegrees, out double[] destinationCoefficients, out int[] destinationDegrees)
        {
            const int wasteCoefficient = 0;
            double coefficientToAdd = 0;
            int degreeToCompare = 0;
            int countNotZeroElements = 0;

            for (int i = 0; i < sourceDegrees.Length; i++)
            {
                if (sourceCoefficients[i] == wasteCoefficient)
                {
                    continue;
                }

                coefficientToAdd = sourceCoefficients[i];
                degreeToCompare = sourceDegrees[i];

                for (int j = i + 1; j < sourceDegrees.Length; j++)
                {
                    if (degreeToCompare == sourceDegrees[j])
                    {
                        coefficientToAdd += sourceCoefficients[j];
                        sourceCoefficients[j] = wasteCoefficient;
                    }
                }

                if (coefficientToAdd != wasteCoefficient)
                {
                    countNotZeroElements++;
                    sourceCoefficients[i] = coefficientToAdd;
                }
            }

            if (countNotZeroElements != sourceCoefficients.Length)
            {
                RemoveZeroValues(sourceCoefficients, sourceDegrees, out destinationCoefficients, out destinationDegrees, countNotZeroElements);
                return;
            }

            destinationCoefficients = sourceCoefficients;
            destinationDegrees = sourceDegrees;

        }

        private static void RemoveZeroValues(double[] sourceCoefficient, int[] sourceDegrees, out double[] destinationCoefficient, out int[] destinationDegrees, int count)
        {
            destinationCoefficient = new double[count];
            destinationDegrees = new int[count];
            int indexDestination = 0;
            const int valueToRemove = 0;

            for (int i = 0; i < sourceCoefficient.Length && indexDestination < destinationCoefficient.Length; i++)
            {
                double coefficient = sourceCoefficient[i];
                if (coefficient != valueToRemove)
                {
                    destinationCoefficient[indexDestination] = coefficient;
                    destinationDegrees[indexDestination] = sourceDegrees[i];
                    indexDestination++;
                }
            }
        }

        private static void SortPolynomialByDegreeDesc(double[] coefficient, int[] degrees)
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
                throw new ArgumentException("Coefficient must be not zero", nameof(value));
            }

            this._coefficients[index] = value;
        }

        private void AddDegree(int value, int index)
        {
            if (value < 0)
            {
                throw new ArgumentException("degree must be greater than 0");
            }

            this._degrees[index] = value;
        }

        private int ComputeHashCode()
        {
            int hashcode = 0;
            int magic = 1000;

            for (int i = 0; i < this.Count - 1; i++)
            {
                hashcode += this._degrees[i] ^ (int)this._coefficients[i];
            }

            return magic + hashcode;
        }

        private bool AreCoefficientSimilar(double first, double second)
        {
            double accuracy = 0.0001;

            if (Math.Abs(first - second) < accuracy)
            {
                return true;
            }

            return false;
        }

        #endregion // private methods

    }
}
