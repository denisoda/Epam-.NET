using System;
using System.Collections.Generic;

namespace Logic
{
    public class KeysForSort
    {
        /// <summary>
        /// Get array of min numbers in each rows jugged array.
        /// </summary>
        /// <param name="array">The jugged array.</param>
        /// <returns>Array of min numbers.</returns>
        public static int[] GetMinRowsElements(int[][] array)
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

        /// <summary>
        /// Get array of max numbers in each rows jugged array.
        /// </summary>
        /// <param name="array">The jugged array.</param>
        /// <returns>Array of max numbers.</returns>
        public static int[] GetMaxRowsElements(int[][] array)
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

        /// <summary>
        /// Get array of sum numbers in each rows jugged array.
        /// </summary>
        /// <param name="array">The jugged array.</param>
        /// <returns>Array of sum numbers in each rows.</returns>
        public static int[] GetSumRowsElements(int[][] array)
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

    }
}
