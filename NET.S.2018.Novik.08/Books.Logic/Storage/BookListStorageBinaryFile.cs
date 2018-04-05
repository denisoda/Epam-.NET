using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Books.Logic.Storage
{
    /// <summary>
    /// The books storage is based by binary file.
    /// </summary>
    public class BookListStorageBinaryFile : IBookListStorage
    {
        #region Private fields

        private string _path;

        #endregion

        #region Constructors

        public BookListStorageBinaryFile(string path)
        {
            this.Path = path;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Path of a file.
        /// </summary>
        public string Path
        {
            get
            {
                return this._path;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this._path = value;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Load <see cref="Book"/> from the binary file.
        /// </summary>
        /// <returns>Load sequence of <see cref="Book"/>.</returns>
        public IEnumerable<Book> Load()
        {
            List<Book> listLoadBooks = new List<Book>();

            using (Stream stream = File.Open(this.Path, FileMode.OpenOrCreate))
            {
                using (BinaryReader binaryReader = new BinaryReader(stream))
                {
                    while (binaryReader.PeekChar() > -1)
                    {
                        string ISBN = binaryReader.ReadString();
                        string autor = binaryReader.ReadString();
                        string name = binaryReader.ReadString();
                        string publisher = binaryReader.ReadString();
                        int yearOfPublishing = binaryReader.ReadInt32();
                        int count = binaryReader.ReadInt32();
                        decimal price = binaryReader.ReadDecimal();

                        Book book = new Book(ISBN, autor, name, publisher, yearOfPublishing, count, price);
                        listLoadBooks.Add(book);
                    }
                }
            }

            return listLoadBooks;
        }

        /// <summary>
        /// Save sequence of <see cref="Book"/> to the storage.
        /// </summary>
        /// <param name="items">The sequence of <see cref="Book"/>.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="items"/> is null.
        /// </exception>
        public void Save(IEnumerable<Book> items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            using (Stream stream = File.Open(this.Path, FileMode.Truncate))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                {
                    foreach (var book in items)
                    {
                        binaryWriter.Write(book.ISBN);
                        binaryWriter.Write(book.Author);
                        binaryWriter.Write(book.Name);
                        binaryWriter.Write(book.Publisher);
                        binaryWriter.Write(book.YearOfPublishing);
                        binaryWriter.Write(book.Count);
                        binaryWriter.Write(book.Price);
                    }
                }
            }
        }

        #endregion
    }
}
