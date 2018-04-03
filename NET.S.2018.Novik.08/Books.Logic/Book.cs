using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        // (ISBN, автор, название, издательство, год издания,
        // количество страниц, цена),

        #region Private fields

        private string _ISBN;
        private string _autor;
        private string _name;
        private string _publisher;
        private int _yearOfPublishing;
        private int _count;
        private decimal _price;

        #endregion

        #region Constructors

        public Book(string ISBN, string autor, string name, string publisher, int yearOfPublishing, int count, decimal price)
        {
            this.ISBN = ISBN;
            this.Autor = autor;
            this.Name = name;
            this.Publisher = publisher;
            this.YearOfPublishing = yearOfPublishing;
            this.Count = count;
            this.Price = price;
        }

        #endregion

        #region Propertias

        public string ISBN { get => _ISBN; set => _ISBN = value; }
        public string Autor { get => _autor; set => _autor = value; }
        public string Name { get => _name; set => _name = value; }
        public string Publisher { get => _publisher; set => _publisher = value; }
        public int YearOfPublishing { get => _yearOfPublishing; set => _yearOfPublishing = value; }
        public int Count { get => _count; set => _count = value; }
        public decimal Price { get => _price; set => _price = value; }

        #endregion

        #region Public methods

        public override string ToString()
        {
            string bookAsString = $"[\"ISBN\":{this.ISBN}; \"Autor\": {this.Autor}; \"Name\": {this.Name}; \"Publisher\": {this.Publisher}; " +
                $"\"YearOfPublishing\": {this.YearOfPublishing}; \"Count\": {this.Count}; \"Price\": {this.Price}]";
            return bookAsString;
        }

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

            return this.CompareTo(other) == 1;
        }

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

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public int CompareTo(Book other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (string.Compare(this.ISBN, other.ISBN, StringComparison.Ordinal) != 0)
            {
                return -1;
            }

            if (string.Compare(this.Name, other.Name, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                return -1;
            }

            if (string.Compare(this.Autor, other.Autor, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                return -1;
            }

            if (string.Compare(this.Publisher, other.Publisher, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                return -1;
            }

            if (this.YearOfPublishing != other.YearOfPublishing)
            {
                return -1;
            }

            if (this.Count != other.Count)
            {
                return -1;
            }

            if (this.Price != other.Price)
            {
                return -1;
            }
            
            return 0;
        }

        #endregion



    }
}
