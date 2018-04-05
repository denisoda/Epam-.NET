using System;
using System.Collections.Generic;

namespace Books.Logic.Storage
{
    public interface IBookListStorage
    {
        IEnumerable<Book> Load();

        void Save(IEnumerable<Book> items);
    }
}
