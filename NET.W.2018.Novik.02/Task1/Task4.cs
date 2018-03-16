//-----------------------------------------------------------------------
// <copyright file="Task4.cs" company="Epam training">
//     Copyright (c) Epam training. All rights reserved.
// </copyright>
// <author>Novik Ilya</author>
//-----------------------------------------------------------------------
namespace Tasks
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation task 4 (FilterDigit)
    /// </summary>
    public class Task4
    {
        #region public methods

        /// <summary>
        /// Find numbers which has <paramref name="digit"/>
        /// </summary>
        /// <param name="sequence">Input sequence</param>
        /// <param name="digit">Digit</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="digit"/> is not a positive digit
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="sequence"/> is null
        /// </exception>
        /// <returns>Sequence has numbers which contains <paramref name="digit"/></returns>
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
