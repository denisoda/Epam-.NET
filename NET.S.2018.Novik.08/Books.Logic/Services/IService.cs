using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic.Services
{
    public interface IService
    {
        void AddBook(Book book);
        void RemoveBook(Book book);
        Book FindBookByTag(IFinder find);
        void SortsBooksByTag(IComparer<Book> comparer);
        void SaveInStorage();
    }
}
