//-----------------------------------------------------------------------
// <copyright file="GCD.cs" company="Epam training">
//     Copyright (c) Epam training. All rights reserved.
// </copyright>
// <author>Novik Ilya</author>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;

namespace Tasks
{
    /// <summary>
    /// Implementation algorithms which compute the greatest common divisor.
    /// </summary>
    public class GCD
    {
        #region public methods

        /// <summary>
        /// Computing the greatest common divisor of two numbers by Euclidean's algorithm.
        /// </summary>
        /// <param name="number1">The first number to compute.</param>
        /// <param name="number2">The second number to compute.</param>
        /// <returns>The greatest common divisor number.</returns>
        public int Euclidean(int number1, int number2)
        {
            int result = this.EuclideanNative(number1, number2);
            return result;
        }

        /// <summary>
        /// Computing the greatest common divisor of set of integers by Euclid's algorithm.
        /// </summary>
        /// <param name="number1">The first number to compute.</param>
        /// <param name="number2">The second number to compute.</param>
        /// <param name="numbers">The numbers to compute.</param>
        /// <returns>The greatest common divisor number.</returns>
        public int Euclidean(int number1, int number2, params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers), $"{nameof(numbers)} must be not null");
            }

            int result = this.EuclideanNative(number1, number2);

            int i = 0;
            while (result != 1 && i < numbers.Length)
            {
                result = this.EuclideanNative(result, numbers[i]);
                i++;
            }

            return result;
        }

        /// <summary>
        /// Computing the greatest common divisor of set of integers by Euclid's algorithm.
        /// </summary>
        /// <param name="time">The out parameter to compute lead time.</param>
        /// <param name="number1">The first number to compute.</param>
        /// <param name="number2">The second number to compute.</param>
        /// <param name="numbers">The numbers to compute.</param>
        /// <returns>The greatest common divisor number.</returns>
        public int Euclidean(out TimeSpan time, int number1, int number2, params int[] numbers)
        {
            return this.GetLeadTime(out time, () => this.Euclidean(number1, number2, numbers));
        }

        /// <summary>
        /// Computing the greatest common divisor of set of integers by Euclid's algorithm.
        /// </summary>
        /// <param name="time">The out parameter to compute lead time.</param>
        /// <param name="number1">The first number to compute.</param>
        /// <param name="number2">The second number to compute.</param>
        /// <returns>The greatest common divisor number.</returns>
        public int Euclidean(out TimeSpan time, int number1, int number2)
        {
            return this.GetLeadTime(out time, () => this.Euclidean(number1, number2));
        }

        /// <summary>
        /// Computing the greatest common divisor of two numbers by Stein's algorithm.
        /// </summary>
        /// <param name="number1">The first number to compute.</param>
        /// <param name="number2">The second number to compute.</param>
        /// <returns>The greatest common divisor number.</returns>
        public int Stein(int number1, int number2)
        {
            int result = this.SteinNative(number1, number2);
            return result;
        }

        /// <summary>
        /// Computing the greatest common divisor of set of integers by Stein's algorithm.
        /// </summary>
        /// <param name="number1">The first number to compute.</param>
        /// <param name="number2">The second number to compute.</param>
        /// <param name="numbers">The numbers to compute.</param>
        /// <returns>The greatest common divisor number.</returns>
        public int Stein(int number1, int number2, params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers), $"{nameof(numbers)} must be not null");
            }

            int result = this.SteinNative(number1, number2);

            for (int i = 0; i < numbers.Length && result != 1; i++)
            {
                result = this.SteinNative(result, numbers[i]);
            }

            return result;
        }

        /// <summary>
        /// Computing the greatest common divisor of set of integers by Stein's algorithm.
        /// </summary>
        /// <param name="time">The out parameter to compute lead time.</param>
        /// <param name="number1">The first number to compute.</param>
        /// <param name="number2">The second number to compute.</param>
        /// <param name="numbers">The numbers to compute.</param>
        /// <returns>The greatest common divisor number.</returns>
        public int Stein(out TimeSpan time, int number1, int number2, params int[] numbers)
        {
            return this.GetLeadTime(out time, () => this.Stein(number1, number2, numbers));
        }

        /// <summary>
        /// Computing the greatest common divisor of set of integers by Stein's algorithm.
        /// </summary>
        /// <param name="time">The out parameter to compute lead time.</param>
        /// <param name="number1">The first number to compute.</param>
        /// <param name="number2">The second number to compute.</param>
        /// <returns>The greatest common divisor number.</returns>
        public int Stein(out TimeSpan time, int number1, int number2)
        {
            return this.GetLeadTime(out time, () => this.Stein(number1, number2));
        }

        #endregion // public methods

        #region private methods

        private int EuclideanNative(int number1, int number2)
        {
            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);

            if (number1 == 0 && number2 != 0)
            {
                return number2;
            }

            if (number2 == 0 && number1 != 0)
            {
                return number1;
            }

            while (number1 != number2)
            {
                if (number1 > number2)
                {
                    number1 -= number2;
                }
                else
                {
                    number2 -= number1;
                }
            }

            return number1;
        }

        private int SteinNative(int number1, int number2)
        {
            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);

            if (number1 == number2)
            {
                return number1;
            }

            if (number1 == 0)
            {
                return number2;
            }

            if (number2 == 0)
            {
                return number1;
            }

            if ((~number1 & 1) != 0)
            {
                if ((number2 & 1) != 0)
                {
                    return this.SteinNative(number1 >> 1, number2);
                }
                else
                {
                    return this.SteinNative(number1 >> 1, number2 >> 1) << 1;
                }
            }

            if ((~number2 & 1) != 0)
            {
                return this.SteinNative(number1, number2 >> 1);
            }

            if (number1 > number2)
            {
                return this.SteinNative((number1 - number2) >> 1, number2);
            }

            return this.SteinNative((number2 - number1) >> 1, number1);
        }

        private int GetLeadTime(out TimeSpan time, Func<int> alghoritm)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = alghoritm();
            stopwatch.Stop();
            time = stopwatch.Elapsed;
            return result;
        }

        #endregion // private methods
    }
}
