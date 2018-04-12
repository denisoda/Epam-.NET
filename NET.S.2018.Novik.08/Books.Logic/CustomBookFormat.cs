using System;
using System.Globalization;
using System.Text;

namespace Books.Logic
{
    public class CustomBookFormat : IFormatProvider, ICustomFormatter
    {
        IFormatProvider parent;

        public CustomBookFormat()
            : this(CultureInfo.CurrentCulture)
        {
        }

        public CustomBookFormat(IFormatProvider parent)
        {
            this.parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || format != "IATPYCP+")
            {
                return string.Format(this.parent, format, arg);
            }

            var book = arg as Book;

            if (format == "IATPYCP+")
            {
                return $"{book.ISBN}. {book.Author} - {book.Title}, {book.Publisher}, {book.YearOfPublishing}, {book.Count} pages, {book.Price.ToString("C", formatProvider)}";
            }

            throw new FormatException($"{format} is not supported");
        }
    }
}
