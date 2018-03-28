using System;
using System.Collections.Generic;

namespace Logic
{
    public static class BubbleSort
    {
        #region private fields

        private static IComparer<int> defaultOrder = new DefaultOrder();
        private static IComparer<int> descendingOrder = new DescendingOrder();

        #endregion

        #region public methods

        /// <summary>
        /// Sorts the rows in an entire jugged Array by minimum elements in rows.
        /// </summary>
        /// <param name="array">The jugged Array to sort.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array"/> is null.
        /// </exception>
        public static void SortByMinRowElement(int[][] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            InnerBubbleSortRows(array, GetMinRowsElements(array), defaultOrder);
        }

        /// <summary>
        /// Descending sorts the rows in an entire jugged Array by minimum elements in rows.
        /// </summary>
        /// <param name="array">The jugged Array to sort.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array"/> is null.
        /// </exception>
        public static void SortByMinRowElementDescending(int[][] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            InnerBubbleSortRows(array, GetMinRowsElements(array), descendingOrder);
        }

        /// <summary>
        /// Sorts the rows in an entire jugged Array by maximum elements in rows.
        /// </summary>
        /// <param name="array">The jugged Array to sort.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array"/> is null.
        /// </exception>
        public static void SortByMaxRowElement(int[][] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            InnerBubbleSortRows(array, GetMaxRowsElements(array), defaultOrder);
        }

        /// <summary>
        /// Descending sorts the rows in an entire jugged Array by maximum elements in rows.
        /// </summary>
        /// <param name="array">The jugged Array to sort.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array"/> is null.
        /// </exception>
        public static void SortByMaxRowElementDescending(int[][] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            InnerBubbleSortRows(array, GetMaxRowsElements(array), descendingOrder);
        }

        /// <summary>
        /// Sorts the rows in an entire jugged Array by sum elements of rows.
        /// </summary>
        /// <param name="array">The jugged Array to sort.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array"/> is null.
        /// </exception>
        public static void SortBySumRowElements(int[][] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            InnerBubbleSortRows(array, GetSumRowsElements(array), defaultOrder);
        }

        /// <summary>
        /// Descending sorts the rows in an entire jugged Array by sum elements of rows.
        /// </summary>
        /// <param name="array">The jugged Array to sort.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array"/> is null.
        /// </exception>
        public static void SortBySumRowElementsDescending(int[][] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            InnerBubbleSortRows(array, GetSumRowsElements(array), descendingOrder);
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

        private static int[] GetMinRowsElements(int[][] array)
        {
            int[] minRowsElements = new int[array.Length];
            int find = 0;

            for (int i = 0; i < array.Length; i++)
            {
                find = 0;
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (array[i][find] > array[i][j])
                    {
                        find = j;
                    }
                }

                minRowsElements[i] = array[i].Length == 0 ? 0 : array[i][find];
            }

            return minRowsElements;
        }

        private static int[] GetMaxRowsElements(int[][] array)
        {
            int[] maxRowsElements = new int[array.Length];
            int find = 0;

            for (int i = 0; i < array.Length; i++)
            {
                find = 0;
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (array[i][find] < array[i][j])
                    {
                        find = j;
                    }
                }

                maxRowsElements[i] = array[i].Length == 0 ? 0 : array[i][find];
            }

            return maxRowsElements;
        }

        private static int[] GetSumRowsElements(int[][] array)
        {
            int[] totalRows = new int[array.GetLength(0)];
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }

                totalRows[i] = sum;
            }

            return totalRows;
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
