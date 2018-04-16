using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Provides methods for sort.
    /// </summary>
    public class BinarySearch
    {

        #region Public methods

        /// <summary>
        /// Search <paramref name="element"/> in <paramref name="array"/> by binary search.
        /// To compare elements using <see cref="Comparer{T}"/>
        /// </summary>
        /// <typeparam name="T">Type implementations <see cref="IComparer{T}"/></typeparam>
        /// <param name="array">Array to search in.</param>
        /// <param name="element">Element to search.</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="array"/> is null.
        /// If <paramref name="element"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <typeparamref name="T"/> type does not impelemnts <see cref="IComparer{T}"/>.
        /// </exception>
        /// <returns>Found element's index. If <paramref name="element"/> not found then return -1.</returns>
        public static int Search<T>(T[] array, T element)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (ReferenceEquals(element, null))
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (Comparer<T>.Default == null)
            {
                throw new ArithmeticException($"{nameof(element)} must implementation IComparer");
            }

            return InnerBinarySearch(array, element, Comparer<T>.Default.Compare, 0, array.Length - 1);
        }

        /// <summary>
        /// Search <paramref name="element"/> in <paramref name="array"/> by binary search.
        /// To compare elements using <see cref="Comparer{T}"/>
        /// </summary>
        /// <typeparam name="T">Any type.</typeparam>
        /// <param name="array">Array to search in.</param>
        /// <param name="element">Element to search.</param>
        /// <param name="comparer">An instance of type that implements <see cref="IComparer{T}"./></param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="array"/> is null.
        /// If <paramref name="element"/> is null.
        /// If <paramref name="comparer"/> is null.
        /// </exception>
        /// <returns>Found element's index. If <paramref name="element"/> not found then return -1.</returns>
        public static int Search<T>(T[] array, T element, IComparer<T> comparer)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (ReferenceEquals(element, null))
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (comparer == null)
            {
                throw new ArithmeticException($"{nameof(element)} must implementation IComparer");
            }

            return InnerBinarySearch(array, element, comparer.Compare, 0, array.Length - 1);
        }

        #endregion

        #region Private methods

        private static int InnerBinarySearch<T>(T[] array, T element, Comparison<T> comparison, int start, int end)
        {
            while (start <= end)
            {
                int mid = start + ((end - start) >> 1);
                int resultCompare = comparison(array[mid], element);

                if (resultCompare == 0)
                {
                    return mid;
                }

                if (resultCompare > 0)
                {
                    end = mid - 1;
                }

                if (resultCompare < 0)
                {
                    start = mid + 1;
                }
            }

            return -1;
        }

        #endregion

    }
}
