using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic.Services
{
    public class BookDoesNotExistException : Exception
    {
        public BookDoesNotExistException()
        {

        }

        public BookDoesNotExistException(string message) : base(message)
        {

        }
    }
}
