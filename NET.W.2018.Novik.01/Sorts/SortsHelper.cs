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
                // if left array is empty , then add elemnt from right array
                if (indexLeft >= left.Length) { result[i] = right[indexRight++]; continue; }
                // if right array is empty , then add elemnt from left array
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

        private static void innerQuickSort(int[] array, int start, int end)
        {
            int i = start, j = end;
            int halfElement = array[start + (end - start >> 1)];

            while (i <= j)
            {
                // find element less than half
                while (array[i] < halfElement)
                {
                    i++;
                }

                // find element bigger than half
                while (array[j] > halfElement)
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

            // if left part of array has not order , then do sort again
            if (start < j)
            {
                innerQuickSort(array, start, j);
            }
            // if right part of array has not order , then do sort again
            if (i < end)
            {
                innerQuickSort(array, i, end);
            }
        }
        #endregion

    }
}
