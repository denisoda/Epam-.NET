using System;

namespace Tasks
{
    /// <summary>
    /// Implementation task 5
    /// </summary>
    public class Task5
    {
        #region public methods

        /// <summary>
        /// Сalculate the nth root of the number.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <param name="root">Root.</param>
        /// <param name="eps">Accuracy.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="root"/> is less than 0.
        /// <paramref name="eps"/> is less than 0.
        /// <paramref name="number"/> is less than 0 and <paramref name="root"/> is a even number.
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

            double nextNumber(double n, double x, int r) => (1.0 / r) * (((r - 1) * x) + (n / Math.Pow(x, r - 1)));

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
