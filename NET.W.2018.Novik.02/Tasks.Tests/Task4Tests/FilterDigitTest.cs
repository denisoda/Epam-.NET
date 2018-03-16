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
        public void FilterDigit_CorrectValues()
        {
            // Arrange
            IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int digit = 7;
            IEnumerable<int> expected = new List<int> { 7, 70, 17 };

            // Act
            IEnumerable<int> result = Task4.FilterDigits(source, digit);

            // Assert
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void FilterDigit_IsNotDigit_ArgumentException()
        {
            // Arrange
            IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int digit = 71;
            // Assert
            Assert.Throws<ArgumentException>(() => Task4.FilterDigits(source, digit));
        }

        [Test]
        public void FilterDigit_IsNegativeDigit_ArgumentException()
        {
            // Arrange
            IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int digit = -8;
            // Assert
            Assert.Throws<ArgumentException>(() => Task4.FilterDigits(source, digit));
        }

        [Test]
        public void FilterDigit_SequenceNull_ArgumentNullException()
        {
            // Arrange
            IEnumerable<int> source = null;
            int digit = 7;
            // Assert
            Assert.Throws<ArgumentNullException>(() => Task4.FilterDigits(source, digit));
        }

        [Test]
        public void FilterDigit_ReturnedEmptySequence()
        {
            // Arrange
            IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5, 6, 7, 68, 70, 15, 17 };
            int digit = 9;
            // Act
            IEnumerable<int> result = Task4.FilterDigits(source, digit);
            // Assert
            Assert.IsTrue(result.Count() == 0);
        }
    }
}
