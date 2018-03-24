using System;

namespace Sorts
{
    /// <summary>
    /// Contains implementation algorithms:
    /// Merge sort
    /// Quick sort
    /// </summary>
    public class SortsHelper
    {
        #region public methods

        /// <summary>
        /// Sort array of integer by Merger sort.
        /// </summary>
        /// <param name="array">Array to sort.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="array"/> is null.
        /// </exception>
        /// <returns>Sorted array</returns>
        public static int[] MergerSort(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            return InnerMergeSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Sort array of integer by Quick sort.
        /// </summary>
        /// <param name="array">Array to sort.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="array"/> is null.
        /// </exception>
        /// <returns>Sorted array</returns>
        public static void QuickSort(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            InnerQuickSort(array, 0, array.Length - 1);
        }

        #endregion

        #region private methods


        private static int[] InnerMergeSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return new int[] { array[start] };
            }

            int middle = start + ((end - start) >> 1);

            int[] left = InnerMergeSort(array, start, middle);
            int[] right = InnerMergeSort(array, middle + 1, end);
            int[] result = new int[left.Length + right.Length];

            int indexLeft = 0;
            int indexRight = 0;

            for (int i = 0; i < result.Length; i++)
            {
                if (indexLeft >= left.Length)
                {
                    result[i] = right[indexRight++];
                    continue;
                }

                if (indexRight >= right.Length)
                {
                    result[i] = left[indexLeft++];
                    continue;
                }

                if (right[indexRight] >= left[indexLeft])
                {
                    result[i] = left[indexLeft++];
                }
                else
                {
                    result[i] = right[indexRight++];
                }
            }

            return result;
        }

        private static void InnerQuickSort(int[] array, int start, int end)
        {
            int i = start, j = end;
            int middle = start + ((end - start) >> 1);
            int middleElement = array[middle];

            while (i <= j)
            {
                while (array[i] < middleElement)
                {
                    i++;
                }

                while (array[j] > middleElement)
                {
                    j--;
                }

                if (i <= j)
                {
                    int tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (start < j)
            {
                InnerQuickSort(array, start, j);
            }
            
            if (i < end)
            {
                InnerQuickSort(array, i, end);
            }
        }

        #endregion
    }
}
