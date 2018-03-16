using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Tasks;

namespace Tasks.Tests.Task4Tests
{
    [TestFixture]
    class FilterDigitTest
    {
        [Test]
        public void FilterDigitTest_CorrectValues()
        {
            //Arrange
            IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int digit = 7;
            IEnumerable<int> expected = new List<int> { 7, 70, 17 };

            //Act
            IEnumerable<int> result = Task4.FilterDigits(source, digit);

            //Assert
            Assert.IsTrue(expected.SequenceEqual(result));
        }
    }
}
