using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Logic.Factories;

namespace Books.Logic.Services
{
    public class BookListService : IService
    {
        #region Private fields

        private readonly IBookListStorageFactory storageFactory;
        private List<Book> listBooks;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class by instance of factory of storage.
        /// </summary>
        /// <param name="storageFactory">The factory of storage.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="storageFactory"/> is null.
        /// </exception>
        public BookListService(IBookListStorageFactory storageFactory)
        {
            if (storageFactory is null)
            {
                throw new ArgumentNullException(nameof(storageFactory));
            }

            this.storageFactory = storageFactory;
            this.listBooks = this.storageFactory.GetStorage().Load().ToList();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Add a book to the service.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="book"/> is null.
        /// </exception>
        /// <exception cref="BookAlreadyExistsException">
        /// <paramref name="book"/> exists in the service.
        /// </exception>
        /// <param name="book">The Book to add.</param>
        public void AddBook(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (IsExist(book))
            {
                throw new BookAlreadyExistsException($"{nameof(book)} already exists in the service");
            }

            this.listBooks.Add(book);
        }

        /// <summary>
        /// Remove a book from the service.
        /// </summary>
        /// <exception cref="BookDoesNotExistException">
        /// <paramref name="book"/> does not exist in the service.
        /// </exception>
        /// <param name="book">Book to remove.</param>
        public void RemoveBook(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (!IsExist(book, out int indexRemoveBook))
            {
                throw new BookDoesNotExistException($"{nameof(book)} is not in");
            }

            this.listBooks.RemoveAt(indexRemoveBook);

        }

        public Book FindBookByTag(IFinder find)
        {
            if (find is null)
            {
                throw new ArgumentNullException(nameof(find));
            }

            foreach (var book in this.listBooks)
            {
                if (find.IsSought(book))
                {
                    return book;
                }
            }

            return null;
        }

        /// <summary>
        /// Sorts By <paramref name="comparer"/>.
        /// </summary>
        /// <param name="comparer"></param>
        public void SortsBooksByTag(IComparer<Book> comparer)
        {
            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            this.listBooks.Sort(comparer);
        }

        public void SaveInStorage()
        {
            this.storageFactory.GetStorage().Save(this.listBooks);
        }

        public override string ToString()
        {
            return $"service contains {this.listBooks.Count} books";
        }

        #endregion !Public methods

        #region Private methods

        private bool IsExist(Book book)
        {
            bool result = false;

            foreach (var item in this.listBooks)
            {
                if (item.Equals(book))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private bool IsExist(Book book, out int index)
        {
            bool result = false;
            index = -1;

            for (int i = 0; i < this.listBooks.Count; i++)
            {
                if (book.Equals(this.listBooks[i]))
                {
                    result = true;
                    index = i;
                    break;
                }
            }

            return result;
        }

        #endregion !Private methods
    }
}
