using System;
using System.Collections.Generic;
using NUnit.Framework;
using Tasks;

namespace Tasks.Tests.Task2Tests
{
    [TestFixture]
    class FindNextBiggerNumberTest
    {
        [Test]
        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(414, 441)]
        [TestCase(144, 414)]
        [TestCase(1234321,1241233)]
        [TestCase(1234126, 1234162)]
        [TestCase(3456432, 3462345)]
        [TestCase(10, -1)]
        [TestCase(20, -1)]
        [TestCase(9, -1)]
        [TestCase(0, -1)]
        public void FindNextBiggerNumber_CorrectValues(int number, int expected)
        {
            //Act
            int result = Task2.FindNextBiggerNumber(number);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(-5)]
        public void FindNextBiggerNumber_WrongValues_ReturnException(int number)
        {
            Assert.Throws<ArgumentException>(
                () => Task2.FindNextBiggerNumber(number));
        }
    }
}
