using System;
using System.Collections.Generic;

namespace Books.Logic.SortByTag
{
    /// <summary>
    /// Defines a method that a type implements to compare two object
    /// of the <see cref="Book"/> by <see cref="Book.YearOfPublishing"/>.
    /// </summary>
    public class SortsByYearOfPublishing : IComparer<Book>
    {
        /// <summary>
        /// Compare two object of the <see cref="Book"/> by <see cref="Book.YearOfPublishing"/>.
        /// </summary>
        /// <param name="lhs">First book to compare.</param>
        /// <param name="rhs">Second book to compare.</param>
        /// <returns>A value that indicates the relative order of the <see cref="Book"/> being compared.</returns>
        public int Compare(Book lhs, Book rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return lhs.YearOfPublishing.CompareTo(rhs.YearOfPublishing);
        }
    }
}
