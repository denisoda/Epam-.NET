using System;
using System.Collections.Generic;

namespace Tasks
{

    /// <summary>
    /// Implementation task 4 (FilterDigit)
    /// </summary>
    public class Task4
    {
        #region public methods

        /// <summary>
        /// Find numbers which has <paramref name="digit"/>.
        /// </summary>
        /// <param name="sequence">The source sequence.</param>
        /// <param name="digit">The digit</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="digit"/> is not a positive digit.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="sequence"/> is null.
        /// </exception>
        /// <returns>The sequence of numbers which contains <paramref name="digit"/></returns>
        public static List<int> FilterDigits(IEnumerable<int> sequence, int digit)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException($"{nameof(sequence)} must be not null");
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentException($"{nameof(digit)} must be positive number");
            }

            List<int> result = new List<int>();
            string strDigit = Convert.ToString(digit);

            foreach (var item in sequence)
            {
                string str = Convert.ToString(item);
                if (str.Contains(strDigit))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        #endregion
    }
}
