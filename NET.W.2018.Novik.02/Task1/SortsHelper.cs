//-----------------------------------------------------------------------
// <copyright file="SortsHelper.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Novik Ilya</author>
//-----------------------------------------------------------------------
namespace Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Contains implementation algorithms:
    /// Merge sort
    /// Quick sort
    /// </summary>
    public class SortsHelper
    {
        #region Merge Sort
        /// <summary>
        /// Implementation algorithm  Merge Sort (via inner method InnerMergeSort)
        /// </summary>
        /// <param name="array">Array type of int</param>
        /// <returns>Sorted array</returns>
        public static int[] MergerSort(int[] array)
        {
            return InnerMergeSort(array, 0, array.Length - 1); // invoke inner mergersort
        }

        /// <summary>
        /// Inner impelementation algorithm of Merge Sort. Used for recurcive calls.
        /// </summary>
        /// <param name="array">Input array of integer numbers</param>
        /// <param name="start">Begin point of array</param>
        /// <param name="end">End point of array</param>
        /// <returns>Sorted array</returns>
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
                /*
                 * if left array is empty , then add elemnt from right array
                 */
                if (indexLeft >= left.Length)  
                {
                    result[i] = right[indexRight++];
                    continue;
                }

                /*
                 * if right array is empty , then add elemnt from left array 
                 */
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

        #endregion

        #region Quick Sort
        /// <summary>
        /// Implementation algorithm Quick Sort (via inner method InnerQuickSort)
        /// </summary>
        /// <param name="array">Array type of int</param>
        public static void QuickSort(int[] array)
        {
            InnerQuickSort(array, 0, array.Length - 1); // invoke inner quicksort
        }

        public static void QuickSort(int[] array, int start, int end)
        {
            if (start < 0 || end > array.Length - 1 )
            {
                throw new IndexOutOfRangeException();
            }

            if (start >= end)
            {
                throw new ArgumentException();
            }

            InnerQuickSort(array, start, end); // invoke inner quicksort
        }

        /// <summary>
        /// Inner impelementation algorithm of Quick Sort. Used for recurcive calls.
        /// </summary>
        /// <param name="array">Input array of integer numbers</param>
        /// <param name="start">Begin point of array</param>
        /// <param name="end">End point of array</param>
        private static void InnerQuickSort(int[] array, int start, int end)
        {
            int i = start, j = end;
            int middle = start + ((end - start) >> 1);
            int middleElement = array[middle];

            while (i <= j)
            {
                // find element less than half
                while (array[i] < middleElement)
                {
                    i++;
                }

                // find element bigger than half
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

            /*
             * if left part of array has not order , then do sort again
             */
            if (start < j)
            {
                InnerQuickSort(array, start, j);
            }

            /*
             * if right part of array has not order , then do sort again
             */           
            if (i < end)
            {
                InnerQuickSort(array, i, end);
            }
        }
        #endregion
    }
}
