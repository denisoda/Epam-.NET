﻿using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Implementation sort jugged array by bubble sort.
    /// </summary>
    public static class BubbleSort
    {
        #region public methods

        /// <summary>
        /// Sorts the rows in an entire jugged Array by minimum elements in rows.
        /// </summary>
        /// <param name="array">The jugged Array to sort.</param>
        /// <param name="keys">Keys to sort.</param>
        /// <param name="comparer">The instance of class that implementation IComparer to define order sort.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array"/> is null.
        /// <paramref name="comparer"/> is null.
        /// <paramref name="keys"/> is null.
        /// </exception>
        public static void SortRows(int[][] array, int[] keys, IComparer<int> comparer)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (keys is null)
            {
                throw new ArgumentNullException(nameof(keys));
            }

            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            InnerBubbleSortRows(array, keys, comparer.Compare);
        }

        #endregion // public methods

        #region private methods

        private static void InnerBubbleSortRows(int[][] items, int[] keys, Comparison<int> comparison)
        {
            bool isSort = false;

            for (int i = 0; i < keys.Length && !isSort; i++)
            {
                isSort = true;
                for (int j = 0; j < keys.Length - i - 1; j++)
                {
                    if (comparison(keys[j], keys[j + 1]) == 1)
                    {
                        SwapKeys(keys, j, j + 1);
                        SwapRows(items, j, j + 1);
                        isSort = false;
                    }
                }
            }
        }

        private static void SwapRows(int[][] array, int indexFirstRow, int indexSecondRow)
        {
            var temp = array[indexFirstRow];
            array[indexFirstRow] = array[indexSecondRow];
            array[indexSecondRow] = temp;
        }

        private static void SwapKeys(int[] keys, int indexFirstKey, int indexSecondKey)
        {
            int temp = keys[indexFirstKey];
            keys[indexFirstKey] = keys[indexSecondKey];
            keys[indexSecondKey] = temp;
        }

        #endregion // !private methods
    }
}
