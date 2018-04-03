using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Logic.Storage;

namespace Books.Logic.Factories
{
    public interface IBookListStorageFactory
    {
        IBookListStorage GetStorage();
    }
}
