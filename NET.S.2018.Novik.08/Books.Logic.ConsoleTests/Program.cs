using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Logic;
using Books.Logic.Factories;
using Books.Logic.Services;

namespace Books.Logic.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookService = new BookListService(new BookListStorageFactory());
            bookService.AddBook(new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000));

            bookService.SaveInStorage();

            //var bookService;
        }
    }
}
