using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic
{
    public interface IFinder
    {
        bool IsSought(Book book);
    }
}
