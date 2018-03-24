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

            InnerBubbleSortRows(array, GetMinRowsElements(array));
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

            InnerBubbleSortRowsDesc(array, GetMinRowsElements(array));
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

            InnerBubbleSortRows(array, GetMaxRowsElements(array));
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

            InnerBubbleSortRowsDesc(array, GetMaxRowsElements(array));
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

            InnerBubbleSortRows(array, GetSumRowsElements(array));
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

            InnerBubbleSortRowsDesc(array, GetSumRowsElements(array));
        }

        #endregion // public methods

        #region private methods

        private static void InnerBubbleSortRows(int[][] array, int[] keys)
        {
            bool isSort = false;
            for (int i = 0; i < keys.Length && !isSort; i++)
            {
                isSort = true;
                for (int j = 0; j < keys.Length - i - 1; j++)
                {
                    if (keys[j] > keys[j + 1])
                    {
                        int temp = keys[j];
                        keys[j] = keys[j + 1];
                        keys[j + 1] = temp;
                        SwapRows(array, j, j + 1);
                        isSort = false;
                    }
                }
            }
        }

        private static void InnerBubbleSortRowsDesc(int[][] array, int[] keys)
        {
            bool isSort = false;
            for (int i = 0; i < keys.Length && !isSort; i++)
            {
                isSort = true;
                for (int j = 0; j < keys.Length - i - 1; j++)
                {
                    if (keys[j] < keys[j + 1])
                    {
                        int temp = keys[j];
                        keys[j] = keys[j + 1];
                        keys[j + 1] = temp;
                        SwapRows(array, j, j + 1);
                        isSort = false;
                    }
                }
            }
        }

        private static int[] GetMinRowsElements(int[][] array)
        {
            int[] result = new int[array.Length];

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

                result[i] = array[i].Length == 0 ? 0 : array[i][find];
            }

            return result;
        }

        private static int[] GetMaxRowsElements(int[][] array)
        {
            int[] result = new int[array.Length];

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

                result[i] = array[i].Length == 0 ? 0 : array[i][find];
            }

            return result;
        }

        private static int[] GetArrayMaxElementsRow(int[][] array, Func<int, int, bool> func)
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

        private static int[] GetSumRowsElements(int[][] array)
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

        private static void SwapRows(int[][] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        #endregion // private methods
    }
}
