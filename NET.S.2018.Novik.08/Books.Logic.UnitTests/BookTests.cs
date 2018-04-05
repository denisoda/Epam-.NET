using Books.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Books.Logic.UnitTests
{
    [TestFixture]
    public class BookTests
    {
        #region test creating the book

        [Test, TestCaseSource("GetBookCorrectISBN")]
        public bool BookTest_CreateBook_ISBN_Succed(Func<Book> getBook)
        {
            Book bookToTest = getBook();
            return true;
        }

        [Test, TestCaseSource("GetBookWrongISBN")]
        public void BookTest_CreateBook_ISBN_AgrumentException(Func<Book> getBook)
        {
            Assert.Throws<ArgumentException>(() => getBook());
        }

        [Test, TestCaseSource("GetCorrectBook")]
        public bool BookTest_CreateBook_Succed(Func<Book> getBook)
        {
            Book book = getBook();
            return true;
        }

        private static TestCaseData CreateTestCaseData(Func<Book> getBook)
        {
            return new TestCaseData(getBook);
        }

        public static IEnumerable<TestCaseData> GetBookCorrectISBN()
        {
            yield return CreateTestCaseData(() => new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000)).Returns(true);
            yield return CreateTestCaseData(() => new Book("978-5-496-00782-5", "Эрик Фримен, Элизабет Фримен", "Паттерны проектирования", "Apress", 2017, 1431, 10001)).Returns(true);
        }

        public static IEnumerable<TestCaseData> GetBookWrongISBN()
        {
            yield return CreateTestCaseData(() => new Book("asdasd", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000));
            yield return CreateTestCaseData(() => new Book("123123123", "Эрик Фримен, Элизабет Фримен", "Паттерны проектирования", "Apress", 2017, 1431, 10001));
        }

        public static IEnumerable<TestCaseData> GetCorrectBook()
        {
            yield return CreateTestCaseData(() => new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000)).Returns(true);
            yield return CreateTestCaseData(() => new Book("978-5-496-00782-5", "Эрик Фримен, Элизабет Фримен", "Паттерны проектирования", "Apress", 2017, 1431, 10001)).Returns(true);
        }

        #endregion

        #region test implemenatation inrefaces


        [Test]
        public void BookTest_GetHashCode_TheSameBooks_Succed()
        {
            Book firstBook = new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000);
            Book secondBook = new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000);

            Assert.AreEqual(firstBook.GetHashCode(), secondBook.GetHashCode());
        }

        [Test]
        public void BookTest_GetHashCode_DifferentBooks_Succed()
        {
            Book firstBook = new Book("978-5-496-00782-5", "Эрик Фримен, Элизабет Фримен", "Паттерны проектирования", "Apress", 2018, 1431, 10001);
            Book secondBook = new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000);

            Assert.AreNotEqual(firstBook.GetHashCode(), secondBook.GetHashCode());
        }

        [Test]
        public void BookTest_Equals_Reflectivity()
        {
            Book firstBook = new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000);

            Assert.IsTrue(firstBook.Equals(firstBook));
        }

        [Test]
        public void BookTest_Equals_Trans()
        {
            Book firstBook = new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000);
            Book secondBook = new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000);
            Book thirdBook = new Book("978-5-905463-15-0", "Эндрю Троелсон", "C# 6.0", "Apress", 2018, 1431, 10000);

            Assert.IsTrue(firstBook.Equals(secondBook) && secondBook.Equals(thirdBook) && thirdBook.Equals(firstBook));
        }

        #endregion test implemenatation inrefaces
    }
}
