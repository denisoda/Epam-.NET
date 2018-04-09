using System;
using System.Collections.Generic;

namespace Logic
{
    public class BubbleSortDelegate
    {
        #region public methods

        /// <summary>
        /// Sorts the rows in an entire jugged Array by minimum elements in rows.
        /// </summary>
        /// <param name="array">The jugged Array to sort.</param>
        /// <param name="keys">Keys to sort.</param>
        /// <param name="comparator">The delegate to define order sort.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array"/> is null.
        /// <paramref name="comparer"/> is null.
        /// <paramref name="keys"/> is null.
        /// </exception>
        public static void SortRows(int[][] array, int[] keys, Comparison<int> comparator)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (keys is null)
            {
                throw new ArgumentNullException(nameof(keys));
            }

            if (comparator is null)
            {
                throw new ArgumentNullException(nameof(comparator));
            }

            InnerBubbleSortRows(array, keys, new DelegateComparer(comparator));
        }

        #endregion // public methods

        #region private methods

        private static void InnerBubbleSortRows(int[][] items, int[] keys, IComparer<int> comparer)
        {
            bool isSort = false;

            for (int i = 0; i < keys.Length && !isSort; i++)
            {
                isSort = true;
                for (int j = 0; j < keys.Length - i - 1; j++)
                {
                    if (comparer.Compare(keys[j], keys[j + 1]) == 1)
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