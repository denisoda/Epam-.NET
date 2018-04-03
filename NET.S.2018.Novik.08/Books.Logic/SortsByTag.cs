using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic
{
    class SortsByISBN : IComparer<Book>
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

            return string.Compare(lhs.ISBN, rhs.ISBN);
        }
    }

    class SortsByAuthor : IComparer<Book>
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

            return string.Compare(lhs.Autor, rhs.Autor, StringComparison.InvariantCultureIgnoreCase);
        }
    }

    class SortsByName : IComparer<Book>
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

    class SortsByPublisher : IComparer<Book>
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

            return string.Compare(lhs.Publisher, rhs.Publisher, StringComparison.InvariantCultureIgnoreCase);
        }
    }

    class SortsByPrice : IComparer<Book>
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

            return Decimal.Compare(lhs.Price, rhs.Price);
        }
    }

    class SortsByCount : IComparer<Book>
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

            return lhs.Count.CompareTo(rhs.Count);
        }
    }

    class SortsByYearOfPublishing : IComparer<Book>
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

            return lhs.YearOfPublishing.CompareTo(rhs.YearOfPublishing); 
        }
    }
}
