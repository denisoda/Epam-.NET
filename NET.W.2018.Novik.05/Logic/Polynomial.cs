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

        private double[] coefficients;
        private int[] degrees;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class value by array of
        /// <see cref="Monomial"/>.
        /// </summary>
        /// <param name="monomials">Array of <see cref="Monomial"/>.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="monomials"/> is null.
        /// </exception>
        public Polynomial(IEnumerable<Monomial> monomials)
        {
            if (monomials is null)
            {
                throw new ArgumentNullException($"{nameof(monomials)} must be not null", nameof(monomials));
            }

            this.coefficients = new double[monomials.Count()];
            this.degrees = new int[monomials.Count()];
            this.AddCoefficientDegree(monomials);
        }

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

            this.degrees = new int[degrees.Length];
            this.coefficients = new double[coefficients.Length];

            for (int i = 0; i < degrees.Length; i++)
            {
                this.AddCoefficient(coefficients[i], i);
                this.AddDegree(degrees[i], i);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Count of elemnts in Polynomial.
        /// </summary>
        public int GetsCount => this.coefficients.Length;

        /// <summary>
        /// The greatest degree.
        /// </summary>
        public int GetsDegree
        {
            get
            {
                if (this.GetsCount == 0)
                {
                    return -1;
                }

                int max = 0;

                for (int i = 1; i < this.degrees.Length; i++)
                {
                    if (this.degrees[max] < this.degrees[i])
                    {
                        max = i;
                    }
                }

                return this.degrees[max];
            }
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Returns <see cref="Monomial"/>
        /// </summary>
        /// <param name="index">Index monomial.</param>
        /// <returns>Monomial.</returns>
        public Monomial this[int index]
        {
            get
            {
                if (index < 0 || index > this.GetsCount - 1)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(index)} out of range", nameof(index));
                }

                return new Monomial() { Coefficient = this.coefficients[index], Degree = this.degrees[index] };
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Cast a polynomial to standart view.
        /// </summary>
        /// <param name="value">The polynomial.</param>
        /// <returns>The polynomial by standart view.</returns>
        public static Polynomial ToStandart(Polynomial value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            int[] arrDegrees = new int[value.degrees.Length];
            double[] arrCoefficients = new double[value.coefficients.Length];

            Array.Copy(value.degrees, arrDegrees, arrDegrees.Length);
            Array.Copy(value.coefficients, arrCoefficients, arrCoefficients.Length);

            double coefficient = 0;
            int degree = 0;

            List<Monomial> result = new List<Monomial>();

            for (int i = 0; i < arrDegrees.Length; i++)
            {
                coefficient = arrCoefficients[i];
                degree = arrDegrees[i];

                if (coefficient == 0)
                {
                    continue;
                }

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
                    result.Add(new Monomial(coefficient, degree));
                }
            }

            return new Polynomial(result);
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
            for (int i = 0; i < this.GetsCount; i++)
            {
                result += $"({this.coefficients[i]}{letter}^{this.degrees[i]}) + ";
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

            if (lhs.GetsCount != this.GetsCount)
            {
                return false;
            }

            bool isEquals = true;
            for (int i = 0; i < lhs.GetsCount && isEquals; i++)
            {
                isEquals = false;
                for (int j = 0; j < this.GetsCount; j++)
                {
                    if (this.coefficients[i] == lhs.coefficients[i] ||
                        this.degrees[i] == lhs.degrees[i])
                    {
                        isEquals = true;
                    }
                }
            }

            return isEquals;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        object ICloneable.Clone()
        {
            int[] arrDegrees = new int[this.degrees.Length];
            double[] arrCoefficients = new double[this.coefficients.Length];

            Array.Copy(this.degrees, arrDegrees, arrDegrees.Length);
            Array.Copy(this.coefficients, arrCoefficients, arrCoefficients.Length);

            return new Polynomial(arrCoefficients, arrDegrees);
        }

        #endregion

        #region private methods

        private void AddCoefficientDegree(IEnumerable<Monomial> monomials)
        {
            int i = 0;
            foreach (var item in monomials)
            {
                this.AddCoefficient(item.Coefficient, i);
                this.AddDegree(item.Degree, i);
                i++;
            }
        }

        private void AddCoefficient(double value, int index)
        {
            if (value == 0)
            {
                throw new ArgumentException("Coefficient must not equal 0");
            }

            this.coefficients[index] = value;
        }

        private void AddDegree(int value, int index)
        {
            this.degrees[index] = value;
        }

        #endregion // private methods

    }
}
