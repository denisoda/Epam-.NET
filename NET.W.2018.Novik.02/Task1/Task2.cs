using System;
using System.Linq;

namespace Tasks
{
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
        /// Thrown when <paramref name="number"/> is a negative number.
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

            int[] arrDigits = ConvertIntToArrayDigits(number);

            bool hasFound = false;
            int size = 0;
            int indexStartPoint = arrDigits.Length - 1;

            while (!hasFound && size < arrDigits.Length - 1)
            {
                for (int k = indexStartPoint; k >= indexStartPoint - size; k--)
                {
                    if (arrDigits[k] > arrDigits[indexStartPoint - size - 1])
                    {
                        int temp = arrDigits[k];
                        arrDigits[k] = arrDigits[indexStartPoint - size - 1];
                        arrDigits[indexStartPoint - size - 1] = temp;
                        hasFound = true;
                        break;
                    }
                }

                size++;
            }

            if (!hasFound)
            {
                return -1;
            }

            if (size > 1)
            {
                SortsHelper.QuickSort(arrDigits, --size, arrDigits.Length - 1); // Use quick sort
            }

            return Convert.ToInt32(string.Concat(arrDigits));
        }

        #endregion

        #region private methods

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
