using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Books.Logic
{
    /// <summary>
    /// Entity of book.
    /// </summary>
    public class Book : IEquatable<Book>, IComparable<Book>, IFormattable
    {
        #region Private fields

        private string _ISBN;
        private string _author;
        private string _title;
        private string _publisher;
        private int _yearOfPublishing;
        private int _count;
        private decimal _price;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class by parameters.
        /// </summary>
        /// <param name="ISBN">The international standard book number.</param>
        /// <param name="author">The autor of book.</param>
        /// <param name="name">The name book.</param>
        /// <param name="publisher">The publisher book.</param>
        /// <param name="yearOfPublishing">Year of publication.</param>
        /// <param name="count">Count of pages.</param>
        /// <param name="price">The price.</param>
        /// <exception cref="ArgumentException">
        /// If any parameters does not match format.
        /// </exception>
        public Book(string ISBN, string author, string name, string publisher, int yearOfPublishing, int count, decimal price)
        {
            this.ISBN = ISBN;
            this.Author = author;
            this.Title = name;
            this.Publisher = publisher;
            this.YearOfPublishing = yearOfPublishing;
            this.Count = count;
            this.Price = price;
        }

        #endregion

        #region Propertias

        /// <summary>
        /// The international standard book number.
        /// The number has a special format.
        /// </summary>
        public string ISBN
        {
            get
            {
                return this._ISBN;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                const string patternISBN = @"\d{1,3}-\d{1,3}-\d{1,6}-\d{1,5}-\d{1}";
                if (!Regex.IsMatch(value, patternISBN))
                {
                    throw new ArgumentException($"{nameof(value)} must match correct format.");
                }

                this._ISBN = value;
            }
        }

        /// <summary>
        /// The author this book.
        /// </summary>
        public string Author
        {
            get
            {
                return this._author;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException($"{nameof(value)} must be not empty");
                }

                this._author = value;
            }
        }

        /// <summary>
        /// The name this book.
        /// </summary>
        public string Title
        {
            get
            {
                return this._title;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException($"{nameof(value)} must be not empty");
                }

                this._title = value;
            }
        }

        /// <summary>
        /// The name publisher that has produced this book.
        /// </summary>
        public string Publisher
        {
            get
            {
                return this._publisher;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException($"{nameof(value)} must be not empty");
                }

                this._publisher = value;
            }
        }

        /// <summary>
        /// Year of publishing.
        /// </summary>
        public int YearOfPublishing
        {
            get
            {
                return this._yearOfPublishing;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(value)} must be greater than 0");
                }

                this._yearOfPublishing = value;
            }
        }

        /// <summary>
        /// The count page in this book.
        /// </summary>
        public int Count
        {
            get
            {
                return this._count;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(value)} must be greater than 0");
                }

                this._count = value;
            }
        }

        /// <summary>
        /// Cost this book.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this._price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(value)} must be greater than 0");
                }

                this._price = value;
            }
        }

        #endregion !Public propertias

        #region Public methods

        /// <summary>
        /// Converts <see cref="Book"/> states of this instance to its equvalent string representation.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            string bookAsString = $"[\"ISBN\":{this.ISBN}; \"Autor\": {this.Author}; \"Name\": {this.Title}; \"Publisher\": {this.Publisher}; " +
                $"\"YearOfPublishing\": {this.YearOfPublishing}; \"Count\": {this.Count}; \"Price\": {this.Price}]";
            return bookAsString;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "IATPYCP";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "IATPYCP":
                    return $"{this.ISBN}. {this.Author} - {this.Title}, {this.Publisher}, {this.YearOfPublishing}, {this.Count} pages, {this.Price.ToString("C", formatProvider)}";
                case "IATPYC":
                    return $"{this.ISBN}. {this.Author} - {this.Title}, {this.Publisher}, {this.YearOfPublishing}, {this.Count} pages";
                case "IATPY":
                    return $"{this.ISBN}. {this.Author} - {this.Title}, {this.Publisher}, {this.YearOfPublishing}";
                case "IATP":
                    return $"{this.ISBN}. {this.Author} - {this.Title}, {this.Publisher}";
                case "IAT":
                    return $"{this.ISBN}. {this.Author} - {this.Title}";
                case "AT":
                    return $"{this.Author} - {this.Title}";
            }

            throw new FormatException($"{format} is not supported");
        }

        /// <summary>
        /// Returns a value indicating  wheter this instance is equal to a specified <see cref="Book"/> instance.
        /// </summary>
        /// <param name="other">A <see cref="Book"/> instance to compare with this <see cref="Book"/> instance.</param>
        /// <returns>
        /// <see cref="true"/> if the specified <see cref="Book"/> instance is equal to the current <see cref="Book"/> instance; otherwise, <see cref="false"/>.
        /// </returns>
        public bool Equals(Book other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return this.InnerCompare(other);
        }

        /// <summary>
        /// Returns a value indicating  wheter this instance is equal to a specified object instance.
        /// </summary>
        /// <param name="obj">A object instance to compare with this instance.</param>
        /// <returns>
        /// <see cref="true"/> if the specified  object instance is equal to the current object instance; otherwise, <see cref="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals((Book)obj);
        }

        /// <summary>
        /// Return numeric representation this book instance.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Compares the current instance with another object of the <see cref="Book"/> and returns
        /// an integer that indicates whether the current instance precedes.
        /// </summary>
        /// <param name="other">A object of <see cref="Book"/> to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the <see cref="Book"/> being compared.
        /// If <paramref name="other"/> is same then return 0.
        /// If <paramref name="other"/> less than this instance then return 1.
        /// If <paramref name="other"/> greater than this instance then return -1.
        /// </returns>
        public int CompareTo(Book other)
        {
            if (other is null)
            {
                return 1;
            }

            return this.Price.CompareTo(other.Price);
        }

        #endregion Public methods

        #region Private methods

        private bool InnerCompare(Book other)
        {
            if (string.Compare(this.ISBN, other.ISBN, StringComparison.Ordinal) != 0)
            {
                return false;
            }

            if (string.Compare(this.Title, other.Title, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                return false;
            }

            if (string.Compare(this.Author, other.Author, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                return false;
            }

            if (string.Compare(this.Publisher, other.Publisher, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                return false;
            }

            if (this.YearOfPublishing != other.YearOfPublishing)
            {
                return false;
            }

            if (this.Count != other.Count)
            {
                return false;
            }

            if (this.Price != other.Price)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
