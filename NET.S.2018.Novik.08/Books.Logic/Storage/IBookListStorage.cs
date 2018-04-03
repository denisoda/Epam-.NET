using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic.Storage
{
    public interface IBookListStorage
    {
        IEnumerable<Book> Load();
        void Save(IEnumerable<Book> items);
    }
}
