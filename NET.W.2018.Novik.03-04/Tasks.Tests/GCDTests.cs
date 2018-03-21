using System;
using NUnit.Framework;
using Tasks;

namespace Tasks.Tests
{
    [TestFixture]
    public class GCDTests
    {
        #region Euclidean tests

        [Test]
        [TestCase(4, 16, 8, ExpectedResult = 4)]
        [TestCase(5, 40, 20, ExpectedResult = 5)]
        [TestCase(24, 50, 72, ExpectedResult = 2)]
        public int Euclidean_CorrectArguments(int number1, int number2, params int[] numbers)
        {
            return (new GCD()).Euclidean(number1, number2, numbers);
        }

        [Test]
        public void Euclidean_NullArgument_ArgumentsNullException()
        {
            Assert.Throws<ArgumentNullException>(() => (new GCD()).Euclidean(4, 16, null));
        }

        [Test]
        [TestCase(4, 16, 8)]
        [TestCase(5, 40, 20)]
        [TestCase(24, 50, 72)]
        public void Euclidean_LeadTime_Less1s(int number1, int number2, params int[] numbers)
        {
            GCD task1 = new GCD();
            TimeSpan time = new TimeSpan();
            int result = task1.Euclidean(out time,number1, number2, numbers);

            Assert.IsTrue(time.Seconds <= 1 , $"Lead time is {time.ToString()}");
        }

        #endregion

        #region Stein tests

        [Test]
        [TestCase(4, 16, 8, ExpectedResult = 4)]
        [TestCase(5, 40, 20, ExpectedResult = 5)]
        [TestCase(24, 50, 72, ExpectedResult = 2)]
        public int Stein_CorrectArguments(int number1, int number2, params int[] numbers)
        {
            return (new GCD()).Stein(number1, number2, numbers);
        }

        [Test]
        [TestCase(4, 16, 8)]
        [TestCase(5, 40, 20)]
        [TestCase(24, 50, 72)]
        public void Stein_LeadTime_Less1s(int number1, int number2, params int[] numbers)
        {
            GCD task1 = new GCD();
            TimeSpan time = new TimeSpan();
            int result = task1.Stein(out time, number1, number2, numbers);

            Assert.IsTrue(time.Seconds <= 1, $"Lead time is {time.ToString()}");
        }

        #endregion
    }
}
