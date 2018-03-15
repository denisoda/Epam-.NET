//-----------------------------------------------------------------------
// <copyright file="Task1.cs" company="Epam training">
//     Copyright (c) Epam training. All rights reserved.
// </copyright>
// <author>Novik Ilya</author>
//-----------------------------------------------------------------------
namespace Tasks
{
    using System;

    /// <summary>
    /// Implementation task 1
    /// </summary>
    public class Task1
    {
        /// <summary>
        /// Inserting one number into another so that the second number occupies the position from bit <paramref name="start"/> to bit <paramref name="end"/> (bits are numbered from right to left)
        /// </summary>
        /// <param name="numberSource">the source number</param>
        /// <param name="numberInsert">the number to insert</param>
        /// <param name="start">left border </param>
        /// <param name="end">right bodrder</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="start"/> greater than <paramref name="end"/> or
        /// (<paramref name="start"/> &lt; 0) || (<paramref name="start"/> &gt; 31) 
        /// || (<paramref name="end"/> &lt; 0) || (<paramref name="end"/> &gt; 31).
        /// </exception>
        /// <returns>number is the number source contains bits of the number in</returns>
        public static int InsertNumber(int numberSource, int numberInsert, int start, int end)
        {
            if (end < start)
            {
                throw new ArgumentException($" {nameof(end)} could not less than {nameof(start)} ");
            }

            const int MAXBITS = 31;
            const int MINBITS = 0;

            if ((start < MINBITS || start > MAXBITS) || (end > MAXBITS  || end < MINBITS))
            {
                throw new ArgumentException($"Parameters goes range");
            }

            for (int i = start, j = 0; i <= end; i++, j++)
            {
                if ((numberInsert & (1 << j)) == 0)
                {
                    numberSource = numberSource & ~(1 << i);
                }
                else
                {
                    numberSource = numberSource | (1 << i);
                }
            }

            return numberSource;
        }
    }
}
