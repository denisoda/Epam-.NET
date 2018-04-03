using Books.Logic;
using NUnit.Framework;
using System;


namespace Books.Logic.UnitTests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void Book_Equals_Reflectivity()
        {
            Book firstBook = new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000);

            Assert.IsTrue(firstBook.Equals(firstBook));
        }

        [Test]
        public void Book_Equals_Trans()
        {
            Book firstBook = new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000);
            Book secondBook = new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000);
            Book thirdBook = new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000);

            Assert.IsTrue(firstBook.Equals(secondBook) && secondBook.Equals(thirdBook) && thirdBook.Equals(firstBook));
        }


    }
}
