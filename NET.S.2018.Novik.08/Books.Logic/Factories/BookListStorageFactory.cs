using System;
using Books.Logic.Storage;

namespace Books.Logic.Factories
{
    public class BookListStorageFactory : IBookListStorageFactory
    {
        /// <summary>
        /// Create a instance that implementation <see cref="IBookListStorage"/>
        /// </summary>
        /// <returns>A storage instance.</returns>
        public IBookListStorage GetStorage()
        {
            return new BookListStorageBinaryFile("storage.dat");
        }
    }
}
