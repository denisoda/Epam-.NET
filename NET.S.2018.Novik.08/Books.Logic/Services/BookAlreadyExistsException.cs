using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic.Services
{
    public class BookAlreadyExistsException : Exception
    {
        public BookAlreadyExistsException()
        {
        }

        public BookAlreadyExistsException(string message)
            : base(message)
        {
        }

        public BookAlreadyExistsException(string message, Exception innerException)
                    : base(message, innerException)
        {
        }
    }
}
