using System;

namespace Tasks
{
    /// <summary>
    /// Implementation task 1
    /// </summary>
    public class Task1
    {
        #region public methods

        /// <summary>
        /// Inserting one number into another so that the second number occupies
        /// the position from bit <paramref name="start"/> to bit <paramref name="end"/> (bits are numbered from right to left).
        /// </summary>
        /// <param name="number1">The source number.</param>
        /// <param name="number2">number to insert</param>
        /// <param name="start">left border</param>
        /// <param name="end">right border</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="start"/> greater than <paramref name="end"/> or
        /// (<paramref name="start"/> &lt; 0) || (<paramref name="start"/> &gt; 31)
        /// || (<paramref name="end"/> &lt; 0) || (<paramref name="end"/> &gt; 31).
        /// </exception>
        /// <returns>An integer.</returns>
        public static int InsertNumber(int number1, int number2, int start, int end)
        {
            if (end < start)
            {
                throw new ArgumentException($" {nameof(end)} could not less than {nameof(start)} ");
            }

            const int MAXBITS = 31; // max bits type int
            const int MINBITS = 0;

            if ((start < MINBITS || start > MAXBITS) || (end > MAXBITS || end < MINBITS))
            {
                throw new ArgumentException($"Parameters goes range");
            }

            for (int i = start, j = 0; i <= end; i++, j++)
            {
                // If the bit is 1
                if ((number2 & (1 << j)) == 0)
                {
                    number1 = number1 & ~(1 << i);
                }
                else
                {
                    number1 = number1 | (1 << i);
                }
            }

            return number1;
        }

        #endregion
    }
}
