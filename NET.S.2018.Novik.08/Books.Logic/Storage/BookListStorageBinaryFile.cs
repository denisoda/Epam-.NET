using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Books.Logic.Storage
{
    class BookListStorageBinaryFile : IBookListStorage
    {

        private string _path;

        public string Path
        {
            get
            {
                return this._path;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this._path = value;
            }
        }

        public BookListStorageBinaryFile(string path)
        {
            this.Path = path;
        }

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
                        binaryWriter.Write(book.Autor);
                        binaryWriter.Write(book.Name);
                        binaryWriter.Write(book.Publisher);
                        binaryWriter.Write(book.YearOfPublishing);
                        binaryWriter.Write(book.Count);
                        binaryWriter.Write(book.Price);
                    }
                }
            }
        }
    }
}
