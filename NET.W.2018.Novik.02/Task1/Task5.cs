//-----------------------------------------------------------------------
// <copyright file="Task5.cs" company="Epam training">
//     Copyright (c) Epam training. All rights reserved.
// </copyright>
// <author>Novik Ilya</author>
//-----------------------------------------------------------------------
namespace Tasks
{
    using System;

    /// <summary>
    /// Implementation task 5
    /// </summary>
    public class Task5
    {
        #region public methods

        /// <summary>
        /// Сalculate the nth root of the number
        /// </summary>
        /// <param name="number">Number.</param>
        /// <param name="root">Root.</param>
        /// <param name="eps">Accuracy.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="root"/> is less than 0
        /// Thrown when <paramref name="eps"/> is less than 0
        /// Thrown when <paramref name="number"/> is less than 0 and
        /// <paramref name="root"/> is a even number
        /// </exception>
        /// <returns>The nth root of the number></returns>
        public static double FindNthRoot(double number, int root, double eps)
        {
            if (root <= 0)
            {
                throw new ArgumentException($"{nameof(root)} must be greater than 0", nameof(root));
            }

            if ((number <= 0) && (root % 2 == 0))
            {
                throw new ArgumentException($"{nameof(number)} must be greater than or equal to 0", nameof(number));
            }

            if (eps <= 0)
            {
                throw new ArgumentException($"{nameof(eps)} must be greater than 0", nameof(eps));
            }

            Func<double, double, int, double> nextNumber = (n, x, r) => (1.0 / r) * (((r - 1) * x) + (n / Math.Pow(x, r - 1)));

            double x0 = number / root;
            double x1 = nextNumber(number, x0, root);
            double delta = eps * 2;

            while (Math.Abs(x0 - x1) > eps)
            {
                x0 = x1;
                x1 = nextNumber(number, x0, root);
            }

            return x1;
        }

        #endregion
    }
}
