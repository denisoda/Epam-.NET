using System;
using System.Collections.Generic;

namespace Books.Logic.SortByTag
{

    public class SortsByName : IComparer<Book>
    {
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

            return string.Compare(lhs.Name, rhs.Name, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
