using System;

namespace Logic
{
    public static class BubbleSort
    {
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

            InnerSortByMinRowElements(array, (a, b) => a > b);
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

            InnerSortByMinRowElements(array, (a, b) => a < b);
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

            InnerSortByMaxRowElements(array, (a, b) => a > b);
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

            InnerSortByMaxRowElements(array, (a, b) => a < b);
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

            InnerSortBySumElements(array, (a, b) => a > b);
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

            InnerSortBySumElements(array, (a, b) => a < b);
        }

        #endregion // public methods

        #region private methods

        private static void InnerBubbleSort(int[][] array, Func<int[][], int[]> getKeys, Func<int, int, bool> order)
        {
            int[] sumRows = getKeys(array);
            bool isSort = false;

            for (int i = 0; i < sumRows.Length && !isSort; i++)
            {
                isSort = true;
                for (int j = 0; j < sumRows.Length - i - 1; j++)
                {
                    if (order(sumRows[j], sumRows[j + 1]))
                    {
                        int temp = sumRows[j];
                        sumRows[j] = sumRows[j + 1];
                        sumRows[j + 1] = temp;
                        SwapRows(array, j, j + 1);
                        isSort = false;
                    }
                }
            }
        }
        #region Sort by min (max) elements of rows

        private static void InnerSortByMinRowElements(int[][] array, Func<int, int, bool> func)
        {
            InnerBubbleSort(array, GetMinRowsElements, func);
        }

        private static void InnerSortByMaxRowElements(int[][] array, Func<int, int, bool> func)
        {
            InnerBubbleSort(array, GetMaxRowsElements, func);
        }

        private static int[] GetMinRowsElements(int[][] array)
        {
            return GetElements(array, (a, b) => a > b);
        }

        private static int[] GetMaxRowsElements(int[][] array)
        {
            return GetElements(array, (a, b) => a < b);
        }

        private static int[] GetElements(int[][] array, Func<int, int, bool> func)
        {
            int[] result = new int[array.GetLength(0)];

            int find = 0;
            for (int i = 0; i < array.Length; i++)
            {
                find = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (func(find, array[i][j]))
                    {
                        find = array[i][j];
                    }
                }

                result[i] = find;
            }

            return result;
        }

        #endregion

        #region Sort by sum elements of rows

        private static void InnerSortBySumElements(int[][] array, Func<int, int, bool> func)
        {
            InnerBubbleSort(array, SumRows, func);
        }

        private static int[] SumRows(int[][] array)
        {
            int[] result = new int[array.GetLength(0)];

            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }

                result[i] = sum;
            }

            return result;
        }

        #endregion

        private static void SwapRows(int[][] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        #endregion // private methods
    }
}
