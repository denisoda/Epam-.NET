//-----------------------------------------------------------------------
// <copyright file="Task2.cs" company="Epam training">
//     Copyright (c) Epam training. All rights reserved.
// </copyright>
// <author>Novik Ilya</author>
//-----------------------------------------------------------------------
namespace Tasks
{
    using System;

    /// <summary>
    /// Implementation task 2
    /// </summary>
    public class Task2
    {
        /// <summary>
        /// Find the closest number that greater than <paramref name="initialNumber"/>.
        /// </summary>
        /// <param name="initialNumber">Number.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="initialNumber"/> is a negative number
        /// </exception>
        /// <returns>Number.If number has not found then return -1.</returns>
        public static int FindNextBiggerNumber(int initialNumber)
        {
            if (initialNumber < 0)
            {
                throw new ArgumentException($"{nameof(initialNumber)} must be possitive number");
            }

            if (initialNumber < 11)
            {
                return -1;
            }

            string numberStr = Convert.ToString(initialNumber);
            int[] arrDigits = new int[numberStr.Length];

            for (int si = 0; si < numberStr.Length; si++)
            {
                arrDigits[si] = int.Parse(numberStr[si].ToString());
            }

            bool hasFound = false;
            int i = 0;
            int indexStartPoint = arrDigits.Length - 1;
            int indexFindNumber = 0;
            while (!hasFound && i < arrDigits.Length - 1)
            {
                for (int k = indexStartPoint; k >= indexStartPoint - i; k--)
                {
                    if (arrDigits[k]  > arrDigits[indexStartPoint - i - 1])
                    {
                        int temp = arrDigits[k];
                        arrDigits[k] = arrDigits[indexStartPoint - i - 1];
                        arrDigits[indexStartPoint - i - 1] = temp;
                        indexFindNumber = indexStartPoint - i;
                        hasFound = true;
                        break;
                    }
                }

                i++;
            }

            if (hasFound)
            {
                if (indexFindNumber != arrDigits.Length - 1)
                {
                    SortsHelper.QuickSort(arrDigits, indexFindNumber, arrDigits.Length - 1);
                }

                return Convert.ToInt32(string.Concat(arrDigits));
            }
            else
            {
                return -1;
            }
        }
    }
}
