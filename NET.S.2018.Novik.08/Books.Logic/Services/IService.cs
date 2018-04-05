using System;
using System.Collections.Generic;

namespace Books.Logic.Services
{
    public interface IService
    {
        void AddBook(Book book);

        void RemoveBook(Book book);

        Book FindBookByName(string name);

        void SortsBooksByTag(IComparer<Book> comparer);

        void SaveInStorage();
    }
}
