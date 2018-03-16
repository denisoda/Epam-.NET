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
    /// Implementation task 2 (FindNextBiggerNumber)
    /// </summary>
    public class Task2
    {
        #region public methods

        /// <summary>
        /// Find the closest number that greater than <paramref name="number"/> that contains only <paramref name="number"/> digits.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="number"/> is a negative number
        /// </exception>
        /// <returns>
        /// Number.
        /// If required number has not found return -1.
        /// </returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} must be positive number");
            }

            // Numbers from 0 to 11 have not the required number
            if (number < 11)
            {
                return -1;
            }

            int[] arrDigits = ConvertIntToArrayDigits(number); // Using inner method
            bool hasFound = false; // The required number has found
            int size = 0; // Size of range
            int indexStartPoint = arrDigits.Length - 1;
            int indexStartSort = 0;

            while (!hasFound && size < arrDigits.Length - 1)
            {
                for (int k = indexStartPoint; k >= indexStartPoint - size; k--)
                {
                    if (arrDigits[k] > arrDigits[indexStartPoint - size - 1])
                    {
                        int temp = arrDigits[k];
                        arrDigits[k] = arrDigits[indexStartPoint - size - 1];
                        arrDigits[indexStartPoint - size - 1] = temp;
                        indexStartSort = indexStartPoint - size;
                        hasFound = true;
                        break;
                    }
                }

                size++;
            }

            // If the required number has found
            if (hasFound)
            {
                // Sort part digits of number
                if (indexStartSort != arrDigits.Length - 1)
                {
                    SortsHelper.QuickSort(arrDigits, indexStartSort, arrDigits.Length - 1); // User quick sort
                }

                return Convert.ToInt32(string.Concat(arrDigits));
            }
            else
            {
                return -1;
            }
        }

        #endregion

        #region private methods

        /// <summary>
        /// Convert number to array digits
        /// </summary>
        /// <param name="number">Number.</param>
        /// <returns>Array digits.</returns>
        private static int[] ConvertIntToArrayDigits(int number)
        {
            string numberStr = Convert.ToString(number);

            int[] resultArray = new int[numberStr.Length];

            for (int si = 0; si < numberStr.Length; si++)
            {
                resultArray[si] = int.Parse(numberStr[si].ToString());
            }

            return resultArray;
        }

        #endregion
    }
}
