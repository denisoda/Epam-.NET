using Books.Logic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Logic.Services
{
    /// <summary>
    /// Implementation a service to work with list of <see cref="Book"/>.
    /// </summary>
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

            if (this.IsExist(book))
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

            if (!this.IsExist(book, out int indexRemoveBook))
            {
                throw new BookDoesNotExistException($"{nameof(book)} is not in");
            }

            this.listBooks.RemoveAt(indexRemoveBook);
        }

        /// <summary>
        /// Find book by name.
        /// </summary>
        /// <param name="name">Name of book to find.</param>
        /// <returns>The </returns>
        public Book FindBookByName(string name)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (name == string.Empty)
            {
                throw new ArgumentException($"{nameof(name)} must be not empty");
            }

            foreach (var book in this.listBooks)
            {
                if (string.Compare(book.Name, name, StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    return book;
                }
            }

            return null;
        }

        /// <summary>
        /// Sorts By <paramref name="comparer"/>.
        /// </summary>
        /// <param name="comparer">Instance that impelemntation <see cref="IComparer{Book}"/>.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="comparer"/> is null.
        /// </exception>
        public void SortsBooksByTag(IComparer<Book> comparer)
        {
            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            this.listBooks.Sort(comparer);
        }

        /// <summary>
        /// Save state of this service in the storage.
        /// </summary>
        public void SaveInStorage()
        {
            this.storageFactory.GetStorage().Save(this.listBooks);
        }

        /// <summary>
        /// Converts <see cref="BookListService"/> states of this instance to its equvalent string representation.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            string result = string.Empty;

            foreach (var item in this.listBooks)
            {
                result += item + "\n";
            }

            return result;
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
