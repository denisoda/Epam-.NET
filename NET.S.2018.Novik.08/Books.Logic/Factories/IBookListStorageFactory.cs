using System;
using Books.Logic.Storage;

namespace Books.Logic.Factories
{
    public interface IBookListStorageFactory
    {
        IBookListStorage GetStorage();
    }
}
