using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public class SortsHelper
    {

        #region Merge Sort
        /// <summary>
        /// Merge Sort
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] MergerSort(int[] array)
        {
            return innerMergeSort(array, 0, array.Length - 1); // invoke inner mergersort
        }
        public static int[] innerMergeSort(int[] array, int start, int end)
        {
            if (start >= end) return new int[] { array[start] };

            int middle = start + (end - start >> 1);

            int[] left = innerMergeSort(array, start, middle);
            int[] right = innerMergeSort(array, middle + 1, end);
            int[] result = new int[left.Length + right.Length];

            int indexLeft = 0;
            int indexRight = 0;

            for (int i = 0; i < result.Length; i++)
            {
                if (indexLeft >= left.Length) { result[i] = right[indexRight++]; continue; }
                if (indexRight >= right.Length) { result[i] = left[indexLeft++]; continue; }

                if (right[indexRight] >= left[indexLeft])
                { result[i] = left[indexLeft++]; }
                else
                { result[i] = right[indexRight++]; }
            }

            return result;
        }

        #endregion

        #region Quick Sort
        /// <summary>
        /// Quick Sort
        /// </summary>
        /// <param name="array"></param>
        public static void QuickSort(int[] array)
        {
            innerQuickSort(array, 0, array.Length - 1); // invoke inner quicksort
        }

        private static void innerQuickSort(int[] array, int left, int right)
        {
            int i = left, j = right;
            int halfElement = array[left + (right - left >> 1)];

            while (i <= j)
            {
                while (array[i] < halfElement)
                {
                    i++;
                }

                while (array[j] > halfElement)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    int tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                innerQuickSort(array, left, j);
            }

            if (i < right)
            {
                innerQuickSort(array, i, right);
            }
        }
        #endregion

    }
}
